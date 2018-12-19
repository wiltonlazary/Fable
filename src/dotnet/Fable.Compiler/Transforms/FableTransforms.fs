module Fable.Transforms.FableTransforms

open Fable
open Fable.AST.Fable
open Microsoft.FSharp.Compiler.SourceCodeServices

// TODO: Use trampoline here?
let visit f e =
    match e with
    | IdentExpr _ | Debugger _ -> e
    | TypeCast(e, t) -> TypeCast(f e, t)
    | Import(e1, e2, kind, t, r) -> Import(f e1, f e2, kind, t, r)
    | Value kind ->
        match kind with
        | TypeInfo _ | Null _ | UnitConstant
        | BoolConstant _ | CharConstant _ | StringConstant _
        | NumberConstant _ | RegexConstant _ -> e
        | Enum(kind, name) ->
            match kind with
            | NumberEnum e -> Enum(NumberEnum(f e), name) |> Value
            | StringEnum e -> Enum(StringEnum(f e), name) |> Value
        | NewOption(e, t) -> NewOption(Option.map f e, t) |> Value
        | NewTuple exprs -> NewTuple(List.map f exprs) |> Value
        | NewArray(kind, t) ->
            match kind with
            | ArrayValues exprs -> NewArray(ArrayValues(List.map f exprs), t) |> Value
            | ArrayAlloc e -> NewArray(ArrayAlloc(f e), t) |> Value
        | NewList(ht, t) ->
            let ht = ht |> Option.map (fun (h,t) -> f h, f t)
            NewList(ht, t) |> Value
        | NewRecord(exprs, ent, genArgs) ->
            NewRecord(List.map f exprs, ent, genArgs) |> Value
        | NewErasedUnion(e, genArgs) ->
            NewErasedUnion(f e, genArgs) |> Value
        | NewUnion(exprs, uci, ent, genArgs) ->
            NewUnion(List.map f exprs, uci, ent, genArgs) |> Value
    | Test(e, kind, r) -> Test(f e, kind, r)
    | DelayedResolution(kind, t, r) ->
        match kind with
        | AsPojo(e1, e2) -> DelayedResolution(AsPojo(f e1, f e2), t, r)
        | Curry(e, arity) -> DelayedResolution(Curry(f e, arity), t, r)
    | Function(kind, body, name) -> Function(kind, f body, name)
    | ObjectExpr(members, t, baseCall) ->
        let baseCall = Option.map f baseCall
        let members = members |> List.map (fun (ObjectMember(k,v,kind)) -> ObjectMember(f k, f v, kind))
        ObjectExpr(members, t, baseCall)
    | Operation(kind, t, r) ->
        match kind with
        | CurriedApply(callee, args) ->
            Operation(CurriedApply(f callee, List.map f args), t, r)
        | Call(kind, info) ->
            let kind =
                match kind with
                | ConstructorCall e -> ConstructorCall(f e)
                | StaticCall e -> StaticCall(f e)
                | InstanceCall memb -> InstanceCall(Option.map f memb)
            let info = { info with ThisArg = Option.map f info.ThisArg
                                   Args = List.map f info.Args }
            Operation(Call(kind, info), t, r)
        | Emit(macro, info) ->
            let info = info |> Option.map (fun info ->
                { info with ThisArg = Option.map f info.ThisArg
                            Args = List.map f info.Args })
            Operation(Emit(macro, info), t, r)
        | UnaryOperation(operator, operand) ->
            Operation(UnaryOperation(operator, f operand), t, r)
        | BinaryOperation(op, left, right) ->
            Operation(BinaryOperation(op, f left, f right), t, r)
        | LogicalOperation(op, left, right) ->
            Operation(LogicalOperation(op, f left, f right), t, r)
    | Get(e, kind, t, r) ->
        match kind with
        | ListHead | ListTail | OptionValue | TupleGet _ | UnionTag
        | UnionField _ | FieldGet _ -> Get(f e, kind, t, r)
        | ExprGet e2 -> Get(f e, ExprGet (f e2), t, r)
    | Throw(e, typ, r) -> Throw(f e, typ, r)
    | Sequential exprs -> Sequential(List.map f exprs)
    | Let(bs, body) ->
        let bs = bs |> List.map (fun (i,e) -> i, f e)
        Let(bs, f body)
    | IfThenElse(cond, thenExpr, elseExpr) ->
        IfThenElse(f cond, f thenExpr, f elseExpr)
    | Set(e, kind, v, r) ->
        match kind with
        | VarSet | FieldSet _ ->
            Set(f e, kind, f v, r)
        | ExprSet e2 -> Set(f e, ExprSet (f e2), f v, r)
    | Loop (kind, r) ->
        match kind with
        | While(e1, e2) -> Loop(While(f e1, f e2), r)
        | For(i, e1, e2, e3, up) -> Loop(For(i, f e1, f e2, f e3, up), r)
    | TryCatch(body, catch, finalizer) ->
        TryCatch(f body,
                 Option.map (fun (i, e) -> i, f e) catch,
                 Option.map f finalizer)
    | DecisionTree(expr, targets) ->
        let targets = targets |> List.map (fun (idents, v) -> idents, f v)
        DecisionTree(f expr, targets)
    | DecisionTreeSuccess(idx, boundValues, t) ->
        DecisionTreeSuccess(idx, List.map f boundValues, t)

let rec visitFromInsideOut f e =
    visit (visitFromInsideOut f) e |> f

let rec visitFromOutsideIn (f: Expr->Expr option) e =
    match f e with
    | Some e -> e
    | None ->
        visit (visitFromOutsideIn f) e

let getSubExpressions = function
    | IdentExpr _ | Debugger _ -> []
    | TypeCast(e,_) -> [e]
    | Import(e1,e2,_,_,_) -> [e1;e2]
    | Value kind ->
        match kind with
        | TypeInfo _ | Null _ | UnitConstant
        | BoolConstant _ | CharConstant _ | StringConstant _
        | NumberConstant _ | RegexConstant _ -> []
        | Enum(kind, _) ->
            match kind with
            | NumberEnum e -> [e]
            | StringEnum e -> [e]
        | NewOption(e, _) -> Option.toList e
        | NewTuple exprs -> exprs
        | NewArray(kind, _) ->
            match kind with
            | ArrayValues exprs -> exprs
            | ArrayAlloc e -> [e]
        | NewList(ht, _) ->
            match ht with Some(h,t) -> [h;t] | None -> []
        | NewRecord(exprs, _, _) -> exprs
        | NewErasedUnion(e, _) -> [e]
        | NewUnion(exprs, _, _, _) -> exprs
    | Test(e, _, _) -> [e]
    | DelayedResolution(kind, _, _) ->
        match kind with
        | Curry(e,_) -> [e]
        | AsPojo(e1, e2) -> [e1; e2]
    | Function(_, body, _) -> [body]
    | ObjectExpr(members, _, baseCall) ->
        let members = members |> List.collect (fun (ObjectMember(k,v,_)) -> [k;v])
        match baseCall with Some b -> b::members | None -> members
    | Operation(kind, _, _) ->
        match kind with
        | CurriedApply(callee, args) -> callee::args
        | Call(kind, info) ->
            let e1 =
                match kind with
                | ConstructorCall e -> [e]
                | StaticCall e -> [e]
                | InstanceCall memb -> Option.toList memb
            e1 @ (Option.toList info.ThisArg) @ info.Args
        | Emit(_, info) ->
            match info with Some info -> (Option.toList info.ThisArg) @ info.Args | None -> []
        | UnaryOperation(_, operand) -> [operand]
        | BinaryOperation(_, left, right) -> [left; right]
        | LogicalOperation(_, left, right) -> [left; right]
    | Get(e, kind, _, _) ->
        match kind with
        | ListHead | ListTail | OptionValue | TupleGet _ | UnionTag
        | UnionField _ | FieldGet _ -> [e]
        | ExprGet e2 -> [e; e2]
    | Throw(e, _, _) -> [e]
    | Sequential exprs -> exprs
    | Let(bs, body) -> (List.map snd bs) @ [body]
    | IfThenElse(cond, thenExpr, elseExpr) -> [cond; thenExpr; elseExpr]
    | Set(e, kind, v, _) ->
        match kind with
        | VarSet | FieldSet _ -> [e; v]
        | ExprSet e2 -> [e; e2; v]
    | Loop (kind, _) ->
        match kind with
        | While(e1, e2) -> [e1; e2]
        | For(_, e1, e2, e3, _) -> [e1; e2; e3]
    | TryCatch(body, catch, finalizer) ->
        match catch with
        | Some(_,c) -> body::c::(Option.toList finalizer)
        | None -> body::(Option.toList finalizer)
    | DecisionTree(expr, targets) -> expr::(List.map snd targets)
    | DecisionTreeSuccess(_, boundValues, _) -> boundValues

let rec deepExists f expr =
    f expr || (getSubExpressions expr |> List.exists (deepExists f))

let rec deepExistsWithShortcircuit f expr =
    match f expr with
    | Some res -> res
    | None -> getSubExpressions expr |> List.exists (deepExistsWithShortcircuit f)

let replaceValues replacements expr =
    if Map.isEmpty replacements
    then expr
    else expr |> visitFromInsideOut (function
        | IdentExpr id as e ->
            match Map.tryFind id.Name replacements with
            | Some e -> e
            | None -> e
        | e -> e)

let countReferences limit identName body =
    let mutable count = 0
    body |> deepExists (function
        | IdentExpr id2 when id2.Name = identName ->
            count <- count + 1
            count > limit
        | _ -> false) |> ignore
    count

let canInlineArg identName value body =
    // Don't erase expressions referenced 0 times, they may have side-effects
    not(hasDoubleEvalRisk value) || (countReferences 1 identName body = 1)

module private Transforms =
    let (|LambdaOrDelegate|_|) = function
        | Function(Lambda arg, body, name) -> Some([arg], body, name)
        | Function(Delegate args, body, name) -> Some(args, body, name)
        | _ -> None

    let lambdaBetaReduction (_: ICompiler) e =
        let applyArgs (args: Ident list) argExprs body =
            let bindings, replacements =
                (([], Map.empty), args, argExprs)
                |||> List.fold2 (fun (bindings, replacements) ident expr ->
                    if canInlineArg ident.Name expr body
                    then bindings, Map.add ident.Name expr replacements
                    else (ident, expr)::bindings, replacements)
            match bindings with
            | [] -> replaceValues replacements body
            | bindings -> Let(List.rev bindings, replaceValues replacements body)
        match e with
        | Operation(BinaryOperation(AST.BinaryPlus, Value(StringConstant str1), Value(StringConstant str2)),_,_) ->
            Value(StringConstant (str1 + str2))
        | Operation(CurriedApply(NestedLambda(args, body, None) as lambda, argExprs), _, _) ->
            if List.sameLength args argExprs
            then applyArgs args argExprs body
            else
                // Partial apply
                match List.length argExprs, lambda with
                | 1, Function(Lambda arg, body, _) ->
                    applyArgs [arg] argExprs body
                | 2, Function(Lambda arg1, Function(Lambda arg2, body,_),_) ->
                    applyArgs [arg1; arg2] argExprs body
                | 3, Function(Lambda arg1, Function(Lambda arg2, Function(Lambda arg3, body,_),_),_) ->
                    applyArgs [arg1; arg2; arg3] argExprs body
                | 4, Function(Lambda arg1, Function(Lambda arg2, Function(Lambda arg3, Function(Lambda arg4, body,_),_),_),_) ->
                    applyArgs [arg1; arg2; arg3; arg4] argExprs body
                | _ -> e
        | e -> e

    /// Tuples created when pattern matching multiple elements can usually be erased
    /// after the binding and lambda beta reduction
    let tupleBetaReduction (_: ICompiler) = function
        | Get(Value(NewTuple exprs), TupleGet index, _, _) -> List.item index exprs
        | e -> e

    let bindingBetaReduction (com: ICompiler) e =
        let isTuple = function
            | Tuple _ -> true
            | _ -> false
        match e with
        // Don't try to optimize bindings with multiple ident-value pairs as they can reference each other
        | Let([ident, value], letBody) when not ident.IsMutable ->
            match value with
            // Erase bindings for getters of compiler-generated tuples (as in pattern matching or lambdas destructuring tuple args)
            | Get(IdentExpr tupleIdent, TupleGet _, _, _) as value when tupleIdent.IsCompilerGenerated ->
                replaceValues (Map [ident.Name, value]) letBody
            | Function(args, funBody, currentName) when ident.IsCompilerGenerated
                                                    && (countReferences 1 ident.Name letBody <= 1) ->
                if Option.isSome currentName then
                    sprintf "Unexpected named function when erasing binding (%s > %s)" currentName.Value ident.Name
                    |> addWarning com [] ident.Range
                let replacement = Function(args, funBody, Some ident.Name)
                replaceValues (Map [ident.Name, replacement]) letBody
            | value when ident.IsCompilerGenerated
                    // Don't erase the binding if the compiler-generated ident is a tuple, because the getters
                    // will be erased later (see above) and there's a risk the expression gets totally removed
                    && not(isTuple ident.Type)
                    && canInlineArg ident.Name value letBody ->
                replaceValues (Map [ident.Name, value]) letBody
            | _ -> e
        | e -> e

    /// Returns arity of lambda (or lambda option) types
    let getLambdaTypeArity t =
        let rec getLambdaTypeArity acc = function
            | FunctionType(LambdaType _, returnType) ->
                getLambdaTypeArity (acc + 1) returnType
            | _ -> acc
        match t with
        | FunctionType(LambdaType _, returnType)
        | Option(FunctionType(LambdaType _, returnType)) ->
            getLambdaTypeArity 1 returnType
        | _ -> 0

    let curryIdentsInBody replacements body =
        visitFromInsideOut (function
            | IdentExpr id as e ->
                match Map.tryFind id.Name replacements with
                | Some arity -> DelayedResolution(Curry(e, arity), id.Type, id.Range)
                | None -> e
            | e -> e) body

    let uncurryIdentsAndReplaceInBody (idents: Ident list) body =
        let replacements =
            (Map.empty, idents) ||> List.fold (fun replacements id ->
                let arity = getLambdaTypeArity id.Type
                if arity > 1
                then Map.add id.Name arity replacements
                else replacements)
        if Map.isEmpty replacements
        then body
        else curryIdentsInBody replacements body

    let uncurryExpr arity expr =
        let matches arity arity2 =
            match arity with
            // TODO: check cases where arity <> arity2
            | Some arity -> arity = arity2
            // Remove currying for dynamic operations (no arity)
            | None -> true
        match expr, expr with
        | MaybeCasted(LambdaUncurriedAtCompileTime arity lambda), _ -> lambda
        | _, DelayedResolution(Curry(innerExpr, arity2),_,_)
            when matches arity arity2 -> innerExpr
        | _, Get(DelayedResolution(Curry(innerExpr, arity2),_,_), OptionValue, t, r)
            when matches arity arity2 -> Get(innerExpr, OptionValue, t, r)
        | _, Value(NewOption(Some(DelayedResolution(Curry(innerExpr, arity2),_,_)),r))
            when matches arity arity2 -> Value(NewOption(Some(innerExpr),r))
        | _ ->
            match arity with
            | Some arity -> Replacements.uncurryExprAtRuntime arity expr
            | None -> expr

    // For function arguments check if the arity of their own function arguments is expected or not
    // TODO: Do we need to do this recursively, and check options and delegates too?
    let checkSubArguments com expectedType (expr: Expr) =
        match expectedType, expr with
        | NestedLambdaType(expectedArgs,_), ExprType(NestedLambdaType(actualArgs, returnType))
                when List.sameLength expectedArgs actualArgs ->
            let _, replacements =
                ((0, Map.empty), expectedArgs, actualArgs)
                |||> List.fold2 (fun (index, replacements) expected actual ->
                    match expected, actual with
                    | GenericParam _, NestedLambdaType(args2, _) when List.isMultiple args2 ->
                        index + 1, Map.add index (0, List.length args2) replacements
                    | NestedLambdaType(args1, _), NestedLambdaType(args2, _)
                            when not(List.sameLength args1 args2) ->
                        let expectedArity = List.length args1
                        let actualArity = List.length args2
                        index + 1, Map.add index (expectedArity, actualArity) replacements
                    | _ -> index + 1, replacements)
            if Map.isEmpty replacements
            then expr
            else
                let args = List.map (fun _ -> makeIdentUnique com "arg") actualArgs
                let argExprs =
                    args |> List.mapi (fun i arg ->
                        let argExpr = IdentExpr arg
                        match Map.tryFind i replacements with
                        | Some (expectedArity, actualArity) ->
                            let argExpr =
                                if expectedArity > 1
                                then Replacements.curryExprAtRuntime expectedArity argExpr
                                else argExpr
                            Replacements.uncurryExprAtRuntime actualArity argExpr
                        | None -> argExpr)
                let body = Operation(CurriedApply(expr, argExprs), returnType, None)
                makeLambda args body
        | _ -> expr

    let uncurryArgs com argTypes args =
        let mapArgs f argTypes args =
            let rec mapArgsInner f acc argTypes args =
                match argTypes, args with
                | head1::tail1, head2::tail2 ->
                    let x = f head1 head2
                    mapArgsInner f (x::acc) tail1 tail2
                | [], args2 -> (List.rev acc)@args2
                | _, [] -> List.rev acc
            mapArgsInner f [] argTypes args
        match argTypes with
        | NoUncurrying | Typed [] -> args // Do nothing
        | Typed argTypes ->
            (argTypes, args) ||> mapArgs (fun expectedType arg ->
                let arg = checkSubArguments com expectedType arg
                let arity = getLambdaTypeArity expectedType
                if arity > 1
                then uncurryExpr (Some arity) arg
                else arg)
        | AutoUncurrying -> List.map (uncurryExpr None) args

    let uncurryInnerFunctions (_: ICompiler) e =
        let curryIdentInBody identName (args: Ident list) body =
            curryIdentsInBody (Map [identName, List.length args]) body
        match e with
        | Let([ident, NestedLambda(args, fnBody, _)], letBody) when List.isMultiple args ->
            let fnBody = curryIdentInBody ident.Name args fnBody
            let letBody = curryIdentInBody ident.Name args letBody
            Let([ident, Function(Delegate args, fnBody, None)], letBody)
        // Anonymous lambda immediately applied
        | Operation(CurriedApply((NestedLambda(args, fnBody, Some name)), argExprs), t, r)
                        when List.isMultiple args && List.sameLength args argExprs ->
            let fnBody = curryIdentInBody name args fnBody
            let info = argInfo None argExprs (args |> List.map (fun a -> a.Type) |> Typed)
            Function(Delegate args, fnBody, Some name)
            |> staticCall r t info
        | e -> e

    let propagateUncurryingThroughLets (_: ICompiler) = function
        | Let(identsAndValues, body) ->
            let identsAndValues, replacements =
                (identsAndValues, ([], Map.empty)) ||> List.foldBack (fun (id, value) (identsAndValues, replacements) ->
                    match value with
                    | DelayedResolution(Curry(innerExpr, arity),_,_) ->
                        (id, innerExpr)::identsAndValues, Map.add id.Name arity replacements
                    | Get(DelayedResolution(Curry(innerExpr, arity),_,_), OptionValue, t, r) ->
                        (id, Get(innerExpr, OptionValue, t, r))::identsAndValues, Map.add id.Name arity replacements
                    | Value(NewOption(Some(DelayedResolution(Curry(innerExpr, arity),_,_)),r)) ->
                        (id, Value(NewOption(Some(innerExpr),r)))::identsAndValues, Map.add id.Name arity replacements
                    | _ -> (id, value)::identsAndValues, replacements)
            if Map.isEmpty replacements
            then Let(identsAndValues, body)
            else Let(identsAndValues, curryIdentsInBody replacements body)
        | e -> e

    let uncurryReceivedArgs (_: ICompiler) e =
        match e with
        | Function(Lambda arg, body, name) ->
            let body = uncurryIdentsAndReplaceInBody [arg] body
            Function(Lambda arg, body, name)
        | Function(Delegate args, body, name) ->
            let body = uncurryIdentsAndReplaceInBody args body
            Function(Delegate args, body, name)
        // Uncurry also values received from getters
        | Get(_, (FieldGet(_,_,fieldType) | UnionField(_,_,fieldType)), t, r) ->
            let arity = getLambdaTypeArity fieldType
            if arity > 1
            then DelayedResolution(Curry(e, arity), t, r)
            else e
        | e -> e

    let uncurrySendingArgs (com: ICompiler) e =
        let uncurryConsArgs args (fields: seq<FSharpField>) =
            let argTypes =
                fields
                |> Seq.map (fun fi -> FSharp2Fable.TypeHelpers.makeType com Map.empty fi.FieldType)
                |> Seq.toList
            uncurryArgs com (Typed argTypes) args
        match e with
        | Operation(Call(kind, info), t, r) ->
            let info = { info with Args = uncurryArgs com info.SignatureArgTypes info.Args }
            Operation(Call(kind, info), t, r)
        | Operation(CurriedApply(callee, args), t, r) ->
            match callee.Type with
            | NestedLambdaType(argTypes, _) ->
                Operation(CurriedApply(callee, uncurryArgs com (Typed argTypes) args), t, r)
            | _ -> e
        | Operation(Emit(macro, Some info), t, r) ->
            let info = { info with Args = uncurryArgs com info.SignatureArgTypes info.Args }
            Operation(Emit(macro, Some info), t, r)
        // Uncurry also values in setters or new record/union/tuple
        | Value(NewRecord(args, ent, genArgs)) ->
            let args = uncurryConsArgs args ent.FSharpFields
            Value(NewRecord(args, ent, genArgs))
        | Value(NewUnion(args, uci, ent, genArgs)) ->
            let args = uncurryConsArgs args uci.UnionCaseFields
            Value(NewUnion(args, uci, ent, genArgs))
        | Set(e, FieldSet(fieldName, fieldType), value, r) ->
            let value = uncurryArgs com (Typed [fieldType]) [value]
            Set(e, FieldSet(fieldName, fieldType), List.head value, r)
        | e -> e

    let rec uncurryApplications (com: ICompiler) e =
        let uncurryApply r t applied args uncurriedArity =
            let argsLen = List.length args
            if uncurriedArity = argsLen then
                let info = argInfo None args AutoUncurrying
                staticCall r t info applied |> Some
            else
                Replacements.partialApplyAtRuntime t (uncurriedArity - argsLen) applied args |> Some
        match e with
        | NestedApply(applied, args, t, r) ->
            let applied = visitFromOutsideIn (uncurryApplications com) applied
            let args = args |> List.map (visitFromOutsideIn (uncurryApplications com))
            match applied with
            | DelayedResolution(Curry(applied, uncurriedArity),_,_) ->
                uncurryApply r t applied args uncurriedArity
            | Get(DelayedResolution(Curry(applied, uncurriedArity),_,_), OptionValue, t2, r2) ->
                uncurryApply r t (Get(applied, OptionValue, t2, r2)) args uncurriedArity
            | _ -> Operation(CurriedApply(applied, args), t, r) |> Some
        | _ -> None

    // Unwrapping functions (e.g `(x, y) => f(x, y)` --> `f`) is important for readability
    // and also in some situations, like passing fucntions as props to React components
    // See https://blog.vbfox.net/2018/02/08/fable-react-2-optimizing-react.html
    let unwrapFunctions (_: ICompiler) e =
        let notReferencedInExpr (args: Ident list) (e: Expr) =
            args |> List.exists (fun a ->
                let identName = a.Name
                e |> deepExists (function
                    | IdentExpr id -> id.Name = identName
                    | _ -> false)) |> not
        let sameArgs args1 args2 =
            List.sameLength args1 args2
            && List.forall2 (fun (a1: Ident) -> function
                | IdentExpr a2 -> a1.Name = a2.Name
                | _ -> false) args1 args2
        let unwrapFunctionsInner = function
            // TODO: When Option.isSome info.ThisArg we could bind it (also for InstanceCall)
            | LambdaOrDelegate(args, Operation(Call(StaticCall funcExpr, info), _, _), _)
                when Option.isNone info.ThisArg
                    // Make sure first argument is not `this`, because it wil be removed
                    // from args in Fable2Babel.transformObjectExpr (see #1434).
                    && List.tryHead args |> Option.map (fun x -> x.IsThisArgDeclaration) |> Option.defaultValue false |> not
                    && sameArgs args info.Args
                    // Check the args are not used in the expression. See #1484
                    && notReferencedInExpr args funcExpr
                -> funcExpr
            | e -> e
        match e with
        // We cannot apply the unwrap optimization to the outmost function,
        // as we would be losing the ValueDeclarationInfo
        | Function(kind, body, name) -> Function(kind, visitFromInsideOut unwrapFunctionsInner body, name)
        | e -> visitFromInsideOut unwrapFunctionsInner e

open Transforms

// ATTENTION: Order of transforms matters for optimizations
// TODO: Optimize binary operations with numerical or string literals
let optimizations =
    [ // First apply beta reduction
      fun com e -> visitFromInsideOut (bindingBetaReduction com) e
      fun com e -> visitFromInsideOut (lambdaBetaReduction com) e
      fun com e -> visitFromInsideOut (tupleBetaReduction com) e
      // Then apply uncurry optimizations
      fun com e -> visitFromInsideOut (uncurryReceivedArgs com) e
      fun com e -> visitFromInsideOut (uncurryInnerFunctions com) e
      fun com e -> visitFromInsideOut (propagateUncurryingThroughLets com) e
      fun com e -> visitFromInsideOut (uncurrySendingArgs com) e
      // uncurryApplications must come after uncurrySendingArgs as it erases argument type info
      fun com e -> visitFromOutsideIn (uncurryApplications com) e
      // Don't traverse the expression for the unwrap function optimization
      unwrapFunctions
    ]

let optimizeExpr (com: ICompiler) e =
    List.fold (fun e f -> f com e) e optimizations

let rec optimizeDeclaration (com: ICompiler) = function
    | ActionDeclaration expr ->
        ActionDeclaration(optimizeExpr com expr)
    | ValueDeclaration(value, info) ->
        ValueDeclaration(optimizeExpr com value, info)
    | ConstructorDeclaration kind ->
        let kind =
            match kind with
            | ClassImplicitConstructor info ->
                let args, body =
                    // Create a function so the arguments can be uncurried, see #1441
                    Function(Delegate info.Arguments, info.Body, None)
                    |> optimizeExpr com
                    |> function
                        | Function(Delegate args, body, _) -> args, body
                        | _ ->
                            "Unexpected result when optimizing ClassImplicitConstructor, please report"
                            |> addWarning com [] None
                            info.Arguments, info.Body
                ClassImplicitConstructor { info with Arguments = args; Body = body }
            | kind -> kind
        ConstructorDeclaration kind
    | AttachedMemberDeclaration(args, body, info) ->
        AttachedMemberDeclaration(args, optimizeExpr com body, info)

let optimizeFile (com: ICompiler) (file: File) =
    let newDecls = List.map (optimizeDeclaration com) file.Declarations
    File(file.SourcePath, newDecls, usedVarNames=file.UsedVarNames, inlineDependencies=file.InlineDependencies)
