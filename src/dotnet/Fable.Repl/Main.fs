module Fable.Repl.Main

open System
open Fable.AST
open Fable.Transforms
open Fable.Transforms.State
open FsAutoComplete
open Microsoft.FSharp.Compiler.SourceCodeServices

type CheckerImpl(checker: InteractiveChecker) =
    member __.Checker = checker
    interface IChecker

let mapErrors (checkProjectResults: FSharpCheckProjectResults) =
    checkProjectResults.Errors
    |> Array.map (fun er -> {
        FileName = er.FileName
        StartLineAlternate = er.StartLineAlternate
        StartColumn = er.StartColumn
        EndLineAlternate = er.EndLineAlternate
        EndColumn = er.EndColumn
        Message = er.Message
        IsWarning =
            match er.Severity with
            | FSharpErrorSeverity.Error -> false
            | FSharpErrorSeverity.Warning -> true
    })

type ParseResults (optimizedProject: Lazy<Project>,
                   unoptimizedProject: Lazy<Project>,
                   parseFileResultsOpt: FSharpParseFileResults option,
                   checkFileResultsOpt: FSharpCheckFileResults option,
                   checkProjectResults: FSharpCheckProjectResults) =

    member __.GetProject (optimized: bool) =
        if optimized
        then optimizedProject.Force()
        else unoptimizedProject.Force()

    member __.ParseFileResultsOpt = parseFileResultsOpt
    member __.CheckFileResultsOpt = checkFileResultsOpt
    member __.CheckProjectResults = checkProjectResults

    interface IParseResults with
        member __.Errors = mapErrors checkProjectResults

let inline private tryGetLexerSymbolIslands (sym: Lexer.LexerSymbol) =
  match sym.Text with
  | "" -> None
  | _ -> Some (sym.RightColumn, sym.Text.Split '.' |> Array.toList)

// Parsing - find the identifier around the current location
// (we look for full identifier in the backward direction, but only
// for a short identifier forward - this means that when you hover
// 'B' in 'A.B.C', you will get intellisense for 'A.B' module)
let findIdents col lineStr lookupType =
    if lineStr = "" then None
    else
        Lexer.getSymbol 0 col lineStr lookupType [||]
        |> Option.bind tryGetLexerSymbolIslands

let findLongIdents (col, lineStr) =
    findIdents col lineStr Lexer.SymbolLookupKind.Fuzzy

let findLongIdentsAndResidue (col: int, lineStr:string) =
    let lineStr = lineStr.Substring(0, col)
    match Lexer.getSymbol 0 col lineStr Lexer.SymbolLookupKind.ByLongIdent [||] with
    | Some sym ->
        match sym.Text with
        | "" -> [], ""
        | text ->
            let res = text.Split '.' |> List.ofArray |> List.rev
            if lineStr.[col - 1] = '.' then res |> List.rev, ""
            else
                match res with
                | head :: tail -> tail |> List.rev, head
                | [] -> [], ""
    | _ -> [], ""

let convertGlyph glyph =
    match glyph with
    | FSharpGlyph.Class | FSharpGlyph.Struct | FSharpGlyph.Union
    | FSharpGlyph.Type | FSharpGlyph.Typedef ->
        Glyph.Class
    | FSharpGlyph.Enum | FSharpGlyph.EnumMember ->
        Glyph.Enum
    | FSharpGlyph.Constant ->
        Glyph.Value
    | FSharpGlyph.Variable ->
        Glyph.Variable
    | FSharpGlyph.Interface ->
        Glyph.Interface
    | FSharpGlyph.Module | FSharpGlyph.NameSpace ->
        Glyph.Module
    | FSharpGlyph.Method | FSharpGlyph.OverridenMethod | FSharpGlyph.ExtensionMethod ->
        Glyph.Method
    | FSharpGlyph.Property ->
        Glyph.Property
    | FSharpGlyph.Field ->
        Glyph.Field
    | FSharpGlyph.Delegate ->
        Glyph.Function
    | FSharpGlyph.Error | FSharpGlyph.Exception ->
        Glyph.Error
    | FSharpGlyph.Event ->
        Glyph.Event

let makeProjOptions projectFileName fileNames =
    let projOptions: FSharpProjectOptions =
      { ProjectFileName = projectFileName
        ProjectId = None
        SourceFiles = fileNames
        OtherOptions = [| |]
        ReferencedProjects = [| |]
        IsIncompleteTypeCheckEnvironment = false
        UseScriptResolutionRules = false
        LoadTime = DateTime.Now
        UnresolvedReferences = None
        OriginalLoadReferences = []
        ExtraProjectInfo = None
        Stamp = None }
    projOptions

let makeProject projectOptions (projectResults: FSharpCheckProjectResults) optimized =
    // let errors = com.GetFormattedLogs() |> Map.tryFind "error"
    // if errors.IsSome then failwith (errors.Value |> String.concat "\n")
    let implFiles =
        (if optimized
        then projectResults.GetOptimizedAssemblyContents()
        else projectResults.AssemblyContents).ImplementationFiles
        |> Seq.map (fun file -> Fable.Path.normalizePath file.FileName, file) |> Map
    // Dealing with fableLibraryDir is a bit messy atm, for the REPL, only the value in the Compiler options matters
    let project = Project(projectOptions, implFiles, projectResults.Errors, Map.empty, "", isWatchCompile=false)
    project

let parseFSharpScript (checker: InteractiveChecker) projectFileName fileName source =
    let parseResults, typeCheckResults, projectResults =
        checker.ParseAndCheckScript (projectFileName, fileName, source)
    let projectOptions = makeProjOptions projectFileName [| fileName |]
    let optimizedProject = lazy (makeProject projectOptions projectResults true)
    let unoptimizedProject = lazy (makeProject projectOptions projectResults false)
    ParseResults (optimizedProject, unoptimizedProject, Some parseResults, Some typeCheckResults, projectResults)

let parseFSharpProject (checker: InteractiveChecker) projectFileName fileNames sources =
    let projectResults = checker.ParseAndCheckProject (projectFileName, fileNames, sources)
    let projectOptions = makeProjOptions projectFileName fileNames
    let optimizedProject = lazy (makeProject projectOptions projectResults true)
    let unoptimizedProject = lazy (makeProject projectOptions projectResults false)
    ParseResults (optimizedProject, unoptimizedProject, None, None, projectResults)

let tooltipToString (el: FSharpToolTipElement<string>): string[] =
    let dataToString (data: FSharpToolTipElementData<string>) =
        [| match data.ParamName with
           | Some x -> yield x + ": " + data.MainDescription
           | None -> yield data.MainDescription
           match data.XmlDoc with
           | FSharpXmlDoc.Text doc -> yield doc
           | _ -> ()
           yield! data.TypeMapping
           match data.Remarks with
           | Some x -> yield x
           | None -> ()
        |]
    match el with
    | FSharpToolTipElement.None -> [||]
    | FSharpToolTipElement.Group(els) ->
        Seq.map dataToString els |> Array.concat
    | FSharpToolTipElement.CompositionError err -> [|err|]

/// Get tool tip at the specified location
let getDeclarationLocation (parseResults: ParseResults) line col lineText = async {
    match parseResults.CheckFileResultsOpt with
    | Some checkFile ->
        match findLongIdents(col - 1, lineText) with
        | None -> return None
        | Some(col,identIsland) ->
            let! (declarations: FSharpFindDeclResult) = checkFile.GetDeclarationLocation(line, col, lineText, identIsland)
            match declarations with
            | FSharpFindDeclResult.DeclNotFound _
            | FSharpFindDeclResult.ExternalDecl _ ->
                return None
            | FSharpFindDeclResult.DeclFound range ->
                return Some { StartLine = range.StartLine
                              StartColumn = range.StartColumn
                              EndLine = range.EndLine
                              EndColumn = range.EndColumn }
    | None -> return None
}

/// Get tool tip at the specified location
let getToolTipAtLocation (parseResults: ParseResults) line col lineText = async {
    match parseResults.CheckFileResultsOpt with
    | Some checkFile ->
        match findLongIdents(col - 1, lineText) with
        | None -> return [|"Cannot find ident for tooltip"|]
        | Some(col,identIsland) ->
            let! (FSharpToolTipText els) = checkFile.GetToolTipText(line, col, lineText, identIsland, FSharpTokenTag.Identifier)
            return Seq.map tooltipToString els |> Array.concat
    | None ->
        return [||]
}

let getCompletionsAtLocation (parseResults: ParseResults) (line: int) (col: int) lineText = async {
   match parseResults.CheckFileResultsOpt with
    | Some checkFile ->
        let ln, residue = findLongIdentsAndResidue(col - 1, lineText)
        let longName = Microsoft.FSharp.Compiler.QuickParse.GetPartialLongNameEx(lineText, col - 1)
        let longName = { longName with QualifyingIdents = ln; PartialIdent = residue }
        let! decls = checkFile.GetDeclarationListInfo(parseResults.ParseFileResultsOpt, line, lineText, longName, fun () -> [])
        return decls.Items |> Array.map (fun decl ->
            { Name = decl.Name; Glyph = convertGlyph decl.Glyph })
    | None ->
        return [||]
}

let makeCompiler fableLibrary fileName (project: Project) precompiledLib =
    let options: Fable.CompilerOptions =
        { typedArrays = true
          clampByteArrays = false
          verbose = false
          outputPublicInlinedFunctions = false
          precompiledLib = precompiledLib }
    let com = Compiler(fileName, project, options, fableLibrary)
    com

let compileAst (com: Compiler) (project: Project) =
    FSharp2Fable.Compiler.transformFile com project.ImplementationFiles
    |> FableTransforms.optimizeFile com
    |> Fable2Babel.Compiler.transformFile com

let init () =
  { new IFableManager with
        member __.CreateChecker(references, readAllBytes, defines, optimize) =
            InteractiveChecker.Create(references, readAllBytes, defines, optimize)
            |> CheckerImpl :> IChecker

        // obsolete
        member __.CreateChecker(references, readAllBytes, definesOpt) =
            let defines = defaultArg definesOpt [| "FABLE_COMPILER"; "DEBUG" |]
            let optimize = false
            InteractiveChecker.Create(references, readAllBytes, defines, optimize)
            |> CheckerImpl :> IChecker

        member __.ParseFSharpScript(checker, fileName, source) =
            let c = checker :?> CheckerImpl
            let projectFileName = "project" // TODO: make it an argument
            parseFSharpScript c.Checker projectFileName fileName source :> IParseResults

        member __.ParseFSharpProject(checker, projectFileName, fileNames, sources) =
            let c = checker :?> CheckerImpl
            parseFSharpProject c.Checker projectFileName fileNames sources :> IParseResults

        member __.GetParseErrors(parseResults:IParseResults) =
            parseResults.Errors

        member __.GetDeclarationLocation(parseResults:IParseResults, line:int, col:int, lineText:string) =
            let res = parseResults :?> ParseResults
            getDeclarationLocation res line col lineText

        member __.GetToolTipText(parseResults:IParseResults, line:int, col:int, lineText:string) =
            let res = parseResults :?> ParseResults
            getToolTipAtLocation res line col lineText

        member __.GetCompletionsAtLocation(parseResults:IParseResults, line:int, col:int, lineText:string) =
            let res = parseResults :?> ParseResults
            getCompletionsAtLocation res line col lineText

        member __.CompileToBabelAst(fableLibrary:string, parseResults:IParseResults, fileName:string, optimized: bool, ?precompiledLib) =
            let res = parseResults :?> ParseResults
            let project = res.GetProject (optimized)
            let com = makeCompiler fableLibrary fileName project precompiledLib
            let ast = compileAst com project
            let errors =
                com.GetLogs()
                |> List.map (fun log ->
                    let r = defaultArg log.Range Fable.SourceLocation.Empty
                    { FileName = fileName
                      StartLineAlternate = r.start.line
                      StartColumn = r.start.column
                      EndLineAlternate = r.``end``.line
                      EndColumn = r.``end``.column
                      Message =
                        if log.Tag = "FABLE"
                        then "FABLE: " + log.Message
                        else log.Message
                      IsWarning =
                        match log.Severity with
                        | Fable.Severity.Error -> false
                        | Fable.Severity.Warning
                        | Fable.Severity.Info -> true
                    })
                |> List.toArray
            { new IBabelResult with
                member __.BabelAst = ast :> obj
                member __.FableErrors = errors }

        member __.FSharpAstToString(parseResults:IParseResults, fileName:string, optimized: bool) =
            let res = parseResults :?> ParseResults
            let project = res.GetProject (optimized)
            let implFile = project.ImplementationFiles.Item(fileName)
            AstPrint.printFSharpDecls "" implFile.Declarations |> String.concat "\n"
  }
