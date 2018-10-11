module Fable.Tests.Reflection

open Util.Testing

#if !OPTIMIZE_FCS

type TestType =
    | Union1 of string

type TestType2 =
    | Union2 of string

type TestType3 = class end
type TestType4 = class end
type TestType5 = class end

type GenericRecord<'A,'B> = { a: 'A; b: 'B }

(*
type PassingGenericsTest =
    [<PassGenerics>]
    static member Foo<'T>(x: int) = typeof<'T>
    [<PassGenerics>]
    static member Bar<'T,'U>() = typeof<'U>, typeof<'T>

type PassingGenericsTest2 =
    [<PassGenerics>]
    static member OnlyAccept<'T>(msg: obj) =
        let t = typeof<'T>
        t = typeof<obj> || msg.GetType() = t

type MessageBus () =
  let _create topic value = ()
  [<PassGenerics>]
  member this.create (value:'t) = "topic1: " + (typeof<'t>.Name)
  [<PassGenerics>]
  member this.create (topic, value:'t) = topic + ": " + (typeof<'t>.Name)
  [<PassGenerics>]
  member this.optionalArgs (value:'t, ?flag1: bool) =
    let flag1 = defaultArg flag1 false
    (sprintf "%b: %s" flag1 (typeof<'t>.Name)).ToLower()

let passGenericsAttributeTests = [
  testCase "PassGenericsAttribute works" <| fun () ->
    let t = PassingGenericsTest.Foo<string>(5)
    let t1, t2 = PassingGenericsTest.Bar<TestType, bool>()
    #if FABLE_COMPILER
    box t |> equal (box "string")
    box t1 |> equal (box "boolean")
    #endif
    t |> equal typeof<string>
    t1 |> equal typeof<bool>
    t2 |> equal typeof<TestType>

  testCase "Comparing types works with primitives" <| fun () ->
    PassingGenericsTest2.OnlyAccept<int>(43) |> equal true
    PassingGenericsTest2.OnlyAccept<string>("hi") |> equal true
    PassingGenericsTest2.OnlyAccept<string>(43) |> equal false

  testCase "Comparing types works with custom types" <| fun () ->
    PassingGenericsTest2.OnlyAccept<TestType>(Union1 "bye") |> equal true
    PassingGenericsTest2.OnlyAccept<TestType>(Union2 "bye") |> equal false
    PassingGenericsTest2.OnlyAccept<obj>("I'll accept anything") |> equal true

  testCase "Overloads with PassGenericsAttribute work" <| fun () ->
    let x = { name = "" }
    let bus = MessageBus()
    bus.create x |> equal "topic1: Firm"
    bus.create ("global", x) |> equal "global: Firm"

  testCase "Optional arguments with PassGenericsAttribute work" <| fun () ->
    let x = { name = "" }
    let bus = MessageBus()
    bus.optionalArgs(x) |> equal "false: firm"
    bus.optionalArgs(x, true) |> equal "true: firm"
]
*)

let genericTests = [
  testCase "typedefof works" <| fun () ->
    let tdef1 = typedefof<int list>
    let tdef2 = typedefof<string list>
    equal tdef1 tdef2

  testCase "IsGenericType works" <| fun () ->
    typeof<int list>.IsGenericType |> equal true
    typeof<TestType>.IsGenericType |> equal false
    let t1 = typeof<int list>
    let t2 = typeof<TestType>
    let t3 = typeof<string>
    t1.IsGenericType |> equal true
    t2.IsGenericType |> equal false
    t3.IsGenericType |> equal false

  testCase "GetGenericTypeDefinition works" <| fun () ->
    let tdef1 = typedefof<int list>
    let tdef2 = typeof<int list>.GetGenericTypeDefinition()
    let t = typeof<int list>
    let tdef3 = t.GetGenericTypeDefinition()
    equal tdef1 tdef2
    equal tdef1 tdef3
    tdef1 = typeof<int list> |> equal false

  testCase "Comparing generic types works" <| fun () ->
    let t1 = typeof<GenericRecord<string, TestType>>
    let t2 = typeof<GenericRecord<string, TestType>>
    let t3 = typeof<GenericRecord<string, int>>
    t1 = t2 |> equal true
    t1 = t3 |> equal false
]

let inline getName<'t> = function
    | "namespace" -> typedefof<'t>.Namespace
    | "name" -> typedefof<'t>.Name
    | _ -> typedefof<'t>.FullName

let inline getName2 (d:'t) = function
    | "namespace" -> typeof<'t>.Namespace
    | "name" -> typeof<'t>.Name
    | _ -> typeof<'t>.FullName

let getName3 (t:System.Type) = function
    | "namespace" -> t.Namespace
    | "name" -> t.Name
    | _ -> t.FullName

// Fable 2 cannot check types unknown at compile time
// let getName4 (o:obj) = function
//     | "namespace" -> o.GetType().Namespace
//     | "name" -> o.GetType().Name
//     | _ -> o.GetType().FullName

type Firm = { name: string }

let normalize (x: string) =
    #if FABLE_COMPILER
    x
    #else
    x.Replace("+",".")
    #endif

let inline fullname<'T> () = typeof<'T>.FullName |> normalize
// let inline create<'T when 'T:(new : unit -> 'T)> () = new 'T()
// let inline create2<'T> (args: obj[]) =
//     System.Activator.CreateInstance(typeof<'T>, args) :?> 'T

let typeNameTests = [
  testCase "Type Namespace" <| fun () ->
    let x = typeof<TestType>.Namespace
    #if FABLE_COMPILER
    equal "Fable.Tests.Reflection" x
    #else
    equal "Fable.Tests" x
    #endif

  testCase "Type FullName" <| fun () ->
    let x = typeof<TestType>.FullName
    x |> normalize |> equal "Fable.Tests.Reflection.TestType"

  testCase "Type Name" <| fun () ->
    let x = typeof<TestType>.Name
    equal "TestType" x

  testCase "Get fullname of generic types with inline function" <| fun () ->
    fullname<TestType3>() |> equal "Fable.Tests.Reflection.TestType3"
    fullname<TestType4>() |> equal "Fable.Tests.Reflection.TestType4"

//   testCase "Create new generic objects with inline function" <| fun () ->
//     create<TestType3>().Value |> equal "Hi"
//     create<TestType4>().Value2 |> equal "Bye"
//     // create<TestType5>() // Doesn't compile

//   testCase "Create new generic objects with System.Activator" <| fun () ->
//     (create2<TestType3> [||]).Value |> equal "Hi"
//     (create2<TestType4> [||]).Value2 |> equal "Bye"
//     (create2<TestType5> [|"Yo"|]).Value |> equal "Yo"

  testCase "Type name is accessible" <| fun () ->
    let x = { name = "" }
    getName<Firm> "name" |> equal "Firm"
    getName2 x "name" |> equal "Firm"
    getName3 typedefof<Firm> "name" |> equal "Firm"
    // getName4 x "name" |> equal "Firm"

  testCase "Type namespace is accessible" <| fun () ->
    let test (x: string) =
        x.StartsWith("Fable.Tests") |> equal true
    let x = { name = "" }
    getName<Firm> "namespace" |> test
    getName2 x "namespace" |> test
    getName3 typedefof<Firm> "namespace" |> test
    // getName4 x "namespace" |> test

  testCase "Type full name is accessible" <| fun () ->
    let test (x: string) =
        x.Replace("+", ".") |> equal "Fable.Tests.Reflection.Firm"
    let x = { name = "" }
    getName<Firm> "fullname" |> test
    getName2 x "fullname" |> test
    getName3 typedefof<Firm> "fullname" |> test
    // getName4 x "fullname" |> test
]

// FSharpType and FSharpValue reflection tests
open FSharp.Reflection

exception TestException of String: string * Int: int

let flip f b a = f a b

type TestRecord = {
    String: string
    Int: int
}

type TestUnion =
    | StringCase of String: string * string
    | IntCase of Int: int

type RecordF = { F : int -> string }

type AsyncRecord = {
  asyncProp : Async<string>
}

type MyList<'T> =
| Nil
| Cons of 'T * MyList<'T>

let inline create<'T when 'T: (new: unit->'T)> () = new 'T()

type A() = member __.Value = 5

type B() = member __.Value = 10

let reflectionTests = [
  testCase "Reflection: Array" <| fun () ->
    let arType = typeof<int[]>
    let liType = typeof<int list>
    equal true arType.IsArray
    equal false liType.IsArray
    let elType = arType.GetElementType()
    typeof<int> = elType |> equal true
    typeof<bool> = elType |> equal false
    liType.GetElementType() |> equal null

  // TODO!!!
//   testCase "FSharp.Reflection: Exception" <| fun () ->
//     let typ = typeof<TestException>
//     let ex = TestException("a", 1)
//     let exTypeFields = FSharpType.GetExceptionFields typ
//     let exValueFields = FSharpValue.GetExceptionFields(ex)

//     let expectedExFields =
//         [|
//             "String", box "a"
//             "Int", box 1
//         |]

//     let exFields =
//         exTypeFields
//         |> Array.map (fun field -> field.Name)
//         |> flip Array.zip exValueFields

//     let isExceptionRepresentation = FSharpType.IsExceptionRepresentation typ
//     let matchExFields = exFields = expectedExFields

//     let all = isExceptionRepresentation && matchExFields
//     all |> equal true

  testCase "FSharp.Reflection: Record" <| fun () ->
    let typ = typeof<TestRecord>
    let record = { String = "a"; Int = 1 }
    let recordTypeFields = FSharpType.GetRecordFields typ
    let recordValueFields = FSharpValue.GetRecordFields record

    let expectedRecordFields =
        [|
            "String", box "a"
            "Int", box 1
        |]

    let recordFields =
        recordTypeFields
        |> Array.map (fun field -> field.Name)
        |> flip Array.zip recordValueFields

    let isRecord = FSharpType.IsRecord typ
    let matchRecordFields = recordFields = expectedRecordFields
    let matchIndividualRecordFields =
        Array.zip recordTypeFields recordValueFields
        |> Array.forall (fun (info, value) ->
            FSharpValue.GetRecordField(record, info) = value
        )
    let canMakeSameRecord =
        unbox<TestRecord> (FSharpValue.MakeRecord(typ, recordValueFields)) = record

    let all = isRecord && matchRecordFields && matchIndividualRecordFields && canMakeSameRecord
    all |> equal true

  testCase "FSharp.Reflection Functions" <| fun () ->
    let recordType = typeof<RecordF>
    let fields = FSharpType.GetRecordFields recordType
    let funcProperty = Array.head fields
    let funcType = funcProperty.PropertyType
    let domain, range = FSharpType.GetFunctionElements funcType
    equal domain typeof<int>
    equal range typeof<string>
    equal true (FSharpType.IsFunction funcType)

  testCase "FSharp.Reflection: Tuple" <| fun () ->
    let typ = typeof<string * int>
    let tuple = "a", 1
    let tupleTypeFields = FSharpType.GetTupleElements typ
    let tupleValueFields = FSharpValue.GetTupleFields tuple

    let expectedTupleFields =
        [|
            typeof<string>, box "a"
            typeof<int>, box 1
        |]

    let tupleFields = Array.zip tupleTypeFields tupleValueFields

    let isTuple = FSharpType.IsTuple typ
    let matchTupleFields = tupleFields = expectedTupleFields
    let matchIndividualTupleFields =
        tupleValueFields
        |> Array.mapi (fun i value -> i, value)
        |> Array.forall (fun (i, value) ->
            FSharpValue.GetTupleField(tuple, i) = value
        )
    let canMakeSameTuple =
        unbox<string * int> (FSharpValue.MakeTuple(tupleValueFields, typ)) = tuple

    let all = isTuple && matchTupleFields && matchIndividualTupleFields && canMakeSameTuple
    all |> equal true

  testCase "FSharp.Reflection: MakeTupleType" <| fun () ->
    let t = FSharpType.MakeTupleType [|typeof<float>; typeof<string>; typeof<int[]>|]
    FSharpValue.MakeTuple([|5.; "foo"; [|2;3|]|], t)
    |> unbox<float * string * int[]>
    |> equal (5., "foo", [|2;3|])

  testCase "FSharp.Reflection: Union" <| fun () ->
    let typ = typeof<TestUnion>
    let unionCase1 = StringCase("a", "b")
    let unionCase2 = IntCase 1
    let unionTypeFields = FSharpType.GetUnionCases typ
    unionTypeFields |> Array.map (fun x -> x.Name) |> equal [| "StringCase"; "IntCase" |]
    let unionCase1Info, unionCase1ValueFields = FSharpValue.GetUnionFields(unionCase1, typ)
    let unionCase2Info, unionCase2ValueFields = FSharpValue.GetUnionFields(unionCase2, typ)
    let unionCaseInfos = [| unionCase1Info; unionCase2Info |]
    let unionCaseValueFields = [| unionCase1ValueFields; unionCase2ValueFields |]

    let expectedUnionCase1Fields = 0, "StringCase", [| typeof<string>; typeof<string> |], [| box "a"; box "b" |]
    let expectedUnionCase2Fields = 1, "IntCase", [| typeof<int> |], [| box 1 |]
    let expectedUnionFields = [| expectedUnionCase1Fields; expectedUnionCase2Fields |]

    let unionFields =
        Array.zip unionCaseInfos unionCaseValueFields
        |> Array.map (fun (info, values) ->
            let types =
                info.GetFields()
                |> Array.map (fun field -> field.PropertyType)
            info.Tag, info.Name, types, values)

    let canMakeSameUnionCases =
        unbox<TestUnion> (FSharpValue.MakeUnion(unionCase1Info, unionCase1ValueFields)) = unionCase1
        && unbox<TestUnion> (FSharpValue.MakeUnion(unionCase2Info, unionCase2ValueFields)) = unionCase2

    FSharpType.IsUnion typ |> equal true
    unionFields |> equal expectedUnionFields
    canMakeSameUnionCases |> equal true

  testCase "Type.GenericTypeArguments works" <| fun () ->
    let recordType = typeof<AsyncRecord>
    let asyncProp = FSharpType.GetRecordFields recordType |> Array.head
    asyncProp.PropertyType.GenericTypeArguments |> Array.head |> equal typeof<string>

  testCase "Recursive types work" <| fun () ->
    let cons =
        FSharpType.GetUnionCases(typeof<MyList<int>>)
        |> Array.find (fun x -> x.Name = "Cons")
    let fieldTypes = cons.GetFields()
    fieldTypes.[0].PropertyType.FullName |> equal typeof<int>.FullName
    fieldTypes.[1].PropertyType.GetGenericTypeDefinition().FullName |> equal typedefof<MyList<obj>>.FullName

  testCase "Calling constructor of generic type in inline functions works" <| fun () ->
    let a = create<A>()
    let b = create<B>()
    a.Value |> equal 5
    b.Value |> equal 10
]

#if FABLE_COMPILER
open Fable.Core

type R1 = { x: int }
type R2 = { y: int }

type Helper =
    static member Make(values: obj[], [<Inject>] ?res: ITypeResolver<'U>) =
        let t = res.Value.ResolveType()
        FSharpValue.MakeRecord(t, values) :?> 'U

type Maybe<'t> =
    | Just of 't
    | Nothing

// The !!!NAME!!! of this type fails with somethings, I don't know
type RecWithGenDU<'t> = { Other: 't; Value : Maybe<string> }
// But this one works, very weird
type GenericTestRecord<'t> = { Other: 't; Value : Maybe<string> }

// helper class to extract the name of an injected type
type Types() =
    static member getNameOf<'t> ([<Inject>] ?resolver: ITypeResolver<'t>) : string =
        let resolvedType = resolver.Value.ResolveType()
        resolvedType.Name

    static member get<'t> ([<Inject>] ?resolver: ITypeResolver<'t>) : System.Type =
        let resolvedType = resolver.Value.ResolveType()
        resolvedType

let injectTests = [
    testCase "ITypeResolver can be injected" <| fun () ->
        let x: R1 = Helper.Make [|box 5|]
        let y: R2 = Helper.Make [|box 10|]
        equal x { x = 5 }
        equal y { y = 10 }

    testCase "Recursively reading generic arguments of nested generic types works" <| fun () ->
        let typeInfo = Types.get<Maybe<Maybe<int>>>()

        // recursively reads the generic arguments
        let rec getGenericArgs (typeDef: System.Type) : string list =
            [ yield typeDef.Name
              for genericTypeArg in typeDef.GetGenericArguments() do
                yield! getGenericArgs genericTypeArg ]

        getGenericArgs typeInfo
        |> equal ["Maybe`1"; "Maybe`1"; "Int32"]

    testCase "Name can be extracted from RecWithGenDU" <| fun () ->
        let name = Types.getNameOf<Maybe<list<RecWithGenDU<string>>>>()
        equal false (name = "")

    testCase "Name can be extracted from GenericTestRecord" <| fun () ->
        let name = Types.getNameOf<Maybe<list<GenericTestRecord<string>>>>()
        equal false (name = "")
]
#else
let injectTests = []
#endif



let genericTypeNamesTests =
    testList "Naming generic types"
      [  ]



let tests =
    testList "Reflection tests" (
        // passGenericsAttributeTests
        genericTests
        @ typeNameTests
        @ reflectionTests
        @ injectTests
    )

#else // OPTIMIZE_FCS
let tests = testList "Reflection tests" []
#endif
