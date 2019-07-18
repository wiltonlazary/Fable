module Fable.WebWorker.Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Standalone
open Fable.WebWorker

let FILE_NAME = "test.fs"

type IFableInit =
    abstract member init: unit -> IFableManager

let [<Global>] self: obj = jsNative
let [<Global>] importScripts(path: string): unit = jsNative
// let [<Global("import")>] importDynamic<'T>(path: string): JS.Promise<'T> = jsNative
let [<Emit("fetch($0).then(x => x.json())")>] fetchJson(url: string): JS.Promise<obj> = jsNative

// Load FCS+Fable bundle
importScripts "bundle.min.js"
let [<Global("__FABLE_STANDALONE__")>] FableInit: IFableInit = jsNative

let resolveLibCall(libMap: obj, entityName: string): (string*string) option = importMember "./util.js"
let getAssemblyReader(getBlobUrl: string->string, _refs: string[]): JS.Promise<string->byte[]> = importMember "./util.js"
let getBabelAstCompiler(): JS.Promise<obj->string> = importMember "./util.js"

let measureTime f arg =
    let before: float = self?performance?now()
    let res = f arg
    let after: float = self?performance?now()
    res, after - before

type FableState =
    { Manager: IFableManager
      Checker: IChecker
      BabelAstCompiler: obj->string
      LoadTime: float
      LibMap: obj }

type State =
    { Fable: FableState option
      Worker: ObservableWorker<WorkerRequest>
      CurrentResults: IParseResults option }

let rec loop (box: MailboxProcessor<WorkerRequest>) (state: State) = async {
    let! msg = box.Receive()
    match state.Fable, msg with
    | None, CreateChecker(refsDirUrl, extraRefs, refsExtraSuffix, libJsonUrl) ->
        let getBlobUrl name =
            refsDirUrl.TrimEnd('/') + "/" + name + ".dll" + (defaultArg refsExtraSuffix "")
        try
            let manager = FableInit.init()
            let! babelCompiler = getBabelAstCompiler() |> Async.AwaitPromise
            let! libMap =
                match libJsonUrl with
                | Some url -> fetchJson url |> Async.AwaitPromise
                | None -> async.Return null
            let references = Array.append Fable.Standalone.Metadata.references_core extraRefs
            let! reader = getAssemblyReader(getBlobUrl, references) |> Async.AwaitPromise
            let (checker, checkerTime) = measureTime (fun () ->
                manager.CreateChecker(references, reader, [||], false)) ()
            state.Worker.Post Loaded
            return! loop box { state with Fable = Some { Manager = manager
                                                         Checker = checker
                                                         BabelAstCompiler = babelCompiler
                                                         LoadTime = checkerTime
                                                         LibMap = libMap } }
        with err ->
            JS.console.error("Cannot create F# checker", err)
            state.Worker.Post LoadFailed
            return! loop box state

    // These combination of messages are ignored
    | None, _
    | Some _, CreateChecker _ -> return! loop box state

    | Some fable, ParseCode fsharpCode ->
        let res = fable.Manager.ParseFSharpScript(fable.Checker, FILE_NAME, fsharpCode)
        ParsedCode res.Errors |> state.Worker.Post
        return! loop box { state with CurrentResults = Some res }

    | Some fable, CompileCode(fsharpCode, optimize) ->
        try
            let (parseResults, parsingTime) = measureTime fable.Manager.ParseFSharpScript (fable.Checker, FILE_NAME, fsharpCode)
            let (res, fableTransformTime) = measureTime (fun () ->
                fable.Manager.CompileToBabelAst("fable-library", parseResults, FILE_NAME, optimize, fun x -> resolveLibCall(fable.LibMap, x))) ()
            let (jsCode, babelTime, babelErrors) =
                try
                    let code, t = measureTime fable.BabelAstCompiler res.BabelAst
                    code, t, [||]
                with ex ->
                    let error =
                        { FileName = FILE_NAME
                          StartLineAlternate = 1
                          StartColumn = 0
                          EndLineAlternate = 1
                          EndColumn = 0
                          Message = "BABEL: " + ex.Message
                          IsWarning = false }
                    "", 0., [|error|]

            let stats : CompileStats =
                { FCS_checker = fable.LoadTime
                  FCS_parsing = parsingTime
                  Fable_transform = fableTransformTime
                  Babel_generation = babelTime }

            let errors = Array.concat [parseResults.Errors; res.FableErrors; babelErrors]
            CompilationFinished (jsCode, errors, stats) |> state.Worker.Post
        with er ->
            JS.console.error er
            CompilerCrashed er.Message |> state.Worker.Post
        return! loop box state

    | Some fable, GetTooltip(id, line, col, lineText) ->
        let! tooltipLines =
            match state.CurrentResults with
            | None -> async.Return [||]
            | Some res -> fable.Manager.GetToolTipText(res, int line, int col, lineText)
        FoundTooltip(id, tooltipLines) |> state.Worker.Post
        return! loop box state

    | Some fable, GetCompletions(id, line, col, lineText) ->
        let! completions =
            match state.CurrentResults with
            | None -> async.Return [||]
            | Some res -> fable.Manager.GetCompletionsAtLocation(res, int line, int col, lineText)
        FoundCompletions(id, completions) |> state.Worker.Post
        return! loop box state

    | Some fable, GetDeclarationLocation(id, line, col, lineText) ->
        let! result =
            match state.CurrentResults with
            | None -> async.Return None
            | Some res -> fable.Manager.GetDeclarationLocation(res, int line, int col, lineText)
        match result with
        | Some x -> FoundDeclarationLocation(id, Some(x.StartLine, x.StartColumn, x.EndLine, x.EndColumn))
        | None -> FoundDeclarationLocation(id, None)
        |> state.Worker.Post
        return! loop box state
}

let worker = ObservableWorker(self, WorkerRequest.Decoder)
let box = MailboxProcessor.Start(fun box ->
    { Fable = None
      Worker = worker
      CurrentResults = None }
    |> loop box)

worker
|> Observable.add box.Post
