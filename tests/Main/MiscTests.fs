module Fable.Tests.Misc

open System
open Util.Testing
open Util2.Extensions

// We can have aliases with same name in same file #1662
module One =
    type Id = System.Guid

module Two =
    type Id = System.Guid

type Base() =
    let mutable x = 5
    member this.Mutate i = x <- x + i
    member __.Value = x

type Test(i) as myself =
    inherit Base()
    let mutable y = 12
    do myself.Mutate(i+2)
    do myself.Mutate2(i)
    member this.Mutate2 i = y <- y + i
    member __.Value2 = y
    member __.Foo() = myself.Value * 2

let log2 (a: string) (b: string) = String.Format("a = {0}, b = {1}", a, b)
let logItem1 = log2 "item1"
let logItem2 = log2 "item2"

type PartialFunctions() =
    member __.logItem1 = log2 "item1"
    member __.logItem2 = log2 "item2"

type MaybeBuilder() =
  member __.Bind(x,f) = Option.bind f x
  member __.Return v = Some v
  member __.ReturnFrom o = o
let maybe = MaybeBuilder()

let riskyOp x y =
  if x + y < 100 then Some(x+y) else None

let execMaybe a = maybe {
  let! b = riskyOp a (a+1)
  let! c = riskyOp b (b+1)
  return c
}

[<Measure>] type km           // Define the measure units
[<Measure>] type mi           // as simple types decorated
[<Measure>] type h            // with Measure attribute

// Can be used in a generic way
type Vector3D<[<Measure>] 'u> =
    { x: float<'u>; y: float<'u>; z: float<'u> }
    static member (+) (v1: Vector3D<'u>, v2: Vector3D<'u>) =
        { x = v1.x + v2.x; y = v1.y + v2.y; z = v1.z + v2.z }

type PointWithCounter(a: int, b: int) =
    // A variable i.
    let mutable i = 0
    // A let binding that uses a pattern.
    let (x, y) = (a, b)
    // A private function binding.
    let privateFunction x y = x * x + 2*y
    // A static let binding.
    static let mutable count = 0
    // A do binding.
    do count <- count + 1
    member this.Prop1 = x
    member this.Prop2 = y
    member this.CreatedCount = count
    member this.FunctionValue = privateFunction x y


let inline f x y = x + y

module FooModule =
    type FooInline() =
        member __.Bar = "Bar"
        member val Value = 0uy with get, set
        member inline self.Foo = "Foo" + self.Bar
        member inline self.Foofy(i) = String.replicate i self.Bar
        member inline this.PropertyInline
            with get() = this.Value
            and set(v: uint8) = this.Value <- v

type FooModule.FooInline with
    member inline self.Bar2 = "Bar" + self.Bar
    member inline self.FoofyPlus(i) = self.Foofy(i * 2)

let counter =
    let mutable i = 0
    fun () ->
        i <- i + 1
        i

type Type = {
    a : int
    b : int
    c : int
    d : int
    e : int
}
  with
    static member New(n) = {
        a = n
        b = n * 2
        c = n * 3
        d = n * 4
        e = counter()  // <== should only be called twice
      }

    member        this.Method  (v:bool) = { this with a = this.a * if v then 2 else 3 }
    member inline this.MethodI (v:bool) = { this with a = this.a * if v then 2 else 3 }
    member        this.Method  ()       = { this with a = this.a * 10 }
    member inline this.MethodI ()       = { this with a = this.a * 10 }

let f1 x y z = x + y + z
let f2 x = x + x

let f3 () = 5

let mutable myMutableField = 0

let f4 i = myMutableField <- i
let f5 () = myMutableField <- 5
let f6 i j = myMutableField <- i * j
let f7 i () = myMutableField <- i * 3

type DisposableFoo() =
    member __.Foo() = 5
    interface IDisposable with
        member __.Dispose () = ()

type DisposableBar(v) =
    do v := 10
    interface IDisposable with
        member __.Dispose () = v := 20

let createCellDiposable cell =
  cell := 10
  { new System.IDisposable with
      member x.Dispose() = cell := 20 }

let (|NonEmpty|_|) (s: string) =
    match s.Trim() with "" -> None | s -> Some s

type IFoo =
   abstract Bar: s: string * [<ParamArray>] rest: obj[] -> string

type IFoo2 =
    abstract Value: int with get, set
    abstract Test: int -> int
    abstract MakeFoo: unit -> IFoo

type Foo(i) =
    let mutable j = 5
    member x.Value = i + j
    member x.MakeFoo2() = {
        new IFoo2 with
        member x2.Value
            with get() = x.Value * 2
            and set(i) = j <- j + i
        member x2.Test(i) = x2.Value - i
        member x2.MakeFoo() = {
            new IFoo with
            member x3.Bar(s: string, [<ParamArray>] rest: obj[]) =
                sprintf "%s: %i %i %i" s x.Value x2.Value j
        }
    }

type IRenderer =
  abstract member doWork: unit -> string

type MyComponent(name) as self =
  let work i = sprintf "%s-%i" name i
  let create2 () = { new IRenderer with member __.doWork () = work 2 }
  let create3 = { new IRenderer with member __.doWork () = work 3 }
  let create4 = { new IRenderer with member __.doWork () = self.Work 4 }
  let create5() = { new IRenderer with member __.doWork () = self.Work 5 }
  member __.Work i = work i
  member __.works1 () = { new IRenderer with member __.doWork () = work 1 }
  member __.works2 () = create2()
  member __.works3 () = create3
  member __.works4 () = create4
  member __.works5 () = create5()

type IFoo3 =
   abstract Bar: int with get, set

type SomeClass(name: string) =
    member x.Name = name

type AnotherClass(value: int) =
    member x.Value = value

module NestedModule =
    type AnotherClass(value: int) =
        member x.Value = value + 5

type INum = abstract member Num: int
let inline makeNum f = { new INum with member __.Num = f() }

type TestClass(n) =
    let addOne x = x + 4
    let inner = makeNum (fun () -> addOne n)
    member __.GetNum() = inner.Num

type RecursiveType(subscribe) as self =
    let foo = 3
    let getNumber() = 3
    do subscribe (getNumber >> self.Add2)
    member __.Add2(i) = self.MultiplyFoo(i) + 2
    member __.MultiplyFoo(i) = i * foo

module Extensions =
    type IDisposable with
        static member Create(f) =
            { new IDisposable with
                member __.Dispose() = f() }

    type SomeClass with
        member x.FullName = sprintf "%s Smith" x.Name
        member x.NameTimes (i: int, j: int) = String.replicate (i + j) x.Name

    type AnotherClass with
        member x.FullName = sprintf "%i" x.Value
        member x.Overload(i: int) = i * 4
        member x.Overload(s: string) = s + s
        member x.Value2 = x.Value * 2

    type NestedModule.AnotherClass with
        member x.Value2 = x.Value * 4

open Extensions


module StyleBuilderHelper =
    type StyleBuilderHelper = { TopOffset : int; BottomOffset : int }
    type DomBuilder = { ElementType : string; StyleBuilderHelper : StyleBuilderHelper }
    let test() =
        let helper = { TopOffset = 1; BottomOffset = 2 }
        let builder1 = { ElementType = "test"; StyleBuilderHelper = helper }
        let builder2 = { builder1 with StyleBuilderHelper =  { builder1.StyleBuilderHelper with BottomOffset = 3 } }
        match builder1, builder2 with
        | { StyleBuilderHelper = { BottomOffset = 2 } },
          { StyleBuilderHelper = { TopOffset = 1; BottomOffset = 3 } } -> true
        | _ -> false

module Mutable =
    let mutable prop = 10

module Same =
    let a = 5
    module Same =
        module Same =
            let a = 10
        let shouldEqual5 = a
        let shouldEqual10 = Same.a

        let private Same = 20
        let shouldEqual20 = Same
        let shouldEqual30 = let Same = 25 in Same + 5


let f8 a b = a + b
let mutable a = 10

module B =
  let c = a
  a <- a + 5
  let mutable a = 20
  let d = f8 2 2
  let f8 a b = a - b

  module D =
    let d = a
    a <- a + 5
    let e = f8 2 2

module Internal =
    let internal add x y = x + y

    type internal MyType =
        static member Subtract x y = x - y
        static member Add(?x: int, ?y: int) =
            let x = defaultArg x 20
            let y = defaultArg y 50
            x + y

type MyEnum =
    | One = 1
    | Two = 2

type TestRef = TestRef of bool ref

let delay (f:unit -> unit) = f

let mutable mutableValue = 0

let rec recursive1 = delay (fun () -> recursive2())
and recursive2 =
    mutableValue <- 5
    fun () -> mutableValue <- mutableValue * 2

let empty<'a> = [Unchecked.defaultof<'a>]

type IInterface =
  abstract member Member : thing1:string -> thing2:string -> string

type Taster =
    abstract Starter: float
    abstract Taste: quality: float * quantity: float -> int

type Eater =
    abstract Bite: unit -> int

let taste (com: Taster) qlty qty =
    com.Starter * qlty + qty |> int

module private MyPrivateModule =
    let private bar = "bar"
    let publicFoo() = sprintf "foo %s" bar
    type Concrete() =
        interface IInterface with
            member this.Member (thing1: string) (thing2: string) =
                sprintf "%s %s" thing2 thing1

module Trampoline =
    type Result<'a, 'b> =
        | Continue of 'a
        | Break of 'b
    let run func arg =
        let mutable state = arg
        let mutable result = None
        while result.IsNone do
            match func state with
            | Continue r -> state <- r
            | Break r -> result <- Some r
        result.Value

let setCellBuggy x: (int*int) option =
    Option.map (fun (x, y) -> max (x - 1) 0, y) x

let setCell x: (int*int) option =
    let max = max
    Option.map (fun (x, y) -> max (x - 1) 0, y) x

type Shape =
    | Circle of int
    | Square of int
    | Rectangle of int * int

type StaticClass =
    static member inline Add(x: int, ?y: int) =
        x + (defaultArg y 2)

let tests =
  testList "Miscellaneous" [
    testCase "Values of autogenerated functions are not replaced by optimizations" <| fun () -> // See #1583
        let model = Some (5, 5)
        let model1 = setCellBuggy model
        let model2 = setCell model
        model1 = model2 |> equal true

    testCase "Assignment block as expression is optimized" <| fun () ->
        let foo x y = x - y
        let mutable x = 15
        let res = A.C.Helper.Add5(let mutable x = 2 in let mutable y = 3 in x + y)
        let test () =
            A.C.Helper.Add5(let mutable x = 4 in let mutable y = 3 in x + y)
            |> equal 12
        test()
        equal 10 res
        foo x 5 |> equal 10

    testCase "Optimized assignment blocks inside try ... with work" <| fun () ->
        let res =
            try A.C.Helper.Add5(let mutable x = 2 in let mutable y = 3 in x + y)
            with _ -> 1
        equal 10 res

    testCase "for .. downto works" <| fun () -> // See #411
        let mutable x = ""
        for i = 1 to 5 do
            x <- x + (string i)
        equal "12345" x
        let mutable y = ""
        for i = 5 downto 1 do
            y <- y + (string i)
        equal "54321" y

    testCase "Self references in constructors work" <| fun () -> // See #124
        let t = Test(5)
        equal 12 t.Value
        equal 17 t.Value2

    testCase "Using self identifier from class definition in members works" <| fun () -> // See #124
        let t = Test(5)
        t.Foo() |> equal 24

    testCase "Module members from partial functions work" <| fun () -> // See #115
        logItem1 "item1" |> equal "a = item1, b = item1"

    testCase "Class members from partial functions work" <| fun () -> // See #115
        let x = PartialFunctions()
        x.logItem1 "item1" |> equal "a = item1, b = item1"

    testCase "Local values from partial functions work" <| fun () -> // See #115
        let logItem1 = log2 "item1"
        let logItem2 = log2 "item2"
        logItem1 "item1" |> equal "a = item1, b = item1"

    testCase "Custom computation expressions work" <| fun () ->
        execMaybe 5 |> equal (Some 23)
        execMaybe 99 |> equal None

    testCase "Units of measure work" <| fun () ->
        3<km/h> + 2<km/h> |> equal 5<km/h>

        let v1 = { x = 4.3<mi>; y = 5.<mi>; z = 2.8<mi> }
        let v2 = { x = 5.6<mi>; y = 3.8<mi>; z = 0.<mi> }
        let v3 = v1 + v2
        equal 8.8<mi> v3.y

    testCase "Units of measure work with longs" <| fun () ->
        3L<km/h> + 2L<km/h> |> equal 5L<km/h>

    testCase "Units of measure work with decimals" <| fun () ->
        3M<km/h> + 2M<km/h> |> equal 5M<km/h>

    testCase "Static constructors work" <| fun () ->
        let point1 = PointWithCounter(10, 52)
        sprintf "%d %d %d %d" (point1.Prop1) (point1.Prop2) (point1.CreatedCount) (point1.FunctionValue)
        |> equal "10 52 1 204"
        let point2 = PointWithCounter(20, 99)
        sprintf "%d %d %d %d" (point2.Prop1) (point2.Prop2) (point2.CreatedCount) (point2.FunctionValue)
        |> equal "20 99 2 598"

    testCase "File with single type in namespace compiles" <| fun () ->
        equal SingleTypeInNamespace.Hello "Hello"

    testCase "Type abbreviation in namespace compiles" <| fun () -> // See #140
        let h = Util2.H(5)
        equal "5" h.Value

    testCase "Multiple namespaces in same file work" <| fun () -> // See #1218
        A.C.Helper.Add5(9) |> equal 14

    testCase "Inline methods work" <| fun () ->
        f 2 3 |> equal 5

    testCase "Inline methods with this argument work" <| fun () -> // See #638
        let x = FooModule.FooInline()
        x.Foo |> equal "FooBar"
        x.Foofy 4 |> equal "BarBarBarBar"

    testCase "Inline properties work" <| fun () ->
        let x = FooModule.FooInline()
        x.PropertyInline <- 3uy
        x.PropertyInline |> equal 3uy

    testCase "Inline extension methods with this argument work" <| fun () -> // See #638
        let x = FooModule.FooInline()
        x.Bar2 |> equal "BarBar"
        x.FoofyPlus 3 |> equal "BarBarBarBarBarBar"

    testCase "Inline extension methods in other files can be found" <| fun () -> // See #1667
        "HOLA CARACOLA".StartsWith("hola") |> equal false
        "HOLA CARACOLA".StartsWithIgnoreCase("hola") |> equal true

    testCase "Inline overloaded methods work" <| fun () ->
      let res1 = Type.New(5).Method(false).Method(true).Method()
      let res2 = Type.New(5).MethodI(false).MethodI(true).MethodI()
      equal res1.a res2.a
      counter() |> equal 3

    testCase "Inline overloaded methods in other files work" <| fun () ->
      let res1 = MiscTestsHelper.Type.New(5).Method(false).Method(true).Method()
      let res2 = MiscTestsHelper.Type.New(5).MethodI(false).MethodI(true).MethodI()
      equal res1.a res2.a
      MiscTestsHelper.counter() |> equal 3

    testCase "Calls to core lib from a subfolder work" <| fun () ->
        Util2.Helper.Format("{0} + {0} = {1}", 2, 4)
        |> equal "2 + 2 = 4"

    testCase "Conversion to delegate works" <| fun () ->
        (System.Func<_,_,_,_> f1).Invoke(1,2,3) |> equal 6

        let f = f1
        (System.Func<_,_,_,_> f).Invoke(1,2,3) |> equal 6

        let del = System.Func<_,_,_,_>(fun x y z -> x + y + z)
        del.Invoke(1,2,3) |> equal 6

        (System.Func<_,_> f2).Invoke(2) |> equal 4

    // TODO!!!
    // testCase "Conversion to Func<_> works" <| fun () ->
    //     (System.Func<_> f3).Invoke() |> equal 5
    //     let f = Func<_>(fun () -> 6)
    //     f.Invoke() |> equal 6

    // TODO
    // testCase "Conversion to FSharpFunc<_,_,_> works" <| fun () ->
    //     let f x y = x + y
    //     let f = FSharpFunc<_,_,_>.Adapt(f)
    //     f.Invoke(1, 2) |> equal 3

    // testCase "Conversion to FSharpFunc<_,_,_,_> works" <| fun () ->
    //     let f x y z = x + y + z
    //     let f = FSharpFunc<_,_,_,_>.Adapt(f)
    //     f.Invoke(1, 2, 3) |> equal 6

    testCase "Conversion to Action<_> works" <| fun () ->
        let f1' = Action<int>(fun i -> myMutableField <- i * 2)
        let f2' = Action<int>(f4)
        let f3' = Action<_>(f6 4)
        f1'.Invoke(1)
        equal 2 myMutableField
        f2'.Invoke(8)
        equal 8 myMutableField
        f3'.Invoke(10)
        equal 40 myMutableField

    // TODO!!!
    // testCase "Conversion to Action works" <| fun () ->
    //     let f4' = Action(fun () -> myMutableField <- 7)
    //     let f5' = Action(f5)
    //     let f6' = Action(f7 3)
    //     let f7' i () = myMutableField <- i * 3
    //     let f8' = Action(f7' 3)
    //     f4'.Invoke()
    //     equal 7 myMutableField
    //     f5'.Invoke()
    //     equal 5 myMutableField
    //     f6'.Invoke()
    //     equal 9 myMutableField
    //     f8'.Invoke()
    //     equal 9 myMutableField

    testCase "Multiple active pattern calls work" <| fun () ->
        match " Hello ", " Bye " with
        | NonEmpty "Hello", NonEmpty "Bye" -> true
        | _ -> false
        |> equal true

    testCase "ParamArray in object expression works" <| fun () ->
       let o = { new IFoo with member x.Bar(s: string, [<ParamArray>] rest: obj[]) = String.Format(s, rest) }
       o.Bar("{0} + {0} = {1}", 2, 4)
       |> equal "2 + 2 = 4"

    testCase "Object expression can reference enclosing type and self" <| fun () -> // See #158
        let f = Foo(5)
        let f2 = f.MakeFoo2()
        f2.Value <- 2
        f.Value |> equal 12
        f2.Test(2) |> equal 22

    testCase "Nested object expressions work" <| fun () -> // See #158
        let f = Foo(5)
        let f2 = f.MakeFoo2()
        f2.MakeFoo().Bar("Numbers") |> equal "Numbers: 10 20 5"

    testCase "References to enclosing type from object expression work" <| fun () -> // See #438
        MyComponent("TestA").works1().doWork() |> equal "TestA-1"
        MyComponent("TestB").works2().doWork() |> equal "TestB-2"
        MyComponent("TestC").works3().doWork() |> equal "TestC-3"
        MyComponent("TestD").works4().doWork() |> equal "TestD-4"
        MyComponent("TestE").works5().doWork() |> equal "TestE-5"

    testCase "Properties in object expression work" <| fun () ->
        let mutable backend = 0
        let o = { new IFoo3 with member x.Bar with get() = backend and set(v) = backend <- v }
        o.Bar |> equal 0
        backend <- 5
        o.Bar |> equal 5
        o.Bar <- 10
        o.Bar |> equal 10

    testCase "Object expression from class works" <| fun () ->
        let o = { new SomeClass("World") with member x.ToString() = sprintf "Hello %s" x.Name }
        // TODO: Type testing for object expressions?
        // match box o with
        // | :? SomeClass as c -> c.ToString()
        // | _ -> "Unknown"
        // |> equal "Hello World"
        o.ToString() |> equal "Hello World"

    testCase "Inlined object expression doesn't change argument this context" <| fun () -> // See #1291
        let t = TestClass(42)
        t.GetNum() |> equal 46

    testCase "Object expressions don't optimize members away" <| fun () -> // See #1434
        let o =
            { new Taster with
                member __.Starter = 5.5
                member this.Taste(quality, quantity) =
                    taste this quality quantity
              interface Eater with
                member __.Bite() = 25
            }
        o.Taste(4., 6.) |> equal 28

    testCase "Composition with recursive `this` works" <| fun () ->
        let mutable x = 0
        RecursiveType(fun f -> x <- f()) |> ignore
        equal 11 x

    testCase "Type extension static methods work" <| fun () ->
        let disposed = ref false
        let disp = IDisposable.Create(fun () -> disposed := true)
        disp.Dispose ()
        equal true !disposed

    testCase "Type extension properties work" <| fun () ->
        let c = SomeClass("John")
        equal "John Smith" c.FullName

    testCase "Type extension methods work" <| fun () ->
        let c = SomeClass("John")
        c.NameTimes(1,2) |> equal "JohnJohnJohn"

    testCase "Type extension methods with same name work" <| fun () ->
        let c = AnotherClass(3)
        equal "3" c.FullName

    testCase "Type extension overloads work" <| fun () ->
        let c = AnotherClass(3)
        c.Overload("3") |> equal "33"
        c.Overload(3) |> equal 12

    testCase "Extending different types with same name and same method works" <| fun () ->
        AnotherClass(5).Value2 |> equal 10
        NestedModule.AnotherClass(5).Value2 |> equal 40

    testCase "Module, members and properties with same name don't clash" <| fun () ->
        StyleBuilderHelper.test() |> equal true

    testCase "Module mutable properties work" <| fun () ->
        equal 10 Mutable.prop
        Mutable.prop <- 5
        equal 5 Mutable.prop

    testCase "Accessing members of parent module with same name works" <| fun () ->
        equal 5 Same.Same.shouldEqual5

    testCase "Accessing members of child module with same name works" <| fun () ->
        equal 10 Same.Same.shouldEqual10

    testCase "Accessing members with same name as module works" <| fun () ->
        equal 20 Same.Same.shouldEqual20

    testCase "Naming values with same name as module works" <| fun () ->
        equal 30 Same.Same.shouldEqual30

    testCase "Can access nested recursive function with mangled name" <| fun () ->
        Util.Bar.nestedRecursive 3 |> equal 10

    testCase "Can access non nested recursive function with mangled name" <| fun () ->
        Util.nonNestedRecursive "ja" |> equal "jajaja"

    testCase "Module members don't conflict with JS names" <| fun () ->
        Util.Int32Array |> Array.sum |> equal 3

    testCase "Modules don't conflict with JS names" <| fun () ->
        Util.Float64Array.Float64Array |> Array.sum |> equal 7.

    // Modules and TestFixtures bind values in a slightly different way
    // Test both cases
    testCase "Binding doesn't shadow top-level values" <| fun () -> // See #130
        equal 10 Util.B.c
        equal 20 Util.B.D.d

    testCase "Binding doesn't shadow top-level values (TestFixture)" <| fun () -> // See #130
        equal 10 B.c
        equal 20 B.D.d

    testCase "Binding doesn't shadow top-level functions" <| fun () -> // See #130
        equal 4 Util.B.d
        equal 0 Util.B.D.e

    testCase "Binding doesn't shadow top-level functions (TestFixture)" <| fun () -> // See #130
        equal 4 B.d
        equal 0 B.D.e

    testCase "Setting a top-level value doesn't alter values at same level" <| fun () -> // See #130
        equal 15 Util.a
        equal 25 Util.B.a

    testCase "Setting a top-level value doesn't alter values at same level (TestFixture)" <| fun () -> // See #130
        equal 15 a
        equal 25 B.a

    testCase "Internal members can be accessed from other modules" <| fun () -> // See #163
        Internal.add 3 2 |> equal 5

    testCase "Internal types can be accessed from other modules" <| fun () -> // See #163
        Internal.MyType.Subtract 3 2 |> equal 1

    // In F# both branches of if-then-else has the same type,
    // but this is not always true in Fable AST. For example when
    // one branch is a Throw expression, it has always type Unit.
    // So we should test that the type of the whole expression is not determined
    // by the throw expression in one of its branches.
    //
    // The same applies to try-with expression.

    testCase "Pattern-matching against discriminated unions gives proper error message" <| fun () ->
        try
            let unitCircle = Circle 1
            match unitCircle with
            | Rectangle(n, m) -> failwith "Should not happen"
            | Square n -> failwith "Should not happen"
        with
            | ex -> ex.Message.StartsWith "The match cases were incomplete" |> equal true

    testCase "Type of if-then-else expression is correctly determined when 'then' branch throws" <| fun () ->
        let f () =
            if false then failwith "error" else 7

        f () |> equal 7

    testCase "Type of if-then-else expression is correctly determined when 'else' branch throws" <| fun () ->
        let f () =
            if true then 7 else failwith "error"

        f () |> equal 7

    testCase "Type of try-with expression is correctly determined when 'try' block throws" <| fun () ->
        let f () =
            try failwith "error" with | _ -> 7

        f () |> equal 7

    testCase "Type of try-with expression is correctly determined when exception handler throws" <| fun () ->
        let f () =
            try 7 with | _ -> failwith "error"

        f () |> equal 7

    testCase "use doesn't return on finally clause" <| fun () -> // See #211
        let foo() =
            use c = new DisposableFoo()
            c.Foo()
        foo() |> equal 5

    testCase "use calls Dispose at the end of the scope" <| fun () ->
        let cell = ref 0
        let res =
            use c = new DisposableBar(cell)
            !cell
        res |> equal 10
        !cell |> equal 20

    testCase "use calls Dispose (of an object expression) at the end of the scope" <| fun () ->
        let cell = ref 0
        let res =
            use c = createCellDiposable cell
            !cell
        res |> equal 10
        !cell |> equal 20

    testCase "Unchecked.defaultof works" <| fun () ->
        Unchecked.defaultof<int> |> equal 0
        Unchecked.defaultof<bool> |> equal false
        Unchecked.defaultof<string> |> equal null

    testCase "Pattern matching optimization works (switch statement)" <| fun () ->
        let mutable x = ""
        let i = 4
        match i with
        | 1 -> x <- "1"
        | 2 -> x <- "2"
        | 3 | 4 -> x <- "3" // Multiple cases are allowed
        // | 5 | 6 as j -> x <- string j // This prevents the optimization
        | 4 -> x <- "4" // Unreachable cases are removed
        | _ -> x <- "?"
        equal "3" x

        match "Bye" with
        | "Hi" -> x <- "Bye"
        | "Bye" -> let h = "Hi" in x <- sprintf "%s there!" h
        | _ -> x <- "?"
        equal "Hi there!" x

        // Pattern matching with Int64/UInt64 is not converted to switch
        match 2L with
        | 1L -> x <- "1L"
        | 2L -> x <- "2L"
        | _ -> x <- "?"
        equal "2L" x

        // Pattern matching with boolean is not converted to switch
        match false with
        | true -> x <- "True"
        | false -> x <- "False"
        equal "False" x

        match MyEnum.One with
        | MyEnum.One -> x <- "One"
        | MyEnum.Two -> x <- "Two"
        | _ -> failwith "never"
        equal "One" x

    testCase "Pattern matching optimization works (switch expression)" <| fun () ->
        let i = 4
        match i with
        | 1 -> "1"
        | 2 -> "2"
        | 3 | 4 -> "3"
        | _ -> "?"
        |> equal "3"

        match "Bye" with
        | "Hi" -> "Bye"
        | "Bye" -> let h = "Hi" in sprintf "%s there!" h
        | _ -> "?"
        |> equal "Hi there!"

        match MyEnum.One with
        | MyEnum.One -> "One"
        | MyEnum.Two -> "Two"
        | _ -> failwith "never"
        |> equal "One"

    testCase "FSharpRef can be used in properties" <| fun () -> // See #521
        let r = ref false
        let x = TestRef r
        r := true
        match x with TestRef r2 -> !r2
        |> equal true

    testCase "Recursive values work" <| fun () -> // See #237
        mutableValue |> equal 5
        recursive1()
        mutableValue |> equal 10

    testCase "Module generic methods without arguments work" <| fun () ->
        let li = empty<string>
        Seq.length li |> equal 1

    testCase "Public members of private modules can be accessed" <| fun () -> // See #696
        MyPrivateModule.publicFoo() |> equal "foo bar"

    testCase "Public types of private modules can be accessed" <| fun () -> // See #841
        let thing = MyPrivateModule.Concrete() :> IInterface
        thing.Member "World" "Hello" |> equal "Hello World"

    testCase "Types declared in signature file work" <| fun () -> // See #754
        let t = Spaces.TRec.Create("haha", "hoho")
        t.Value |> equal "hahahoho"

    testCase "Primary constructor of types from signature files work" <| fun () -> // See #571
        Spaces.Test(true).Status |> equal true
        Spaces.Test(false).Status |> equal false

    testCase "Two types with same name in different folders work" <| fun () -> // See #781
        tempet.SayA.hello "Albert"
        |> equal "Hello Albert from SayA"
        tempet.SayB.hello "Albert"
        |> equal "Hello Albert from SayB"

    testCase "While with isNone doesn't hang with Some ()" <| fun () ->
        Trampoline.run (fun _ -> Trampoline.Break "hello") () |> ignore
        Trampoline.run (fun _ -> Trampoline.Break 42) () |> ignore
        Trampoline.run (fun _ -> Trampoline.Break ()) () |> ignore

    testCase "Removing optional arguments not in tail position works" <| fun () ->
        Internal.MyType.Add(y=6) |> equal 26

    testCase "Inlined methods can have optional arguments" <| fun () ->
        StaticClass.Add(2, 3) |> equal 5
        StaticClass.Add(5) |> equal 7
  ]