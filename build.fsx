#r "packages/FAKE/tools/FakeLib.dll"

open Fake
open System.IO

// Directories
let mainBuildDir  = "build/main/"
let testBuildDir   = "build/test/"

// Filesets
let appReferences  = !! "src/**/*.fsproj"

// version info
let version = "0.1"  // or retrieve from CI server

// Targets
Target "Clean" (fun _ ->
    !! mainBuildDir ++ testBuildDir
        ++ "src/**/bin/" ++ "test/**/bin/"
        ++ "src/**/obj/" ++ "test/**/obj/"
    |> CleanDirs
)

Target "TestNUnit" (fun _ ->
    !! "test/**/*.fsproj"
    |> MSBuildRelease testBuildDir "Build"
    |> Log "Release-Output: "
    
    [testBuildDir + "Fabel.Tests.dll"]
    |> NUnit (fun p ->
        { p with
            DisableShadowCopy = true
            OutputFile = "TestResults.xml" })
)

Target "TestMocha" (fun _ ->
    Shell.Exec("node", "tools/fabel.js --projFile test/Fabel.Tests.fsproj")
    |> function
    | 0 ->
        Shell.Exec("node", "node_modules/mocha/bin/mocha build/test")
        |> function
        | 0 -> ()
        | _ -> failwith "Mocha tests failed"
    | _ -> failwith "Cannot compile tests to JS"
)

Target "Release" (fun _ ->
    let xmlPath = Path.Combine(Path.GetFullPath mainBuildDir, "Fabel.xml")
    !! "src/**/*.fsproj"
    |> MSBuild mainBuildDir "Build"
        ["Configuration","Release"; "DocumentationFile", xmlPath]
    |> Log "Release-Output: "
)

Target "Debug" (fun _ ->
    !! "src/**/*.fsproj"
    |> MSBuildDebug mainBuildDir "Build"
    |> Log "Debug-Output: "
)

// Build order
"Clean"
  ==> "Release"

// Start build
RunTargetOrDefault "Debug"