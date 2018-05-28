
export type PrimitiveTypeInfo =
  | "any"
  | "unit"
  | "boolean"
  | "string"
  | "number"
  | "function";

export enum TypeInfoKind {
  Option = 1,
  Tuple = 2,
  Array = 3,
  List = 4,
  Record = 5,
  Union = 6,
  Class = 7,
}

export interface OptionInfo {
  kind: TypeInfoKind.Option;
  arg: TypeInfo;
}

export interface TupleInfo {
  kind: TypeInfoKind.Tuple;
  args: TypeInfo[];
}

export interface ArrayInfo {
  kind: TypeInfoKind.Array;
  arg: TypeInfo;
}

export interface ListInfo {
  kind: TypeInfoKind.List;
  arg: TypeInfo;
}

export interface RecordInfo {
  kind: TypeInfoKind.Record;
  fullname: string;
  fields: Array<[string, TypeInfo]>;
}

export interface UnionInfo {
  kind: TypeInfoKind.Union;
  fullname: string;
  cases: Array<[string, TypeInfo[]]>;
}

export interface ClassInfo {
  kind: TypeInfoKind.Class;
  fullname: string;
  args: TypeInfo[];
}

export type NonPrimitiveTypeInfo =
  | OptionInfo
  | TupleInfo
  | ArrayInfo
  | ListInfo
  | RecordInfo
  | UnionInfo
  | ClassInfo;

export type TypeInfo = PrimitiveTypeInfo | NonPrimitiveTypeInfo;

function todo(msg?: string) {
  throw new Error(msg ? "TODO: " + msg : "TODO");
}

function test(t: TypeInfo) {
  switch (t) {
    case "any":
    case "unit":
    case "boolean":
    case "string":
    case "number":
    case "function":
      return todo();
    default:
      switch (t.kind) {
        case TypeInfoKind.Option:
        case TypeInfoKind.Tuple:
        case TypeInfoKind.Array:
        case TypeInfoKind.List:
        case TypeInfoKind.Record:
        case TypeInfoKind.Union:
        case TypeInfoKind.Class:
          return todo();
      }
  }
}
