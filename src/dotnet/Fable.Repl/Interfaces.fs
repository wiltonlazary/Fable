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
    { StartLineAlternate: int
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

type IFableManager =
    abstract CreateChecker: references: string[] * readAllBytes: (string -> byte[]) -> IChecker
    abstract ParseFSharpProject: checker: IChecker * fileName: string * source: string -> IParseResults
    abstract GetParseErrors: parseResults: IParseResults -> Error[]
    abstract GetDeclarationLocation: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<Range option>
    abstract GetToolTipText: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<string[]>
    abstract GetCompletionsAtLocation: parseResults: IParseResults * line: int * col: int * lineText: string -> Async<Completion[]>
    abstract CompileToBabelAst: fableCore: string * parseResults: IParseResults * fileName: string * optimized: bool -> obj * Error[]
    abstract FSharpAstToString: parseResults: IParseResults * optimized: bool -> string
