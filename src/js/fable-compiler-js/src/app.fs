module Fable.Compiler.App

open Fable.Compiler.Platform
open System.Text.RegularExpressions

// let references = Fable.Repl.Metadata.references false

// Compilation seems to work only with these references
let references = [|
    "Fable.Core"
    // "Fable.Import.Browser"
    "FSharp.Core"
    "mscorlib"
    "netstandard"
    "System.Collections"
    "System.Console"
    "System.Core"
    "System.Diagnostics.Debug"
    "System"
    "System.IO"
    "System.Numerics"
    "System.Reflection"
    "System.Reflection.Extensions"
    "System.Reflection.Metadata"
    "System.Reflection.Primitives"
    "System.Reflection.TypeExtensions"
    "System.Runtime"
    "System.Runtime.Extensions"
    "System.Runtime.Numerics"
    "System.Text.Encoding"
    "System.Text.Encoding.Extensions"
    "System.Text.RegularExpressions"
    "System.ValueTuple"
    "System.Threading"
    "System.Threading.Tasks"
|]

let metadataPath = __dirname + "/metadata2/" // .NET BCL binaries (metadata)

let (|Regex|_|) (pattern: string) (input: string) =
    let m = Regex.Match(input, pattern)
    if m.Success then
        let mutable groups = []
        for i = m.Groups.Count - 1 downto 0 do
            groups <- m.Groups.[i].Value::groups
        Some groups
    else None

let parseProjectFile projectPath =
    let projectFileName = Path.GetFileName projectPath
    let projectText = readAllText projectPath
    if projectPath.EndsWith(".fsx") then
        let projDir = Path.GetDirectoryName projectPath
        let dllRefs, srcFiles =
            (([||], [||]), projectText.Split('\n')) ||> Array.fold (fun (dllRefs, srcFiles) line ->
                let line = line.Trim()
                match line.Trim() with
                | Regex @"^#r\s+""(.*?)""$" [_;path]
                    when not(path.EndsWith("Fable.Core.dll")) ->
                    Array.append [|Path.Combine(projDir, path)|] dllRefs, srcFiles
                | Regex @"^#load\s+""(.*?)""$" [_;path] ->
                    dllRefs, Array.append [|Path.Combine(projDir, path)|] srcFiles
                | _ -> dllRefs, srcFiles)
        (projectFileName, dllRefs, [||], Array.append srcFiles [|projectPath|], [|"FABLE_COMPILER"|])
    else
        // remove all comments
        let projectText = Regex.Replace(projectText, @"<!--[\s\S]*?-->", "")

        // get conditional defines
        let definesRegex = @"<DefineConstants[^>]*>([^<]*)<\/DefineConstants[^>]*>"
        let defines =
            Regex.Matches(projectText, definesRegex)
            |> Seq.collect (fun m -> m.Groups.[1].Value.Split(';'))
            |> Seq.append ["FABLE_COMPILER"]
            |> Seq.map (fun s -> s.Trim())
            |> Seq.distinct
            |> Seq.except ["$(DefineConstants)"; ""]
            |> Seq.toArray

        // get project references
        let projectRefsRegex = @"<ProjectReference\s+[^>]*Include\s*=\s*(""[^""]*|'[^']*)"
        let projectRefs =
            Regex.Matches(projectText, projectRefsRegex)
            |> Seq.map (fun m -> m.Groups.[1].Value.TrimStart('"').TrimStart(''').Trim().Replace("\\", "/"))
            |> Seq.toArray

        // replace some variables
        let projectText = projectText.Replace(@"$(MSBuildProjectDirectory)", __dirname)

        // get source files
        let sourceFilesRegex = @"<Compile\s+[^>]*Include\s*=\s*(""[^""]*|'[^']*)"
        let sourceFiles =
            Regex.Matches(projectText, sourceFilesRegex)
            |> Seq.map (fun m -> m.Groups.[1].Value.TrimStart('"').TrimStart(''').Trim().Replace("\\", "/"))
            |> Seq.toArray

        (projectFileName, [||], projectRefs, sourceFiles, defines)

let rec parseProject projectPath =
    let (projectFileName, dllRefs, projectRefs, sourceFiles, defines) = parseProjectFile projectPath

    let projectFileDir = Path.GetDirectoryName projectPath
    let isAbsolutePath (path: string) = path.StartsWith("/")
    let trimPath (path: string) = path.TrimStart([|'.';'/'|])
    let makePath path = if isAbsolutePath path then path else Path.Combine(projectFileDir, path)
    let makeName path = Path.Combine(trimPath projectFileDir, trimPath path)

    let fileNames = sourceFiles |> Array.map (fun path -> path |> makeName)
    let sources = sourceFiles |> Array.map (fun path -> path |> makePath |> readAllText)

    let parsedProjects = projectRefs |> Array.map makePath |> Array.map parseProject
    let fileNames = fileNames |> Array.append (parsedProjects |> Array.collect (fun (_,_,x,_,_) -> x))
    let sources   = sources   |> Array.append (parsedProjects |> Array.collect (fun (_,_,_,x,_) -> x))
    let defines   = defines   |> Array.append (parsedProjects |> Array.collect (fun (_,_,_,_,x) -> x))

    (projectFileName, dllRefs, fileNames, sources, defines |> Array.distinct)

let dedupFileNames fileNames =
    let nameSet = System.Collections.Generic.HashSet<string>()
    let padName (name: string) =
        let pos = name.LastIndexOf(".")
        let nm = if pos < 0 then name else name.Substring(0, pos)
        let ext = if pos < 0 then "" else name.Substring(pos)
        nm + "_" + ext
    let rec dedup name =
        if nameSet.Contains(name) then
            dedup (padName name)
        else
            nameSet.Add(name) |> ignore
            name
    fileNames |> Array.map dedup

let printErrors showWarnings (errors: Fable.Repl.Error[]) =
    let printError (e: Fable.Repl.Error) =
        let errorType = (if e.IsWarning then "Warning" else "Error")
        printfn "%s (%d,%d--%d,%d): %s: %s" e.FileName e.EndLineAlternate
            e.StartColumn e.EndLineAlternate e.EndColumn errorType e.Message
    let warnings, errors = errors |> Array.partition (fun e -> e.IsWarning)
    let hasErrors = not (Array.isEmpty errors)
    if showWarnings then
        warnings |> Array.iter printError
    if hasErrors then
        errors |> Array.iter printError
        failwith "Too many errors."

let parseFiles projectPath outDir optimized commonjs =
    // parse project
    let (projectFileName, dllRefs, fileNames, sources, defines) = parseProject projectPath

    // dedup file names
    let fileNames = dedupFileNames fileNames
    let extraDll = dllRefs |> Seq.map (fun x -> Path.GetFileName x, x) |> Map
    let references =
        dllRefs |> Array.map Path.GetFileNameWithoutExtension
        |> Array.append references
        // |> Array.distinct

    // create checker
    let fable = initFable ()
    let readBytesExtra name =
        Map.tryFind name extraDll
        |> Option.defaultValue (metadataPath + name)
        |> readAllBytes
    let createChecker () = fable.CreateChecker(references, readBytesExtra, defines, optimize=false)
    let ms0, checker = measureTime createChecker ()
    printfn "--------------------------------------------"
    printfn "InteractiveChecker created in %d ms" ms0

    // parse F# files to AST
    let parseFSharpProject () = fable.ParseFSharpProject(checker, projectFileName, fileNames, sources)
    let ms1, parseRes = measureTime parseFSharpProject ()
    printfn "Project: %s, FCS time: %d ms" projectFileName ms1
    printfn "--------------------------------------------"
    let showWarnings = true
    parseRes.Errors |> printErrors showWarnings

    // exclude signature files
    let fileNames = fileNames |> Array.filter (fun x -> not (x.EndsWith(".fsi")))

    // Fable (F# to Babel)
    let fableLibraryDir = "fable-library"
    let fableLibraryDist = if commonjs then "/fable-library-commonjs" else "/bundle/fable-library"
    copyFolder (__dirname + fableLibraryDist, Path.Combine(outDir, fableLibraryDir))
    let parseFable (res, fileName) = fable.CompileToBabelAst(fableLibraryDir, res, fileName, optimized)

    for fileName in fileNames do

        // transform F# AST to Babel AST
        let ms2, res = measureTime parseFable (parseRes, fileName)
        printfn "File: %s, Fable time: %d ms" fileName ms2
        res.FableErrors |> printErrors showWarnings

        // transform and save Babel AST
        transformAndSaveBabelAst(res.BabelAst, fileName, outDir, commonjs)

let parseArguments (argv: string[]) =
    // TODO: more sophisticated argument parsing
    let usage = "Usage: fable <PROJECT_PATH> <OUT_DIR> [--options]"
    let opts, args = argv |> Array.partition (fun s -> s.StartsWith("--"))
    match opts, args with
    | [| "--help" |], _ -> printfn "%s" usage
    | [| "--version" |], _ -> printfn "v%s" (getVersion())
    | _, [| projectPath; outDir |] ->
        let outDir =
            if outDir = "--run" then
                Path.Combine(Path.GetDirectoryName(projectPath), "bin")
            else outDir
        let commandToRun =
            opts |> Array.tryFindIndex ((=) "--run")
            |> Option.map (fun i ->
                // TODO: This only works if the project is an .fsx file
                let scriptFile = Path.Combine(outDir, Path.GetFileNameWithoutExtension(projectPath) + ".js")
                let runArgs = opts.[i+1..] |> String.concat " "
                sprintf "node %s %s" scriptFile runArgs)
        let optimized = opts |> Array.contains "--optimize-fcs"
        let commonjs = Option.isSome commandToRun || opts |> Array.contains "--commonjs"
        parseFiles projectPath outDir optimized commonjs
        commandToRun |> Option.iter runCmd
    | _ -> printfn "%s" usage

[<EntryPoint>]
let main argv =
    try
        parseArguments argv
    with ex ->
        printfn "Error: %A" ex.Message
    0
