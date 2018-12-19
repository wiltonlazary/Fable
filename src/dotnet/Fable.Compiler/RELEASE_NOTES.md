### 2.0.11

* Fix conflicting extensions with same type and member names

### 2.0.10

* Improve decimal support #1627
* Compile fable-core/BigInt from F# #1631
* Add range info to Debugger statement

### 2.0.9

* Include non-mangled identifier names for source maps
* Optimize tailcalls returning unit #1624
* Fix DateTimeOffset @ncave
* Fix #1607: More descriptive error when two module members have same name
* Fix #1628: `String.filter Char.IsDigit` freezes REPL

### 2.0.8

* Implement eprintf and eprintfn @inosik
* Fix #1389: Throw proper error when match cases are incomplete @Zaid-Aja
* Fix #1602: constructor "as this" notation
* Only check for Fable.Core major and minor version

### 2.0.6

* Don't change the first letter of erased union cases in keyValueList
* Updates for creating precompiled libraries
* Fix `isRelativePath`

### 2.0.4

* Fix #1594 Array.partition results are too long @ericharding
* Fix #1599: Folders starting with dot @OnurGumus @inosik
* Check files exist when collecing all sources into single .fsproj @dbrattli
* Don't trigger Symbol.iterator when testing for iterables
* Improvements for Fable REPL @ncave

### 2.0.3

* Fix #1588: MailboxProcessor.PostAndAsyncReply with falsy values @nilekirk
* Fix #1586: Parsing signed longs @ncave
* Fix #1585: Timespan milliseconds to int conversion
* Fix #1386: Proper convertion to .NET delegates
* More fixes for optimization switch @ncave

### 2.0.2

* Fix #1583: Generated idents must always be unique
* Fix #1582: Enable Seq.sum(By)/average(By) with custom types
* Fixes for optimization switch @ncave

### 2.0.1

* Fix sorting of Fable dependencies

### 2.0.0

* Fable 2

### 2.0.0-beta-005

* Update to FCS 25.0.1
* Add replacements for System.Uri @JacobChang
* Fix #1539: 0xFFFFFFFFu is read as 0u in REPL @ncave

### 2.0.0-beta-004

* Attach interface members to prototype (as in Fable 1, no cast needed anymore) #1562
* Improvements in fable-core JS files @ncave
* Fix #1551: Truncation of large unsigned bitwise op results @tomcl
* Fix #1337: Add Option.contains @iyegoroff
* Fix #1383: Range with longs
* Fix abstract properties with getter and setter

### 2.0.0-beta-003

* Improve int64 conversions @tomcl #1546
* Add full call path for errors in inlined functions
* Fix #1545: Warning when casting to and interface not directly implemented
* Fix extension member overloads

### 2.0.0-beta-002

* Compile chars as JS strings (as in Fable 1)
* Add Map.TryGetValue
* Add EnumToValue @zpodlovics #1522
* Fix: Use operators as functions @xdaDaveShaw #1529
* Fix hexadecimal printing @xdaDaveShaw #1535
* Fix overloaded inline methods in other files @dgchurchill #1534
* Fix #1516: Add warning if unit value is replaced
* Fix #1533: Enable inheriting empty interfaces
* Fix #1519: FSharpType.MakeTupleType
* Fix extension member overloads
* Fix: Check bitwise shift left for unsigned integers
* Improvements in pattern matching compilation
* Add --force-pkgs CLI option
* Return non-zero error code when CLI arguments are wrong @theimowski #1515

### 2.0.0-beta-001

* Fable 2 beta

### 1.3.7

* Fix PassGenerics attribute with optional arguments
* Fix interface getter and setter overloads
* Add PhysicalHash (@ncave)
* Check empty/whitespace strings when parsing floats
* Fix #1296 String chunkBySize fails

### 1.3.6

* Fix #1294: Deserializing F# Result doesn't restore type information (@inosik)

### 1.3.5

* Change license to MIT
* Remove point-free warning
* Fix #1272 #1274: Decimal literals and parsing
* Fix #1199: Application of point-free functions
* Fix #1291: Inlined object expression shouldn't change `this` context of argument
* Fix Compare and Equal for IE11 (@SCullman)
* Fix assignment block optimization inside try...with
* Add PowDouble, RangeChar and RangeDouble (@Zaid-Ajaj)
* Make `Double.Parse` and `Single.Parse` compilable with IFormatProvider (@Zaid-Ajaj)
* Add ErrorStrings (@Zaid-Ajaj)
* Add `List.Equals` & `List.CompareTo` (@Zaid-Ajaj)
* Add `Char.parse` (@inosik)

### 1.3.4

* Optimize assignment blocks as expressions (#1265)
* Improve method resolution with function parameters
* Fix applicative operators with 3-arg functions

### 1.3.3

* Add Char.IsWhiteSpace
* Bring back warning for point-free style
* Better error message when `ofJson` fails
* Fix application of function options
* Fix #1256: Optimize unions without fields
* Fix #1255: Add Enum.HasFlag
* Fix #838: Return empty group values when group is not matched instead of undefined
* Fix option wrapper in serialization

### 1.3.2

* Don't pass dependencies to JS clients (see #1241)
* Recompile edited and dependent files in watch compilations and send errors (if any) to client
* Remove point-free warning for now as it was too noisy (see #1244)
* Added List.RemoveRange (PR #1243 by Zaid-Ajaj)
* Built with dotnet SDK 2.0.3 on Windows

### 1.3.1

* Add warning for point-free style function declarations
* Fix #1238: Inline overloaded methods and "this" double eval
* Fix #1236 #1237: Char.IsUpper, Char.IsDigit and friends
* Fix #1234: Local inline lambdas work standalone
* Fix #1185: Transform importMember expressions for functions

### 1.3.0

* Optimize watch compilations
* Add dependencies to ensure all necessary files are recompiled in a watch compilation (#1188)
* Enable nested options (#1189, #1219)
* Remove closures generated by F# compiler
* Add DateTimeOffset
* Added inf, nan operators
* Fix #1218: Multiple namespaces in same file
* Fix #1230: Seq.singleton returns empty after first use
* Fix #1227: Names in paket.references are not case sensitive
* Fix #1223: Async.StartChild
* Fix #1216: Print.sprintf (note the qualified module)
* Fix #1204: kprintf works indirectly
* Fix #1203: choose and pick with generic options
* Fix #1201: Cannot find replacement for `System.Char::ToUpper`
* Fix #1193 and other string printing errors
* Fix #1190: Trait calls don't check inherited members
* Fix #1187: List.truncate returning one-too-many elements
* Fix #1186: Negated negative values

### 1.3.0-beta-009

* Fix #1218: Multiple namespaces in same file
* Add "eval" to JS keywords
* Fix DateTime[Offset].ToString() (without format)

### 1.3.0-beta-008

* Add DateTimeOffset
* Added inf, nan operators
* Fix #1223: Async.StartChild
* Fix #1230: Seq.singleton returns empty after first use

### 1.3.0-beta-007

* Fix #1227: Names in paket.references are not case sensitive
* Fix #1216: Print.sprintf (note the qualified module)
* More fixes for nested options (see PR #1219)

### 1.3.0-beta-005

* Add `PackageType` to dotnet-fable.fsproj

### 1.3.0-beta-003

* Fix #1203: choose and pick with generic options
* Fix #1204: kprintf works indirectly
* Fix #1201: Cannot find replacement for `System.Char::ToUpper`
* Fix #1193 and other string printing errors
* Fix #1190: Trait calls don't check inherited members
* Fix option handling
* Remove closures generated by F# compiler

### 1.3.0-beta-002

* #1188: Add dependencies to ensure all necessary files are recompiled in a watch compilation
* #1189: Enable nested options
* Fix #1187: List.truncate returning one-too-many elements
* Fix #1186: Negated negative values

### 1.3.0-beta-001

* Optimize watch compilations with `extra.optimizeWatch` option (see FSharp.Compiler.Service/issues/796)

### 1.2.4

* Add `jsOptions` helper
* Add `List/Array.splitAt`
* Add `ParamListAttribute`
* Don't reference `Buffer` from fable-core
* Fix #1156: Partially applied functions don't duplicate side effects
* Fix #1155: Regex replacing with `$0` doesn't work
* Fix #1154: Applying to a function returned by a member works

### 1.2.3

* Fix #1135, #1136: `unit option` hack doesn't work with generic functions

### 1.2.2

* Fix #1150: Application of closures generated by F# compiler
* Fix #1143: Seq.cache is not implemented
* Enable Emit Replacements
* Simplify print formatting
* Fix enum to int64 conversion
* Fix null detection in Fable REPL
* Fix cancellation with null tokens

### 1.2.1

* Guid validation and byte[] conversion
* Fix #1140: Side effects executed twice on Array.map

### 1.2.0

* Fix #1123: Optimize pattern matching with DUs into switch

### 1.2.0-beta-0015

* Updated FSharp.Compiler.Service to 14.0.2
* Fix #1120: IDictionary.Clear calls wrong method
* Fix #1121: Function generic type alias conflicts with uncurrying optimization

### 1.2.0-beta-0014

* Target netstandard1.6 again

### 1.2.0-beta-0012

* Allow fableCore as global var

### 1.2.0-beta-001

* Upgrade to netstandard2.0

### 1.1.22

* Fix public names conflict error and some cleanup
* Fix warning for Convert.ToBase64String

### 1.1.20

* Update FSharp.Core
* Optimize string and int literal addition

### 1.1.19

* Fix watch compilation with errors affecting not modified files

### 1.1.18

* Fix #1057: Add caught exception to context for reraise

### 1.1.17

* Update Fable.Core

### 1.1.16

* Clean up

### 1.1.14

* Add `Option.defaultWith` and `Option.orElse[With]`

### 1.1.12

* Fix #1076: Add Option.flatten replacement
* Fix #1072: Curried application with option type
* Fix instances of base class compiled as super calls

### 1.1.11

* Fix package transitive dependencies

### 1.1.10

* Fix #1062: Refactor to improve performance

### 1.1.9

* Temporary fix for #1057: Disallow `reraise`

### 1.1.8

* Fix #1053: Union cases with single array field in keyValueList resolved at compile-time
* Use Erase attribute with union cases for keyValueList

### 1.1.7

* Update FCS dependency

### 1.1.6

* Fix #1040: Expose Array.chunkBySize
* Fix #1041: Point-free style with multiple arguments
* Support some System.Uri static methods (#1048)

### 1.1.5

* Fix #1028: Arguments of auto-generated lambdas conflicting with outer variables

### 1.1.4

* Fix fable-import/#9: Don't try to replace method calls in bindings

### 1.1.3

* Add System.Console reference

### 1.1.2

* Fix Paket groups for Fable.Core

### 1.1.1

* Fix F# compiler errors in recompilation
* Fix Elmish.Browser parser (#1003)
* Add support for Option.defaultValue
* Warn when there are nested options
* Add replacement for System.Environment.NewLine (#993)
* Expose Console among JS import globals

### 1.1.0

* Fable stablish, yeah!

### 1.1.0-rc-002

* Fix #996: Don't wrap dynamic CurriedLambdas

### 1.1.0-rc-001

* Support Paket groups and move Browser and Node bindings out of Fable.Core

### 1.0.8

* Fix #940: Compilation of multiple projects in parallel

### 1.0.7

* Fix #952: Don't remove non-null unit arguments
* Fix #944: Import and Emit on same function

### 1.0.6

* Propagate subprocess exit code

### 1.0.5

* Fix #946: --port free throws exception

### 1.0.4

* Don't redirect dotnet-fable commands but check version and locate fable-core JS files in packages/Fable.Core

### 1.0.0-narumi-917

* Fix location of fable-core files

### 1.0.0-narumi-916

* We're going PAKET!

### 1.0.0-narumi-915

* Fix curried lambdas assigned to generic params (see #888)

### 0.7.49

* Fix #744: CLI argument flags

### 0.7.48

* Fix #736: Case testing with erased unions

### 0.7.47

* Tailcall optimizes function arguments: #681

### 0.7.45

* Fix import expressions with methods with function arguments: #721

### 0.7.43

* Add reflection methods (see ReflectionTests.fs)
* Improve import expressions #721

### 0.7.42

* Tailcall optimizations: PR #669 + Fixes

### 0.7.37

* Add FSharp.Core.dll to fable-compiler package
* Improve handling of `jsThis`

### 0.7.35

* Only show Rollup warnings in `--verbose` mode
* Minor fixes

### 0.7.34

* Fix #660: `Option.fold` and `Option.foldBack`

### 0.7.33

* Add operator `enum`

### 0.7.32

* Fixed default comparer: PR #658

### 0.7.31

* Added BigInt conversions: PR #650

### 0.7.30

* Fix #649: Int64 serialization
* Fix #648: Caching of namespace F# entities
* Fix #646: Zero fill shift right (>>>) for uint32

### 0.7.29

* Add `BigInteger` support

### 0.7.28

* Fix #640: Omitted non optional nulls
* Fix #638: Inlined methods with `this` argument

### 0.7.27

* Add `--includeJs` compiler argument
* Fix #629: Visual Studio error format
* Fix  #637: IEnumerable runtime issue

### 0.7.26

* Fixed Option.foldBack (#634)
* Improve .NET Enumerator/JS Iterator compatibility
* Fix #633: jsThis
* Fixed Option.foldBack (PR #634)

### 0.7.25

* Fix #623: JS Global properties
* Fix #624: Aether compilation

### 0.7.24

* Fix module generic methods without arguments
* Added `String.IndexOfAny/Compare/Equals` with `StringComparison` enum
* Fix generic types when compiling to ES2015
* Unify `Equals` and `CompareTo` methods of `Long.ts`

### 0.7.23

* Fix #348 #608 Double/Int32 Parse & TryParse
* Fix #609: Event unsubscription
* Fix custom exception type testing in ES5
* Inline local lambdas as values (#601)
* Fix edge case in `toJson` (#611)
* Fix fable-core Babel compilation
* Added 64-bit integers (#600)
* Fix #237: Recursive value definitions
* Added char to int (#594)

### 0.7.22

* Fix secondary constructors of imported classes
* Improvements in option handling

### 0.7.20

* Prevent infinite loops for bundle errors in watch mode

### 0.7.19

* Fix #509: Add KeyValuePattern
* Fix #544 #585: Bundling in watch mode
* Fix #589: Regex Provider with Fable 0.7
* Add optional argument to GlobalAttribute

### 0.7.18

* Add validation to `ofJson`
* Make `Assert.AreEqual` work with F# equality
* Improve dynamic programming (add `jsThis`)
* Add `Printf.kprintf` (#583)
* Fix sprintf "%X" (#580)
* Fix #579: Printf.printfn

### 0.7.17

* Add `Pojo` union types

### 0.7.16

* Fix issues in generic resolution

### 0.7.15

* Issue warning when calling `typeof` on a generic parameter
* Use absolute paths for assembly references in `node_modules`

### 0.7.14

* Use "umd" distribution of fable-core and other libs when compiling for umd modules
* Fix #569: Types with circular dependencies

### 0.7.12

* Fix #568: Types with `StructAttribute` (compiled as records)
* Better checking when calling functions with `PassGenericsAttribute`

### 0.7.11

* Some adjustments in attribute resolution

### 0.7.10

* Fix #565, #566: Only watch F# files
* Fix #564: Don't overload methods from imported classes
* Fix #563: Overloads with `PassGenericsAttribute`

### 0.7.9

* Fix `Array.rev` (see #559)
* Added UnboxFast intrinsic / List.truncate (see #561)

### 0.7.8

* `System.Exception` translates to JS `Error`
* Fix #556: inline methods placed after calls

### 0.7.7

* Fix ES2015 imports

### 0.7.6

* Too many changes to be listed, check the [migration guide](http://fable.io/blog/Introducing-0-7.html)

### 0.7.5-alpha.41

* Fix cyclic dependencies in fable-core

### 0.7.5-alpha.40

* Minor fix

### 0.7.5-alpha.39

* Simplify Reflection system
* Add `PojoAttribute`
* Replace baseDir of references with --refs argument

### 0.7.5-alpha.38

* Fix #547: Ignored entities conflicting when calculating root namespace

### 0.7.5-alpha.37

* Mangle class methods when they conflict with an implemented interface

### 0.7.5-alpha.35

* Fix #545: Using `Microsoft.FSharp` namespace

### 0.7.5-alpha.34

* Add `import: selector->path->'T` to import expressions
* Make arguments of JsConstructor statically typed
* Add logs when compiling files for bundling

### 0.7.5-alpha.33

* Fix default watch directories
* Ignore interfaces

### 0.7.5-alpha.32

* Compile scripts referenced as plugins
* Apply Replace plugins to any call
* Include in compilation JS files with relative paths

### 0.7.5-alpha.31

* Fix #535: Script referenced entity replacements

### 0.7.5-alpha.30

* Allow configuration of watching dirs

### 0.7.5-alpha.29

* Fix infinite recursion when resolving generic parameters

### 0.7.5-alpha.28

* More meaningful runtime representation of non-declared types

### 0.7.5-alpha.27

* When inlining, assign arguments referenced more than once to a temp var
* `Array.zeroCreate` fills non-numeric arrays with null

### 0.7.5-alpha.26

* Resolve trait calls as normal method calls (check EmitAttribute, etc)

### 0.7.5-alpha.24

* Fix mangled interfaces
* Improve error messages

### 0.7.5-alpha.23

* Add `MangleAttribute` to prevent conflicts with interfaces
* Allow combination of `ImportAttribute` and `EmitAttribute`
* Several fixes

### 0.7.5-alpha.22

* Add catch-all for missing replacements when referencing
  types of the BCL or FSharp.Core
* Omit `.js` extension again in imports to keep
  compatibility with Require.js

### 0.7.5-alpha.21

* Don't print warnings in process.stderr (see #516)
* Add `String/formatError` (see #519)
* Add `.js` extension to `fable-core` and internal imports

### 0.7.5-alpha.19

* Distribute fable-core with ES2015 (default) and UMD module formats

### 0.7.5-alpha.18

* Don't deem interface setters as overloads (see #505)

### 0.7.5-alpha.17

* Update FCS and use Forge to read .fsproj files (removes MSBuild dependency)
* Bug fixes and optimizations

### 0.7.5-alpha.16

* Add JsFunc and JsCons to Fable.Core.JsInterop

### 0.7.5-alpha.15

* Use outDir to place the generated dll with .fsproj projects
* Only emit warnings when generating dlls in verbose mode
* Fix error when reading Rollup options

### 0.7.5-alpha.14

* Fix errors in Fable JS API

### 0.7.5-alpha.12

* Change `--bundle` option to `--rollup`
* `--rollup` can accept an object (in fableconfig.json) with Rollup config
* Improve plugin resolution for Babel and Rollup

### 0.7.5-alpha.11

* Add a block scope to switch cases (see #483)

### 0.7.5-alpha.10

* Fix invalid identifiers in top level members (see #482)
* Generate `dll` also for `fsproj` files
* Expose Fable library to JS API

### 0.7.5-alpha.9

* Fix issues with bundling and `System.Exception`

### 0.7.5-alpha.8

* Fix problems with `dll` generation

### 0.7.5-alpha.7

* Add experimental `--dll` compiler option to generate assemblies

### 0.7.5-alpha.6

* Fix path resolution when referencing assemblies

### 0.7.5-alpha.5

* Fix partial patterns not returning any value (see #478)

### 0.7.5-alpha.4

* Minor fixes

### 0.7.5-alpha.2

* Resolve relative paths of referenced projects/dlls as
  if they were pointing to generated JS code from the fsproj/dll file
  (`EntryModuleAttribute`) or from working directory (`--refs`)
  and make them reachable from `outDir` (see #472)
* Always resolve relative paths in command line options with
  the directory from where fable is called

### 0.7.5-alpha.1

* Fix prerelease semver. See: https://docs.npmjs.com/misc/semver#prerelease-tags

### 0.7.5-alpha

* Add `typedefof<>`, `.IsGenericType`, `.GetGenericTypeDefinition`

### 0.7.4-alpha

* Resolve import relative paths so they can be reached from `outDir`
  if they don't point to an internal file (see #472)

### 0.7.3-alpha

* Add warning when creating references of types unknown at compile time

### 0.7.2-alpha

* Convert functions to delegates when passed as arguments to EmitAttribute
* Add warning when passing generic param to Serialize.ofJson/inflate

### 0.7.1-alpha

* Add `--bundle` compiler option
* Bring back JSON serialization with `$type` info

### 0.7.0-alpha

* Add type info to JS constructors: cases (unions) and properties (records and classes)
* Extend type references with generic info when calling `typeof`
* Add `GenericParamAttribute` to implicitly pass type info of generic parameters
* Add `MutatingUpdateAttribute` to compile record updates as mutations
* Add `EntryModuleAttribute` to mark assemblies as Fable libraries

### 0.6.15

* Revert change from 0.6.14: ES6 modules automatically enable
  strict mode, so the directive is not needed

### 0.6.14

* Add always "use strict" directive

### 0.6.12

* Now fableconfig.json can be in JSON5 format (comments!)
* Omit lambda argument when it's of unit type

### 0.6.11

* Don't wait until "postbuild-once" script is finished (see #432)

### 0.6.9

* Fix #431: Add --babelrc compiler option
* Fix #432: Add "postbuild-once" script
* Fix #433: Add --noTypedArrays compiler option
* Fix #436: Inform users about not supported overloads of String.IndexOf/LastIndexOf
* Fix #438: Incorrect this in local let functions creating object expressions
* Fix #439: IDE locking project file and preventing watch compilations
* Change compilation defaults: module=commonjs & loose=true

### 0.6.7

* Fix #416: Can't ifdef around a load directive
* Fix List.unfold: PR #428
* Use reference hint paths for netcore: PR #423

### 0.6.6

* Support ResizeArray.FindAll: PR #412

### 0.6.5

* Support decimal (converted to JS number): PR #413
* Support recursive records: PR #417

### 0.6.4

* Fix #411: for .. downto

### 0.6.3

* Fix watch compilation on Windows

### 0.6.2

* Integer conversions (see #407)

### 0.6.1

* Multiple bug fixes
* Internal Fable AST additions
* [Rewrite plugins](https://fable-compiler.github.io/docs/plugins.html#Creating-rewriter-plugins)
* Use let/const when compiling value bindings to ES6
* Compile pattern matching with string or number literals as switch statements

### 0.5.11

* Fix #382 (partially): Exclude files in "node_modules" when calculating the base
  directory of referenced dlls.

### 0.5.10

* Fix #369: Extra blank lines when running postbuild script
* Fix #375: Add warning when replacements change semantics (printf, Async.Start...)
* Fix #377: Remove null args at the end of method/constructor calls also with macros

### 0.5.9

* Fix type testing with Erased Unions
* Erase assigments generated for tuple, record and union gets
* Fix #370: Add warning when using unions or records with Dictionary (as keys) or HashSet
* Internal cleanup

### 0.5.8

* Use chokidar to watch for file changes
* Fix calculation of relative paths with special characters (like "#")
