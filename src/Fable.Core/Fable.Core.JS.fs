namespace Fable.Import

[<System.Obsolete("Use Fable.Core.JS")>]
module JS =
    /// Use Fable.Core.JS
    let obsolete<'T> : 'T = failwith "Use Fable.Core.JS"

namespace Fable.Core

open System
open System.Text.RegularExpressions

module JS =
    type [<AllowNullLiteral>] PropertyDescriptor =
        abstract configurable: bool option with get, set
        abstract enumerable: bool option with get, set
        abstract value: obj option with get, set
        abstract writable: bool option with get, set
        abstract get: unit -> obj
        abstract set: v: obj -> unit

    and [<AllowNullLiteral>] ArrayConstructor =
        abstract isArray: arg: obj -> bool

    and [<AllowNullLiteral>] NumberConstructor =
        abstract isNaN: float -> bool

    and [<AllowNullLiteral>] Object =
        abstract toString: unit -> string
        abstract toLocaleString: unit -> string
        abstract valueOf: unit -> obj
        abstract hasOwnProperty: v: string -> bool
        abstract isPrototypeOf: v: obj -> bool
        abstract propertyIsEnumerable: v: string -> bool
        abstract hasOwnProperty: v: obj -> bool
        abstract propertyIsEnumerable: v: obj -> bool

    and [<AllowNullLiteral>] ObjectConstructor =
        abstract getPrototypeOf: o: obj -> obj
        abstract getOwnPropertyDescriptor: o: obj * p: string -> PropertyDescriptor
        abstract getOwnPropertyNames: o: obj -> ResizeArray<string>
        abstract create: o: obj * ?properties: obj -> obj
        abstract defineProperty: o: obj * p: string * attributes: PropertyDescriptor -> obj
        abstract defineProperties: o: obj * properties: obj -> obj
        abstract seal: o: 'T -> 'T
        abstract freeze: o: 'T -> 'T
        abstract preventExtensions: o: 'T -> 'T
        abstract isSealed: o: obj -> bool
        abstract isFrozen: o: obj -> bool
        abstract isExtensible: o: obj -> bool
        abstract keys: o: obj -> ResizeArray<string>
        abstract assign: target: 'T * source: 'U -> obj
        abstract assign: target: 'T * source1: 'U * source2: 'V -> obj
        abstract assign: target: 'T * source1: 'U * source2: 'V * source3: 'W -> obj
        abstract assign: target: obj * [<ParamArray>] sources: obj[] -> obj
        // abstract getOwnPropertySymbols: o: obj -> ResizeArray<Symbol>
        abstract is: value1: obj * value2: obj -> bool
        abstract setPrototypeOf: o: obj * proto: obj -> obj
        abstract getOwnPropertyDescriptor: o: obj * propertyKey: obj -> PropertyDescriptor
        abstract defineProperty: o: obj * propertyKey: obj * attributes: PropertyDescriptor -> obj

    and [<AllowNullLiteral>] Math =
        abstract E: float with get, set
        abstract LN10: float with get, set
        abstract LN2: float with get, set
        abstract LOG2E: float with get, set
        abstract LOG10E: float with get, set
        abstract PI: float with get, set
        abstract SQRT1_2: float with get, set
        abstract SQRT2: float with get, set
        abstract abs: x: float -> float
        abstract acos: x: float -> float
        abstract asin: x: float -> float
        abstract atan: x: float -> float
        abstract atan2: y: float * x: float -> float
        abstract ceil: x: float -> float
        abstract cos: x: float -> float
        abstract exp: x: float -> float
        abstract floor: x: float -> float
        abstract log: x: float -> float
        abstract max: [<ParamArray>] values: float[] -> float
        abstract min: [<ParamArray>] values: float[] -> float
        abstract pow: x: float * y: float -> float
        abstract random: unit -> float
        abstract round: x: float -> float
        abstract sin: x: float -> float
        abstract sqrt: x: float -> float
        abstract tan: x: float -> float
        abstract clz32: x: float -> float
        abstract imul: x: float * y: float -> float
        abstract sign: x: float -> float
        abstract log10: x: float -> float
        abstract log2: x: float -> float
        abstract log1p: x: float -> float
        abstract expm1: x: float -> float
        abstract cosh: x: float -> float
        abstract sinh: x: float -> float
        abstract tanh: x: float -> float
        abstract acosh: x: float -> float
        abstract asinh: x: float -> float
        abstract atanh: x: float -> float
        abstract hypot: [<ParamArray>] values: float[] -> float
        abstract trunc: x: float -> float
        abstract fround: x: float -> float
        abstract cbrt: x: float -> float

    and [<AllowNullLiteral>] Date =
        abstract toString: unit -> string
        abstract toDateString: unit -> string
        abstract toTimeString: unit -> string
        abstract toLocaleString: unit -> string
        abstract toLocaleDateString: unit -> string
        abstract toLocaleTimeString: unit -> string
        abstract valueOf: unit -> float
        abstract getTime: unit -> float
        abstract getFullYear: unit -> float
        abstract getUTCFullYear: unit -> float
        abstract getMonth: unit -> float
        abstract getUTCMonth: unit -> float
        abstract getDate: unit -> float
        abstract getUTCDate: unit -> float
        abstract getDay: unit -> float
        abstract getUTCDay: unit -> float
        abstract getHours: unit -> float
        abstract getUTCHours: unit -> float
        abstract getMinutes: unit -> float
        abstract getUTCMinutes: unit -> float
        abstract getSeconds: unit -> float
        abstract getUTCSeconds: unit -> float
        abstract getMilliseconds: unit -> float
        abstract getUTCMilliseconds: unit -> float
        abstract getTimezoneOffset: unit -> float
        abstract setTime: time: float -> float
        abstract setMilliseconds: ms: float -> float
        abstract setUTCMilliseconds: ms: float -> float
        abstract setSeconds: sec: float * ?ms: float -> float
        abstract setUTCSeconds: sec: float * ?ms: float -> float
        abstract setMinutes: min: float * ?sec: float * ?ms: float -> float
        abstract setUTCMinutes: min: float * ?sec: float * ?ms: float -> float
        abstract setHours: hours: float * ?min: float * ?sec: float * ?ms: float -> float
        abstract setUTCHours: hours: float * ?min: float * ?sec: float * ?ms: float -> float
        abstract setDate: date: float -> float
        abstract setUTCDate: date: float -> float
        abstract setMonth: month: float * ?date: float -> float
        abstract setUTCMonth: month: float * ?date: float -> float
        abstract setFullYear: year: float * ?month: float * ?date: float -> float
        abstract setUTCFullYear: year: float * ?month: float * ?date: float -> float
        abstract toUTCString: unit -> string
        abstract toISOString: unit -> string
        abstract toJSON: ?key: obj -> string

    and [<AllowNullLiteral>] DateConstructor =
        [<Emit("new $0()")>] abstract Create: unit -> DateTime
        [<Emit("new $0($1)")>] abstract Create: value: float -> DateTime
        [<Emit("new $0($1)")>] abstract Create: value: string -> DateTime
        [<Emit("new $0($1...)")>] abstract Create: year: float * month: float * ?date: float * ?hours: float * ?minutes: float * ?seconds: float * ?ms: float -> DateTime
        [<Emit("$0()")>] abstract Invoke: unit -> string
        abstract parse: s: string -> float
        abstract UTC: year: float * month: float * ?date: float * ?hours: float * ?minutes: float * ?seconds: float * ?ms: float -> float
        abstract now: unit -> float

    and [<AllowNullLiteral>] JSON =
        abstract parse: text: string * ?reviver: (obj->obj->obj) -> obj
        abstract stringify: value: obj * ?replacer: (string->obj->obj) * ?space: obj -> string

    and [<AllowNullLiteral>] Map<'K, 'V> =
        abstract size: float with get, set
        abstract clear: unit -> unit
        abstract delete: key: 'K -> bool
        abstract entries: unit -> seq<'K * 'V>
        abstract forEach: callbackfn: ('V->'K->Map<'K, 'V>->unit) * ?thisArg: obj -> unit
        abstract get: key: 'K -> 'V
        abstract has: key: 'K -> bool
        abstract keys: unit -> seq<'K>
        abstract set: key: 'K * ?value: 'V -> Map<'K, 'V>
        abstract values: unit -> seq<'V>

    and [<AllowNullLiteral>] MapConstructor =
        [<Emit("new $0($1..)")>] abstract Create: ?iterable: seq<'K * 'V> -> Map<'K, 'V>

    and [<AllowNullLiteral>] WeakMap<'K, 'V> =
        abstract clear: unit -> unit
        abstract delete: key: 'K -> bool
        abstract get: key: 'K -> 'V
        abstract has: key: 'K -> bool
        abstract set: key: 'K * ?value: 'V -> WeakMap<'K, 'V>

    and [<AllowNullLiteral>] WeakMapConstructor =
        [<Emit("new $0($1...)")>] abstract Create: ?iterable: seq<'K * 'V> -> WeakMap<'K, 'V>

    and [<AllowNullLiteral>] Set<'T> =
        abstract size: float with get, set
        abstract add: value: 'T -> Set<'T>
        abstract clear: unit -> unit
        abstract delete: value: 'T -> bool
        abstract entries: unit -> seq<'T * 'T>
        abstract forEach: callbackfn: ('T->'T->Set<'T>->unit) * ?thisArg: obj -> unit
        abstract has: value: 'T -> bool
        abstract keys: unit -> seq<'T>
        abstract values: unit -> seq<'T>

    and [<AllowNullLiteral>] SetConstructor =
        [<Emit("new $0($1...)")>] abstract Create: ?iterable: seq<'T> -> Set<'T>

    and [<AllowNullLiteral>] WeakSet<'T> =
        abstract add: value: 'T -> WeakSet<'T>
        abstract clear: unit -> unit
        abstract delete: value: 'T -> bool
        abstract has: value: 'T -> bool

    and [<AllowNullLiteral>] WeakSetConstructor =
        [<Emit("new $0($1...)")>] abstract Create: ?iterable: seq<'T> -> WeakSet<'T>

    and [<AllowNullLiteral>] Promise<'T> =
        abstract ``then``: ?onfulfilled: ('T->'TResult) * ?onrejected: (obj->'TResult) -> Promise<'TResult>
        abstract catch: ?onrejected: (obj->'T) -> Promise<'T>

    and [<AllowNullLiteral>] PromiseConstructor =
        [<Emit("new $0($1...)")>] abstract Create: executor: ((obj->unit) -> (obj->unit) -> unit) -> Promise<'T>
        abstract all: [<ParamArray>] values: obj[] -> Promise<obj>
        abstract race: values: obj seq -> Promise<obj>
        abstract reject: reason: obj -> Promise<unit>
        abstract reject: reason: obj -> Promise<'T>
        abstract resolve: value: 'T -> Promise<'T>
        abstract resolve: unit -> Promise<unit>

    and [<AllowNullLiteral>] RegExpConstructor =
        [<Emit("new $0($1...)")>] abstract Create: pattern: string * ?flags: string -> Regex

    and [<AllowNullLiteral>] ArrayBuffer =
        abstract byteLength: int with get, set
        abstract slice: ``begin``: int * ?``end``: int -> ArrayBuffer

    and [<AllowNullLiteral>] ArrayBufferConstructor =
        [<Emit("new $0($1...)")>] abstract Create: byteLength: int -> ArrayBuffer
        abstract isView: arg: obj -> bool

    and [<AllowNullLiteral>] ArrayBufferView =
        abstract buffer: ArrayBuffer
        abstract byteLength: int
        abstract byteOffset: int

    and [<AllowNullLiteral>] DataView =
        abstract buffer: ArrayBuffer
        abstract byteLength: int
        abstract byteOffset: int
        abstract getFloat32: byteOffset: int * ?littleEndian: bool -> float32
        abstract getFloat64: byteOffset: int * ?littleEndian: bool -> float
        abstract getInt8: byteOffset: int -> sbyte
        abstract getInt16: byteOffset: int * ?littleEndian: bool -> int16
        abstract getInt32: byteOffset: int * ?littleEndian: bool -> int32
        abstract getUint8: byteOffset: int -> byte
        abstract getUint16: byteOffset: int * ?littleEndian: bool -> uint16
        abstract getUint32: byteOffset: int * ?littleEndian: bool -> uint32
        abstract setFloat32: byteOffset: int * value: float32 * ?littleEndian: bool -> unit
        abstract setFloat64: byteOffset: int * value: float * ?littleEndian: bool -> unit
        abstract setInt8: byteOffset: int * value: sbyte -> unit
        abstract setInt16: byteOffset: int * value: int16 * ?littleEndian: bool -> unit
        abstract setInt32: byteOffset: int * value: int32 * ?littleEndian: bool -> unit
        abstract setUint8: byteOffset: int * value: byte -> unit
        abstract setUint16: byteOffset: int * value: uint16 * ?littleEndian: bool -> unit
        abstract setUint32: byteOffset: int * value: uint32 * ?littleEndian: bool -> unit

    // TODO: Add constructors for other typed arrays from buffer?
    and [<AllowNullLiteral>] DataViewConstructor =
        [<Emit("new $0($1...)")>] abstract Create: buffer: ArrayBuffer * ?byteOffset: int * ?byteLength: float -> DataView

    and [<AllowNullLiteral>] Console =
        abstract ``assert``: ?test: bool * ?message: string * [<ParamArray>] optionalParams: obj[] -> unit
        abstract clear: unit -> unit
        abstract count: ?countTitle: string -> unit
        abstract debug: ?message: string * [<ParamArray>] optionalParams: obj[] -> unit
        abstract dir: ?value: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract dirxml: value: obj -> unit
        abstract error: ?message: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract group: ?groupTitle: string -> unit
        abstract groupCollapsed: ?groupTitle: string -> unit
        abstract groupEnd: unit -> unit
        abstract info: ?message: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract log: ?message: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract profile: ?reportName: string -> unit
        abstract profileEnd: unit -> unit
        abstract time: ?timerName: string -> unit
        abstract timeEnd: ?timerName: string -> unit
        abstract trace: ?message: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract warn: ?message: obj * [<ParamArray>] optionalParams: obj[] -> unit
        abstract table: ?data: obj -> unit

    let [<Global>] Array: ArrayConstructor = jsNative
    let [<Global>] Number: NumberConstructor = jsNative
    let [<Global>] NaN: float = jsNative
    let [<Global>] Infinity: float = jsNative
    let [<Global>] Object: ObjectConstructor = jsNative
    let [<Global>] Math: Math = jsNative
    let [<Global>] Date: DateConstructor = jsNative
    let [<Global>] JSON: JSON = jsNative
    let [<Global>] Map: MapConstructor = jsNative
    let [<Global>] WeakMap: WeakMapConstructor = jsNative
    let [<Global>] Set: SetConstructor = jsNative
    let [<Global>] WeakSet: WeakSetConstructor = jsNative
    let [<Global>] Promise: PromiseConstructor = jsNative
    let [<Global>] RegExp: RegExpConstructor = jsNative
    let [<Global>] ArrayBuffer: ArrayBufferConstructor = jsNative
    let [<Global>] DataView: DataViewConstructor = jsNative
    let [<Global>] eval: string -> string = jsNative
    let [<Global>] isFinite: float -> bool = jsNative
    let [<Global>] isNaN: float -> bool = jsNative
    let [<Global>] parseFloat: string -> float = jsNative
    let [<Global>] parseInt: string -> int -> int = jsNative
    let [<Global>] decodeURI: string -> string = jsNative
    let [<Global>] decodeURIComponent: string -> string = jsNative
    let [<Global>] encodeURI: string -> string = jsNative
    let [<Global>] encodeURIComponent: string -> string = jsNative
    let [<Global>] console : Console = jsNative
    let [<Global>] setTimeout (callback: unit -> unit) (ms: int): int = jsNative
    let [<Global>] clearTimeout (token: int): unit = jsNative
    let [<Global>] setInterval(callback: unit -> unit) (ms: int) : int = jsNative
    let [<Global>] clearInterval (token: int): unit = jsNative
    let [<Emit("debugger")>] debugger () : unit = jsNative
    let [<Emit("void 0")>] undefined<'a> : 'a = jsNative
