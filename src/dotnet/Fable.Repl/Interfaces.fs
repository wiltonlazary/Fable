namespace Fable.Repl

open Fable.Core

[<StringEnum; RequireQualifiedAccess>]
type Glyph =
    | Class
    | Enum
    | Value
    | Variable
    | Interface
    | Module
    | Method
    | Property
    | Field
    | Function
    | Error
    | Event

type Error =
    { FileName: string
      StartLineAlternate: int
      StartColumn: int
      EndLineAlternate: int
      EndColumn: int
      Message: string
      IsWarning: bool }

type Range =
    { StartLine: int
      StartColumn: int
      EndLine: int
      EndColumn: int }

type Completion =
    { Name: string
      Glyph: Glyph }

type IChecker =
    interface end

type IParseResults =
    abstract Errors: Error[]

type IBabelResult =
    abstract BabelAst: obj
    abstract FableErrors: Error[]

type IFableManager =
    abstract CreateChecker: references: string[] * readAllBytes: (string -> byte[]) * defines: string[] * optimize: bool -> IChecker
    [<System.Obsolete>] abstract CreateChecker: references: string[] * readAllBytes: (string -> byte[]) * definesOpt: string[] option -> IChecker
    abstract ParseFSharpScript: checker: IChecker * fileName: string * source: string -> IParseResults
    abstract ParseFSharpProject: checker: IChecker * projectFileName: string * fileNames: string[] * sources: string[] -> IParseResults
    abstract GetParseErrors: parseResults: IParseResults -> Error[]
    abstract GetDeclarationLocation: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<Range option>
    abstract GetToolTipText: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<string[]>
    abstract GetCompletionsAtLocation: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<Completion[]>
    abstract CompileToBabelAst: fableLibrary: string * parseResults: IParseResults * fileName: string * optimized: bool * ?precompiledLib: (string->(string*string) option) -> IBabelResult
    abstract FSharpAstToString: parseResults: IParseResults * fileName: string * optimized: bool -> string
