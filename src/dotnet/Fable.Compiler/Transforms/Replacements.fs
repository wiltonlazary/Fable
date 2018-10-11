[<RequireQualifiedAccess>]
module Fable.Transforms.Replacements

open Microsoft.FSharp.Compiler.SourceCodeServices
open Fable
open Fable.AST
open Fable.AST.Fable
open Fable.Core

type Context = Fable.Transforms.FSharp2Fable.Context
type ICompiler = Fable.Transforms.FSharp2Fable.IFableCompiler
type CallInfo = Fable.ReplaceCallInfo

type Helper =
    static member ConstructorCall(consExpr: Expr, returnType: Type, args: Expr list,
                                  ?argTypes: Type list, ?loc: SourceLocation) =
        let argTypes = match argTypes with Some xs -> Typed xs | None -> NoUncurrying
        Operation(Call(ConstructorCall consExpr, argInfo None args argTypes), returnType, loc)

    static member InstanceCall(callee: Expr, memb: string, returnType: Type, args: Expr list,
                               ?argTypes: Type list, ?loc: SourceLocation) =
        let kind = makeStrConst memb |> Some |> InstanceCall
        let argTypes = match argTypes with Some xs -> Typed xs | None -> NoUncurrying
        Operation(Call(kind, argInfo (Some callee) args argTypes), returnType, loc)

    static member Application(callee: Expr, returnType: Type, args: Expr list,
                               ?argTypes: Type list, ?loc: SourceLocation) =
        let argTypes = match argTypes with Some xs -> Typed xs | None -> NoUncurrying
        Operation(Call(InstanceCall None, argInfo (Some callee) args argTypes), returnType, loc)

    static member CoreCall(coreModule: string, coreMember: string, returnType: Type, args: Expr list,
                           ?argTypes: Type list, ?thisArg: Expr, ?isConstructor: bool,
                           ?hasSpread: bool, ?loc: SourceLocation) =
        let info =
            { ThisArg = thisArg
              Args = args
              SignatureArgTypes = match argTypes with Some xs -> Typed xs | None -> NoUncurrying
              Spread = match hasSpread with Some true -> SeqSpread | _ -> NoSpread
              IsBaseOrSelfConstructorCall = false }
        let funcExpr = makeCoreRef Any coreMember coreModule
        match isConstructor with
        | Some true -> Operation(Call(ConstructorCall funcExpr, info), returnType, loc)
        | _ -> Operation(Call(StaticCall funcExpr, info), returnType, loc)

    static member GlobalCall(ident: string, returnType: Type, args: Expr list,
                             ?argTypes: Type list, ?memb: string, ?isConstructor: bool, ?loc: SourceLocation) =
        let funcExpr =
            match memb with
            | Some m -> get None Any (makeIdentExprNonMangled ident) m
            | None -> makeIdentExprNonMangled ident
        let op =
            match isConstructor with
            | Some true -> ConstructorCall funcExpr
            | _ -> StaticCall funcExpr
        let argTypes = match argTypes with Some xs -> Typed xs | None -> NoUncurrying
        let info = argInfo None args argTypes
        Operation(Call(op, info), returnType, loc)

    static member GlobalIdent(ident: string, memb: string, typ: Type, ?loc: SourceLocation) =
        get loc typ (makeIdentExprNonMangled ident) memb

module Helpers =
    let inline makeType com t =
        FSharp2Fable.TypeHelpers.makeType com Map.empty t

    let resolveArgTypes argTypes (genArgs: (string * Type) list) =
        argTypes |> List.map (function
            | GenericParam name as t ->
                genArgs |> List.tryPick (fun (name2, t) ->
                    if name = name2 then Some t else None)
                |> Option.defaultValue t
            | t -> t)

    let emitJs r t args macro =
        let info = argInfo None args AutoUncurrying
        Operation(Emit(macro, Some info), t, r)

    let objExpr t kvs =
        let kvs = List.map (fun (k,v) -> ObjectMember(makeStrConst k, v, ObjectValue)) kvs
        ObjectExpr(kvs, t, None)

    let add left right =
        Operation(BinaryOperation(BinaryPlus, left, right), left.Type, None)

    let sub left right =
        Operation(BinaryOperation(BinaryMinus, left, right), left.Type, None)

    let eq left right =
        Operation(BinaryOperation(BinaryEqualStrict, left, right), Boolean, None)

    let neq left right =
        Operation(BinaryOperation(BinaryUnequalStrict, left, right), Boolean, None)

    let isNull expr =
        Operation(BinaryOperation(BinaryEqual, expr, Value(Null Any)), Boolean, None)

    let error msg =
        Helper.ConstructorCall(makeIdentExprNonMangled "Error", Any, [msg])

    let s txt = Value(StringConstant txt)

    let genArg (com: ICompiler) (ctx: Context) r i (genArgs: (string * Type) list) =
        List.tryItem i genArgs
        |> Option.map snd
        |> Option.defaultWith (fun () ->
            "Couldn't find generic argument in position " + (string i)
            |> addError com ctx.InlinePath r
            Any)

    /// Records, unions and F# exceptions (value types are assimilated into records) will have a base
    /// implementing basic methods: toString, toJSON, GetHashCode, Equals, CompareTo. See fable-core/Types
    let hasBaseImplementingBasicMethods (ent: FSharpEntity) =
        ent.IsFSharpRecord || ent.IsFSharpUnion || ent.IsFSharpExceptionDeclaration || ent.IsValueType

open Helpers

type BuiltinType =
    | BclGuid
    | BclTimeSpan
    | BclDateTime
    | BclDateTimeOffset
    | BclTimer
    | BclInt64
    | BclUInt64
    | BclBigInt
    | BclHashSet of Type
    | BclDictionary of key:Type * value:Type
    | FSharpSet of Type
    | FSharpMap of key:Type * value:Type

let (|Builtin|_|) = function
    | DeclaredType(ent, genArgs) ->
        // TODO: Convert this to dictionary
        match ent.TryFullName, genArgs with
        | Some Types.guid, _ -> Some BclGuid
        | Some Types.timespan, _ -> Some BclTimeSpan
        | Some Types.datetime, _ -> Some BclDateTime
        | Some Types.datetimeOffset, _ -> Some BclDateTimeOffset
        | Some "System.Timers.Timer", _ -> Some BclTimer
        | Some Types.int64, _ -> Some BclInt64
        | Some Types.uint64, _ -> Some BclUInt64
        | Some "Microsoft.FSharp.Core.int64`1", _ -> Some BclInt64
        | Some Types.bigint, _ -> Some BclBigInt
        | Some Types.fsharpSet, [t] -> Some(FSharpSet(t))
        | Some Types.fsharpMap, [k;v] -> Some(FSharpMap(k,v))
        | Some Types.hashset, [t] -> Some(BclHashSet(t))
        | Some Types.dictionary, [k;v] -> Some(BclDictionary(k,v))
        | _ -> None
    | _ -> None

let (|Integer|Float|) = function
    | Int8 | UInt8 | Int16 | UInt16 | Int32 | UInt32 -> Integer
    | Float32 | Float64 | Decimal -> Float

let (|Nameof|_|) = function
    | IdentExpr ident -> Some ident.Name
    | Get(_, ExprGet(Value(StringConstant prop)), _, _) -> Some prop
    | Get(_, FieldGet(fi,_,_), _, _) -> Some fi
    | _ -> None

let (|ReplaceName|_|) (namesAndReplacements: (string*string) list) name =
    namesAndReplacements |> List.tryPick (fun (name2, replacement) ->
        if name2 = name then Some replacement else None)

let inline (|ExprType|) (e: Expr) = e.Type

let (|OrDefault|) (def:'T) = function
    | Some v -> v
    | None -> def

let (|EntFullName|_|) (typ: Type) =
    match typ with
    | DeclaredType(ent, _) -> Some ent.FullName
    | _ -> None

let (|ListLiteral|_|) e =
    let rec untail t acc = function
        | Value(NewList(None, _)) -> Some(List.rev acc, t)
        | Value(NewList(Some(head, tail), _)) -> untail t (head::acc) tail
        | _ -> None
    match e with
    | Value(NewList(None, t)) -> Some([], t)
    | Value(NewList(Some(head, tail), t)) -> untail t [head] tail
    | _ -> None

let (|IDictionary|IEqualityComparer|Other|) = function
    | DeclaredType(ent,_) ->
        match ent.TryFullName with
        | Some Types.idictionary -> IDictionary
        | Some Types.equalityComparer -> IEqualityComparer
        | _ -> Other
    | _ -> Other

let (|IEnumerable|IEqualityComparer|Other|) = function
    | DeclaredType(ent,_) ->
        match ent.TryFullName with
        | Some Types.ienumerableGeneric -> IEnumerable
        | Some Types.equalityComparer -> IEqualityComparer
        | _ -> Other
    | _ -> Other

let coreModFor = function
    | BclGuid -> "String"
    | BclDateTime -> "Date"
    | BclDateTimeOffset -> "DateOffset"
    | BclTimer -> "Timer"
    | BclInt64 -> "Long"
    | BclUInt64 -> "Long"
    | BclBigInt -> "BigInt"
    | BclTimeSpan -> "Int32"
    | FSharpSet _ -> "Set"
    | FSharpMap _ -> "Map"
    | BclHashSet _
    | BclDictionary _ -> failwith "Cannot decide core module"

let genericTypeInfoError com file r =
    "Cannot get type info of generic parameter, please inline or inject a type resolver"
    |> addError com file r

let defaultof (t: Type) =
    match t with
    | Number _ -> makeIntConst 0
    | Boolean -> makeBoolConst false
    | _ -> Null t |> Value

let makeLongInt t signed (x: uint64) =
    let lowBits = NumberConstant (float (uint32 x), Float64)
    let highBits = NumberConstant (float (x >>> 32), Float64)
    let unsigned = BoolConstant (not signed)
    let args = [Value lowBits; Value highBits; Value unsigned]
    Helper.CoreCall("Long", "fromBits", t, args)

let makeFloat32 (x: float32) =
    Helper.GlobalCall("Math", Number Float32, [NumberConstant (float x, Float32) |> Value], memb="fround")

let makeTypeConst (typ: Type) (value: obj) =
    match typ, value with
    // Long Integer types
    | Builtin BclInt64, (:? int64 as x) -> makeLongInt typ true (uint64 x)
    | Builtin BclUInt64, (:? uint64 as x) -> makeLongInt typ false x
    // Decimal type
    | Number Decimal, (:? decimal as x) -> makeDecConst x
    // Short Float type
    | Number Float32, (:? float32 as x) -> makeFloat32 x
    | Boolean, (:? bool as x) -> BoolConstant x |> Value
    | String, (:? string as x) -> StringConstant x |> Value
    | Char, (:? char as x) -> CharConstant x |> Value
    // Integer types
    | Number UInt8, (:? byte as x) -> NumberConstant (float x, UInt8) |> Value
    | Number Int8, (:? sbyte as x) -> NumberConstant (float x, Int8) |> Value
    | Number Int16, (:? int16 as x) -> NumberConstant (float x, Int16) |> Value
    | Number UInt16, (:? uint16 as x) -> NumberConstant (float x, UInt16) |> Value
    | Number Int32, (:? int as x) -> NumberConstant (float x, Int32) |> Value
    | Number UInt32, (:? uint32 as x) -> NumberConstant (float x, UInt32) |> Value
    // Float types
    | Number Float64, (:? float as x) -> NumberConstant (float x, Float64) |> Value
    // Enums
    | EnumType _, (:? int64)
    | EnumType _, (:? uint64) -> failwith "int64 enums are not supported"
    | EnumType(_, name), (:? byte as x) -> Enum(NumberEnum(makeIntConst(int x)), name) |> Value
    | EnumType(_, name), (:? sbyte as x) -> Enum(NumberEnum(makeIntConst(int x)), name) |> Value
    | EnumType(_, name), (:? int16 as x) -> Enum(NumberEnum(makeIntConst(int x)), name) |> Value
    | EnumType(_, name), (:? uint16 as x) -> Enum(NumberEnum(makeIntConst(int x)), name) |> Value
    | EnumType(_, name), (:? int as x) -> Enum(NumberEnum(makeIntConst x), name) |> Value
    | EnumType(_, name), (:? uint32 as x) -> Enum(NumberEnum(makeIntConst(int x)), name) |> Value
    // TODO: Regex
    | Unit, _ -> UnitConstant |> Value
    // Arrays with small data type (ushort, byte) are represented
    // in F# AST as BasicPatterns.Const
    | Array (Number kind), (:? (byte[]) as arr) ->
        let values = arr |> Array.map (fun x -> NumberConstant (float x, kind) |> Value) |> Seq.toList
        NewArray (ArrayValues values, Number kind) |> Value
    | Array (Number kind), (:? (uint16[]) as arr) ->
        let values = arr |> Array.map (fun x -> NumberConstant (float x, kind) |> Value) |> Seq.toList
        NewArray (ArrayValues values, Number kind) |> Value
    | _ -> failwithf "Unexpected type %A for literal %O (%s)" typ value (value.GetType().FullName)

let makeTypeInfo r t =
    TypeInfo(t, r) |> Value

let makeTypeDefinitionInfo r t =
    let t =
        match t with
        | Option _ -> Option Any
        | Array _ -> Array Any
        | List _ -> List Any
        | Tuple genArgs ->
            genArgs |> List.map (fun _ -> Any) |> Tuple
        | DeclaredType(ent, genArgs) ->
            let genArgs = genArgs |> List.map (fun _ -> Any)
            DeclaredType(ent, genArgs)
        // TODO: Do something with FunctionType and ErasedUnion?
        | t -> t
    TypeInfo(t, r) |> Value

let createAtom (value: Expr) =
    let typ = value.Type
    Helper.CoreCall("Util", "createAtom", typ, [value], [typ])

let toChar (arg: Expr) =
    match arg.Type with
    | Char | String -> arg
    | _ -> Helper.GlobalCall("String", Char, [arg], memb="fromCharCode")

let toString com (ctx: Context) r (args: Expr list) =
    match args with
    | [] ->
        "toString is called with empty args"
        |> addErrorAndReturnNull com ctx.InlinePath r
    | head::tail ->
        match head.Type with
        | Char | String -> head
        | Unit | Boolean | Array _ | Tuple _ | FunctionType _ | EnumType _ ->
            Helper.GlobalCall("String", String, [head])
        | Builtin (BclInt64 | BclUInt64) -> Helper.CoreCall("Long", "toString", String, args)
        | Number Int16 -> Helper.CoreCall("Util", "int16ToString", String, args)
        | Number Int32 -> Helper.CoreCall("Util", "int32ToString", String, args)
        | Number _ -> Helper.InstanceCall(head, "toString", String, tail)
        | DeclaredType(ent,_) when hasBaseImplementingBasicMethods ent ->
            Helper.InstanceCall(head, "toString", String, [])
        | _ -> Helper.CoreCall("Util", "toString", String, [head])

let toFloat com (ctx: Context) r targetType (args: Expr list) =
    match args.Head.Type with
    | String ->
        Helper.CoreCall("Double", "parse", Number Float64, args)
    | Builtin (BclInt64 | BclUInt64) ->
        Helper.CoreCall("Long", "toNumber", Number Float64, args)
    | Builtin BclBigInt ->
        let meth = match targetType with
                    | Number Float32 -> "toSingle"
                    | Number Float64 -> "toDouble"
                    | Number Decimal -> "toDecimal"
                    | _ -> failwith "Unexpected BigInt conversion"
        Helper.CoreCall("BigInt", meth, Number Float64, args)
    | Number _ | Char | EnumType(NumberEnumType,_) -> TypeCast(args.Head, targetType)
    | _ ->
        addWarning com ctx.InlinePath r "Cannot make conversion at compile time because source type is unknown"
        TypeCast(args.Head, targetType)

// Apparently ~~ is faster than Math.floor (see https://coderwall.com/p/9b6ksa/is-faster-than-math-floor)
let fastIntFloor expr =
    let inner = makeUnOp None Any expr UnaryNotBitwise
    makeUnOp None (Number Int32) inner UnaryNotBitwise

let toInt com (ctx: Context) r (round: bool) targetType (args: Expr list) =
    let sourceType =
        match args.Head.Type with
        | EnumType(NumberEnumType, _) -> Number Int32
        | t -> t
    let targetType =
        match targetType with
        | EnumType(NumberEnumType, _) -> Number Int32
        | t -> t
    let kindIndex t =             //         0   1   2   3   4   5   6   7   8   9  10  11
        match t with              //         i8 i16 i32 i64  u8 u16 u32 u64 f32 f64 dec big
        | Number Int8 -> 0        //  0 i8   -   -   -   -   +   +   +   +   -   -   -   +
        | Number Int16 -> 1       //  1 i16  +   -   -   -   +   +   +   +   -   -   -   +
        | Number Int32 -> 2       //  2 i32  +   +   -   -   +   +   +   +   -   -   -   +
        | Builtin BclInt64 -> 3   //  3 i64  +   +   +   -   +   +   +   +   -   -   -   +
        | Number UInt8 -> 4       //  4 u8   +   +   +   +   -   -   -   -   -   -   -   +
        | Number UInt16 -> 5      //  5 u16  +   +   +   +   +   -   -   -   -   -   -   +
        | Number UInt32 -> 6      //  6 u32  +   +   +   +   +   +   -   -   -   -   -   +
        | Builtin BclUInt64 -> 7  //  7 u64  +   +   +   +   +   +   +   -   -   -   -   +
        | Number Float32 -> 8     //  8 f32  +   +   +   +   +   +   +   +   -   -   -   +
        | Number Float64 -> 9     //  9 f64  +   +   +   +   +   +   +   +   -   -   -   +
        | Number Decimal -> 10    // 10 dec  +   +   +   +   +   +   +   +   -   -   -   +
        | Builtin BclBigInt -> 11 // 11 big  +   +   +   +   +   +   +   +   +   +   +   -
        | _ -> failwithf "Unexpected non-number type %A" t
    let needToCast typeFrom typeTo =
        let v = kindIndex typeFrom // argument type (vertical)
        let h = kindIndex typeTo   // return type (horizontal)
        ((v > h) || (v < 4 && h > 3)) && (h < 8) || (h <> v && (h = 11 || v = 11))
    let emitLong unsigned (args: Expr list) =
        let args = args @ [makeBoolConst unsigned]
        match sourceType with
        | Builtin (BclInt64|BclUInt64) -> Helper.CoreCall("Long", "fromValue", targetType, args)
        | Number Integer -> Helper.CoreCall("Long", "fromInteger", targetType, args @ [makeIntConst (kindIndex sourceType)])
        | _ -> Helper.CoreCall("Long", "fromNumber", targetType, args)
    let emitBigInt (args: Expr list) =
        match sourceType with
        | Builtin (BclInt64|BclUInt64) -> Helper.CoreCall("BigInt", "fromInt64", targetType, args)
        | _ -> Helper.CoreCall("BigInt", "fromInt32", targetType, args)
    let emitCast typeTo args =
        match typeTo with
        | Builtin BclBigInt -> emitBigInt args
        | Builtin BclUInt64 -> emitLong true args
        | Builtin BclInt64 -> emitLong false args
        | Number Int8 -> emitJs None targetType args "($0 + 0x80 & 0xFF) - 0x80"
        | Number Int16 -> emitJs None targetType args "($0 + 0x8000 & 0xFFFF) - 0x8000"
        | Number Int32 -> fastIntFloor args.Head
        | Number UInt8 -> emitJs None targetType args "$0 & 0xFF"
        | Number UInt16 -> emitJs None targetType args "$0 & 0xFFFF"
        | Number UInt32 -> emitJs None targetType args "$0 >>> 0"
        | Number Float32 -> TypeCast(args.Head, targetType)
        | Number Float64 -> TypeCast(args.Head, targetType)
        | Number Decimal -> TypeCast(args.Head, targetType)
        | _ -> failwithf "Unexpected non-number type %A" typeTo
    let castBigIntMethod typeTo =
        match typeTo with
        | Builtin BclBigInt -> failwith "Unexpected conversion"
        | Number Int8 -> "toSByte"
        | Number Int16 -> "toInt16"
        | Number Int32 -> "toInt32"
        | Builtin BclInt64 -> "toInt64"
        | Number UInt8 -> "toByte"
        | Number UInt16 -> "toUInt16"
        | Number UInt32 -> "toUInt32"
        | Builtin BclUInt64 -> "toUInt64"
        | Number Float32 -> "toSingle"
        | Number Float64 -> "toDouble"
        | Number Decimal -> "toDecimal"
        | _ -> failwithf "Unexpected non-number type %A" typeTo
    match sourceType with
    | EnumType(NumberEnumType,_) -> TypeCast(args.Head, targetType)
    | Char -> Helper.InstanceCall(args.Head, "charCodeAt", targetType, [makeIntConst 0])
    | String ->
        match targetType with
        | Builtin (BclInt64|BclUInt64 as kind) ->
            let unsigned = kind = BclUInt64
            let args = [args.Head]@[makeBoolConst unsigned]@args.Tail
            Helper.CoreCall("Long", "fromString", targetType, args)
        | _ -> Helper.CoreCall("Int32", "parse", targetType, args)
    | Builtin BclBigInt ->
        let meth = castBigIntMethod targetType
        Helper.CoreCall("BigInt", meth, targetType, args)
    | Number _ | Builtin (BclInt64 | BclUInt64) as typeFrom ->
        match targetType with
        | typeTo when needToCast typeFrom typeTo ->
            match typeFrom, typeTo with
            | Builtin (BclUInt64|BclInt64), Number Integer ->
                Helper.CoreCall("Long", "toIntNumber", targetType, args)
            | Builtin (BclUInt64|BclInt64), Number _ ->
                Helper.CoreCall("Long", "toNumber", targetType, args)
            | Number (Decimal|Float), (Number Integer | Builtin(BclInt64|BclUInt64)) when round ->
                Helper.CoreCall("Util", "round", targetType, args)
            | _, _ -> args.Head
            |> List.singleton
            |> emitCast typeTo
        | Builtin (BclUInt64|BclInt64 as kind) ->
            emitLong (kind = BclUInt64) [args.Head]
        | _ -> TypeCast(args.Head, targetType)
    | _ ->
        addWarning com ctx.InlinePath r "Cannot make conversion at compile time because source type is unknown"
        TypeCast(args.Head, targetType)

let arrayCons (com: ICompiler) genArg =
    match genArg with
    | Number numberKind when com.Options.typedArrays ->
        getTypedArrayName com numberKind |> makeIdentExprNonMangled
    | _ -> makeIdentExprNonMangled "Array"

// TODO: Should we pass the empty list representation here?
let toList returnType expr =
    Helper.CoreCall("Seq", "toList", returnType, [expr])

let toArray (com: ICompiler) returnType expr =
    // match expr, returnType with
    // | _, Array(Number numberKind) when com.Options.typedArrays ->
    //     Helper.GlobalCall(getTypedArrayName com numberKind, returnType, [expr], memb="from")
    // | _ -> Helper.GlobalCall("Array", returnType, [expr], memb="from")

    // Calling the JS global methods (Array.from) directly creates problems with lambda optimization
    // because passing these functions as values in JS (e.g. `foo(Array.from)`) doesn't work
    let args =
        match returnType with
        | Array genArg
        // This is used also by Seq.cache, which returns `'T seq` instead of `'T array`
        | DeclaredType(_, [genArg]) -> [expr; arrayCons com genArg]
        | _ -> [expr]
    Helper.CoreCall("Array", "ofSeq", returnType, args)

let listToArray com r t (li: Expr) =
    match li with
    | ListLiteral(exprs, t) -> NewArray(ArrayValues exprs, t) |> Value
    | _ ->
        let args = match t with Array genArg -> [li; arrayCons com genArg] | _ -> [li]
        Helper.CoreCall("Array", "ofList", t, args, ?loc=r)

let stringToCharArray t e =
    Helper.InstanceCall(e, "split", t, [makeStrConst ""])

let enumerator2iterator (e: Expr) =
    Helper.CoreCall("Seq", "toIterator", e.Type, [e])

let toSeq t (e: Expr) =
    match e.Type with
    // Convert to array to get 16-bit code units, see #1279
    | String -> stringToCharArray t e
    | _ -> TypeCast(e, t)

let iterate r ident body (xs: Expr) =
    let f = Function(Delegate [ident], body, None)
    Helper.CoreCall("Seq", "iterate", Unit, [f; toSeq xs.Type xs], ?loc=r)

let (|ListSingleton|) x = [x]

let (|CustomOp|_|) com ctx opName argTypes sourceTypes =
    let tryFindMember com (ctx: Context) (ent: FSharpEntity) opName argTypes =
        FSharp2Fable.TypeHelpers.tryFindMember com ent ctx.GenericArgs opName false argTypes
    sourceTypes |> List.tryPick (function
        | DeclaredType(ent,_) -> tryFindMember com ctx ent opName argTypes
        | _ -> None)

let applyOp (com: ICompiler) (ctx: Context) r t opName (args: Expr list) argTypes genArgs =
    let unOp operator operand =
        Operation(UnaryOperation(operator, operand), t, r)
    let binOp op left right =
        Operation(BinaryOperation(op, left, right), t, r)
    let truncateUnsigned operation = // see #1550
        match t with
        | Number UInt32 ->
            Operation(BinaryOperation(BinaryShiftRightZeroFill,operation,makeIntConst 0), t, r)
        | _ -> operation
    let logicOp op left right =
        Operation(LogicalOperation(op, left, right), Boolean, r)
    let nativeOp opName argTypes args =
        match opName, args with
        | Operators.addition, [left; right] -> binOp BinaryPlus left right
        | Operators.subtraction, [left; right] -> binOp BinaryMinus left right
        | Operators.multiply, [left; right] -> binOp BinaryMultiply left right
        | (Operators.division|Operators.divideByInt), [left; right] ->
            match argTypes with
            // Floor result of integer divisions (see #172)
            | Number Integer::_ -> binOp BinaryDivide left right |> fastIntFloor
            | _ -> binOp BinaryDivide left right
        | Operators.modulus, [left; right] -> binOp BinaryModulus left right
        | Operators.leftShift, [left; right] -> binOp BinaryShiftLeft left right |> truncateUnsigned // See #1530
        | Operators.rightShift, [left; right] ->
            match argTypes with
            | Number UInt32::_ -> binOp BinaryShiftRightZeroFill left right // See #646
            | _ -> binOp BinaryShiftRightSignPropagating left right
        | Operators.bitwiseAnd, [left; right] -> binOp BinaryAndBitwise left right |> truncateUnsigned
        | Operators.bitwiseOr, [left; right] -> binOp BinaryOrBitwise left right |> truncateUnsigned
        | Operators.exclusiveOr, [left; right] -> binOp BinaryXorBitwise left right |> truncateUnsigned
        | Operators.booleanAnd, [left; right] -> logicOp LogicalAnd left right
        | Operators.booleanOr, [left; right] -> logicOp LogicalOr left right
        | Operators.logicalNot, [operand] -> unOp UnaryNotBitwise operand |> truncateUnsigned
        | Operators.unaryNegation, [operand] -> unOp UnaryMinus operand
        | _ -> sprintf "Operator %s not found in %A" opName argTypes
               |> addErrorAndReturnNull com ctx.InlinePath r
    let argTypes = resolveArgTypes argTypes genArgs
    match argTypes with
    | Builtin(BclInt64|BclUInt64|BclBigInt|BclDateTime|BclDateTimeOffset as bt)::_ ->
        let opName =
            match bt, opName with
            | BclUInt64, "op_RightShift" -> "op_RightShiftUnsigned" // See #1482
            | _ -> opName
        Helper.CoreCall(coreModFor bt, opName, t, args, argTypes, ?loc=r)
    | Builtin(FSharpSet _)::_ ->
        let mangledName = Naming.buildNameWithoutSanitationFrom "FSharpSet" true opName ""
        Helper.CoreCall("Set", mangledName, t, args, argTypes, ?loc=r)
    // | Builtin (FSharpMap _)::_ ->
    //     let mangledName = Naming.buildNameWithoutSanitationFrom "FSharpMap" true opName overloadSuffix.Value
    //     Helper.CoreCall("Map", mangledName, t, args, argTypes, ?loc=r)
    | Builtin BclTimeSpan::_ ->
        nativeOp opName argTypes args
    | CustomOp com ctx opName argTypes m ->
        let genArgs = genArgs |> Seq.map snd
        FSharp2Fable.Util.makeCallFrom com ctx r t false genArgs None args m
    | _ -> nativeOp opName argTypes args

let isCompatibleWithJsComparison = function
    | Builtin(BclInt64|BclUInt64|BclBigInt)
    | Array _ | List _ | Tuple _ | Option _ | MetaType -> false
    | Builtin(BclGuid|BclTimeSpan) -> true
    // TODO: Non-record/union declared types without custom equality
    // should be compatible with JS comparison
    | DeclaredType _ -> false
    // TODO: Raise warning when building dictionary/hashset with generic params?
    | GenericParam _ -> true
    | Any | Unit | Boolean | Number _ | String | Char | Regex
    | EnumType _ | ErasedUnion _ | FunctionType _ -> true

// Overview of hash rules:
// * `hash`, `Unchecked.hash` first check if GetHashCode is implemented and then default to structural hash.
// * `.GetHashCode` called directly defaults to identity hash (for reference types except string) if not implemented.
// * `LanguagePrimitive.PhysicalHash` creates an identity hash no matter whether GetHashCode is implemented or not.
let identityHash r (arg: Expr) =
    match arg.Type with
    | Boolean | Char | String | Number _ | EnumType _
    | Builtin(BclInt64|BclUInt64|BclBigInt)
    | Builtin(BclDateTime|BclDateTimeOffset)
    | Builtin(BclGuid|BclTimeSpan) ->
        Helper.CoreCall("Util", "structuralHash", Number Int32, [arg], ?loc=r)
    | DeclaredType(ent,_) when ent.IsValueType ->
        Helper.CoreCall("Util", "structuralHash", Number Int32, [arg], ?loc=r)
    | _ ->
        Helper.CoreCall("Util", "identityHash", Number Int32, [arg], ?loc=r)

let structuralHash r (arg: Expr) =
    Helper.CoreCall("Util", "structuralHash", Number Int32, [arg], ?loc=r)

let makeFunctionsObject (namesAndFunctions: (string * Expr) list) =
    let members =
        namesAndFunctions |> List.map (fun (name, fn) ->
            Fable.ObjectMember(makeStrConst name, fn, Fable.ObjectValue))
    ObjectExpr(members, Fable.Any, None)

let rec equals (com: ICompiler) r equal (left: Expr) (right: Expr) =
    let is equal expr =
        if equal
        then expr
        else makeUnOp None Boolean expr UnaryNot
    match left.Type with
    | Builtin(BclGuid|BclTimeSpan)
    | Boolean | Char | String | Number _ | EnumType _ ->
        let op = if equal then BinaryEqualStrict else BinaryUnequalStrict
        makeBinOp r Boolean left right op
    | Builtin(BclDateTime|BclDateTimeOffset) ->
        Helper.CoreCall("Date", "equals", Boolean, [left; right], ?loc=r) |> is equal
    | Builtin(FSharpSet _|FSharpMap _) ->
        Helper.InstanceCall(left, "Equals", Boolean, [right]) |> is equal
    | Builtin(BclInt64|BclUInt64|BclBigInt as bt) ->
        Helper.CoreCall(coreModFor bt, "equals", Boolean, [left; right], ?loc=r) |> is equal
    | Array t ->
        let f = makeComparerFunction com t
        Helper.CoreCall("Array", "equalsWith", Boolean, [f; left; right], ?loc=r) |> is equal
    | List _ ->
        Helper.CoreCall("Util", "equals", Boolean, [left; right], ?loc=r) |> is equal
    | MetaType ->
        Helper.CoreCall("Reflection", "equals", Boolean, [left; right], ?loc=r) |> is equal
    | Tuple _ ->
        Helper.CoreCall("Util", "equalArrays", Boolean, [left; right], ?loc=r) |> is equal
    // unsafe optimization, left can sometimes be null
    // | DeclaredType(ent,_) when hasBaseImplementingBasicMethods ent ->
    //     Helper.InstanceCall(left, "Equals", Boolean, [right]) |> is equal
    | _ ->
        Helper.CoreCall("Util", "equals", Boolean, [left; right], ?loc=r) |> is equal

/// Compare function that will call Util.compare or instance `CompareTo` as appropriate
and compare (com: ICompiler) r (left: Expr) (right: Expr) =
    match left.Type with
    | Builtin(BclGuid|BclTimeSpan)
    | Boolean | Char | String | Number _ | EnumType _ ->
        Helper.CoreCall("Util", "comparePrimitives", Number Int32, [left; right], ?loc=r)
    | Builtin(BclDateTime|BclDateTimeOffset) ->
        Helper.CoreCall("Date", "compare", Number Int32, [left; right], ?loc=r)
    | Builtin(BclInt64|BclUInt64|BclBigInt as bt) ->
        Helper.CoreCall(coreModFor bt, "compare", Number Int32, [left; right], ?loc=r)
    | Array t ->
        let f = makeComparerFunction com t
        Helper.CoreCall("Array", "compareWith", Number Int32, [f; left; right], ?loc=r)
    | List _ ->
        Helper.CoreCall("Util", "compare", Number Int32, [left; right], ?loc=r)
    | MetaType ->
        Helper.CoreCall("Reflection", "compare", Number Int32, [left; right], ?loc=r)
    | Tuple _ ->
        Helper.CoreCall("Util", "compareArrays", Number Int32, [left; right], ?loc=r)
    | DeclaredType(ent,_) when hasBaseImplementingBasicMethods ent ->
        Helper.InstanceCall(left, "CompareTo", Number Int32, [right], ?loc=r)
    | DeclaredType(ent,_) when FSharp2Fable.Util.hasInterface Types.icomparable ent ->
        Helper.InstanceCall(left, "CompareTo", Number Int32, [right], ?loc=r)
    | _ ->
        Helper.CoreCall("Util", "compare", Number Int32, [left; right], ?loc=r)

/// Wraps comparison with the binary operator, like `comparison < 0`
and compareIf (com: ICompiler) r (left: Expr) (right: Expr) op =
    match left.Type with
    | Builtin(BclGuid|BclTimeSpan)
    | Boolean | Char | String | Number _ | EnumType _ ->
        makeEqOp r left right op
    | _ ->
        let comparison = compare com r left right
        makeEqOp r comparison (makeIntConst 0) op

and makeComparerFunction (com: ICompiler) typArg =
    let x = makeTypedIdentUnique com typArg "x"
    let y = makeTypedIdentUnique com typArg "y"
    let body = compare com None (IdentExpr x) (IdentExpr y)
    Function(Delegate [x; y], body, None)

and makeComparer (com: ICompiler) typArg =
    let fn = makeComparerFunction com typArg
    makeFunctionsObject ["Compare", fn]

let makeEqualityComparer (com: ICompiler) typArg =
    let x = makeTypedIdentUnique com typArg "x"
    let y = makeTypedIdentUnique com typArg "y"
    let body = equals com None true (IdentExpr x) (IdentExpr y)
    let f = Function(Delegate [x; y], body, None)
    // TODO: Use proper IEqualityComparer<'T> type instead of Any
    ObjectExpr
        ([ObjectMember(makeStrConst "Equals", f, ObjectValue)
          ObjectMember(makeStrConst "GetHashCode", makeCoreRef Any "structuralHash" "Util", ObjectValue)], Any, None)

// TODO: Try to detect at compile-time if the object already implements `Compare`?
let inline makeComparerFromEqualityComparer e =
    Helper.CoreCall("Util", "comparerFromEqualityComparer", Any, [e])

/// Adds comparer as last argument for set creator methods
let makeSet (com: ICompiler) r t methName args genArg =
    let args = args @ [makeComparer com genArg]
    Helper.CoreCall("Set", Naming.lowerFirst methName, t, args, ?loc=r)

/// Adds comparer as last argument for map creator methods
let makeMap (com: ICompiler) r t methName args genArg =
    let args = args @ [makeComparer com genArg]
    Helper.CoreCall("Map", Naming.lowerFirst methName, t, args, ?loc=r)

let makeDictionaryWithComparer r t sourceSeq comparer =
    Helper.CoreCall("Map", "createMutable", t, [sourceSeq; comparer], ?loc=r)

let makeDictionary (com: ICompiler) r t sourceSeq =
    match t with
    | DeclaredType(_,[key;_]) when not(isCompatibleWithJsComparison key) ->
        makeComparer com key |> makeDictionaryWithComparer r t sourceSeq
    | _ -> Helper.GlobalCall("Map", t, [sourceSeq], isConstructor=true, ?loc=r)

let makeHashSetWithComparer r t sourceSeq comparer =
    Helper.CoreCall("Set", "createMutable", t, [sourceSeq; comparer], ?loc=r)

let makeHashSet (com: ICompiler) r t sourceSeq =
    match t with
    | DeclaredType(_,[key]) when not(isCompatibleWithJsComparison key) ->
        makeComparer com key |> makeHashSetWithComparer r t sourceSeq
    | _ -> Helper.GlobalCall("Set", t, [sourceSeq], isConstructor=true, ?loc=r)

let getZero (com: ICompiler) ctx (t: Type) =
    match t with
    | Char | String -> makeStrConst ""
    | Builtin BclTimeSpan -> makeIntConst 0
    | Builtin BclDateTime as t -> Helper.CoreCall("Date", "minValue", t, [])
    | Builtin BclDateTimeOffset as t -> Helper.CoreCall("DateOffset", "minValue", t, [])
    | Builtin (FSharpSet genArg) as t -> makeSet com None t "Empty" [] genArg
    | Builtin (BclInt64|BclUInt64) as t -> Helper.CoreCall("Long", "fromInt", t, [makeIntConst 0])
    | Builtin BclBigInt as t -> Helper.CoreCall("BigInt", "fromInt32", t, [makeIntConst 0])
    | ListSingleton(CustomOp com ctx "get_Zero" [] m) ->
        FSharp2Fable.Util.makeCallFrom com ctx None t false [] None [] m
    | _ -> makeIntConst 0

let getOne (com: ICompiler) ctx (t: Type) =
    match t with
    | Builtin (BclInt64|BclUInt64) as t -> Helper.CoreCall("Long", "fromInt", t, [makeIntConst 1])
    | Builtin BclBigInt as t -> Helper.CoreCall("BigInt", "fromInt32", t, [makeIntConst 1])
    | ListSingleton(CustomOp com ctx "get_One" [] m) ->
        FSharp2Fable.Util.makeCallFrom com ctx None t false [] None [] m
    | _ -> makeIntConst 1

let makeAddFunction (com: ICompiler) ctx t =
    let x = makeTypedIdentUnique com t "x"
    let y = makeTypedIdentUnique com t "y"
    let body = applyOp com ctx None t Operators.addition [IdentExpr x; IdentExpr y] [t; t] []
    Function(Delegate [x; y], body, None)

let makeGenericAdder (com: ICompiler) ctx t =
    makeFunctionsObject [
        "GetZero", getZero com ctx t |> makeDelegate []
        "Add", makeAddFunction com ctx t
    ]

let makeGenericAverager (com: ICompiler) ctx t =
    let divideFn =
        let x = makeTypedIdentUnique com t "x"
        let i = makeTypedIdentUnique com (Number Int32) "i"
        let body = applyOp com ctx None t Operators.divideByInt [IdentExpr x; IdentExpr i] [t; Number Int32] []
        Function(Delegate [x; i], body, None)
    makeFunctionsObject [
        "GetZero", getZero com ctx t |> makeDelegate []
        "Add", makeAddFunction com ctx t
        "DivideByInt", divideFn
    ]

let makePojoFromLambda arg =
    let rec flattenSequential = function
        | Sequential statements ->
            List.collect flattenSequential statements
        | e -> [e]
    match arg with
    | Function(Lambda _, lambdaBody, _) ->
        (flattenSequential lambdaBody, Some []) ||> List.foldBack (fun statement acc ->
            match acc, statement with
            | Some acc, Set(_, FieldSet(fiName, _), value, _) ->
                ObjectMember(makeStrConst fiName, value, ObjectValue)::acc |> Some
            | Some acc, Set(_, ExprSet prop, value, _) ->
                ObjectMember(prop, value, ObjectValue)::acc |> Some
            | _ -> None)
    | _ -> None
    |> Option.map (fun members -> ObjectExpr(members, Any, None))
    |> Option.defaultWith (fun () -> Helper.CoreCall("Util", "jsOptions", Any, [arg]))

let changeCase caseRule name =
    match caseRule with
    | CaseRules.LowerFirst -> Naming.lowerFirst name
    | CaseRules.None | _ -> name

let makePojo (com: Fable.ICompiler) r caseRule keyValueList =
    let makeObjMember caseRule name values =
        let value =
            match values with
            | [] -> makeBoolConst true
            | [value] -> value
            | values -> Value(NewArray(ArrayValues values, Any))
        ObjectMember(changeCase caseRule name |> makeStrConst, value, ObjectValue)
    match caseRule with
    | Value(NumberConstant(rule, _))
    | Value(Enum(NumberEnum(Value(NumberConstant(rule, _))), _)) ->
        let caseRule = enum(int rule)
        match keyValueList with
        | MaybeCasted(Value(NewArray(ArrayValues ms, _)) | ListLiteral(ms, _)) ->
            (ms, Some []) ||> List.foldBack (fun m acc ->
                match acc, m with
                // Try to get the member key and value at compile time for unions and tuples
                | Some acc, MaybeCasted(Value(NewUnion(values, uci, _, _))) ->
                    // Union cases with EraseAttribute are used for `Custom`-like cases
                    match FSharp2Fable.Helpers.tryFindAtt Atts.erase uci.Attributes with
                    | Some _ ->
                        match values with
                        | (Value(StringConstant name))::values -> makeObjMember caseRule name values::acc |> Some
                        | _ -> None
                    | None ->
                        let name = defaultArg (FSharp2Fable.Helpers.unionCaseCompiledName uci) uci.Name
                        makeObjMember caseRule name values::acc |> Some
                | Some acc, Value(NewTuple((Value(StringConstant name))::values)) ->
                    makeObjMember caseRule name values::acc |> Some
                | _ ->
                    None)
        | _ -> None
        |> Option.map (fun members -> ObjectExpr(members, Any, None))
        // With key & value for all members, build the POJO at compile time. If not, build it at runtime
        |> Option.defaultWith (fun () ->
            Helper.CoreCall("Util", "createObj", Any, [keyValueList; caseRule |> int |> makeIntConst]))
    | _ ->
        Helper.CoreCall("Util", "createObj", Any, [keyValueList; caseRule])

let injectArg com (ctx: Context) r moduleName methName (genArgs: (string * Type) list) args =
    let (|GenericArg|_|) genArgs genArgIndex =
        List.tryItem genArgIndex genArgs

    let buildArg = function
        | (Types.comparer, GenericArg genArgs (_,genArg)) ->
            makeComparer com genArg |> Some
        | (Types.equalityComparer, GenericArg genArgs (_,genArg)) ->
            makeEqualityComparer com genArg |> Some
        | (Types.arrayCons, GenericArg genArgs (_,genArg)) ->
            arrayCons com genArg |> Some
        | (Types.adder, GenericArg genArgs (_,genArg)) ->
            makeGenericAdder com ctx genArg |> Some
        | (Types.averager, GenericArg genArgs (_,genArg)) ->
            makeGenericAverager com ctx genArg |> Some
        | (_, genArgIndex) ->
            sprintf "Cannot inject arg to %s.%s (genArgs %A - expected index %i)"
                moduleName methName (List.map fst genArgs) genArgIndex
            |> addError com ctx.InlinePath r
            None

    Map.tryFind moduleName ReplacementsInject.fableCoreModules
    |> Option.bind (Map.tryFind methName)
    |> Option.map (List.choose buildArg)
    |> function
        | None -> args
        | Some injections -> args @ injections

let fableCoreLib (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, args with
    | ("Async.AwaitPromise.Static"|"Async.StartAsPromise.Static" as m), _ ->
        let meth =
            if m = "Async.AwaitPromise.Static"
            then "awaitPromise" else "startAsPromise"
        Helper.CoreCall("Async", meth, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "importDynamic", _ -> Helper.GlobalCall("import", t, args, ?loc=r) |> Some
    | Naming.StartsWith "import" suffix, _ ->
        match suffix, args with
        | "Member", [path]      -> Import(makeStrConst Naming.placeholder, path, CustomImport, t, r) |> Some
        | "Default", [path]     -> Import(makeStrConst "default", path, CustomImport, t, r) |> Some
        | "SideEffects", [path] -> Import(makeStrConst "", path, CustomImport, t, r) |> Some
        | "All", [path]         -> Import(makeStrConst "*", path, CustomImport, t, r) |> Some
        | _, [selector; path]   -> Import(selector, path, CustomImport, t, r) |> Some
        | _ -> None
    // Dynamic casting, erase
    | "op_BangBang", _ | "op_BangHat", _ -> List.tryHead args
    | "op_Dynamic", [left; memb] -> getExpr r t left memb |> Some
    | "op_DynamicAssignment", [callee; prop; MaybeLambdaUncurriedAtCompileTime value] ->
        Set(callee, ExprSet prop, value, r) |> Some
    | ("op_Dollar"|"createNew" as m), callee::args ->
        let argInfo = { argInfo None args AutoUncurrying with Spread = TupleSpread }
        if m = "createNew"
        then constructorCall r t argInfo callee |> Some
        else staticCall r t argInfo callee |> Some
    | "op_EqualsEqualsGreater", [name; MaybeLambdaUncurriedAtCompileTime value] ->
        NewTuple [name; value] |> Value |> Some
    | "createObj", [kvs] ->
        DelayedResolution(AsPojo(kvs, (CaseRules.None |> int |> makeIntConst)), t, r) |> Some
     | "keyValueList", [caseRule; keyValueList] ->
            DelayedResolution(AsPojo(keyValueList, caseRule), t, r) |> Some
    | "toPlainJsObj", _ ->
        let emptyObj = ObjectExpr([], t, None)
        Helper.GlobalCall("Object", Any, emptyObj::args, memb="assign", ?loc=r) |> Some
    | "jsOptions", [arg] ->
        makePojoFromLambda arg |> Some
    | "jsThis", _ ->
        makeTypedIdentNonMangled t "this" |> IdentExpr |> Some
    | "jsConstructor", _ ->
        match (genArg com ctx r 0 i.GenericArgs) with
        | DeclaredType(ent, _) when ent.IsClass -> FSharp2Fable.Util.entityRefMaybeImported com ent |> Some
        | _ -> "Only class types define a function constructor in JS"
               |> addError com ctx.InlinePath r; None
    | "createEmpty", _ ->
        objExpr t [] |> Some
    | "nameof", _ ->
        match args with
        | [Nameof name] -> name
        | _ -> "Cannot infer name of expression"
               |> addError com ctx.InlinePath r; Naming.unknown
        |> makeStrConst |> Some
    | "nameofLambda", _ ->
        match args with
        | [Function(_, Nameof name, _)] -> name
        | _ -> "Cannot infer name of expression"
               |> addError com ctx.InlinePath r; Naming.unknown
        |> makeStrConst |> Some
    | "AreEqual", _ ->
        Helper.CoreCall("Util", "assertEqual", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "NotEqual", _ ->
        Helper.CoreCall("Util", "assertNotEqual", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "jsNative", _ ->
        // TODO: Fail at compile time?
        addWarning com ctx.InlinePath r "jsNative is being compiled without replacement, this will fail at runtime."
        let runtimeMsg =
            "A function supposed to be replaced by JS native code has been called, please check."
            |> StringConstant |> Value
        Throw(error runtimeMsg, t, r) |> Some
    // Deprecated methods
    | "ofJson", _ -> Helper.GlobalCall("JSON", t, args, memb="parse", ?loc=r) |> Some
    | "toJson", _ -> Helper.GlobalCall("JSON", t, args, memb="stringify", ?loc=r) |> Some
    | ("inflate"|"deflate"), _ -> List.tryHead args
    | _ -> None

let getReference r t expr = get r t expr "contents"
let setReference r expr value = Set(expr, makeStrConst "contents" |> ExprSet, value, r)
let newReference r t value = Helper.ConstructorCall(makeCoreRef Any "FSharpRef" "Types", t, [value], ?loc=r)

let references (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | "get_Value", Some callee, _ -> getReference r t callee |> Some
    | "set_Value", Some callee, [value] -> setReference r callee value |> Some
    | _ -> None

let getMangledNames (i: CallInfo) (thisArg: Expr option) =
    let isStatic = Option.isNone thisArg
    let pos = i.DeclaringEntityFullName.LastIndexOf('.')
    let moduleName = i.DeclaringEntityFullName.Substring(0, pos).Replace("Microsoft.", "")
    let entityName = Naming.sanitizeIdentForbiddenChars (i.DeclaringEntityFullName.Substring(pos + 1))
    let memberName = Naming.sanitizeIdentForbiddenChars (i.CompiledName)
    let mangledName = Naming.buildNameWithoutSanitationFrom entityName isStatic memberName i.OverloadSuffix.Value
    moduleName, mangledName

let bclType (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let moduleName, mangledName = getMangledNames i thisArg
    let args = match thisArg with Some callee -> callee::args | _ -> args
    Helper.CoreCall(moduleName, mangledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let fsharpModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let moduleName, mangledName = getMangledNames i thisArg
    Helper.CoreCall(moduleName, mangledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let getFableReplLibImport isStatic (entityFullName: string) memberName overloadSuffix =
    // Remove Fable.Repl.Lib. prefix from entity name
    let entityFullName = entityFullName.Substring(15)
    let memberName = Naming.sanitizeIdentForbiddenChars memberName
    let fileName, name, memberPart =
        match entityFullName.IndexOf('.') with
        | -1 -> entityFullName, memberName, Naming.NoMemberPart
        | pos ->
            let fileName = entityFullName.Substring(0, pos)
            let entityName = Naming.sanitizeIdentForbiddenChars (entityFullName.Substring(pos + 1))
            let memberPart =
                match memberName, isStatic with
                | "", _ -> Naming.NoMemberPart
                | _, true -> Naming.StaticMemberPart(memberName, overloadSuffix)
                | _, false -> Naming.InstanceMemberPart(memberName, overloadSuffix)
            fileName, entityName, memberPart
    let mangledName = Naming.buildNameWithoutSanitation name memberPart
    makeCustomImport Fable.Any mangledName ("fable-repl-lib/" + fileName)

let fableReplLib (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let argInfo = { argInfo thisArg args (Typed i.SignatureArgTypes) with Spread = i.Spread }
    getFableReplLibImport (Option.isNone thisArg) i.DeclaringEntityFullName i.CompiledName i.OverloadSuffix.Value
    |> staticCall r t argInfo |> Some

let fsFormat (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | "get_Value", Some callee, _ ->
        get None t callee "input" |> Some
    | "PrintFormatToStringThen", _, _ ->
        match args with
        | [_] -> Helper.CoreCall("String", "toText", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | [cont; fmt] -> Helper.InstanceCall(fmt, "cont", t, [cont]) |> Some
        | _ -> None
    | "PrintFormatToString", _, _ ->
        Helper.CoreCall("String", "toText", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "PrintFormatLine", _, _ ->
        Helper.CoreCall("String", "toConsole", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("PrintFormatToTextWriter"|"PrintFormatLineToTextWriter"), _, _::args ->
        // addWarning com ctx.FileName r "fprintfn will behave as printfn"
        Helper.CoreCall("String", "toConsole", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "PrintFormat", _, _ ->
        // addWarning com ctx.FileName r "Printf will behave as printfn"
        Helper.CoreCall("String", "toConsole", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "PrintFormatThen", _, arg::callee::_ ->
        Helper.InstanceCall(callee, "cont", t, [arg]) |> Some
    | "PrintFormatToStringThenFail", _, _ ->
        Helper.CoreCall("String", "toFail", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("PrintFormatToStringBuilder"      // bprintf
    |  "PrintFormatToStringBuilderThen"  // Printf.kbprintf
       ), _, _ -> fsharpModule com ctx r t i thisArg args
    | ".ctor", _, arg::_ ->
        Helper.CoreCall("String", "printf", t, [arg], i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let operators (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let curriedApply r t applied args =
        Operation(CurriedApply(applied, args), t, r)

    let compose (com: ICompiler) r t f1 f2 =
        let argType, retType =
            match t with
            | FunctionType(LambdaType argType, retType) -> argType, retType
            | _ -> Any, Any
        let tempVar = makeTypedIdentUnique com argType "arg"
        let tempVarExpr =
            match argType with
            // Erase unit references, because the arg may be erased
            | Unit -> Value UnitConstant
            | _ -> IdentExpr tempVar
        let body =
            [tempVarExpr]
            |> curriedApply None Any f1
            |> List.singleton
            |> curriedApply r retType f2
        Function(Lambda tempVar, body, None)

    let math r t (args: Expr list) argTypes methName =
        Helper.GlobalCall("Math", t, args, argTypes, memb=Naming.lowerFirst methName, ?loc=r)

    match i.CompiledName, args with
    | "DefaultArg", _ ->
        Helper.CoreCall("Option", "defaultArg", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "DefaultAsyncBuilder", _ ->
        makeCoreRef t "singleton" "AsyncBuilder" |> Some
    // Erased operators.
    // KeyValuePair is already compiled as a tuple
    | ("KeyValuePattern"|"Identity"|"Box"|"Unbox"|"ToEnum"), [arg] -> TypeCast(arg, t) |> Some
    // Cast to unit to make sure nothing is returned when wrapped in a lambda, see #1360
    | "Ignore", [arg]  -> TypeCast(arg, Unit) |> Some
    // TODO: Number and String conversions
    | ("ToSByte"|"ToByte"|"ToInt8"|"ToUInt8"|"ToInt16"|"ToUInt16"|"ToInt"|"ToUInt"|"ToInt32"|"ToUInt32"|"ToInt64"|"ToUInt64"), _ ->
        toInt com ctx r false t args |> Some
    | ("ToSingle"|"ToDouble"|"ToDecimal"), _ ->
        toFloat com ctx r t args |> Some
    | "ToChar", _ -> toChar args.Head |> Some
    | "ToString", _ -> toString com ctx r args |> Some
    | "CreateSequence", [xs] -> toSeq t xs |> Some
    | "CreateDictionary", [arg] -> makeDictionary com r t arg |> Some
    | "CreateSet", _ -> (genArg com ctx r 0 i.GenericArgs) |> makeSet com r t "OfSeq" args |> Some
    // Ranges
    | ("op_Range"|"op_RangeStep"), _ ->
        let genArg = genArg com ctx r 0 i.GenericArgs
        let addStep args =
            match args with
            | [first; last] -> [first; getOne com ctx genArg; last]
            | _ -> args
        let meth, args =
            match genArg with
            // TODO: BigInt?
            | Char -> "rangeChar", args
            | Builtin BclInt64 -> "rangeLong", (addStep args) @ [makeBoolConst false]
            | Builtin BclUInt64 -> "rangeLong", (addStep args) @ [makeBoolConst true]
            | _ -> "rangeNumber", addStep args
        Helper.CoreCall("Seq", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // Pipes and composition
    | "op_PipeRight", [x; f]
    | "op_PipeLeft", [f; x] -> curriedApply r t f [x] |> Some
    | "op_PipeRight2", [x; y; f]
    | "op_PipeLeft2", [f; x; y] -> curriedApply r t f [x; y] |> Some
    | "op_PipeRight3", [x; y; z; f]
    | "op_PipeLeft3", [f; x; y; z] -> curriedApply r t f [x; y; z] |> Some
    | "op_ComposeRight", [f1; f2] -> compose com r t f1 f2 |> Some
    | "op_ComposeLeft", [f2; f1] -> compose com r t f1 f2 |> Some
    // Strings
    | ("PrintFormatToString"             // sprintf
    |  "PrintFormatToStringThen"         // Printf.ksprintf
    |  "PrintFormat" | "PrintFormatLine" // printf / printfn
    |  "PrintFormatThen"                 // Printf.kprintf
    |  "PrintFormatToStringThenFail"     // Printf.failwithf
    |  "PrintFormatToStringBuilder"      // bprintf
    |  "PrintFormatToStringBuilderThen"  // Printf.kbprintf
        ), _ -> fsFormat com ctx r t i thisArg args
    | ("Failure"
    |  "FailurePattern"  // (|Failure|_|)
    |  "Lock"            // lock
    |  "NullArg"         // nullArg
       ), _ -> fsharpModule com ctx r t i thisArg args
    // Exceptions
    | "FailWith", [msg] | "InvalidOp", [msg] ->
        Throw(error msg, t, r) |> Some
    | "InvalidArg", [argName; msg] ->
        let msg = add (add msg (s "\\nParameter name: ")) argName
        Throw(error msg, t, r) |> Some
    | "Raise", [arg] -> Throw(arg, t, r) |> Some
    | "Reraise", _ ->
        match ctx.CaughtException with
        | Some ex -> Throw(IdentExpr ex, t, r) |> Some
        | None ->
            "`reraise` used in context where caught exception is not available, please report"
            |> addError com ctx.InlinePath r
            Throw(error (s ""), t, r) |> Some
    // Math functions
    // TODO: optimize square pow: x * x
    | "Pow", _ | "PowInteger", _ | "op_Exponentiation", _ ->
        math r t args i.SignatureArgTypes "pow" |> Some
    | "Ceil", _ | "Ceiling", _ ->
        math r t args i.SignatureArgTypes "ceil" |> Some
    | "Log", [arg1; arg2] ->
        // "Math.log($0) / Math.log($1)"
        let dividend = math None t [arg1] (List.take 1 i.SignatureArgTypes) "log"
        let divisor = math None t [arg2] (List.skip 1 i.SignatureArgTypes) "log"
        makeBinOp r t dividend divisor BinaryDivide |> Some
    | "Abs", _ ->
        match resolveArgTypes i.SignatureArgTypes i.GenericArgs with
        | Builtin(BclInt64 | BclBigInt as bt)::_  ->
            Helper.CoreCall(coreModFor bt, "abs", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
        | _ -> math r t args i.SignatureArgTypes i.CompiledName |> Some
    | "Acos", _ | "Asin", _ | "Atan", _ | "Atan2", _
    | "Cos", _ | "Exp", _ | "Floor", _ | "Log", _ | "Log10", _
    | "Sin", _ | "Sqrt", _ | "Tan", _ ->
        math r t args i.SignatureArgTypes i.CompiledName |> Some
    | "Round", _ ->
        Helper.CoreCall("Util", "round", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "Sign", _ ->
        let args = toFloat com ctx r t args |> List.singleton
        Helper.CoreCall("Util", "sign", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // Numbers
    | ("Infinity"|"InfinitySingle"), _ ->
        Helper.GlobalIdent("Number", "POSITIVE_INFINITY", t, ?loc=r) |> Some
    | ("NaN"|"NaNSingle"), _ ->
        Helper.GlobalIdent("Number", "NaN", t, ?loc=r) |> Some
    | "Fst", [tup] -> Get(tup, TupleGet 0, t, r) |> Some
    | "Snd", [tup] -> Get(tup, TupleGet 1, t, r) |> Some
    // Reference
    | "op_Dereference", [arg] -> getReference r t arg  |> Some
    | "op_ColonEquals", [o; v] -> setReference r o v |> Some
    | "Ref", [arg] -> newReference r t arg |> Some
    | ("Increment"|"Decrement"), _ ->
        if i.CompiledName = "Increment" then "void($0.contents++)" else "void($0.contents--)"
        |> emitJs r t args |> Some
    // Concatenates two lists
    | "op_Append", _ -> Helper.CoreCall("List", "append", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | ("op_Inequality"|"Neq"), [left; right] -> equals com r false left right |> Some
    | ("op_Equality"|"Eq"), [left; right] -> equals com r true left right |> Some
    | "IsNull", [arg] -> makeEqOp r arg (Null arg.Type |> Value) BinaryEqual |> Some
    | "Hash", [arg] -> structuralHash r arg |> Some
    // Comparison
    | "Compare", [left; right] -> compare com r left right |> Some
    | ("op_LessThan"|"Lt"), [left; right] -> compareIf com r left right BinaryLess |> Some
    | ("op_LessThanOrEqual"|"Lte"), [left; right] -> compareIf com r left right BinaryLessOrEqual |> Some
    | ("op_GreaterThan"|"Gt"), [left; right] -> compareIf com r left right BinaryGreater |> Some
    | ("op_GreaterThanOrEqual"|"Gte"), [left; right] -> compareIf com r left right BinaryGreaterOrEqual |> Some
    | ("Min"|"Max" as meth), _ ->
        let f = makeComparerFunction com t
        Helper.CoreCall("Util", Naming.lowerFirst meth, t, f::args, i.SignatureArgTypes, ?loc=r) |> Some
    | "Not", [operand] -> // TODO: Check custom operator?
        makeUnOp r t operand UnaryNot |> Some
    | Patterns.SetContains Operators.standardSet, _ ->
        applyOp com ctx r t i.CompiledName args i.SignatureArgTypes i.GenericArgs |> Some
    // Type info
    | "TypeOf", _ -> (genArg com ctx r 0 i.GenericArgs) |> makeTypeInfo r |> Some
    | "TypeDefOf", _ -> (genArg com ctx r 0 i.GenericArgs) |> makeTypeDefinitionInfo r |> Some
    | _ -> None

let chars (com: ICompiler) (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    let icall r t args argTypes memb  =
        match args, argTypes with
        | thisArg::args, _::argTypes ->
            let info = argInfo (Some thisArg) args (Typed argTypes)
            instanceCall r t info (makeStrConst memb |> Some) |> Some
        | _ -> None
    match i.CompiledName with
    | "ToUpper" -> icall r t args i.SignatureArgTypes "toLocaleUpperCase"
    | "ToUpperInvariant" -> icall r t args i.SignatureArgTypes "toUpperCase"
    | "ToLower" -> icall r t args i.SignatureArgTypes "toLocaleLowerCase"
    | "ToLowerInvariant" -> icall r t args i.SignatureArgTypes "toLowerCase"
    | "ToString" -> toString com ctx r args |> Some
    | "GetUnicodeCategory" | "IsControl" | "IsDigit" | "IsLetter"
    | "IsLetterOrDigit" | "IsUpper" | "IsLower" | "IsNumber"
    | "IsPunctuation" | "IsSeparator" | "IsSymbol" | "IsWhiteSpace"
    | "IsHighSurrogate" | "IsLowSurrogate" | "IsSurrogate" | "IsSurrogatePair"
    | "Parse" ->
        let methName = Naming.lowerFirst i.CompiledName
        Helper.CoreCall("Char", methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let implementedStringFunctions =
    set [| "Compare"
           "CompareTo"
           "EndsWith"
           "Format"
           "IndexOfAny"
           "Insert"
           "IsNullOrEmpty"
           "IsNullOrWhiteSpace"
           "PadLeft"
           "PadRight"
           "Remove"
           "Replace"
        |]

let strings (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let join nonDelimiterArgType args =
        let hasSpread =
            match i.Spread, nonDelimiterArgType with
            | SeqSpread, _ -> true
            | _, EntFullName Types.ienumerableGeneric -> true
            | _ -> false
        Helper.CoreCall("String", "join", t, args, hasSpread=hasSpread, ?loc=r)
    match i.CompiledName, thisArg, args with
    | ".ctor", _, fstArg::_ ->
        match fstArg.Type with
        | Char ->
            match args with
            | [_; _] -> emitJs r t args "Array($1 + 1).join($0)" |> Some // String(char, int)
            | _ -> "Unexpected arguments in System.String constructor."
                   |> addErrorAndReturnNull com ctx.InlinePath r |> Some
        | Array _ ->
            match args with
            | [_] -> emitJs r t args "$0.join('')" |> Some // String(char[])
            | [_; _; _] -> emitJs r t args "$0.join('').substr($1, $2)" |> Some // String(char[], int, int)
            | _ -> "Unexpected arguments in System.String constructor."
                   |> addErrorAndReturnNull com ctx.InlinePath r |> Some
        | _ ->
            fsFormat com ctx r t i thisArg args
    | "get_Length", Some c, _ -> get r t c "length" |> Some
    | "get_Chars", Some c, _ ->
        Helper.CoreCall("String", "getCharAtIndex", t, args, i.SignatureArgTypes, c, ?loc=r) |> Some
    | "Equals", Some x, [y] | "Equals", None, [x; y] ->
        makeEqOp r x y BinaryEqualStrict |> Some
    | "Equals", Some x, [y; kind] | "Equals", None, [x; y; kind] ->
        let left = Helper.CoreCall("String", "compare", Number Int32, [x; y; kind])
        makeEqOp r left (makeIntConst 0) BinaryEqualStrict |> Some
    | "Contains", Some c, arg::_ ->
        if (List.length args) > 1 then
            addWarning com ctx.InlinePath r "String.Contains: second argument is ignored"
        let left = Helper.InstanceCall(c, "indexOf", Number Int32, [arg])
        makeEqOp r left (makeIntConst 0) BinaryGreaterOrEqual |> Some
    | "StartsWith", Some c, [_str] ->
        let left = Helper.InstanceCall(c, "indexOf", Number Int32, args)
        makeEqOp r left (makeIntConst 0) BinaryEqualStrict |> Some
    | "StartsWith", Some c, [_str; _comp] ->
        Helper.CoreCall("String", "startsWith", t, args, i.SignatureArgTypes, c, ?loc=r) |> Some
    | ReplaceName [ "Substring",        "substr"
                    "ToUpper",          "toLocaleUpperCase"
                    "ToUpperInvariant", "toUpperCase"
                    "ToLower",          "toLocaleLowerCase"
                    "ToLowerInvariant", "toLowerCase" ] methName, Some c, args ->
        Helper.InstanceCall(c, methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("IndexOf" | "LastIndexOf"), Some c, _ ->
        match args with
        | [ExprType Char]
        | [ExprType String]
        | [ExprType Char; ExprType(Number Int32)]
        | [ExprType String; ExprType(Number Int32)] ->
            Helper.InstanceCall(c, Naming.lowerFirst i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | _ -> "The only extra argument accepted for String.IndexOf/LastIndexOf is startIndex."
               |> addErrorAndReturnNull com ctx.InlinePath r |> Some
    | ("Trim" | "TrimStart" | "TrimEnd"), Some c, _ ->
        let methName = Naming.lowerFirst i.CompiledName
        match args with
        | [] -> Helper.InstanceCall(c, methName, t, [], i.SignatureArgTypes, ?loc=r) |> Some
        | head::tail ->
            let spread =
                match head.Type, tail with
                | Array _, [] -> true
                | _ -> false
            Helper.CoreCall("String", methName, t, c::args, hasSpread=spread, ?loc=r) |> Some
    | "ToCharArray", Some c, _ ->
        stringToCharArray t c |> Some
    | "Split", Some c, _ ->
        match args with
        // Optimization
        | [] -> Helper.InstanceCall(c, "split", t, [makeStrConst ""]) |> Some
        | [Value(CharConstant _) as separator]
        | [Value(StringConstant _) as separator]
        | [Value(NewArray(ArrayValues [separator],_))] ->
            Helper.InstanceCall(c, "split", t, [separator]) |> Some
        | [arg1; ExprType(EnumType _) as arg2] ->
            let arg1 =
                match arg1.Type with
                | Array _ -> arg1
                | _ -> Value(NewArray(ArrayValues [arg1], String))
            let args = [arg1; Value(Null Any); arg2]
            Helper.CoreCall("String", "split", t, c::args, ?loc=r) |> Some
        | args ->
            Helper.CoreCall("String", "split", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "Join", None, [_delimiter; _parts; ExprType(Number _); ExprType(Number _)] ->
        Helper.CoreCall("String", "joinWithIndices", t, args, ?loc=r) |> Some
    | "Join", None, _ ->
        join (List.item 1 i.SignatureArgTypes) args |> Some
    | "Concat", None, _ ->
        join (List.head i.SignatureArgTypes) ((makeStrConst "")::args) |> Some
    | "CompareOrdinal", None, _ ->
        Helper.CoreCall("String", "compareOrdinal", t, args, ?loc=r) |> Some
    | Patterns.SetContains implementedStringFunctions, thisArg, args ->
        let hasSpread = match i.Spread with SeqSpread -> true | _ -> false
        Helper.CoreCall("String", Naming.lowerFirst i.CompiledName, t, args, i.SignatureArgTypes,
                        hasSpread=hasSpread, ?thisArg=thisArg, ?loc=r) |> Some
    | _ -> None

let stringModule (com: ICompiler) (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName, args with
    | "Length", [arg] -> get r t arg "length" |> Some
    | ("Iterate" | "IterateIndexed" | "ForAll" | "Exists"), _ ->
        // Cast the string to char[], see #1279
        let args = args |> List.replaceLast (fun e -> stringToCharArray e.Type e)
        Helper.CoreCall("Seq", Naming.lowerFirst i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("Map" | "MapIndexed" | "Collect"), _ ->
        // Cast the string to char[], see #1279
        let args = args |> List.replaceLast (fun e -> stringToCharArray e.Type e)
        let name = Naming.lowerFirst i.CompiledName
        emitJs r t [Helper.CoreCall("Seq", name, Any, args, i.SignatureArgTypes)] "Array.from($0).join('')" |> Some
    | "Concat", _ ->
        Helper.CoreCall("String", "join", t, args, hasSpread=true, ?loc=r) |> Some
    // Rest of StringModule methods
    | meth, args ->
        Helper.CoreCall("String", Naming.lowerFirst meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let getEnumerator r t expr =
    Helper.CoreCall("Seq", "getEnumerator", t, [toSeq Any expr], ?loc=r)

let seqs (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let sort r returnType descending projection args genArg =
        let compareFn =
            let identExpr ident =
                match projection with
                | Some projection ->
                    let info = argInfo None [IdentExpr ident] NoUncurrying
                    Operation(Call(StaticCall projection, info), genArg, None)
                | None -> IdentExpr ident
            let x = makeTypedIdentUnique com genArg "x"
            let y = makeTypedIdentUnique com genArg "y"
            let comparison =
                let comparison = compare com None (identExpr x) (identExpr y)
                if descending
                then makeUnOp None (Fable.Number Int32) comparison UnaryMinus
                else comparison
            Function(Delegate [x; y], comparison, None)
        Helper.CoreCall("Seq", "sortWith", returnType, compareFn::args, ?loc=r) |> Some

    match i.CompiledName, args with
    | "Cast", [arg] -> Some arg // Erase
    | ("Cache"|"ToArray"), [arg] -> toArray com t arg |> Some
    | "OfList", [arg] -> toSeq t arg |> Some
    | "ToList", _ -> Helper.CoreCall("List", "ofSeq", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "ChunkBySize" | "Permute" as meth, [arg1; arg2] ->
        let arg2 = toArray com (Array Any) arg2
        let args =
            match meth, t with
            | "Permute", DeclaredType(_seq, [genArg]) ->
                [arg1; arg2] @ [arrayCons com genArg]
            | _ -> [arg1; arg2]
        let result = Helper.CoreCall("Array", Naming.lowerFirst meth, Any, args)
        Helper.CoreCall("Seq", "ofArray", t, [result]) |> Some
    // For Using we need to cast the argument to IDisposable
    | "EnumerateUsing", [arg; f] ->
        Helper.CoreCall("Seq", "enumerateUsing", t, [arg; f], i.SignatureArgTypes, ?loc=r) |> Some
    | ("Sort" | "SortDescending" as meth), args ->
        (genArg com ctx r 0 i.GenericArgs) |> sort r t (meth = "SortDescending") None args
    | ("SortBy" | "SortByDescending" as meth), projection::args ->
        (genArg com ctx r 1 i.GenericArgs) |> sort r t (meth = "SortByDescending") (Some projection) args
    | ("GroupBy" | "CountBy" as meth), args ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "Map" meth i.GenericArgs args
        Helper.CoreCall("Map", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("Distinct" | "DistinctBy" as meth), args ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "Set" meth i.GenericArgs args
        Helper.CoreCall("Set", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | meth, _ ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "Seq" meth i.GenericArgs args
        Helper.CoreCall("Seq", meth, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let resizeArrays (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    // Use Any to prevent creation of a typed array (not resizable)
    // TODO: Include a value in Fable AST to indicate the Array should always be dynamic?
    | ".ctor", _, [] ->
        makeArray Any [] |> Some
    | ".ctor", _, [ExprType(Number _)] ->
        makeArray Any [] |> Some
    // Optimize expressions like `ResizeArray [|1|]` or `ResizeArray [1]`
    | ".ctor", _, [Value(NewArray(ArrayValues vals, _)) | ListLiteral(vals, _)] ->
        makeArray Any vals |> Some
    | ".ctor", _, args ->
        Helper.GlobalCall("Array", t, args, memb="from", ?loc=r) |> Some
    | "get_Item", Some ar, [idx] -> getExpr r t ar idx |> Some
    | "set_Item", Some ar, [idx; value] -> Set(ar, ExprSet idx, value, r) |> Some
    | "Add", Some ar, args ->
        Helper.InstanceCall(ar, "push", t, args, ?loc=r) |> Some
    | "Remove", Some ar, [arg] ->
        Helper.CoreCall("Array", "removeInPlace", t, [arg; ar], ?loc=r) |> Some
    | "GetEnumerator", Some ar, _ -> getEnumerator r t ar |> Some
    // ICollection members, implemented in dictionaries and sets too. We need runtime checks (see #1120)
    | "get_Count", Some ar, _ ->
        Helper.CoreCall("Util", "count", t, [ar], ?loc=r) |> Some
    | "Clear", Some ar, _ ->
        Helper.CoreCall("Util", "clear", t, [ar], ?loc=r) |> Some
    | "Find", Some ar, [arg] ->
        Helper.CoreCall("Option", "value", t,
          [ Helper.CoreCall("Seq", "tryFind", t, [arg; ar; defaultof t], ?loc=r)
            Value(BoolConstant true) ], ?loc=r) |> Some
    | "FindLast", Some ar, [arg] ->
        Helper.CoreCall("Option", "value", t,
          [ Helper.CoreCall("Seq", "tryFindBack", t, [arg; ar; defaultof t], ?loc=r)
            Value(BoolConstant true) ], ?loc=r) |> Some
    | "FindAll", Some ar, [arg] ->
        Helper.CoreCall("Seq", "filter", t, [arg; ar], ?loc=r) |> toArray com t |> Some
    | "AddRange", Some ar, [arg] ->
        Helper.CoreCall("Array", "addRangeInPlace", t, [arg; ar], ?loc=r) |> Some
    | "Contains", Some ar, [arg] ->
        let left = Helper.InstanceCall(ar, "indexOf", Number Int32, [arg], ?loc=r)
        makeEqOp r left (makeIntConst 0) BinaryGreaterOrEqual |> Some
    | "IndexOf", Some ar, args ->
        Helper.InstanceCall(ar, "indexOf", t, args, ?loc=r) |> Some
    | "Insert", Some ar, [idx; arg] ->
        Helper.InstanceCall(ar, "splice", t, [idx; makeIntConst 0; arg], ?loc=r) |> Some
    | "RemoveRange", Some ar, args ->
        Helper.InstanceCall(ar, "splice", t, args, ?loc=r) |> Some
    | "RemoveAt", Some ar, [idx] ->
        Helper.InstanceCall(ar, "splice", t, [idx; makeIntConst 1], ?loc=r) |> Some
    | "Reverse", Some ar, [] ->
        Helper.InstanceCall(ar, "reverse", t, args, ?loc=r) |> Some
    | "Sort", Some ar, [] ->
        let compareFn = (genArg com ctx r 0 i.GenericArgs) |> makeComparerFunction com
        Helper.InstanceCall(ar, "sort", t, [compareFn], ?loc=r) |> Some
    | "Sort", Some ar, [ExprType(Fable.FunctionType _)] ->
        Helper.InstanceCall(ar, "sort", t, args, ?loc=r) |> Some
    | "ToArray", Some ar, [] ->
        Helper.InstanceCall(ar, "slice", t, args, ?loc=r) |> Some
    | _ -> None

let nativeArrayFunctions =
    dict [| "Exists", "some"
            "Filter", "filter"
            "Find", "find"
            "FindIndex", "findIndex"
            "ForAll", "every"
            "Iterate", "forEach"
            "Reduce", "reduce"
            "ReduceBack", "reduceRight"
            "SortInPlace", "sort"
            "SortInPlaceWith", "sort" |]

let arrays (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | "get_Length", Some ar, _ -> get r t ar "length" |> Some
    | "get_Item", Some ar, [idx] -> getExpr r t ar idx |> Some
    | "set_Item", Some ar, [idx; value] -> Set(ar, ExprSet idx, value, r) |> Some
    | "Copy", None, [source; target; count] ->
        Helper.CoreCall("Array", "copyTo", t, [source; makeIntConst 0; target; makeIntConst 0; count], i.SignatureArgTypes, ?loc=r) |> Some
    | "Copy", None, [source; sourceIndex; target; targetIndex; count] ->
        Helper.CoreCall("Array", "copyTo", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let arrayModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    let inline newArray size t =
        Value(NewArray(ArrayAlloc size, t))
    let createArray size value =
        match t, value with
        | Array(Number _ as t2), None -> newArray size t2
        | Array(Number _ as t2), Some value
        | Array(Boolean as t2), OrDefault (makeBoolConst false) value
        | Array t2, OrDefault (Value(Null Any)) value ->
            // If we don't fill the array some operations may behave unexpectedly, like Array.prototype.reduce
            Helper.CoreCall("Array", "fill", t, [newArray size t2; makeIntConst 0; size; value])
        | _ -> sprintf "Expecting an array type but got %A" t
               |> addErrorAndReturnNull com ctx.InlinePath r
    match i.CompiledName, args with
    | "ToSeq", [arg] -> Some arg
    | "OfSeq", [arg] -> toArray com t arg |> Some
    | "OfList", [arg] -> listToArray com r t arg |> Some
    | ("Length" | "Count"), [arg] -> get r t arg "length" |> Some
    | "Item", [idx; ar] -> getExpr r t ar idx |> Some
    | "Get", [ar; idx] -> getExpr r t ar idx |> Some
    | "Set", [ar; idx; value] -> Set(ar, ExprSet idx, value, r) |> Some
    | "ZeroCreate", [count] -> createArray count None |> Some
    | "Create", [count; value] -> createArray count (Some value) |> Some
    | "Empty", _ ->
        let t = match t with Array t -> t | _ -> Any
        newArray (makeIntConst 0) t |> Some
    | "IsEmpty", [ar] ->
        eq (get r (Number Int32) ar "length") (makeIntConst 0) |> Some
    | Patterns.DicContains nativeArrayFunctions meth, _ ->
        let args, thisArg = List.splitLast args
        let argTypes = List.take (List.length args) i.SignatureArgTypes
        Helper.InstanceCall(thisArg, meth, t, args, argTypes, ?loc=r) |> Some
    | meth, _ ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "Array" meth i.GenericArgs args
        Helper.CoreCall("Array", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let lists (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    // Use methods for Head and Tail (instead of Get(ListHead) for example) to check for empty lists
    | ReplaceName
      [ "get_Head",   "head"
        "get_Tail",   "tail"
        "get_Item",   "item"
        "get_Length", "length"
        "GetSlice",   "slice" ] methName, Some x, _ ->
            let args = match args with [ExprType Unit] -> [x] | args -> args @ [x]
            Helper.CoreCall("List", methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "get_IsEmpty", Some x, _ -> Test(x, ListTest false, r) |> Some
    | "get_Empty", None, _ -> NewList(None, (genArg com ctx r 0 i.GenericArgs)) |> Value |> Some
    | "Cons", None, [h;t] -> NewList(Some(h,t), (genArg com ctx r 0 i.GenericArgs)) |> Value |> Some
    | ("GetHashCode" | "Equals" | "CompareTo"), Some callee, _ ->
        Helper.InstanceCall(callee, i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let listModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName, args with
    | "IsEmpty", [x] -> Test(x, ListTest false, r) |> Some
    | "Empty", _ -> NewList(None, (genArg com ctx r 0 i.GenericArgs)) |> Value |> Some
    | "Singleton", [x] ->
        NewList(Some(x, Value(NewList(None, t))), (genArg com ctx r 0 i.GenericArgs)) |> Value |> Some
    // Use a cast to give it better chances of optimization (e.g. converting list
    // literals to arrays) after the beta reduction pass
    | "ToSeq", [x] -> toSeq t x |> Some
    | "ToArray", [x] -> listToArray com r t x |> Some
    | meth, _ ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "List" meth i.GenericArgs args
        Helper.CoreCall("List", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let sets (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | ".ctor" -> (genArg com ctx r 0 i.GenericArgs) |> makeSet com r t "OfSeq" args |> Some
    | _ ->
        let isStatic = Option.isNone thisArg
        let mangledName = Naming.buildNameWithoutSanitationFrom "FSharpSet" isStatic i.CompiledName i.OverloadSuffix.Value
        let args = injectArg com ctx r "Set" mangledName i.GenericArgs args
        Helper.CoreCall("Set", mangledName, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let setModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    let meth = Naming.lowerFirst i.CompiledName
    let args = injectArg com ctx r "Set" meth i.GenericArgs args
    Helper.CoreCall("Set", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let maps (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | ".ctor" -> (genArg com ctx r 0 i.GenericArgs) |> makeMap com r t "OfSeq" args |> Some
    | _ ->
        let isStatic = Option.isNone thisArg
        let mangledName = Naming.buildNameWithoutSanitationFrom "FSharpMap" isStatic i.CompiledName i.OverloadSuffix.Value
        let args = injectArg com ctx r "Map" mangledName i.GenericArgs args
        Helper.CoreCall("Map", mangledName, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let mapModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    let meth = Naming.lowerFirst i.CompiledName
    let args = injectArg com ctx r "Map" meth i.GenericArgs args
    Helper.CoreCall("Map", meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let results (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "Map" -> Some "mapOk"
    | "MapError" -> Some "mapError"
    | "Bind" -> Some "bindOk"
    | _ -> None
    |> Option.map (fun meth -> Helper.CoreCall("Option", meth, t, args, i.SignatureArgTypes, ?loc=r))

// See fable-core/Option.ts for more info on how options behave in Fable runtime
let options (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | "get_Value", Some c, _ -> Get(c, OptionValue, t, r) |> Some
    | "get_IsSome", Some c, _ -> Test(c, OptionTest true, r) |> Some
    | "get_IsNone", Some c, _ -> Test(c, OptionTest false, r) |> Some
    | _ -> None

let optionModule (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    let toArray r t arg =
        let ident = makeIdentUnique com "x"
        let f =
            [IdentExpr ident]
            |> makeArray Any
            |> makeDelegate [ident]
        // Prevent functions being run twice, see #198
        Helper.CoreCall("Option", "defaultArg", t, [arg; makeArray Any []; f], ?loc=r)
    match i.CompiledName, args with
    | "None", _ -> NewOption(None, t) |> Value |> Some
    | "GetValue", [c] -> Get(c, OptionValue, t, r) |> Some
    | ("OfObj" | "OfNullable"), [c] -> TypeCast(c, t) |> Some
    | ("ToObj" | "ToNullable" | "Flatten"), [c] ->
        Helper.CoreCall("Option", "value", t, [c; makeBoolConst true], ?loc=r) |> Some
    | "IsSome", [c] -> Test(c, OptionTest true, r) |> Some
    | "IsNone", [c] -> Test(c, OptionTest false, r) |> Some
    | ("Map" | "Bind"), [f; arg] ->
        let fType, argType =
            match i.SignatureArgTypes with
            | [fType; argType] -> fType, argType
            | _ -> f.Type, arg.Type // unexpected
        let args = [arg; Value(NewOption(None, argType)); f]
        Helper.CoreCall("Option", "defaultArg", t, args, [argType; Option argType; fType],  ?loc=r) |> Some
    | "Filter", _ ->
        Helper.CoreCall("Option", "filter", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "ToArray", [arg] ->
        toArray r t arg |> Some
    | "FoldBack", [folder; opt; state] ->
        Helper.CoreCall("Seq", "foldBack", t, [folder; toArray None Any opt; state], i.SignatureArgTypes, ?loc=r) |> Some
    | ("DefaultValue" | "OrElse"), _ ->
        Helper.CoreCall("Option", "defaultArg", t, List.rev args, ?loc=r) |> Some
    | ("DefaultWith" | "OrElseWith"), _ ->
        Helper.CoreCall("Option", "defaultArgWith", t, List.rev args, List.rev i.SignatureArgTypes, ?loc=r) |> Some
    | ("Count" | "Contains" | "Exists" | "Fold" | "ForAll" | "Iterate" | "ToList" as meth), _ ->
        let args = args |> List.replaceLast (toArray None Any)
        let moduleName, meth =
            if meth = "ToList"
            then "List", "ofArray"
            else "Seq", Naming.lowerFirst meth
        Helper.CoreCall(moduleName, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // | "map2" | "map3" -> failwith "TODO"
    | _ -> None

type ParseTarget =
    | Parse2Int
    | Parse2Int64
    | Parse2Float

let parse target (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    // TODO what about Single (and decimal)?
    let isFloat, numberModule =
        match target with
        | Parse2Int -> false, "Int32"
        | Parse2Int64 -> false, "Long"
        | Parse2Float -> true, "Double"
    match i.CompiledName, args with
    | "IsNaN", [_] when isFloat ->
        Helper.GlobalCall("Number", t, args, memb="isNaN", ?loc=r) |> Some
    | "IsInfinity", [_] when isFloat ->
        Helper.CoreCall("Double", "isInfinity", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // TODO verify that the number is within the Int32/Double/Single range
    | "Parse", [str] ->
        Helper.CoreCall(numberModule, "parse", t,
            [str; (if isFloat then makeFloatConst 10.0 else makeIntConst 10)],
            [i.SignatureArgTypes.Head; Number Float32], ?loc=r) |> Some
    | "Parse", [str; Value(Enum(NumberEnum(Value(NumberConstant(hexConst', _))), _))] ->
        let hexConst = float System.Globalization.NumberStyles.HexNumber
        if hexConst' = hexConst then
            Helper.CoreCall(numberModule, "parse", t,
                [str; (if isFloat then makeFloatConst 16.0 else makeIntConst 16)],
                [i.SignatureArgTypes.Head; Number Float32], ?loc=r) |> Some
        else None  // TODO:
    | "Parse", str::_ ->
        // e.g. Double.Parse(string, IFormatProvider) etc.
        sprintf "%s.Parse(): second argument is ignored" i.DeclaringEntityFullName
        |> addWarning com ctx.InlinePath r
        Helper.CoreCall(numberModule, "parse", t,
            [str; (if isFloat then makeFloatConst 10.0 else makeIntConst 10)],
            [i.SignatureArgTypes.Head; Number Float32])
        |> Some
    | "TryParse", [str; defValue] ->
        Helper.CoreCall(numberModule, "tryParse", t,
            [str; (if isFloat then makeFloatConst 10.0 else makeIntConst 10); defValue],
            [i.SignatureArgTypes.Head; Number Float32; i.SignatureArgTypes.Tail.Head], ?loc=r) |> Some
    | "ToString", [Value (StringConstant _) as format] ->
        let format = emitJs r String [format] "'{0:' + $0 + '}'"
        Helper.CoreCall("String", "format", t, [format; thisArg.Value], [format.Type; thisArg.Value.Type], ?loc=r) |> Some
    | "ToString", _ ->
        Helper.CoreCall("Util", "toString", t, [thisArg.Value], [thisArg.Value.Type], ?loc=r) |> Some
    | _ ->
        None

let decimals (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, args with
    | ".ctor", [Value(NumberConstant(x, _))] ->
        makeDecConst (decimal(x)) |> Some
    | ".ctor", [Value(NewArray(ArrayValues arVals, _))] ->
        match arVals with
        | [ Value(NumberConstant(low, Int32))
            Value(NumberConstant(mid, Int32))
            Value(NumberConstant(_high, Int32)) // TODO: Review
            Value(NumberConstant(scale, Int32)) ] ->
                let x = (float ((uint64 (uint32 mid)) <<< 32 ||| (uint64 (uint32 low))))
                        / System.Math.Pow(10.0, float ((int scale) >>> 16 &&& 0xFF))
                decimal(if scale < 0.0 then -x else x) |> makeDecConst |> Some
        | _ -> None
    | (".ctor" | "MakeDecimal"),
          [ Value(NumberConstant(low, Int32))
            Value(NumberConstant(mid, Int32))
            Value(NumberConstant(high, Int32)) // TODO: Review
            Value(BoolConstant isNegative)
            Value(NumberConstant(scale, UInt8)) ] ->
                let x = (float ((uint64 (uint32 mid)) <<< 32 ||| (uint64 (uint32 low))))
                        / System.Math.Pow(10.0, float scale)
                decimal (if isNegative then -x else x) |> makeDecConst |> Some
    | ".ctor", [IdentExpr _ as arg] ->
        // TODO: Add this warning in other constructors?
        addWarning com ctx.InlinePath r "Decimals are implemented with floats."
        Some arg
    | ("Parse" | "TryParse"), _ ->
        parse Parse2Float com ctx r t i thisArg args
    | "op_LessThan", [left; right] -> compareIf com r left right BinaryLess |> Some
    | "op_LessThanOrEqual", [left; right] -> compareIf com r left right BinaryLessOrEqual |> Some
    | "op_GreaterThan", [left; right] -> compareIf com r left right BinaryGreater |> Some
    | "op_GreaterThanOrEqual", [left; right] -> compareIf com r left right BinaryGreaterOrEqual |> Some
    | "op_UnaryNegation", [arg] ->
        applyOp com ctx r t i.CompiledName args i.SignatureArgTypes i.GenericArgs |> Some
    | "op_Explicit", [arg] ->
        match t with
        | Number Integer | Builtin(BclInt64|BclUInt64) ->
            toInt com ctx r false t args |> Some
        | Number Float ->
            toFloat com ctx r t args |> Some
        | _ -> None
    | _,_ -> None

let bigints (com: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match thisArg, i.CompiledName with
    | None, ".ctor" ->
        match i.SignatureArgTypes with
        | [Builtin(BclInt64|BclUInt64)] ->
            Helper.CoreCall("BigInt", "fromInt64", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | _ ->
            Helper.CoreCall("BigInt", "fromInt32", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | None, "op_Explicit" ->
        match t with
        | Number Integer | Builtin(BclInt64|BclUInt64) ->
            toInt com ctx r false t args |> Some
        | Number Float ->
            toFloat com ctx r t args |> Some
        | _ -> None
    | None, meth ->
        Helper.CoreCall("BigInt", Naming.lowerFirst meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | Some callee, meth ->
        Helper.CoreCall("BigInt", Naming.lowerFirst meth, t, [callee], i.SignatureArgTypes, ?loc=r) |> Some

// Compile static strings to their constant values
// reference: https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/languageprimitives.errorstrings-module-%5bfsharp%5d
let errorStrings = function
    | "InputArrayEmptyString" -> s "The input array was empty" |> Some
    | "InputSequenceEmptyString" -> s "The input sequence was empty" |> Some
    | "InputMustBeNonNegativeString" -> s "The input must be non-negative" |> Some
    | _ -> None

let languagePrimitives (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, args with
    | "GenericZero", _ -> getZero com ctx t |> Some
    | "GenericOne", _ -> getOne com ctx t |> Some
    | "EnumOfValue", [arg] ->
        match t with
        | EnumType(_, fullName) -> Enum(NumberEnum arg, fullName) |> Value |> Some
        | _ -> None
    | "EnumToValue", [arg] ->
        match arg with
        | Value(Enum(NumberEnum(v), _)) -> v |> Some
        | _ -> None
    | ("GenericHash" | "GenericHashIntrinsic"), [arg] ->
        structuralHash r arg |> Some
    | ("GenericHashWithComparer" | "GenericHashWithComparerIntrinsic"), [comp; arg] ->
        Helper.InstanceCall(comp, "GetHashCode", t, [arg], i.SignatureArgTypes, ?loc=r) |> Some
    | ("GenericComparison" | "GenericComparisonIntrinsic"), [left; right] ->
        compare com r left right |> Some
    | ("GenericComparisonWithComparer" | "GenericComparisonWithComparerIntrinsic"), [comp; left; right] ->
        Helper.InstanceCall(comp, "Compare", t, [left; right], i.SignatureArgTypes, ?loc=r) |> Some
    | ("GenericLessThan" | "GenericLessThanIntrinsic"), [left; right] ->
        compareIf com r left right BinaryLess |> Some
    | ("GenericLessOrEqual" | "GenericLessOrEqualIntrinsic"), [left; right] ->
        compareIf com r left right BinaryLessOrEqual |> Some
    | ("GenericGreaterThan" | "GenericGreaterThanIntrinsic"), [left; right] ->
        compareIf com r left right BinaryGreater |> Some
    | ("GenericGreaterOrEqual" | "GenericGreaterOrEqualIntrinsic"), [left; right] ->
        compareIf com r left right BinaryGreaterOrEqual |> Some
    | ("GenericEquality" | "GenericEqualityIntrinsic"), [left; right] ->
        equals com r true left right |> Some
    | ("GenericEqualityER" | "GenericEqualityERIntrinsic"), [left; right] ->
        // TODO: In ER mode, equality on two NaNs returns "true".
        equals com r true left right |> Some
    | ("GenericEqualityWithComparer" | "GenericEqualityWithComparerIntrinsic"), [comp; left; right] ->
        Helper.InstanceCall(comp, "Equals", t, [left; right], i.SignatureArgTypes, ?loc=r) |> Some
    | ("PhysicalEquality" | "PhysicalEqualityIntrinsic"), [left; right] ->
        makeEqOp r left right BinaryEqualStrict |> Some
    | ("PhysicalHash" | "PhysicalHashIntrinsic"), [arg] ->
        identityHash r arg |> Some
    | ("GenericEqualityComparer"
    |  "GenericEqualityERComparer"
    |  "FastGenericComparer"
    |  "FastGenericComparerFromTable"
    |  "FastGenericEqualityComparer"
    |  "FastGenericEqualityComparerFromTable"
        ), _ -> fsharpModule com ctx r t i thisArg args
    | ("ParseInt32" | "ParseUInt32" | "ParseInt64" | "ParseUInt64"), [arg] ->
        toInt com ctx r false t [arg] |> Some
    | _ -> None

let intrinsicFunctions (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    // Erased operators
    | "CheckThis", _, [arg]
    | "UnboxFast", _, [arg]
    | "UnboxGeneric", _, [arg] -> Some arg
    | "MakeDecimal", _, _ -> decimals com ctx r t i thisArg args
    | "GetString", _, [ar; idx]
    | "GetArray", _, [ar; idx] -> getExpr r t ar idx |> Some
    | "SetArray", _, [ar; idx; value] -> Set(ar, ExprSet idx, value, r) |> Some
    | ("GetArraySlice" | "GetStringSlice"), None, [ar; lower; upper] ->
        let upper =
            match upper with
            | Value(NewOption(None,_)) -> getExpr None (Number Int32) ar (makeStrConst "length")
            | _ -> add upper (makeIntConst 1)
        Helper.InstanceCall(ar, "slice", t, [lower; upper], ?loc=r) |> Some
    | "SetArraySlice", None, args ->
        Helper.CoreCall("Array", "setSlice", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "TypeTestGeneric", None, [expr] ->
        Test(expr, TypeTest((genArg com ctx r 0 i.GenericArgs)), r) |> Some
    | "CreateInstance", None, _ ->
        match genArg com ctx r 0 i.GenericArgs with
        | DeclaredType(ent, _) ->
            let entRef = FSharp2Fable.Util.entityRefMaybeImported com ent
            Helper.ConstructorCall(entRef, t, [], ?loc=r) |> Some
        | t -> sprintf "Cannot create instance of type unresolved at compile time: %A" t
               |> addErrorAndReturnNull com ctx.InlinePath r |> Some
    // reference: https://msdn.microsoft.com/visualfsharpdocs/conceptual/operatorintrinsics.powdouble-function-%5bfsharp%5d
    // Type: PowDouble : float -> int -> float
    // Usage: PowDouble x n
    | "PowDouble", None, _ ->
        Helper.GlobalCall("Math", t, args, i.SignatureArgTypes, memb="pow", ?loc=r) |> Some
    // reference: https://msdn.microsoft.com/visualfsharpdocs/conceptual/operatorintrinsics.rangechar-function-%5bfsharp%5d
    // Type: RangeChar : char -> char -> seq<char>
    // Usage: RangeChar start stop
    | "RangeChar", None, _ ->
        Helper.CoreCall("Seq", "rangeChar", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // reference: https://msdn.microsoft.com/visualfsharpdocs/conceptual/operatorintrinsics.rangedouble-function-%5bfsharp%5d
    // Type: RangeDouble: float -> float -> float -> seq<float>
    // Usage: RangeDouble start step stop
    | ("RangeSByte" | "RangeByte"
    | "RangeInt16"  | "RangeUInt16"
    | "RangeInt32"  | "RangeUInt32"
    | "RangeSingle" | "RangeDouble"), None, args ->
        Helper.CoreCall("Seq", "rangeNumber", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("RangeInt64" | "RangeUInt64"), None, args ->
        let isUnsigned = makeBoolConst (i.CompiledName = "RangeUInt64")
        Helper.CoreCall("Seq", "rangeLong", t, args @ [isUnsigned] , i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let funcs (_: ICompiler) (ctx: Context) r t (i: CallInfo) thisArg args =
    match i.CompiledName, thisArg with
    | "Adapt", _ -> List.tryHead args // TODO: What's this used for?
    | "Invoke", Some callee ->
        Helper.Application(callee, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let keyValuePairs (_: ICompiler) (ctx: Context) r t (i: CallInfo) thisArg args =
    match i.CompiledName, thisArg with
    | ".ctor", _ -> Value(NewTuple args) |> Some
    | "get_Key", Some c -> Get(c, TupleGet 0, t, r) |> Some
    | "get_Value", Some c -> Get(c, TupleGet 1, t, r) |> Some
    | _ -> None

let dictionaries (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg with
    | ".ctor", _ ->
        match i.SignatureArgTypes, args with
        | ([]|[Number _]), _ ->
            makeDictionary com r t (makeArray Any []) |> Some
        | [IDictionary], [arg] ->
            makeDictionary com r t arg |> Some
        | [IDictionary; IEqualityComparer], [arg; eqComp] ->
            makeComparerFromEqualityComparer eqComp
            |> makeDictionaryWithComparer r t arg |> Some
        | [IEqualityComparer], [eqComp]
        | [Number _; IEqualityComparer], [_; eqComp] ->
            makeComparerFromEqualityComparer eqComp
            |> makeDictionaryWithComparer r t (makeArray Any []) |> Some
        | _ -> None
    | "get_IsReadOnly", _ -> makeBoolConst false |> Some
    | "get_Count", _ -> get r t thisArg.Value "size" |> Some
    | "GetEnumerator", Some callee -> getEnumerator r t callee |> Some
    | "ContainsValue", _ ->
        match thisArg, args with
        | Some c, [arg] -> Helper.CoreCall("Util", "containsValue", t, [arg; c], ?loc=r) |> Some
        | _ -> None
    | "TryGetValue", _ ->
        Helper.CoreCall("Util", "tryGetValue", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | ReplaceName ["get_Item",     "get"
                   "set_Item",     "set"
                   "get_Keys",     "keys"
                   "get_Values",   "values"
                   "ContainsKey",  "has"
                   "Clear",        "clear"
                   "Add",          "set"
                   "Remove",       "delete" ] methName, Some c ->
        Helper.InstanceCall(c, methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let hashSets (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | ".ctor", _, _ ->
        match i.SignatureArgTypes, args with
        | [], _ ->
            makeHashSet com r t (makeArray Any []) |> Some
        | [IEnumerable], [arg] ->
            makeHashSet com r t arg |> Some
        | [IEnumerable; IEqualityComparer], [arg; eqComp] ->
            makeComparerFromEqualityComparer eqComp
            |> makeHashSetWithComparer r t arg |> Some
        | [IEqualityComparer], [eqComp] ->
            makeComparerFromEqualityComparer eqComp
            |> makeHashSetWithComparer r t (makeArray Any []) |> Some
        | _ -> None
    | "get_Count", _, _ -> get r t thisArg.Value "size" |> Some
    | "get_IsReadOnly", _, _ -> BoolConstant false |> Value |> Some
    | ReplaceName ["Clear",    "clear"
                   "Contains", "has"
                   "Remove",   "delete" ] methName, Some c, args ->
        Helper.InstanceCall(c, methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "Add", Some c, [arg] ->
        Helper.CoreCall("Util", "addToSet", t, [arg; c], ?loc=r) |> Some
    | ("IsProperSubsetOf" | "IsProperSupersetOf" | "UnionWith" | "IntersectWith" |
        "ExceptWith" | "IsSubsetOf" | "IsSupersetOf" as meth), Some c, args ->
        let meth = Naming.lowerFirst meth
        let args = injectArg com ctx r "Set" meth i.GenericArgs args
        Helper.CoreCall("Set", meth, t, c::args, ?loc=r) |> Some
    // | "CopyTo" // TODO!!!
    // | "SetEquals"
    // | "Overlaps"
    // | "SymmetricExceptWith"
    | _ -> None

let exceptions (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg with
    | ".ctor", _ -> Helper.ConstructorCall(makeIdentExprNonMangled "Error", t, args, ?loc=r) |> Some
    | "get_Message", Some e -> get r t e "message" |> Some
    | "get_StackTrace", Some e -> get r t e "stack" |> Some
    | _ -> None

let objects (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | ".ctor", _, _ -> objExpr t [] |> Some
    | "GetHashCode", Some arg, _ ->
        identityHash r arg |> Some
    | "ToString", Some arg, _ ->
        toString com ctx r [arg] |> Some
    | "ReferenceEquals", _, [left; right] ->
        makeEqOp r left right BinaryEqualStrict |> Some
    | "Equals", Some arg1, [arg2]
    | "Equals", None, [arg1; arg2] ->
        Helper.CoreCall("Util", "equals", t, [arg1; arg2], ?loc=r) |> Some
    | "GetType", Some arg, _ ->
        if arg.Type = Any then
            "Types can only be resolved at compile time. At runtime this will be same as `typeof<obj>`"
            |> addWarning com ctx.InlinePath r
        makeTypeInfo r arg.Type |> Some
    | _ -> None

let valueTypes (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg with
    | ".ctor", _ -> objExpr t [] |> Some
    | "ToString", Some thisArg ->
        Helper.InstanceCall(thisArg, "toString", String, [], i.SignatureArgTypes, ?loc=r) |> Some
    | ("GetHashCode" | "Equals" | "CompareTo"), Some thisArg ->
        Helper.InstanceCall(thisArg, i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let unchecked (com: ICompiler) (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "DefaultOf" -> (genArg com ctx r 0 i.GenericArgs) |> defaultof |> Some
    | "Hash" -> structuralHash r args.Head |> Some
    | "Equals" -> Helper.CoreCall("Util", "equals", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "Compare" -> Helper.CoreCall("Util", "compare", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let enums (_: ICompiler) (ctx: Context) r _ (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match thisArg, i.CompiledName, args with
    | Some this, "HasFlag", [arg] ->
        // x.HasFlags(y) => (int x) &&& (int y) <> 0
        makeBinOp r (Number Int32) this arg BinaryAndBitwise
        |> fun bitwise -> makeEqOp r bitwise (makeIntConst 0) BinaryUnequal
        |> Some
    | _ -> None

let log (_: ICompiler) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    let args =
        match args with
        | [] -> []
        | [v] -> [v]
        | (Value (StringConstant _))::_ -> [Helper.CoreCall("String", "format", t, args, i.SignatureArgTypes)]
        | _ -> [args.Head]
    Helper.GlobalCall("console", t, args, memb="log", ?loc=r)

let bitConvert (_: ICompiler) (ctx: Context) r (_: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    let memberName =
        if i.CompiledName = "GetBytes" then
            match args.Head.Type with
            | Boolean -> "getBytesBoolean"
            | Char | String -> "getBytesChar"
            | Number Int16 -> "getBytesInt16"
            | Number Int32 -> "getBytesInt32"
            | Builtin BclInt64 -> "getBytesInt64"
            | Number UInt16 -> "getBytesUInt16"
            | Builtin BclUInt64 -> "getBytesUInt64"
            | Number UInt32 -> "getBytesUInt32"
            | Number Float32 -> "getBytesSingle"
            | Number Float64 -> "getBytesDouble"
            | x -> failwithf "Unsupported type in BitConverter.GetBytes(): %A" x
        else Naming.lowerFirst i.CompiledName
    Helper.CoreCall("BitConverter", memberName, Boolean, args, i.SignatureArgTypes, ?loc=r) |> Some

let convert (com: ICompiler) (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "ToSByte" | "ToByte"
    | "ToInt16" | "ToUInt16"
    | "ToInt32" | "ToUInt32"
    | "ToInt64" | "ToUInt64"
        -> toInt com ctx r true t args |> Some
    | "ToSingle" | "ToDouble" | "ToDecimal"
        -> toFloat com ctx r t args |> Some
    | "ToChar" -> toChar args.Head |> Some
    | "ToString" -> toString com ctx r args |> Some
    | "ToBase64String" | "FromBase64String" ->
        if not(List.isSingle args) then
            sprintf "Convert.%s only accepts one single argument" (Naming.upperFirst i.CompiledName)
            |> addWarning com ctx.InlinePath r
        Helper.CoreCall("String", (Naming.lowerFirst i.CompiledName), t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let console (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "get_Out" -> objExpr t [] |> Some // empty object
    | "Write" ->
        addWarning com ctx.InlinePath r "Write will behave as WriteLine"
        log com r t i thisArg args |> Some
    | "WriteLine" -> log com r t i thisArg args |> Some
    | _ -> None

let debug (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "Write" ->
        addWarning com ctx.InlinePath r "Write will behave as WriteLine"
        log com r t i thisArg args |> Some
    | "WriteLine" -> log com r t i thisArg args |> Some
    | "Break" -> Debugger |> Some
    | "Assert" ->
        // emit i "if (!$0) { debugger; }" i.args |> Some
        let cond = Operation(UnaryOperation (UnaryNot, args.Head), Boolean, r)
        IfThenElse(cond, Debugger, Value (Null Unit)) |> Some
    | _ -> None

let dates (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let getTime (e: Expr) =
        Helper.InstanceCall(e, "getTime", t, [])
    let moduleName =
        if i.DeclaringEntityFullName = Types.datetime
        then "Date" else "DateOffset"
    match i.CompiledName with
    | ".ctor" ->
        match args with
        | [] -> Helper.CoreCall(moduleName, "minValue", t, [], [], ?loc=r) |> Some
        | ExprType(Builtin BclInt64)::_ ->
            Helper.CoreCall(moduleName, "fromTicks", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | ExprType(DeclaredType(e,[]))::_ when e.FullName = Types.datetime ->
            Helper.CoreCall("DateOffset", "fromDate", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | _ ->
            let last = List.last args
            match args.Length, last.Type with
            | 7, EnumType(_, "System.DateTimeKind") ->
                let args = (List.take 6 args) @ [makeIntConst 0; last]
                let argTypes = (List.take 6 i.SignatureArgTypes) @ [Number Int32; last.Type]
                Helper.CoreCall("Date", "create", t, args, argTypes, ?loc=r) |> Some
            | _ ->
                Helper.CoreCall(moduleName, "create", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "ToString" ->
        Helper.CoreCall("Date", "toString", t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some
    | "get_Kind" | "get_Offset" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    // DateTimeOffset
    | "get_DateTime" | "get_LocalDateTime" | "get_UtcDateTime" as m ->
        let kind =
            if m = "get_LocalDateTime" then System.DateTimeKind.Local
            elif m = "get_UtcDateTime" then System.DateTimeKind.Utc
            else System.DateTimeKind.Unspecified
            |> int |> makeIntConst
        Helper.CoreCall("Date", "fromDateTimeOffset", t, [thisArg.Value; kind], [thisArg.Value.Type; kind.Type], ?loc=r) |> Some
    | "FromUnixTimeSeconds"
    | "FromUnixTimeMilliseconds" ->
        let value = Helper.CoreCall("Long", "toNumber", Number Float64, args, i.SignatureArgTypes)
        let value =
            if i.CompiledName = "FromUnixTimeSeconds"
            then makeBinOp r t value (makeIntConst 1000) BinaryMultiply
            else value
        Helper.CoreCall("DateOffset", "default", t, [value; makeIntConst 0], [value.Type; Number Int32], ?loc=r) |> Some
    | "ToUnixTimeSeconds"
    | "ToUnixTimeMilliseconds" ->
        let ms = getTime thisArg.Value
        let args =
            if i.CompiledName = "ToUnixTimeSeconds"
            then [makeBinOp r t ms (makeIntConst 1000) BinaryDivide]
            else [ms]
        Helper.CoreCall("Long", "fromNumber", t, args, ?loc=r) |> Some
    | "get_Ticks" ->
        Helper.CoreCall("Date", "getTicks", t, [thisArg.Value], [thisArg.Value.Type], ?loc=r) |> Some
    | "get_UtcTicks" ->
        Helper.CoreCall("DateOffset", "getUtcTicks", t, [thisArg.Value], [thisArg.Value.Type], ?loc=r) |> Some
    | "AddTicks" ->
        match thisArg, args with
        | Some c, [ticks] ->
            let ms = Helper.CoreCall("Long", "op_Division", i.SignatureArgTypes.Head, [ticks; makeIntConst 10000], [ticks.Type; Number Int32])
            let ms = Helper.CoreCall("Long", "toNumber", Number Float64, [ms], [ms.Type])
            Helper.CoreCall(moduleName, "addMilliseconds", Number Float64, [c; ms], [c.Type; ms.Type], ?loc=r) |> Some
        | _ -> None
    | meth ->
        let meth = Naming.removeGetSetPrefix meth |> Naming.lowerFirst
        Helper.CoreCall(moduleName, meth, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let timeSpans (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    // let callee = match i.callee with Some c -> c | None -> i.args.Head
    match i.CompiledName with
    | ".ctor" -> Helper.CoreCall("TimeSpan", "create", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "FromMilliseconds" -> TypeCast(args.Head, t) |> Some
    | "get_TotalMilliseconds" -> TypeCast(thisArg.Value, t) |> Some
    | meth ->
        let meth = Naming.removeGetSetPrefix meth |> Naming.lowerFirst
        Helper.CoreCall("TimeSpan", meth, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let timers (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | ".ctor", _, _ -> Helper.CoreCall("Timer", "default", t, args, i.SignatureArgTypes, isConstructor=true, ?loc=r) |> Some
    | Naming.StartsWith "get_" meth, Some x, _ -> get r t x meth |> Some
    | Naming.StartsWith "set_" meth, Some x, [value] -> Set(x, ExprSet(makeStrConst meth), value, r) |> Some
    | meth, Some x, args -> Helper.InstanceCall(x, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let systemEnv (_: ICompiler) (ctx: Context) (_: SourceLocation option) (_: Type) (i: CallInfo) (_: Expr option) (_: Expr list) =
    match i.CompiledName with
    | "get_NewLine" -> Some (makeStrConst "\n")
    | _ -> None

// Initial support, making at least InvariantCulture compile-able
// to be used System.Double.Parse and System.Single.Parse
// see https://github.com/fable-compiler/Fable/pull/1197#issuecomment-348034660
let globalization (_: ICompiler) (ctx: Context) (_: SourceLocation option) t (i: CallInfo) (_: Expr option) (_: Expr list) =
    match i.CompiledName with
    | "get_InvariantCulture" ->
        // System.Globalization namespace is not supported by Fable. The value InvariantCulture will be compiled to an empty object literal
        ObjectExpr([], t, None) |> Some
    | _ -> None

let random (_: ICompiler) (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName with
    | ".ctor" -> ObjectExpr ([], t, None) |> Some
    | "Next" ->
        let min, max =
            match args with
            | [] -> makeIntConst 0, makeIntConst System.Int32.MaxValue
            | [max] -> makeIntConst 0, max
            | [min; max] -> min, max
            | _ -> failwith "Unexpected arg count for Random.Next"
        Helper.CoreCall("Util", "randomNext", t, [min; max], [min.Type; max.Type], ?loc=r) |> Some
    | "NextDouble" ->
        Helper.GlobalCall ("Math", t, [], [], memb="random") |> Some
    | _ -> None

let cancels (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | ".ctor" -> Helper.CoreCall("Async", "createCancellationToken", t, args, i.SignatureArgTypes) |> Some
    | "get_Token" -> thisArg
    | "Cancel" | "CancelAfter" | "get_IsCancellationRequested" ->
        let args, argTypes = match thisArg with Some c -> c::args, c.Type::i.SignatureArgTypes | None -> args, i.SignatureArgTypes
        Helper.CoreCall("Async", Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst, t, args, argTypes, ?loc=r) |> Some
    // TODO: Add check so CancellationTokenSource cannot be cancelled after disposed?
    | "Dispose" -> Null Type.Unit |> Value |> Some
    | _ -> None

let monitor (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "Enter" | "Exit" -> Null Type.Unit |> Value |> Some
    | _ -> None

let activator (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    // TODO!!! This probably won't work, add test
    | "CreateInstance", None, typRef::args ->
        let info = argInfo None args (Typed i.SignatureArgTypes.Tail)
        constructorCall r t info typRef |> Some
    | _ -> None

let regex com (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    let propInt p callee = getExpr r t callee (makeIntConst p)
    let propStr p callee = getExpr r t callee (makeStrConst p)
    let isGroup =
        match thisArg with
        | Some (ExprType (EntFullName "System.Text.RegularExpressions.Group")) -> true
        | _ -> false
    match i.CompiledName with
    // TODO: Use RegexConst if no options have been passed?
    | ".ctor"   -> Helper.CoreCall("RegExp", "create", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "get_Options" -> Helper.CoreCall("RegExp", "options", t, [thisArg.Value], [thisArg.Value.Type], ?loc=r) |> Some
    // Capture
    | "get_Index" ->
        if not isGroup
        then propStr "index" thisArg.Value |> Some
        else "Accessing index of Regex groups is not supported"
             |> addErrorAndReturnNull com ctx.InlinePath r |> Some
    | "get_Value" ->
        if isGroup
        // In JS Regex group values can be undefined, ensure they're empty strings #838
        then makeLogOp r thisArg.Value (makeStrConst "") LogicalOr |> Some
        else propInt 0 thisArg.Value |> Some
    | "get_Length" ->
        if isGroup
        then propStr "length" thisArg.Value |> Some
        else propInt 0 thisArg.Value |> propStr "length" |> Some
    // Group
    | "get_Success" -> makeEqOp r thisArg.Value (Value (Null thisArg.Value.Type)) BinaryUnequal |> Some
    // Match
    | "get_Groups" -> thisArg.Value |> Some
    // MatchCollection & GroupCollection
    | "get_Item" -> getExpr r t thisArg.Value args.Head |> Some
    | "get_Count" -> propStr "length" thisArg.Value |> Some
    | meth ->
        let meth = Naming.removeGetSetPrefix meth |> Naming.lowerFirst
        Helper.CoreCall("RegExp", meth, t, args, i.SignatureArgTypes, ?thisArg=thisArg, ?loc=r) |> Some

let encoding (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args.Length with
    | ("get_Unicode" | "get_UTF8"), _, _ ->
        Helper.CoreCall("Encoding", i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | ("GetBytes" | "GetString"), Some callee, (1 | 3) ->
        let meth = Naming.lowerFirst i.CompiledName
        Helper.InstanceCall(callee, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let enumerables (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (_: Expr list) =
    match thisArg, i.CompiledName with
    // This property only belongs to Key and Value Collections
    | Some callee, "get_Count" -> Helper.CoreCall("Seq", "length", t, [callee], ?loc=r) |> Some
    | Some callee, "GetEnumerator" -> getEnumerator r t callee |> Some
    | _ -> None

let enumerators (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg with
    | "get_Current", Some x -> get r t x "Current" |> Some
    | meth, Some x -> Helper.InstanceCall(x, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | _ -> None

let events (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg with
    | ".ctor", _ -> Helper.CoreCall("Event", "default", t, args, i.SignatureArgTypes, isConstructor=true, ?loc=r) |> Some
    | "get_Publish", Some x -> get r t x "Publish" |> Some
    | meth, Some x -> Helper.InstanceCall(x, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | meth, None -> Helper.CoreCall("Event", Naming.lowerFirst meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let observable (_: ICompiler) (ctx: Context) r (t: Type) (i: CallInfo) (_: Expr option) (args: Expr list) =
    Helper.CoreCall("Observable", Naming.lowerFirst i.CompiledName, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let mailbox (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match thisArg with
    | None ->
        match i.CompiledName with
        | ".ctor" -> Helper.CoreCall("MailboxProcessor", "default", t, args, i.SignatureArgTypes, isConstructor=true, ?loc=r) |> Some
        | "Start" -> Helper.CoreCall("MailboxProcessor", "start", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | _ -> None
    | Some callee ->
        match i.CompiledName with
        // `reply` belongs to AsyncReplyChannel
        | "Start" | "Receive" | "PostAndAsyncReply" | "Post" ->
            let memb =
                if i.CompiledName = "Start"
                then "startInstance"
                else Naming.lowerFirst i.CompiledName
            Helper.CoreCall("MailboxProcessor", memb, t, args, i.SignatureArgTypes, thisArg=callee, ?loc=r) |> Some
        | "Reply" -> Helper.InstanceCall(callee, "reply", t, args, i.SignatureArgTypes, ?loc=r) |> Some
        | _ -> None

let asyncBuilder (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match thisArg, i.CompiledName, args with
    | _, "Singleton", _ -> makeCoreRef t "singleton" "AsyncBuilder" |> Some
    // For Using we need to cast the argument to IDisposable
    | Some x, "Using", [arg; f] ->
        Helper.InstanceCall(x, "Using", t, [arg; f], i.SignatureArgTypes, ?loc=r) |> Some
    | Some x, meth, _ -> Helper.InstanceCall(x, meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | None, meth, _ -> Helper.CoreCall("AsyncBuilder", Naming.lowerFirst meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let asyncs com (ctx: Context) r t (i: CallInfo) (_: Expr option) (args: Expr list) =
    match i.CompiledName with
    // TODO: Throw error for RunSynchronously
    | "Start" ->
        "Async.Start will behave as StartImmediate" |> addWarning com ctx.InlinePath r
        Helper.CoreCall("Async", "start", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // Make sure cancellationToken is called as a function and not a getter
    | "get_CancellationToken" -> Helper.CoreCall("Async", "cancellationToken", t, [], ?loc=r) |> Some
    // `catch` cannot be used as a function name in JS
    | "Catch" -> Helper.CoreCall("Async", "catchAsync", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // Fable.Core extensions
    | meth -> Helper.CoreCall("Async", Naming.lowerFirst meth, t, args, i.SignatureArgTypes, ?loc=r) |> Some

let guids (_: ICompiler) (ctx: Context) (_: SourceLocation option) t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "NewGuid"     -> Helper.CoreCall("String", "newGuid", t, []) |> Some
    | "Parse"       -> Helper.CoreCall("String", "validateGuid", t, args, i.SignatureArgTypes) |> Some
    | "TryParse"    -> Helper.CoreCall("String", "validateGuid", t, [args.Head; makeBoolConst true], [args.Head.Type; Boolean]) |> Some
    | "ToByteArray" -> Helper.CoreCall("String", "guidToArray", t, [thisArg.Value], [thisArg.Value.Type]) |> Some
    | ".ctor" ->
        match args with
        | [] -> makeStrConst "00000000-0000-0000-0000-000000000000" |> Some
        | [ExprType (Array _)] -> Helper.CoreCall("String", "arrayToGuid", t, args, i.SignatureArgTypes) |> Some
        | [ExprType String]    -> Helper.CoreCall("String", "validateGuid", t, args, i.SignatureArgTypes) |> Some
        | _ -> None
    | _ -> None

let uris (_: ICompiler) (ctx: Context) (r: SourceLocation option) t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | ".ctor" -> Helper.CoreCall("Uri", "default", t, args, i.SignatureArgTypes, isConstructor=true, ?loc=r) |> Some
    | "UnescapeDataString" -> Helper.CoreCall("Util", "unescapeDataString", t, args, i.SignatureArgTypes) |> Some
    | "EscapeDataString"   -> Helper.CoreCall("Util", "escapeDataString", t, args, i.SignatureArgTypes) |> Some
    | "EscapeUriString"    -> Helper.CoreCall("Util", "escapeUriString", t, args, i.SignatureArgTypes) |> Some
    | "get_IsAbsoluteUri" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_Scheme" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_Host" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_AbsolutePath" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_PathAndQuery" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_Query" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | "get_Fragment" ->
        Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst |> get r t thisArg.Value |> Some
    | _ -> None

let laziness (_: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName, thisArg, args with
    | (".ctor"|"Create"),_,_ -> Helper.CoreCall("Util", "Lazy", t, args, i.SignatureArgTypes, isConstructor=true, ?loc=r) |> Some
    | "CreateFromValue",_,_ -> Helper.CoreCall("Util", "lazyFromValue", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "Force", Some callee, _ -> get r t callee "Value" |> Some
    | ("get_Value"|"get_IsValueCreated"), Some callee, _ ->
        Naming.removeGetSetPrefix i.CompiledName |> get r t callee |> Some
    | _ -> None

let controlExtensions (_: ICompiler) (ctx: Context) (_: SourceLocation option) t (i: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match i.CompiledName with
    | "AddToObservable" -> Some "add"
    | "SubscribeToObservable" -> Some "subscribe"
    | _ -> None
    |> Option.map (fun meth ->
        let args, argTypes =
            thisArg
            |> Option.map (fun thisArg -> thisArg::args, thisArg.Type::i.SignatureArgTypes)
            |> Option.defaultValue (args, i.SignatureArgTypes)
            |> fun (args, argTypes) -> List.rev args, List.rev argTypes
        Helper.CoreCall("Observable", meth, t, args, argTypes))

let types (com: ICompiler) (ctx: Context) r t (i: CallInfo) (thisArg: Expr option) (_args: Expr list) =
    let returnString x = StringConstant x |> Value |> Some
    match thisArg with
    | Some(Value(TypeInfo(exprType, exprRange)) as thisArg) ->
        match exprType with
        | GenericParam _ -> genericTypeInfoError com ctx.InlinePath exprRange
        | _ -> ()
        match i.CompiledName with
        | "get_FullName" -> getTypeFullName false exprType |> returnString
        | "get_Namespace" ->
            let fullname = getTypeFullName false exprType
            match fullname.LastIndexOf(".") with
            | -1 -> "" |> returnString
            | i -> fullname.Substring(0, i) |> returnString
        | "get_IsArray" ->
            match exprType with Array _ -> true | _ -> false
            |> BoolConstant |> Value |> Some
        | "GetElementType" ->
            match exprType with
            | Array t -> TypeInfo(t, r) |> Value |> Some
            | _ -> Null t |> Value |> Some
        | "get_IsGenericType" ->
            List.isEmpty exprType.Generics |> not |> BoolConstant |> Value |> Some
        | "get_GenericTypeArguments" | "GetGenericArguments" ->
            let arVals = exprType.Generics |> List.map (makeTypeInfo r) |> ArrayValues
            NewArray(arVals, Any) |> Value |> Some
        | "GetTypeInfo" -> Some thisArg
        | "GetGenericTypeDefinition" ->
            let newGen = exprType.Generics |> List.map (fun _ -> Any)
            TypeInfo(exprType.ReplaceGenerics(newGen), exprRange) |> Value |> Some
        | _ -> None
    | Some thisArg ->
        match i.CompiledName with
        | "get_GenericTypeArguments" | "GetGenericArguments" ->
            Helper.CoreCall("Reflection", "getGenerics", t, [thisArg], ?loc=r) |> Some
        | "get_FullName" | "get_Namespace" | "get_IsArray" | "GetElementType"
        | "get_IsGenericType" | "GetGenericTypeDefinition" ->
            let meth = Naming.removeGetSetPrefix i.CompiledName |> Naming.lowerFirst
            Helper.CoreCall("Reflection", meth, t, [thisArg], ?loc=r) |> Some
        | "GetTypeInfo" -> Some thisArg
        | _ -> None
    | None -> None

let fsharpType methName (r: SourceLocation option) t (i: CallInfo) (args: Expr list) =
    match methName with
    | "MakeTupleType" ->
        Helper.CoreCall("Reflection", "tuple", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    // Prevent name clash with FSharpValue.GetRecordFields
    | "GetRecordFields" ->
        Helper.CoreCall("Reflection", "getRecordElements", t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "GetUnionCases" | "GetTupleElements" | "GetFunctionElements"
    | "IsUnion" | "IsRecord" | "IsTuple" | "IsFunction" ->
        Helper.CoreCall("Reflection", Naming.lowerFirst methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "IsExceptionRepresentation" | "GetExceptionFields" -> None // TODO!!!
    | _ -> None

let fsharpValue methName (r: SourceLocation option) t (i: CallInfo) (args: Expr list) =
    match methName with
    | "GetUnionFields" | "GetRecordFields" | "GetRecordField" | "GetTupleFields" | "GetTupleField"
    | "MakeUnion" | "MakeRecord" | "MakeTuple" ->
        Helper.CoreCall("Reflection", Naming.lowerFirst methName, t, args, i.SignatureArgTypes, ?loc=r) |> Some
    | "GetExceptionFields" -> None // TODO!!!
    | _ -> None

let curryExprAtRuntime arity (expr: Expr) =
    Helper.CoreCall("Util", "curry", expr.Type, [makeIntConst arity; expr])

let uncurryExprAtRuntime arity (expr: Expr) =
    Helper.CoreCall("Util", "uncurry", expr.Type, [makeIntConst arity; expr])

let partialApplyAtRuntime t arity (fn: Expr) (args: Expr list) =
    let args = NewArray(ArrayValues args, Any) |> Value
    Helper.CoreCall("Util", "partialApply", t, [makeIntConst arity; fn; args])

let tryField returnTyp ownerTyp fieldName =
    match ownerTyp, fieldName with
    | Number Decimal, "Zero" -> makeDecConst 0M |> Some
    | Number Decimal, "One" -> makeDecConst 1M |> Some
    | String, "Empty" -> makeStrConst "" |> Some
    | Builtin BclGuid, "Empty" -> makeStrConst "00000000-0000-0000-0000-000000000000" |> Some
    | Builtin BclTimeSpan, "Zero" -> makeIntConst 0 |> Some
    | Builtin BclDateTime, ("MaxValue" | "MinValue") ->
        Helper.CoreCall(coreModFor BclDateTime, Naming.lowerFirst fieldName, returnTyp, []) |> Some
    | Builtin BclDateTimeOffset, ("MaxValue" | "MinValue") ->
        Helper.CoreCall(coreModFor BclDateTimeOffset, Naming.lowerFirst fieldName, returnTyp, []) |> Some
    | _ -> None

let private replacedModules =
  dict [
    "System.Math", operators
    "Microsoft.FSharp.Core.Operators", operators
    "Microsoft.FSharp.Core.Operators.Checked", operators
    "Microsoft.FSharp.Core.Operators.Unchecked", unchecked
    "Microsoft.FSharp.Core.Operators.OperatorIntrinsics", intrinsicFunctions
    "Microsoft.FSharp.Core.ExtraTopLevelOperators", operators
    "Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicFunctions", intrinsicFunctions
    "Microsoft.FSharp.Core.LanguagePrimitives", languagePrimitives
    "Microsoft.FSharp.Core.LanguagePrimitives.HashCompare", languagePrimitives
    "Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicOperators", operators
    Types.char, chars
    Types.string, strings
    "Microsoft.FSharp.Core.StringModule", stringModule
    "System.Text.StringBuilder", bclType
    Types.array, arrays
    Types.list, lists
    "Microsoft.FSharp.Collections.ArrayModule", arrayModule
    "Microsoft.FSharp.Collections.ListModule", listModule
    "Microsoft.FSharp.Collections.HashIdentity", fsharpModule
    "Microsoft.FSharp.Collections.ComparisonIdentity", fsharpModule
    "Microsoft.FSharp.Core.CompilerServices.RuntimeHelpers", seqs
    "Microsoft.FSharp.Collections.SeqModule", seqs
    "System.Collections.Generic.KeyValuePair`2", keyValuePairs
    Types.dictionary, dictionaries
    Types.idictionary, dictionaries
    Types.ienumerableGeneric, enumerables
    Types.ienumerable, enumerables
    "System.Collections.Generic.Dictionary`2.ValueCollection", enumerables
    "System.Collections.Generic.Dictionary`2.KeyCollection", enumerables
    "System.Collections.Generic.Dictionary`2.Enumerator", enumerators
    "System.Collections.Generic.Dictionary`2.ValueCollection.Enumerator", enumerators
    "System.Collections.Generic.Dictionary`2.KeyCollection.Enumerator", enumerators
    "System.Collections.Generic.List`1.Enumerator", enumerators
    "System.Collections.Generic.List`1", resizeArrays
    "System.Collections.Generic.IList`1", resizeArrays
    "System.Collections.Generic.ICollection`1", resizeArrays
    Types.hashset, hashSets
    Types.iset, hashSets
    Types.option, options
    "Microsoft.FSharp.Core.OptionModule", optionModule
    "Microsoft.FSharp.Core.ResultModule", results
    Types.bigint, bigints
    "Microsoft.FSharp.Core.NumericLiterals.NumericLiteralI", bigints
    Types.reference, references
    Types.object, objects
    Types.valueType, valueTypes
    "System.Enum", enums
    "System.BitConverter", bitConvert
    Types.int32, parse Parse2Int
    Types.int64, parse Parse2Int64
    Types.float32, parse Parse2Float
    Types.float64, parse Parse2Float
    Types.decimal, decimals
    "System.Convert", convert
    "System.Console", console
    "System.Diagnostics.Debug", debug
    "System.Diagnostics.Debugger", debug
    Types.datetime, dates
    Types.datetimeOffset, dates
    Types.timespan, timeSpans
    "System.Timers.Timer", timers
    "System.Environment", systemEnv
    "System.Globalization.CultureInfo", globalization
    "System.Random", random
    "System.Threading.CancellationToken", cancels
    "System.Threading.CancellationTokenSource", cancels
    "System.Threading.Monitor", monitor
    "System.Activator", activator
    "System.Text.Encoding", encoding
    "System.Text.UnicodeEncoding", encoding
    "System.Text.UTF8Encoding", encoding
    "System.Text.RegularExpressions.Capture", regex
    "System.Text.RegularExpressions.Match", regex
    "System.Text.RegularExpressions.Group", regex
    "System.Text.RegularExpressions.MatchCollection", regex
    "System.Text.RegularExpressions.GroupCollection", regex
    Types.regex, regex
    Types.fsharpSet, sets
    "Microsoft.FSharp.Collections.SetModule", setModule
    Types.fsharpMap, maps
    "Microsoft.FSharp.Collections.MapModule", mapModule
    "Microsoft.FSharp.Control.FSharpMailboxProcessor`1", mailbox
    "Microsoft.FSharp.Control.FSharpAsyncReplyChannel`1", mailbox
    "Microsoft.FSharp.Control.FSharpAsyncBuilder", asyncBuilder
    "Microsoft.FSharp.Control.AsyncActivation`1", asyncBuilder
    "Microsoft.FSharp.Control.FSharpAsync", asyncs
    "Microsoft.FSharp.Control.AsyncPrimitives", asyncs
    Types.guid, guids
    "System.Uri", uris
    "System.Lazy`1", laziness
    "Microsoft.FSharp.Control.Lazy", laziness
    "Microsoft.FSharp.Control.LazyExtensions", laziness
    "Microsoft.FSharp.Control.CommonExtensions", controlExtensions
    "Microsoft.FSharp.Control.FSharpEvent`1", events
    "Microsoft.FSharp.Control.EventModule", events
    "Microsoft.FSharp.Control.ObservableModule", observable
    Types.type_, types
    "System.Reflection.TypeInfo", types
]

let tryCall (com: ICompiler) (ctx: Context) r t (info: CallInfo) (thisArg: Expr option) (args: Expr list) =
    match info.DeclaringEntityFullName with
    | Patterns.DicContains replacedModules replacement -> replacement com ctx r t info thisArg args
    | "Microsoft.FSharp.Core.LanguagePrimitives.ErrorStrings" -> errorStrings info.CompiledName
    | Types.printfModule
    | Naming.StartsWith Types.printfFormat _ -> fsFormat com ctx r t info thisArg args
    | Naming.StartsWith "Fable.Core." _ -> fableCoreLib com ctx r t info thisArg args
    | Naming.StartsWith "Fable.Repl.Lib." _ -> fableReplLib com ctx r t info thisArg args
    | Naming.EndsWith "Exception" _ -> exceptions com ctx r t info thisArg args
    | "System.Timers.ElapsedEventArgs" -> thisArg // only signalTime is available here
    | Naming.StartsWith "System.Action" _
    | Naming.StartsWith "System.Func" _
    | Naming.StartsWith "Microsoft.FSharp.Core.FSharpFunc" _
    | Naming.StartsWith "Microsoft.FSharp.Core.OptimizedClosures.FSharpFunc" _ -> funcs com ctx r t info thisArg args
    | "Microsoft.FSharp.Reflection.FSharpType" -> fsharpType info.CompiledName r t info args
    | "Microsoft.FSharp.Reflection.FSharpValue" -> fsharpValue info.CompiledName r t info args
    | "Microsoft.FSharp.Reflection.FSharpReflectionExtensions" ->
        // In netcore F# Reflection methods become extensions
        // with names like `FSharpType.GetExceptionFields.Static`
        let isFSharpType = info.CompiledName.StartsWith("FSharpType")
        let methName = info.CompiledName |> Naming.extensionMethodName
        if isFSharpType
        then fsharpType methName r t info args
        else fsharpValue methName r t info args
    | "Microsoft.FSharp.Reflection.UnionCaseInfo"
    | "System.Reflection.PropertyInfo"
    | "System.Reflection.MemberInfo" ->
        match thisArg, info.CompiledName with
        | Some c, "get_Tag" -> makeStrConst "tag" |> getExpr r t c |> Some
        | Some c, "get_PropertyType" -> makeIntConst 1 |> getExpr r t c |> Some
        | Some c, "GetFields" -> Helper.CoreCall("Reflection", "getUnionCaseFields", t, [c], ?loc=r) |> Some
        | Some c, "get_Name" ->
            match c with
            | Value(TypeInfo(exprType,_)) ->
                let fullname = getTypeFullName false exprType
                match fullname.LastIndexOf(".") with
                | -1 -> fullname |> StringConstant |> Value |> Some
                | i -> fullname.Substring(i + 1) |> StringConstant |> Value |> Some
            | c ->
                Helper.CoreCall("Reflection", "name", t, [c], ?loc=r) |> Some
        | _ -> None
    | _ -> None

// TODO: Add other entities (see Fable 1 Replacements.tryReplaceEntity)
let tryEntityRef (ent: FSharpEntity) =
    match ent.FullName with
    | Types.reference -> makeCoreRef Any "FSharpRef" "Types" |> Some
    | Types.matchFail -> makeCoreRef Any "MatchFailureException" "Types" |> Some
    | Types.result -> makeCoreRef Any "Result" "Option" |> Some
    | Naming.StartsWith Types.choiceNonGeneric _ -> makeCoreRef Any "Choice" "Option" |> Some
    | Naming.StartsWith "Fable.Repl.Lib." _ -> getFableReplLibImport true ent.FullName "" "" |> Some
    | _ -> None

let tryBaseConstructor com (ent: FSharpEntity) (memb: FSharpMemberOrFunctionOrValue) genArgs args =
    match ent.FullName with
    | Types.exception_ -> Some(makeCoreRef Any "Exception" "Types", args)
    | Types.attribute -> Some(makeCoreRef Any "Attribute" "Types", args)
    | Types.dictionary ->
        let args =
            match FSharp2Fable.TypeHelpers.getArgTypes com memb, args with
            | ([]|[Number _]), _ ->
                [makeArray Any []; makeComparer com (Seq.head genArgs)]
            | [IDictionary], [arg] ->
                [arg; makeComparer com (Seq.head genArgs)]
            | [IDictionary; IEqualityComparer], [arg; eqComp] ->
                [arg; makeComparerFromEqualityComparer eqComp]
            | [IEqualityComparer], [eqComp]
            | [Number _; IEqualityComparer], [_; eqComp] ->
                [makeArray Any []; makeComparerFromEqualityComparer eqComp]
            | _ -> failwith "Unexpected dictionary constructor"
        Some(makeCoreRef Any "Dictionary" "DictTypes", args)
    | Types.hashset ->
        let args =
            match FSharp2Fable.TypeHelpers.getArgTypes com memb, args with
            | [], _ ->
                [makeArray Any []; makeComparer com (Seq.head genArgs)]
            | [IEnumerable], [arg] ->
                [arg; makeComparer com (Seq.head genArgs)]
            | [IEnumerable; IEqualityComparer], [arg; eqComp] ->
                [arg; makeComparerFromEqualityComparer eqComp]
            | [IEqualityComparer], [eqComp] ->
                [makeArray Any []; makeComparerFromEqualityComparer eqComp]
            | _ -> failwith "Unexpected hashset constructor"
        Some(makeCoreRef Any "HashSet" "DictTypes", args)
    | _ -> None
