﻿// This is a generated file; the original input is '/src/fsharp/FSComp.txt'
namespace FSComp
type internal SR private() =
    /// The namespace '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:4)
    static member undefinedNameNamespace(a0 : System.String) = (sprintf "The namespace '%s' is not defined." a0)
    /// The namespace or module '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:5)
    static member undefinedNameNamespaceOrModule(a0 : System.String) = (sprintf "The namespace or module '%s' is not defined." a0)
    /// The field, constructor or member '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:6)
    static member undefinedNameFieldConstructorOrMember(a0 : System.String) = (sprintf "The field, constructor or member '%s' is not defined." a0)
    /// The value, constructor, namespace or type '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:7)
    static member undefinedNameValueConstructorNamespaceOrType(a0 : System.String) = (sprintf "The value, constructor, namespace or type '%s' is not defined." a0)
    /// The value or constructor '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:8)
    static member undefinedNameValueOfConstructor(a0 : System.String) = (sprintf "The value or constructor '%s' is not defined." a0)
    /// The value, namespace, type or module '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:9)
    static member undefinedNameValueNamespaceTypeOrModule(a0 : System.String) = (sprintf "The value, namespace, type or module '%s' is not defined." a0)
    /// The constructor, module or namespace '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:10)
    static member undefinedNameConstructorModuleOrNamespace(a0 : System.String) = (sprintf "The constructor, module or namespace '%s' is not defined." a0)
    /// The type '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:11)
    static member undefinedNameType(a0 : System.String) = (sprintf "The type '%s' is not defined." a0)
    /// The type '%s' is not defined in '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:12)
    static member undefinedNameTypeIn(a0 : System.String, a1 : System.String) = (sprintf "The type '%s' is not defined in '%s'." a0 a1)
    /// The record label or namespace '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:13)
    static member undefinedNameRecordLabelOrNamespace(a0 : System.String) = (sprintf "The record label or namespace '%s' is not defined." a0)
    /// The record label '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:14)
    static member undefinedNameRecordLabel(a0 : System.String) = (sprintf "The record label '%s' is not defined." a0)
    /// Maybe you want one of the following:
    /// (Originally from /src/fsharp/FSComp.txt:15)
    static member undefinedNameSuggestionsIntro() = (sprintf "Maybe you want one of the following:" )
    /// The type parameter %s is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:16)
    static member undefinedNameTypeParameter(a0 : System.String) = (sprintf "The type parameter %s is not defined." a0)
    /// The pattern discriminator '%s' is not defined.
    /// (Originally from /src/fsharp/FSComp.txt:17)
    static member undefinedNamePatternDiscriminator(a0 : System.String) = (sprintf "The pattern discriminator '%s' is not defined." a0)
    /// Replace with '%s'
    /// (Originally from /src/fsharp/FSComp.txt:18)
    static member replaceWithSuggestion(a0 : System.String) = (sprintf "Replace with '%s'" a0)
    /// Add . for indexer access.
    /// (Originally from /src/fsharp/FSComp.txt:19)
    static member addIndexerDot() = (sprintf "Add . for indexer access." )
    /// All elements of a list must be of the same type as the first element, which here is '%s'. This element has type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:20)
    static member listElementHasWrongType(a0 : System.String, a1 : System.String) = (sprintf "All elements of a list must be of the same type as the first element, which here is '%s'. This element has type '%s'." a0 a1)
    /// All elements of an array must be of the same type as the first element, which here is '%s'. This element has type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:21)
    static member arrayElementHasWrongType(a0 : System.String, a1 : System.String) = (sprintf "All elements of an array must be of the same type as the first element, which here is '%s'. This element has type '%s'." a0 a1)
    /// This 'if' expression is missing an 'else' branch. Because 'if' is an expression, and not a statement, add an 'else' branch which also returns a value of type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:22)
    static member missingElseBranch(a0 : System.String) = (sprintf "This 'if' expression is missing an 'else' branch. Because 'if' is an expression, and not a statement, add an 'else' branch which also returns a value of type '%s'." a0)
    /// The 'if' expression needs to have type '%s' to satisfy context type requirements. It currently has type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:23)
    static member ifExpression(a0 : System.String, a1 : System.String) = (sprintf "The 'if' expression needs to have type '%s' to satisfy context type requirements. It currently has type '%s'." a0 a1)
    /// All branches of an 'if' expression must return values of the same type as the first branch, which here is '%s'. This branch returns a value of type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:24)
    static member elseBranchHasWrongType(a0 : System.String, a1 : System.String) = (sprintf "All branches of an 'if' expression must return values of the same type as the first branch, which here is '%s'. This branch returns a value of type '%s'." a0 a1)
    /// All branches of a pattern match expression must return values of the same type as the first branch, which here is '%s'. This branch returns a value of type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:25)
    static member followingPatternMatchClauseHasWrongType(a0 : System.String, a1 : System.String) = (sprintf "All branches of a pattern match expression must return values of the same type as the first branch, which here is '%s'. This branch returns a value of type '%s'." a0 a1)
    /// A pattern match guard must be of type 'bool', but this 'when' expression is of type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:26)
    static member patternMatchGuardIsNotBool(a0 : System.String) = (sprintf "A pattern match guard must be of type 'bool', but this 'when' expression is of type '%s'." a0)
    /// A ';' is used to separate field values in records. Consider replacing ',' with ';'.
    /// (Originally from /src/fsharp/FSComp.txt:27)
    static member commaInsteadOfSemicolonInRecord() = (sprintf "A ';' is used to separate field values in records. Consider replacing ',' with ';'." )
    /// The '!' operator is used to dereference a ref cell. Consider using 'not expr' here.
    /// (Originally from /src/fsharp/FSComp.txt:28)
    static member derefInsteadOfNot() = (sprintf "The '!' operator is used to dereference a ref cell. Consider using 'not expr' here." )
    /// The non-generic type '%s' does not expect any type arguments, but here is given %d type argument(s)
    /// (Originally from /src/fsharp/FSComp.txt:29)
    static member buildUnexpectedTypeArgs(a0 : System.String, a1 : System.Int32) = (sprintf "The non-generic type '%s' does not expect any type arguments, but here is given %d type argument(s)" a0 a1)
    /// Consider using 'return!' instead of 'return'.
    /// (Originally from /src/fsharp/FSComp.txt:30)
    static member returnUsedInsteadOfReturnBang() = (sprintf "Consider using 'return!' instead of 'return'." )
    /// Consider using 'yield!' instead of 'yield'.
    /// (Originally from /src/fsharp/FSComp.txt:31)
    static member yieldUsedInsteadOfYieldBang() = (sprintf "Consider using 'yield!' instead of 'yield'." )
    /// \nA tuple type is required for one or more arguments. Consider wrapping the given arguments in additional parentheses or review the definition of the interface.
    /// (Originally from /src/fsharp/FSComp.txt:32)
    static member tupleRequiredInAbstractMethod() = (sprintf "\nA tuple type is required for one or more arguments. Consider wrapping the given arguments in additional parentheses or review the definition of the interface." )
    /// Invalid warning number '%s'
    /// (Originally from /src/fsharp/FSComp.txt:33)
    static member buildInvalidWarningNumber(a0 : System.String) = (203, sprintf "Invalid warning number '%s'" a0)
    /// Invalid version string '%s'
    /// (Originally from /src/fsharp/FSComp.txt:34)
    static member buildInvalidVersionString(a0 : System.String) = (204, sprintf "Invalid version string '%s'" a0)
    /// Invalid version file '%s'
    /// (Originally from /src/fsharp/FSComp.txt:35)
    static member buildInvalidVersionFile(a0 : System.String) = (205, sprintf "Invalid version file '%s'" a0)
    /// Microsoft (R) F# Compiler version %s
    /// (Originally from /src/fsharp/FSComp.txt:36)
    static member buildProductName(a0 : System.String) = (sprintf "Microsoft (R) F# Compiler version %s" a0)
    /// F# Compiler for F# %s
    /// (Originally from /src/fsharp/FSComp.txt:37)
    static member buildProductNameCommunity(a0 : System.String) = (sprintf "F# Compiler for F# %s" a0)
    /// Problem with filename '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:38)
    static member buildProblemWithFilename(a0 : System.String, a1 : System.String) = (206, sprintf "Problem with filename '%s': %s" a0 a1)
    /// No inputs specified
    /// (Originally from /src/fsharp/FSComp.txt:39)
    static member buildNoInputsSpecified() = (207, sprintf "No inputs specified" )
    /// The '--pdb' option requires the '--debug' option to be used
    /// (Originally from /src/fsharp/FSComp.txt:40)
    static member buildPdbRequiresDebug() = (209, sprintf "The '--pdb' option requires the '--debug' option to be used" )
    /// The search directory '%s' is invalid
    /// (Originally from /src/fsharp/FSComp.txt:41)
    static member buildInvalidSearchDirectory(a0 : System.String) = (210, sprintf "The search directory '%s' is invalid" a0)
    /// The search directory '%s' could not be found
    /// (Originally from /src/fsharp/FSComp.txt:42)
    static member buildSearchDirectoryNotFound(a0 : System.String) = (211, sprintf "The search directory '%s' could not be found" a0)
    /// '%s' is not a valid filename
    /// (Originally from /src/fsharp/FSComp.txt:43)
    static member buildInvalidFilename(a0 : System.String) = (212, sprintf "'%s' is not a valid filename" a0)
    /// '%s' is not a valid assembly name
    /// (Originally from /src/fsharp/FSComp.txt:44)
    static member buildInvalidAssemblyName(a0 : System.String) = (213, sprintf "'%s' is not a valid assembly name" a0)
    /// Unrecognized privacy setting '%s' for managed resource, valid options are 'public' and 'private'
    /// (Originally from /src/fsharp/FSComp.txt:45)
    static member buildInvalidPrivacy(a0 : System.String) = (214, sprintf "Unrecognized privacy setting '%s' for managed resource, valid options are 'public' and 'private'" a0)
    /// Multiple references to '%s.dll' are not permitted
    /// (Originally from /src/fsharp/FSComp.txt:46)
    static member buildMultipleReferencesNotAllowed(a0 : System.String) = (215, sprintf "Multiple references to '%s.dll' are not permitted" a0)
    /// Unable to read assembly '%s'
    /// (Originally from /src/fsharp/FSComp.txt:47)
    static member buildCannotReadAssembly(a0 : System.String) = (218, sprintf "Unable to read assembly '%s'" a0)
    /// Assembly resolution failure at or near this location
    /// (Originally from /src/fsharp/FSComp.txt:48)
    static member buildAssemblyResolutionFailed() = (220, sprintf "Assembly resolution failure at or near this location" )
    /// The declarations in this file will be placed in an implicit module '%s' based on the file name '%s'. However this is not a valid F# identifier, so the contents will not be accessible from other files. Consider renaming the file or adding a 'module' or 'namespace' declaration at the top of the file.
    /// (Originally from /src/fsharp/FSComp.txt:49)
    static member buildImplicitModuleIsNotLegalIdentifier(a0 : System.String, a1 : System.String) = (221, sprintf "The declarations in this file will be placed in an implicit module '%s' based on the file name '%s'. However this is not a valid F# identifier, so the contents will not be accessible from other files. Consider renaming the file or adding a 'module' or 'namespace' declaration at the top of the file." a0 a1)
    /// Files in libraries or multiple-file applications must begin with a namespace or module declaration, e.g. 'namespace SomeNamespace.SubNamespace' or 'module SomeNamespace.SomeModule'. Only the last source file of an application may omit such a declaration.
    /// (Originally from /src/fsharp/FSComp.txt:50)
    static member buildMultiFileRequiresNamespaceOrModule() = (222, sprintf "Files in libraries or multiple-file applications must begin with a namespace or module declaration, e.g. 'namespace SomeNamespace.SubNamespace' or 'module SomeNamespace.SomeModule'. Only the last source file of an application may omit such a declaration." )
    /// Files in libraries or multiple-file applications must begin with a namespace or module declaration. When using a module declaration at the start of a file the '=' sign is not allowed. If this is a top-level module, consider removing the = to resolve this error.
    /// (Originally from /src/fsharp/FSComp.txt:51)
    static member noEqualSignAfterModule() = (222, sprintf "Files in libraries or multiple-file applications must begin with a namespace or module declaration. When using a module declaration at the start of a file the '=' sign is not allowed. If this is a top-level module, consider removing the = to resolve this error." )
    /// This file contains multiple declarations of the form 'module SomeNamespace.SomeModule'. Only one declaration of this form is permitted in a file. Change your file to use an initial namespace declaration and/or use 'module ModuleName = ...' to define your modules.
    /// (Originally from /src/fsharp/FSComp.txt:52)
    static member buildMultipleToplevelModules() = (223, sprintf "This file contains multiple declarations of the form 'module SomeNamespace.SomeModule'. Only one declaration of this form is permitted in a file. Change your file to use an initial namespace declaration and/or use 'module ModuleName = ...' to define your modules." )
    /// Option requires parameter: %s
    /// (Originally from /src/fsharp/FSComp.txt:53)
    static member buildOptionRequiresParameter(a0 : System.String) = (224, sprintf "Option requires parameter: %s" a0)
    /// Source file '%s' could not be found
    /// (Originally from /src/fsharp/FSComp.txt:54)
    static member buildCouldNotFindSourceFile(a0 : System.String) = (225, sprintf "Source file '%s' could not be found" a0)
    /// The file extension of '%s' is not recognized. Source files must have extension .fs, .fsi, .fsx, .fsscript, .ml or .mli.
    /// (Originally from /src/fsharp/FSComp.txt:55)
    static member buildInvalidSourceFileExtension(a0 : System.String) = (226, sprintf "The file extension of '%s' is not recognized. Source files must have extension .fs, .fsi, .fsx, .fsscript, .ml or .mli." a0)
    /// Could not resolve assembly '%s'
    /// (Originally from /src/fsharp/FSComp.txt:56)
    static member buildCouldNotResolveAssembly(a0 : System.String) = (227, sprintf "Could not resolve assembly '%s'" a0)
    /// Could not resolve assembly '%s' required by '%s'
    /// (Originally from /src/fsharp/FSComp.txt:57)
    static member buildCouldNotResolveAssemblyRequiredByFile(a0 : System.String, a1 : System.String) = (228, sprintf "Could not resolve assembly '%s' required by '%s'" a0 a1)
    /// Error opening binary file '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:58)
    static member buildErrorOpeningBinaryFile(a0 : System.String, a1 : System.String) = (229, sprintf "Error opening binary file '%s': %s" a0 a1)
    /// The F#-compiled DLL '%s' needs to be recompiled to be used with this version of F#
    /// (Originally from /src/fsharp/FSComp.txt:59)
    static member buildDifferentVersionMustRecompile(a0 : System.String) = (231, sprintf "The F#-compiled DLL '%s' needs to be recompiled to be used with this version of F#" a0)
    /// Invalid directive. Expected '#I \"<path>\"'.
    /// (Originally from /src/fsharp/FSComp.txt:60)
    static member buildInvalidHashIDirective() = (232, sprintf "Invalid directive. Expected '#I \"<path>\"'." )
    /// Invalid directive. Expected '#r \"<file-or-assembly>\"'.
    /// (Originally from /src/fsharp/FSComp.txt:61)
    static member buildInvalidHashrDirective() = (233, sprintf "Invalid directive. Expected '#r \"<file-or-assembly>\"'." )
    /// Invalid directive. Expected '#load \"<file>\" ... \"<file>\"'.
    /// (Originally from /src/fsharp/FSComp.txt:62)
    static member buildInvalidHashloadDirective() = (234, sprintf "Invalid directive. Expected '#load \"<file>\" ... \"<file>\"'." )
    /// Invalid directive. Expected '#time', '#time \"on\"' or '#time \"off\"'.
    /// (Originally from /src/fsharp/FSComp.txt:63)
    static member buildInvalidHashtimeDirective() = (235, sprintf "Invalid directive. Expected '#time', '#time \"on\"' or '#time \"off\"'." )
    /// Directives inside modules are ignored
    /// (Originally from /src/fsharp/FSComp.txt:64)
    static member buildDirectivesInModulesAreIgnored() = (236, sprintf "Directives inside modules are ignored" )
    /// A signature for the file or module '%s' has already been specified
    /// (Originally from /src/fsharp/FSComp.txt:65)
    static member buildSignatureAlreadySpecified(a0 : System.String) = (237, sprintf "A signature for the file or module '%s' has already been specified" a0)
    /// An implementation of file or module '%s' has already been given. Compilation order is significant in F# because of type inference. You may need to adjust the order of your files to place the signature file before the implementation. In Visual Studio files are type-checked in the order they appear in the project file, which can be edited manually or adjusted using the solution explorer.
    /// (Originally from /src/fsharp/FSComp.txt:66)
    static member buildImplementationAlreadyGivenDetail(a0 : System.String) = (238, sprintf "An implementation of file or module '%s' has already been given. Compilation order is significant in F# because of type inference. You may need to adjust the order of your files to place the signature file before the implementation. In Visual Studio files are type-checked in the order they appear in the project file, which can be edited manually or adjusted using the solution explorer." a0)
    /// An implementation of the file or module '%s' has already been given
    /// (Originally from /src/fsharp/FSComp.txt:67)
    static member buildImplementationAlreadyGiven(a0 : System.String) = (239, sprintf "An implementation of the file or module '%s' has already been given" a0)
    /// The signature file '%s' does not have a corresponding implementation file. If an implementation file exists then check the 'module' and 'namespace' declarations in the signature and implementation files match.
    /// (Originally from /src/fsharp/FSComp.txt:68)
    static member buildSignatureWithoutImplementation(a0 : System.String) = (240, sprintf "The signature file '%s' does not have a corresponding implementation file. If an implementation file exists then check the 'module' and 'namespace' declarations in the signature and implementation files match." a0)
    /// '%s' is not a valid integer argument
    /// (Originally from /src/fsharp/FSComp.txt:69)
    static member buildArgInvalidInt(a0 : System.String) = (241, sprintf "'%s' is not a valid integer argument" a0)
    /// '%s' is not a valid floating point argument
    /// (Originally from /src/fsharp/FSComp.txt:70)
    static member buildArgInvalidFloat(a0 : System.String) = (242, sprintf "'%s' is not a valid floating point argument" a0)
    /// Unrecognized option: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:71)
    static member buildUnrecognizedOption(a0 : System.String) = (243, sprintf "Unrecognized option: '%s'" a0)
    /// Invalid module or namespace name
    /// (Originally from /src/fsharp/FSComp.txt:72)
    static member buildInvalidModuleOrNamespaceName() = (244, sprintf "Invalid module or namespace name" )
    /// Error reading/writing metadata for the F# compiled DLL '%s'. Was the DLL compiled with an earlier version of the F# compiler? (error: '%s').
    /// (Originally from /src/fsharp/FSComp.txt:73)
    static member pickleErrorReadingWritingMetadata(a0 : System.String, a1 : System.String) = (sprintf "Error reading/writing metadata for the F# compiled DLL '%s'. Was the DLL compiled with an earlier version of the F# compiler? (error: '%s')." a0 a1)
    /// The type/module '%s' is not a concrete module or type
    /// (Originally from /src/fsharp/FSComp.txt:74)
    static member tastTypeOrModuleNotConcrete(a0 : System.String) = (245, sprintf "The type/module '%s' is not a concrete module or type" a0)
    /// The type '%s' has an inline assembly code representation
    /// (Originally from /src/fsharp/FSComp.txt:75)
    static member tastTypeHasAssemblyCodeRepresentation(a0 : System.String) = (sprintf "The type '%s' has an inline assembly code representation" a0)
    /// A namespace and a module named '%s' both occur in two parts of this assembly
    /// (Originally from /src/fsharp/FSComp.txt:76)
    static member tastNamespaceAndModuleWithSameNameInAssembly(a0 : System.String) = (247, sprintf "A namespace and a module named '%s' both occur in two parts of this assembly" a0)
    /// Two modules named '%s' occur in two parts of this assembly
    /// (Originally from /src/fsharp/FSComp.txt:77)
    static member tastTwoModulesWithSameNameInAssembly(a0 : System.String) = (248, sprintf "Two modules named '%s' occur in two parts of this assembly" a0)
    /// Two type definitions named '%s' occur in namespace '%s' in two parts of this assembly
    /// (Originally from /src/fsharp/FSComp.txt:78)
    static member tastDuplicateTypeDefinitionInAssembly(a0 : System.String, a1 : System.String) = (249, sprintf "Two type definitions named '%s' occur in namespace '%s' in two parts of this assembly" a0 a1)
    /// A module and a type definition named '%s' occur in namespace '%s' in two parts of this assembly
    /// (Originally from /src/fsharp/FSComp.txt:79)
    static member tastConflictingModuleAndTypeDefinitionInAssembly(a0 : System.String, a1 : System.String) = (250, sprintf "A module and a type definition named '%s' occur in namespace '%s' in two parts of this assembly" a0 a1)
    /// Invalid member signature encountered because of an earlier error
    /// (Originally from /src/fsharp/FSComp.txt:80)
    static member tastInvalidMemberSignature() = (251, sprintf "Invalid member signature encountered because of an earlier error" )
    /// This value does not have a valid property setter type
    /// (Originally from /src/fsharp/FSComp.txt:81)
    static member tastValueDoesNotHaveSetterType() = (252, sprintf "This value does not have a valid property setter type" )
    /// Invalid form for a property getter. At least one '()' argument is required when using the explicit syntax.
    /// (Originally from /src/fsharp/FSComp.txt:82)
    static member tastInvalidFormForPropertyGetter() = (253, sprintf "Invalid form for a property getter. At least one '()' argument is required when using the explicit syntax." )
    /// Invalid form for a property setter. At least one argument is required.
    /// (Originally from /src/fsharp/FSComp.txt:83)
    static member tastInvalidFormForPropertySetter() = (254, sprintf "Invalid form for a property setter. At least one argument is required." )
    /// Unexpected use of a byref-typed variable
    /// (Originally from /src/fsharp/FSComp.txt:84)
    static member tastUnexpectedByRef() = (255, sprintf "Unexpected use of a byref-typed variable" )
    /// A value must be mutable in order to mutate the contents or take the address of a value type, e.g. 'let mutable x = ...'
    /// (Originally from /src/fsharp/FSComp.txt:85)
    static member tastValueMustBeMutable() = (256, sprintf "A value must be mutable in order to mutate the contents or take the address of a value type, e.g. 'let mutable x = ...'" )
    /// Invalid mutation of a constant expression. Consider copying the expression to a mutable local, e.g. 'let mutable x = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:86)
    static member tastInvalidMutationOfConstant() = (257, sprintf "Invalid mutation of a constant expression. Consider copying the expression to a mutable local, e.g. 'let mutable x = ...'." )
    /// The value has been copied to ensure the original is not mutated by this operation or because the copy is implicit when returning a struct from a member and another member is then accessed
    /// (Originally from /src/fsharp/FSComp.txt:87)
    static member tastValueHasBeenCopied() = (sprintf "The value has been copied to ensure the original is not mutated by this operation or because the copy is implicit when returning a struct from a member and another member is then accessed" )
    /// Recursively defined values cannot appear directly as part of the construction of a tuple value within a recursive binding
    /// (Originally from /src/fsharp/FSComp.txt:88)
    static member tastRecursiveValuesMayNotBeInConstructionOfTuple() = (259, sprintf "Recursively defined values cannot appear directly as part of the construction of a tuple value within a recursive binding" )
    /// Recursive values cannot appear directly as a construction of the type '%s' within a recursive binding. This feature has been removed from the F# language. Consider using a record instead.
    /// (Originally from /src/fsharp/FSComp.txt:89)
    static member tastRecursiveValuesMayNotAppearInConstructionOfType(a0 : System.String) = (260, sprintf "Recursive values cannot appear directly as a construction of the type '%s' within a recursive binding. This feature has been removed from the F# language. Consider using a record instead." a0)
    /// Recursive values cannot be directly assigned to the non-mutable field '%s' of the type '%s' within a recursive binding. Consider using a mutable field instead.
    /// (Originally from /src/fsharp/FSComp.txt:90)
    static member tastRecursiveValuesMayNotBeAssignedToNonMutableField(a0 : System.String, a1 : System.String) = (261, sprintf "Recursive values cannot be directly assigned to the non-mutable field '%s' of the type '%s' within a recursive binding. Consider using a mutable field instead." a0 a1)
    /// Unexpected decode of AutoOpenAttribute
    /// (Originally from /src/fsharp/FSComp.txt:91)
    static member tastUnexpectedDecodeOfAutoOpenAttribute() = (sprintf "Unexpected decode of AutoOpenAttribute" )
    /// Unexpected decode of InternalsVisibleToAttribute
    /// (Originally from /src/fsharp/FSComp.txt:92)
    static member tastUnexpectedDecodeOfInternalsVisibleToAttribute() = (sprintf "Unexpected decode of InternalsVisibleToAttribute" )
    /// Unexpected decode of InterfaceDataVersionAttribute
    /// (Originally from /src/fsharp/FSComp.txt:93)
    static member tastUnexpectedDecodeOfInterfaceDataVersionAttribute() = (sprintf "Unexpected decode of InterfaceDataVersionAttribute" )
    /// Active patterns cannot return more than 7 possibilities
    /// (Originally from /src/fsharp/FSComp.txt:94)
    static member tastActivePatternsLimitedToSeven() = (265, sprintf "Active patterns cannot return more than 7 possibilities" )
    /// This is not a valid constant expression or custom attribute value
    /// (Originally from /src/fsharp/FSComp.txt:95)
    static member tastNotAConstantExpression() = (267, sprintf "This is not a valid constant expression or custom attribute value" )
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe mutability attributes differ
    /// (Originally from /src/fsharp/FSComp.txt:96)
    static member ValueNotContainedMutabilityAttributesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe mutability attributes differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe names differ
    /// (Originally from /src/fsharp/FSComp.txt:97)
    static member ValueNotContainedMutabilityNamesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe names differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled names differ
    /// (Originally from /src/fsharp/FSComp.txt:98)
    static member ValueNotContainedMutabilityCompiledNamesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled names differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe display names differ
    /// (Originally from /src/fsharp/FSComp.txt:99)
    static member ValueNotContainedMutabilityDisplayNamesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe display names differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe accessibility specified in the signature is more than that specified in the implementation
    /// (Originally from /src/fsharp/FSComp.txt:100)
    static member ValueNotContainedMutabilityAccessibilityMore(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe accessibility specified in the signature is more than that specified in the implementation" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe inline flags differ
    /// (Originally from /src/fsharp/FSComp.txt:101)
    static member ValueNotContainedMutabilityInlineFlagsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe inline flags differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe literal constant values and/or attributes differ
    /// (Originally from /src/fsharp/FSComp.txt:102)
    static member ValueNotContainedMutabilityLiteralConstantValuesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe literal constant values and/or attributes differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is a type function and the other is not. The signature requires explicit type parameters if they are present in the implementation.
    /// (Originally from /src/fsharp/FSComp.txt:103)
    static member ValueNotContainedMutabilityOneIsTypeFunction(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is a type function and the other is not. The signature requires explicit type parameters if they are present in the implementation." a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe respective type parameter counts differ
    /// (Originally from /src/fsharp/FSComp.txt:104)
    static member ValueNotContainedMutabilityParameterCountsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe respective type parameter counts differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe types differ
    /// (Originally from /src/fsharp/FSComp.txt:105)
    static member ValueNotContainedMutabilityTypesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe types differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is an extension member and the other is not
    /// (Originally from /src/fsharp/FSComp.txt:106)
    static member ValueNotContainedMutabilityExtensionsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is an extension member and the other is not" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nAn arity was not inferred for this value
    /// (Originally from /src/fsharp/FSComp.txt:107)
    static member ValueNotContainedMutabilityArityNotInferred(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nAn arity was not inferred for this value" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe number of generic parameters in the signature and implementation differ (the signature declares %s but the implementation declares %s
    /// (Originally from /src/fsharp/FSComp.txt:108)
    static member ValueNotContainedMutabilityGenericParametersDiffer(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String, a4 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe number of generic parameters in the signature and implementation differ (the signature declares %s but the implementation declares %s" a0 a1 a2 a3 a4)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe generic parameters in the signature and implementation have different kinds. Perhaps there is a missing [<Measure>] attribute.
    /// (Originally from /src/fsharp/FSComp.txt:109)
    static member ValueNotContainedMutabilityGenericParametersAreDifferentKinds(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe generic parameters in the signature and implementation have different kinds. Perhaps there is a missing [<Measure>] attribute." a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe arities in the signature and implementation differ. The signature specifies that '%s' is function definition or lambda expression accepting at least %s argument(s), but the implementation is a computed function value. To declare that a computed function value is a permitted implementation simply parenthesize its type in the signature, e.g.\n\tval %s: int -> (int -> int)\ninstead of\n\tval %s: int -> int -> int.
    /// (Originally from /src/fsharp/FSComp.txt:110)
    static member ValueNotContainedMutabilityAritiesDiffer(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String, a4 : System.String, a5 : System.String, a6 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe arities in the signature and implementation differ. The signature specifies that '%s' is function definition or lambda expression accepting at least %s argument(s), but the implementation is a computed function value. To declare that a computed function value is a permitted implementation simply parenthesize its type in the signature, e.g.\n\tval %s: int -> (int -> int)\ninstead of\n\tval %s: int -> int -> int." a0 a1 a2 a3 a4 a5 a6)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe CLI member names differ
    /// (Originally from /src/fsharp/FSComp.txt:111)
    static member ValueNotContainedMutabilityDotNetNamesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe CLI member names differ" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is static and the other isn't
    /// (Originally from /src/fsharp/FSComp.txt:112)
    static member ValueNotContainedMutabilityStaticsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is static and the other isn't" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is virtual and the other isn't
    /// (Originally from /src/fsharp/FSComp.txt:113)
    static member ValueNotContainedMutabilityVirtualsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is virtual and the other isn't" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is abstract and the other isn't
    /// (Originally from /src/fsharp/FSComp.txt:114)
    static member ValueNotContainedMutabilityAbstractsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is abstract and the other isn't" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is final and the other isn't
    /// (Originally from /src/fsharp/FSComp.txt:115)
    static member ValueNotContainedMutabilityFinalsDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is final and the other isn't" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is marked as an override and the other isn't
    /// (Originally from /src/fsharp/FSComp.txt:116)
    static member ValueNotContainedMutabilityOverridesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is marked as an override and the other isn't" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is a constructor/property and the other is not
    /// (Originally from /src/fsharp/FSComp.txt:117)
    static member ValueNotContainedMutabilityOneIsConstructor(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nOne is a constructor/property and the other is not" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled representation of this method is as a static member but the signature indicates its compiled representation is as an instance member
    /// (Originally from /src/fsharp/FSComp.txt:118)
    static member ValueNotContainedMutabilityStaticButInstance(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled representation of this method is as a static member but the signature indicates its compiled representation is as an instance member" a0 a1 a2)
    /// Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled representation of this method is as an instance member, but the signature indicates its compiled representation is as a static member
    /// (Originally from /src/fsharp/FSComp.txt:119)
    static member ValueNotContainedMutabilityInstanceButStatic(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "Module '%s' contains\n    %s    \nbut its signature specifies\n    %s    \nThe compiled representation of this method is as an instance member, but the signature indicates its compiled representation is as a static member" a0 a1 a2)
    /// The %s definitions in the signature and implementation are not compatible because the names differ. The type is called '%s' in the signature file but '%s' in implementation.
    /// (Originally from /src/fsharp/FSComp.txt:120)
    static member DefinitionsInSigAndImplNotCompatibleNamesDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (290, sprintf "The %s definitions in the signature and implementation are not compatible because the names differ. The type is called '%s' in the signature file but '%s' in implementation." a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the respective type parameter counts differ
    /// (Originally from /src/fsharp/FSComp.txt:121)
    static member DefinitionsInSigAndImplNotCompatibleParameterCountsDiffer(a0 : System.String, a1 : System.String) = (291, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the respective type parameter counts differ" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the accessibility specified in the signature is more than that specified in the implementation
    /// (Originally from /src/fsharp/FSComp.txt:122)
    static member DefinitionsInSigAndImplNotCompatibleAccessibilityDiffer(a0 : System.String, a1 : System.String) = (292, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the accessibility specified in the signature is more than that specified in the implementation" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature requires that the type supports the interface %s but the interface has not been implemented
    /// (Originally from /src/fsharp/FSComp.txt:123)
    static member DefinitionsInSigAndImplNotCompatibleMissingInterface(a0 : System.String, a1 : System.String, a2 : System.String) = (293, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature requires that the type supports the interface %s but the interface has not been implemented" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation says this type may use nulls as a representation but the signature does not
    /// (Originally from /src/fsharp/FSComp.txt:124)
    static member DefinitionsInSigAndImplNotCompatibleImplementationSaysNull(a0 : System.String, a1 : System.String) = (294, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation says this type may use nulls as a representation but the signature does not" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation says this type may use nulls as an extra value but the signature does not
    /// (Originally from /src/fsharp/FSComp.txt:125)
    static member DefinitionsInSigAndImplNotCompatibleImplementationSaysNull2(a0 : System.String, a1 : System.String) = (294, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation says this type may use nulls as an extra value but the signature does not" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature says this type may use nulls as a representation but the implementation does not
    /// (Originally from /src/fsharp/FSComp.txt:126)
    static member DefinitionsInSigAndImplNotCompatibleSignatureSaysNull(a0 : System.String, a1 : System.String) = (295, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature says this type may use nulls as a representation but the implementation does not" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature says this type may use nulls as an extra value but the implementation does not
    /// (Originally from /src/fsharp/FSComp.txt:127)
    static member DefinitionsInSigAndImplNotCompatibleSignatureSaysNull2(a0 : System.String, a1 : System.String) = (295, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature says this type may use nulls as an extra value but the implementation does not" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation type is sealed but the signature implies it is not. Consider adding the [<Sealed>] attribute to the signature.
    /// (Originally from /src/fsharp/FSComp.txt:128)
    static member DefinitionsInSigAndImplNotCompatibleImplementationSealed(a0 : System.String, a1 : System.String) = (296, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation type is sealed but the signature implies it is not. Consider adding the [<Sealed>] attribute to the signature." a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation type is not sealed but signature implies it is. Consider adding the [<Sealed>] attribute to the implementation.
    /// (Originally from /src/fsharp/FSComp.txt:129)
    static member DefinitionsInSigAndImplNotCompatibleImplementationIsNotSealed(a0 : System.String, a1 : System.String) = (297, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation type is not sealed but signature implies it is. Consider adding the [<Sealed>] attribute to the implementation." a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation is an abstract class but the signature is not. Consider adding the [<AbstractClass>] attribute to the signature.
    /// (Originally from /src/fsharp/FSComp.txt:130)
    static member DefinitionsInSigAndImplNotCompatibleImplementationIsAbstract(a0 : System.String, a1 : System.String) = (298, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation is an abstract class but the signature is not. Consider adding the [<AbstractClass>] attribute to the signature." a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature is an abstract class but the implementation is not. Consider adding the [<AbstractClass>] attribute to the implementation.
    /// (Originally from /src/fsharp/FSComp.txt:131)
    static member DefinitionsInSigAndImplNotCompatibleSignatureIsAbstract(a0 : System.String, a1 : System.String) = (299, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature is an abstract class but the implementation is not. Consider adding the [<AbstractClass>] attribute to the implementation." a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the types have different base types
    /// (Originally from /src/fsharp/FSComp.txt:132)
    static member DefinitionsInSigAndImplNotCompatibleTypesHaveDifferentBaseTypes(a0 : System.String, a1 : System.String) = (300, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the types have different base types" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the number of %ss differ
    /// (Originally from /src/fsharp/FSComp.txt:133)
    static member DefinitionsInSigAndImplNotCompatibleNumbersDiffer(a0 : System.String, a1 : System.String, a2 : System.String) = (301, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the number of %ss differ" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature defines the %s '%s' but the implementation does not (or does, but not in the same order)
    /// (Originally from /src/fsharp/FSComp.txt:134)
    static member DefinitionsInSigAndImplNotCompatibleSignatureDefinesButImplDoesNot(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (302, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature defines the %s '%s' but the implementation does not (or does, but not in the same order)" a0 a1 a2 a3)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation defines the %s '%s' but the signature does not (or does, but not in the same order)
    /// (Originally from /src/fsharp/FSComp.txt:135)
    static member DefinitionsInSigAndImplNotCompatibleImplDefinesButSignatureDoesNot(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (303, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation defines the %s '%s' but the signature does not (or does, but not in the same order)" a0 a1 a2 a3)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation defines a struct but the signature defines a type with a hidden representation
    /// (Originally from /src/fsharp/FSComp.txt:136)
    static member DefinitionsInSigAndImplNotCompatibleImplDefinesStruct(a0 : System.String, a1 : System.String) = (304, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the implementation defines a struct but the signature defines a type with a hidden representation" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because a CLI type representation is being hidden by a signature
    /// (Originally from /src/fsharp/FSComp.txt:137)
    static member DefinitionsInSigAndImplNotCompatibleDotNetTypeRepresentationIsHidden(a0 : System.String, a1 : System.String) = (305, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because a CLI type representation is being hidden by a signature" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because a type representation is being hidden by a signature
    /// (Originally from /src/fsharp/FSComp.txt:138)
    static member DefinitionsInSigAndImplNotCompatibleTypeIsHidden(a0 : System.String, a1 : System.String) = (306, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because a type representation is being hidden by a signature" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the types are of different kinds
    /// (Originally from /src/fsharp/FSComp.txt:139)
    static member DefinitionsInSigAndImplNotCompatibleTypeIsDifferentKind(a0 : System.String, a1 : System.String) = (307, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the types are of different kinds" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the IL representations differ
    /// (Originally from /src/fsharp/FSComp.txt:140)
    static member DefinitionsInSigAndImplNotCompatibleILDiffer(a0 : System.String, a1 : System.String) = (308, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the IL representations differ" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the representations differ
    /// (Originally from /src/fsharp/FSComp.txt:141)
    static member DefinitionsInSigAndImplNotCompatibleRepresentationsDiffer(a0 : System.String, a1 : System.String) = (309, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the representations differ" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the field %s was present in the implementation but not in the signature
    /// (Originally from /src/fsharp/FSComp.txt:142)
    static member DefinitionsInSigAndImplNotCompatibleFieldWasPresent(a0 : System.String, a1 : System.String, a2 : System.String) = (311, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the field %s was present in the implementation but not in the signature" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the order of the fields is different in the signature and implementation
    /// (Originally from /src/fsharp/FSComp.txt:143)
    static member DefinitionsInSigAndImplNotCompatibleFieldOrderDiffer(a0 : System.String, a1 : System.String) = (312, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the order of the fields is different in the signature and implementation" a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the field %s was required by the signature but was not specified by the implementation
    /// (Originally from /src/fsharp/FSComp.txt:144)
    static member DefinitionsInSigAndImplNotCompatibleFieldRequiredButNotSpecified(a0 : System.String, a1 : System.String, a2 : System.String) = (313, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the field %s was required by the signature but was not specified by the implementation" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the field '%s' was present in the implementation but not in the signature. Struct types must now reveal their fields in the signature for the type, though the fields may still be labelled 'private' or 'internal'.
    /// (Originally from /src/fsharp/FSComp.txt:145)
    static member DefinitionsInSigAndImplNotCompatibleFieldIsInImplButNotSig(a0 : System.String, a1 : System.String, a2 : System.String) = (314, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the field '%s' was present in the implementation but not in the signature. Struct types must now reveal their fields in the signature for the type, though the fields may still be labelled 'private' or 'internal'." a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the abstract member '%s' was required by the signature but was not specified by the implementation
    /// (Originally from /src/fsharp/FSComp.txt:146)
    static member DefinitionsInSigAndImplNotCompatibleAbstractMemberMissingInImpl(a0 : System.String, a1 : System.String, a2 : System.String) = (315, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the abstract member '%s' was required by the signature but was not specified by the implementation" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the abstract member '%s' was present in the implementation but not in the signature
    /// (Originally from /src/fsharp/FSComp.txt:147)
    static member DefinitionsInSigAndImplNotCompatibleAbstractMemberMissingInSig(a0 : System.String, a1 : System.String, a2 : System.String) = (316, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the abstract member '%s' was present in the implementation but not in the signature" a0 a1 a2)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature declares a %s while the implementation declares a %s
    /// (Originally from /src/fsharp/FSComp.txt:148)
    static member DefinitionsInSigAndImplNotCompatibleSignatureDeclaresDiffer(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (317, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature declares a %s while the implementation declares a %s" a0 a1 a2 a3)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the abbreviations differ: %s versus %s
    /// (Originally from /src/fsharp/FSComp.txt:149)
    static member DefinitionsInSigAndImplNotCompatibleAbbreviationsDiffer(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (318, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the abbreviations differ: %s versus %s" a0 a1 a2 a3)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because an abbreviation is being hidden by a signature. The abbreviation must be visible to other CLI languages. Consider making the abbreviation visible in the signature.
    /// (Originally from /src/fsharp/FSComp.txt:150)
    static member DefinitionsInSigAndImplNotCompatibleAbbreviationHiddenBySig(a0 : System.String, a1 : System.String) = (319, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because an abbreviation is being hidden by a signature. The abbreviation must be visible to other CLI languages. Consider making the abbreviation visible in the signature." a0 a1)
    /// The %s definitions for type '%s' in the signature and implementation are not compatible because the signature has an abbreviation while the implementation does not
    /// (Originally from /src/fsharp/FSComp.txt:151)
    static member DefinitionsInSigAndImplNotCompatibleSigHasAbbreviation(a0 : System.String, a1 : System.String) = (320, sprintf "The %s definitions for type '%s' in the signature and implementation are not compatible because the signature has an abbreviation while the implementation does not" a0 a1)
    /// The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe names differ
    /// (Originally from /src/fsharp/FSComp.txt:152)
    static member ModuleContainsConstructorButNamesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe names differ" a0 a1)
    /// The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe respective number of data fields differ
    /// (Originally from /src/fsharp/FSComp.txt:153)
    static member ModuleContainsConstructorButDataFieldsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe respective number of data fields differ" a0 a1)
    /// The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe types of the fields differ
    /// (Originally from /src/fsharp/FSComp.txt:154)
    static member ModuleContainsConstructorButTypesOfFieldsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nThe types of the fields differ" a0 a1)
    /// The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nthe accessibility specified in the signature is more than that specified in the implementation
    /// (Originally from /src/fsharp/FSComp.txt:155)
    static member ModuleContainsConstructorButAccessibilityDiffers(a0 : System.String, a1 : System.String) = (sprintf "The module contains the constructor\n    %s    \nbut its signature specifies\n    %s    \nthe accessibility specified in the signature is more than that specified in the implementation" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe names differ
    /// (Originally from /src/fsharp/FSComp.txt:156)
    static member FieldNotContainedNamesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe names differ" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nthe accessibility specified in the signature is more than that specified in the implementation
    /// (Originally from /src/fsharp/FSComp.txt:157)
    static member FieldNotContainedAccessibilitiesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nthe accessibility specified in the signature is more than that specified in the implementation" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'static' modifiers differ
    /// (Originally from /src/fsharp/FSComp.txt:158)
    static member FieldNotContainedStaticsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'static' modifiers differ" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'mutable' modifiers differ
    /// (Originally from /src/fsharp/FSComp.txt:159)
    static member FieldNotContainedMutablesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'mutable' modifiers differ" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'literal' modifiers differ
    /// (Originally from /src/fsharp/FSComp.txt:160)
    static member FieldNotContainedLiteralsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe 'literal' modifiers differ" a0 a1)
    /// The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe types differ
    /// (Originally from /src/fsharp/FSComp.txt:161)
    static member FieldNotContainedTypesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The module contains the field\n    %s    \nbut its signature specifies\n    %s    \nThe types differ" a0 a1)
    /// The implicit instantiation of a generic construct at or near this point could not be resolved because it could resolve to multiple unrelated types, e.g. '%s' and '%s'. Consider using type annotations to resolve the ambiguity
    /// (Originally from /src/fsharp/FSComp.txt:162)
    static member typrelCannotResolveImplicitGenericInstantiation(a0 : System.String, a1 : System.String) = (331, sprintf "The implicit instantiation of a generic construct at or near this point could not be resolved because it could resolve to multiple unrelated types, e.g. '%s' and '%s'. Consider using type annotations to resolve the ambiguity" a0 a1)
    /// Could not resolve the ambiguity inherent in the use of a 'printf'-style format string
    /// (Originally from /src/fsharp/FSComp.txt:163)
    static member typrelCannotResolveAmbiguityInPrintf() = (333, sprintf "Could not resolve the ambiguity inherent in the use of a 'printf'-style format string" )
    /// Could not resolve the ambiguity in the use of a generic construct with an 'enum' constraint at or near this position
    /// (Originally from /src/fsharp/FSComp.txt:164)
    static member typrelCannotResolveAmbiguityInEnum() = (334, sprintf "Could not resolve the ambiguity in the use of a generic construct with an 'enum' constraint at or near this position" )
    /// Could not resolve the ambiguity in the use of a generic construct with a 'delegate' constraint at or near this position
    /// (Originally from /src/fsharp/FSComp.txt:165)
    static member typrelCannotResolveAmbiguityInDelegate() = (335, sprintf "Could not resolve the ambiguity in the use of a generic construct with a 'delegate' constraint at or near this position" )
    /// Invalid value
    /// (Originally from /src/fsharp/FSComp.txt:166)
    static member typrelInvalidValue() = (337, sprintf "Invalid value" )
    /// The signature and implementation are not compatible because the respective type parameter counts differ
    /// (Originally from /src/fsharp/FSComp.txt:167)
    static member typrelSigImplNotCompatibleParamCountsDiffer() = (338, sprintf "The signature and implementation are not compatible because the respective type parameter counts differ" )
    /// The signature and implementation are not compatible because the type parameter in the class/signature has a different compile-time requirement to the one in the member/implementation
    /// (Originally from /src/fsharp/FSComp.txt:168)
    static member typrelSigImplNotCompatibleCompileTimeRequirementsDiffer() = (339, sprintf "The signature and implementation are not compatible because the type parameter in the class/signature has a different compile-time requirement to the one in the member/implementation" )
    /// The signature and implementation are not compatible because the declaration of the type parameter '%s' requires a constraint of the form %s
    /// (Originally from /src/fsharp/FSComp.txt:169)
    static member typrelSigImplNotCompatibleConstraintsDiffer(a0 : System.String, a1 : System.String) = (340, sprintf "The signature and implementation are not compatible because the declaration of the type parameter '%s' requires a constraint of the form %s" a0 a1)
    /// The signature and implementation are not compatible because the type parameter '%s' has a constraint of the form %s but the implementation does not. Either remove this constraint from the signature or add it to the implementation.
    /// (Originally from /src/fsharp/FSComp.txt:170)
    static member typrelSigImplNotCompatibleConstraintsDifferRemove(a0 : System.String, a1 : System.String) = (341, sprintf "The signature and implementation are not compatible because the type parameter '%s' has a constraint of the form %s but the implementation does not. Either remove this constraint from the signature or add it to the implementation." a0 a1)
    /// The type '%s' implements 'System.IComparable'. Consider also adding an explicit override for 'Object.Equals'
    /// (Originally from /src/fsharp/FSComp.txt:171)
    static member typrelTypeImplementsIComparableShouldOverrideObjectEquals(a0 : System.String) = (342, sprintf "The type '%s' implements 'System.IComparable'. Consider also adding an explicit override for 'Object.Equals'" a0)
    /// The type '%s' implements 'System.IComparable' explicitly but provides no corresponding override for 'Object.Equals'. An implementation of 'Object.Equals' has been automatically provided, implemented via 'System.IComparable'. Consider implementing the override 'Object.Equals' explicitly
    /// (Originally from /src/fsharp/FSComp.txt:172)
    static member typrelTypeImplementsIComparableDefaultObjectEqualsProvided(a0 : System.String) = (343, sprintf "The type '%s' implements 'System.IComparable' explicitly but provides no corresponding override for 'Object.Equals'. An implementation of 'Object.Equals' has been automatically provided, implemented via 'System.IComparable'. Consider implementing the override 'Object.Equals' explicitly" a0)
    /// The struct, record or union type '%s' has an explicit implementation of 'Object.GetHashCode' or 'Object.Equals'. You must apply the 'CustomEquality' attribute to the type
    /// (Originally from /src/fsharp/FSComp.txt:173)
    static member typrelExplicitImplementationOfGetHashCodeOrEquals(a0 : System.String) = (344, sprintf "The struct, record or union type '%s' has an explicit implementation of 'Object.GetHashCode' or 'Object.Equals'. You must apply the 'CustomEquality' attribute to the type" a0)
    /// The struct, record or union type '%s' has an explicit implementation of 'Object.GetHashCode'. Consider implementing a matching override for 'Object.Equals(obj)'
    /// (Originally from /src/fsharp/FSComp.txt:174)
    static member typrelExplicitImplementationOfGetHashCode(a0 : System.String) = (345, sprintf "The struct, record or union type '%s' has an explicit implementation of 'Object.GetHashCode'. Consider implementing a matching override for 'Object.Equals(obj)'" a0)
    /// The struct, record or union type '%s' has an explicit implementation of 'Object.Equals'. Consider implementing a matching override for 'Object.GetHashCode()'
    /// (Originally from /src/fsharp/FSComp.txt:175)
    static member typrelExplicitImplementationOfEquals(a0 : System.String) = (346, sprintf "The struct, record or union type '%s' has an explicit implementation of 'Object.Equals'. Consider implementing a matching override for 'Object.GetHashCode()'" a0)
    /// The exception definitions are not compatible because a CLI exception mapping is being hidden by a signature. The exception mapping must be visible to other modules. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s
    /// (Originally from /src/fsharp/FSComp.txt:176)
    static member ExceptionDefsNotCompatibleHiddenBySignature(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because a CLI exception mapping is being hidden by a signature. The exception mapping must be visible to other modules. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s" a0 a1)
    /// The exception definitions are not compatible because the CLI representations differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s
    /// (Originally from /src/fsharp/FSComp.txt:177)
    static member ExceptionDefsNotCompatibleDotNetRepresentationsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because the CLI representations differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s" a0 a1)
    /// The exception definitions are not compatible because the exception abbreviation is being hidden by the signature. The abbreviation must be visible to other CLI languages. Consider making the abbreviation visible in the signature. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:178)
    static member ExceptionDefsNotCompatibleAbbreviationHiddenBySignature(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because the exception abbreviation is being hidden by the signature. The abbreviation must be visible to other CLI languages. Consider making the abbreviation visible in the signature. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1)
    /// The exception definitions are not compatible because the exception abbreviations in the signature and implementation differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:179)
    static member ExceptionDefsNotCompatibleSignaturesDiffer(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because the exception abbreviations in the signature and implementation differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1)
    /// The exception definitions are not compatible because the exception declarations differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:180)
    static member ExceptionDefsNotCompatibleExceptionDeclarationsDiffer(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because the exception declarations differ. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1)
    /// The exception definitions are not compatible because the field '%s' was required by the signature but was not specified by the implementation. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:181)
    static member ExceptionDefsNotCompatibleFieldInSigButNotImpl(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The exception definitions are not compatible because the field '%s' was required by the signature but was not specified by the implementation. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1 a2)
    /// The exception definitions are not compatible because the field '%s' was present in the implementation but not in the signature. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:182)
    static member ExceptionDefsNotCompatibleFieldInImplButNotSig(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The exception definitions are not compatible because the field '%s' was present in the implementation but not in the signature. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1 a2)
    /// The exception definitions are not compatible because the order of the fields is different in the signature and implementation. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s.
    /// (Originally from /src/fsharp/FSComp.txt:183)
    static member ExceptionDefsNotCompatibleFieldOrderDiffers(a0 : System.String, a1 : System.String) = (sprintf "The exception definitions are not compatible because the order of the fields is different in the signature and implementation. The module contains the exception definition\n    %s    \nbut its signature specifies\n\t%s." a0 a1)
    /// The namespace or module attributes differ between signature and implementation
    /// (Originally from /src/fsharp/FSComp.txt:184)
    static member typrelModuleNamespaceAttributesDifferInSigAndImpl() = (355, sprintf "The namespace or module attributes differ between signature and implementation" )
    /// This method is over-constrained in its type parameters
    /// (Originally from /src/fsharp/FSComp.txt:185)
    static member typrelMethodIsOverconstrained() = (356, sprintf "This method is over-constrained in its type parameters" )
    /// No implementations of '%s' had the correct number of arguments and type parameters. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:186)
    static member typrelOverloadNotFound(a0 : System.String, a1 : System.String) = (357, sprintf "No implementations of '%s' had the correct number of arguments and type parameters. The required signature is '%s'." a0 a1)
    /// The override for '%s' was ambiguous
    /// (Originally from /src/fsharp/FSComp.txt:187)
    static member typrelOverrideWasAmbiguous(a0 : System.String) = (358, sprintf "The override for '%s' was ambiguous" a0)
    /// More than one override implements '%s'
    /// (Originally from /src/fsharp/FSComp.txt:188)
    static member typrelMoreThenOneOverride(a0 : System.String) = (359, sprintf "More than one override implements '%s'" a0)
    /// The method '%s' is sealed and cannot be overridden
    /// (Originally from /src/fsharp/FSComp.txt:189)
    static member typrelMethodIsSealed(a0 : System.String) = (360, sprintf "The method '%s' is sealed and cannot be overridden" a0)
    /// The override '%s' implements more than one abstract slot, e.g. '%s' and '%s'
    /// (Originally from /src/fsharp/FSComp.txt:190)
    static member typrelOverrideImplementsMoreThenOneSlot(a0 : System.String, a1 : System.String, a2 : System.String) = (361, sprintf "The override '%s' implements more than one abstract slot, e.g. '%s' and '%s'" a0 a1 a2)
    /// Duplicate or redundant interface
    /// (Originally from /src/fsharp/FSComp.txt:191)
    static member typrelDuplicateInterface() = (362, sprintf "Duplicate or redundant interface" )
    /// The interface '%s' is included in multiple explicitly implemented interface types. Add an explicit implementation of this interface.
    /// (Originally from /src/fsharp/FSComp.txt:192)
    static member typrelNeedExplicitImplementation(a0 : System.String) = (363, sprintf "The interface '%s' is included in multiple explicitly implemented interface types. Add an explicit implementation of this interface." a0)
    /// A named argument has been assigned more than one value
    /// (Originally from /src/fsharp/FSComp.txt:193)
    static member typrelNamedArgumentHasBeenAssignedMoreThenOnce() = (364, sprintf "A named argument has been assigned more than one value" )
    /// No implementation was given for '%s'
    /// (Originally from /src/fsharp/FSComp.txt:194)
    static member typrelNoImplementationGiven(a0 : System.String) = (365, sprintf "No implementation was given for '%s'" a0)
    /// No implementation was given for '%s'. Note that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'.
    /// (Originally from /src/fsharp/FSComp.txt:195)
    static member typrelNoImplementationGivenWithSuggestion(a0 : System.String) = (366, sprintf "No implementation was given for '%s'. Note that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'." a0)
    /// No implementation was given for those members: %s
    /// (Originally from /src/fsharp/FSComp.txt:196)
    static member typrelNoImplementationGivenSeveral(a0 : System.String) = (365, sprintf "No implementation was given for those members: %s" a0)
    /// No implementation was given for those members: %sNote that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'.
    /// (Originally from /src/fsharp/FSComp.txt:197)
    static member typrelNoImplementationGivenSeveralWithSuggestion(a0 : System.String) = (366, sprintf "No implementation was given for those members: %sNote that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'." a0)
    /// No implementation was given for those members (some results omitted): %s
    /// (Originally from /src/fsharp/FSComp.txt:198)
    static member typrelNoImplementationGivenSeveralTruncated(a0 : System.String) = (365, sprintf "No implementation was given for those members (some results omitted): %s" a0)
    /// No implementation was given for those members (some results omitted): %sNote that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'.
    /// (Originally from /src/fsharp/FSComp.txt:199)
    static member typrelNoImplementationGivenSeveralTruncatedWithSuggestion(a0 : System.String) = (366, sprintf "No implementation was given for those members (some results omitted): %sNote that all interface members must be implemented and listed under an appropriate 'interface' declaration, e.g. 'interface ... with member ...'." a0)
    /// The member '%s' does not have the correct number of arguments. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:200)
    static member typrelMemberDoesNotHaveCorrectNumberOfArguments(a0 : System.String, a1 : System.String) = (367, sprintf "The member '%s' does not have the correct number of arguments. The required signature is '%s'." a0 a1)
    /// The member '%s' does not have the correct number of method type parameters. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:201)
    static member typrelMemberDoesNotHaveCorrectNumberOfTypeParameters(a0 : System.String, a1 : System.String) = (368, sprintf "The member '%s' does not have the correct number of method type parameters. The required signature is '%s'." a0 a1)
    /// The member '%s' does not have the correct kinds of generic parameters. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:202)
    static member typrelMemberDoesNotHaveCorrectKindsOfGenericParameters(a0 : System.String, a1 : System.String) = (369, sprintf "The member '%s' does not have the correct kinds of generic parameters. The required signature is '%s'." a0 a1)
    /// The member '%s' cannot be used to implement '%s'. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:203)
    static member typrelMemberCannotImplement(a0 : System.String, a1 : System.String, a2 : System.String) = (370, sprintf "The member '%s' cannot be used to implement '%s'. The required signature is '%s'." a0 a1 a2)
    /// Error while parsing embedded IL
    /// (Originally from /src/fsharp/FSComp.txt:204)
    static member astParseEmbeddedILError() = (371, sprintf "Error while parsing embedded IL" )
    /// Error while parsing embedded IL type
    /// (Originally from /src/fsharp/FSComp.txt:205)
    static member astParseEmbeddedILTypeError() = (372, sprintf "Error while parsing embedded IL type" )
    /// This indexer notation has been removed from the F# language
    /// (Originally from /src/fsharp/FSComp.txt:206)
    static member astDeprecatedIndexerNotation() = (sprintf "This indexer notation has been removed from the F# language" )
    /// Invalid expression on left of assignment
    /// (Originally from /src/fsharp/FSComp.txt:207)
    static member astInvalidExprLeftHandOfAssignment() = (374, sprintf "Invalid expression on left of assignment" )
    /// The 'ReferenceEquality' attribute cannot be used on structs. Consider using the 'StructuralEquality' attribute instead, or implement an override for 'System.Object.Equals(obj)'.
    /// (Originally from /src/fsharp/FSComp.txt:208)
    static member augNoRefEqualsOnStruct() = (376, sprintf "The 'ReferenceEquality' attribute cannot be used on structs. Consider using the 'StructuralEquality' attribute instead, or implement an override for 'System.Object.Equals(obj)'." )
    /// This type uses an invalid mix of the attributes 'NoEquality', 'ReferenceEquality', 'StructuralEquality', 'NoComparison' and 'StructuralComparison'
    /// (Originally from /src/fsharp/FSComp.txt:209)
    static member augInvalidAttrs() = (377, sprintf "This type uses an invalid mix of the attributes 'NoEquality', 'ReferenceEquality', 'StructuralEquality', 'NoComparison' and 'StructuralComparison'" )
    /// The 'NoEquality' attribute must be used in conjunction with the 'NoComparison' attribute
    /// (Originally from /src/fsharp/FSComp.txt:210)
    static member augNoEqualityNeedsNoComparison() = (378, sprintf "The 'NoEquality' attribute must be used in conjunction with the 'NoComparison' attribute" )
    /// The 'StructuralComparison' attribute must be used in conjunction with the 'StructuralEquality' attribute
    /// (Originally from /src/fsharp/FSComp.txt:211)
    static member augStructCompNeedsStructEquality() = (379, sprintf "The 'StructuralComparison' attribute must be used in conjunction with the 'StructuralEquality' attribute" )
    /// The 'StructuralEquality' attribute must be used in conjunction with the 'NoComparison' or 'StructuralComparison' attributes
    /// (Originally from /src/fsharp/FSComp.txt:212)
    static member augStructEqNeedsNoCompOrStructComp() = (380, sprintf "The 'StructuralEquality' attribute must be used in conjunction with the 'NoComparison' or 'StructuralComparison' attributes" )
    /// A type cannot have both the 'ReferenceEquality' and 'StructuralEquality' or 'StructuralComparison' attributes
    /// (Originally from /src/fsharp/FSComp.txt:213)
    static member augTypeCantHaveRefEqAndStructAttrs() = (381, sprintf "A type cannot have both the 'ReferenceEquality' and 'StructuralEquality' or 'StructuralComparison' attributes" )
    /// Only record, union, exception and struct types may be augmented with the 'ReferenceEquality', 'StructuralEquality' and 'StructuralComparison' attributes
    /// (Originally from /src/fsharp/FSComp.txt:214)
    static member augOnlyCertainTypesCanHaveAttrs() = (382, sprintf "Only record, union, exception and struct types may be augmented with the 'ReferenceEquality', 'StructuralEquality' and 'StructuralComparison' attributes" )
    /// A type with attribute 'ReferenceEquality' cannot have an explicit implementation of 'Object.Equals(obj)', 'System.IEquatable<_>' or 'System.Collections.IStructuralEquatable'
    /// (Originally from /src/fsharp/FSComp.txt:215)
    static member augRefEqCantHaveObjEquals() = (383, sprintf "A type with attribute 'ReferenceEquality' cannot have an explicit implementation of 'Object.Equals(obj)', 'System.IEquatable<_>' or 'System.Collections.IStructuralEquatable'" )
    /// A type with attribute 'CustomEquality' must have an explicit implementation of at least one of 'Object.Equals(obj)', 'System.IEquatable<_>' or 'System.Collections.IStructuralEquatable'
    /// (Originally from /src/fsharp/FSComp.txt:216)
    static member augCustomEqNeedsObjEquals() = (384, sprintf "A type with attribute 'CustomEquality' must have an explicit implementation of at least one of 'Object.Equals(obj)', 'System.IEquatable<_>' or 'System.Collections.IStructuralEquatable'" )
    /// A type with attribute 'CustomComparison' must have an explicit implementation of at least one of 'System.IComparable' or 'System.Collections.IStructuralComparable'
    /// (Originally from /src/fsharp/FSComp.txt:217)
    static member augCustomCompareNeedsIComp() = (385, sprintf "A type with attribute 'CustomComparison' must have an explicit implementation of at least one of 'System.IComparable' or 'System.Collections.IStructuralComparable'" )
    /// A type with attribute 'NoEquality' should not usually have an explicit implementation of 'Object.Equals(obj)'. Disable this warning if this is intentional for interoperability purposes
    /// (Originally from /src/fsharp/FSComp.txt:218)
    static member augNoEqNeedsNoObjEquals() = (386, sprintf "A type with attribute 'NoEquality' should not usually have an explicit implementation of 'Object.Equals(obj)'. Disable this warning if this is intentional for interoperability purposes" )
    /// A type with attribute 'NoComparison' should not usually have an explicit implementation of 'System.IComparable', 'System.IComparable<_>' or 'System.Collections.IStructuralComparable'. Disable this warning if this is intentional for interoperability purposes
    /// (Originally from /src/fsharp/FSComp.txt:219)
    static member augNoCompCantImpIComp() = (386, sprintf "A type with attribute 'NoComparison' should not usually have an explicit implementation of 'System.IComparable', 'System.IComparable<_>' or 'System.Collections.IStructuralComparable'. Disable this warning if this is intentional for interoperability purposes" )
    /// The 'CustomEquality' attribute must be used in conjunction with the 'NoComparison' or 'CustomComparison' attributes
    /// (Originally from /src/fsharp/FSComp.txt:220)
    static member augCustomEqNeedsNoCompOrCustomComp() = (387, sprintf "The 'CustomEquality' attribute must be used in conjunction with the 'NoComparison' or 'CustomComparison' attributes" )
    /// Positional specifiers are not permitted in format strings
    /// (Originally from /src/fsharp/FSComp.txt:221)
    static member forPositionalSpecifiersNotPermitted() = (sprintf "Positional specifiers are not permitted in format strings" )
    /// Missing format specifier
    /// (Originally from /src/fsharp/FSComp.txt:222)
    static member forMissingFormatSpecifier() = (sprintf "Missing format specifier" )
    /// '%s' flag set twice
    /// (Originally from /src/fsharp/FSComp.txt:223)
    static member forFlagSetTwice(a0 : System.String) = (sprintf "'%s' flag set twice" a0)
    /// Prefix flag (' ' or '+') set twice
    /// (Originally from /src/fsharp/FSComp.txt:224)
    static member forPrefixFlagSpacePlusSetTwice() = (sprintf "Prefix flag (' ' or '+') set twice" )
    /// The # formatting modifier is invalid in F#
    /// (Originally from /src/fsharp/FSComp.txt:225)
    static member forHashSpecifierIsInvalid() = (sprintf "The # formatting modifier is invalid in F#" )
    /// Bad precision in format specifier
    /// (Originally from /src/fsharp/FSComp.txt:226)
    static member forBadPrecision() = (sprintf "Bad precision in format specifier" )
    /// Bad width in format specifier
    /// (Originally from /src/fsharp/FSComp.txt:227)
    static member forBadWidth() = (sprintf "Bad width in format specifier" )
    /// '%s' format does not support '0' flag
    /// (Originally from /src/fsharp/FSComp.txt:228)
    static member forDoesNotSupportZeroFlag(a0 : System.String) = (sprintf "'%s' format does not support '0' flag" a0)
    /// Precision missing after the '.'
    /// (Originally from /src/fsharp/FSComp.txt:229)
    static member forPrecisionMissingAfterDot() = (sprintf "Precision missing after the '.'" )
    /// '%s' format does not support precision
    /// (Originally from /src/fsharp/FSComp.txt:230)
    static member forFormatDoesntSupportPrecision(a0 : System.String) = (sprintf "'%s' format does not support precision" a0)
    /// Bad format specifier (after l or L): Expected ld,li,lo,lu,lx or lX. In F# code you can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types.
    /// (Originally from /src/fsharp/FSComp.txt:231)
    static member forBadFormatSpecifier() = (sprintf "Bad format specifier (after l or L): Expected ld,li,lo,lu,lx or lX. In F# code you can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types." )
    /// The 'l' or 'L' in this format specifier is unnecessary. In F# code you can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types.
    /// (Originally from /src/fsharp/FSComp.txt:232)
    static member forLIsUnnecessary() = (sprintf "The 'l' or 'L' in this format specifier is unnecessary. In F# code you can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types." )
    /// The 'h' or 'H' in this format specifier is unnecessary. You can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types.
    /// (Originally from /src/fsharp/FSComp.txt:233)
    static member forHIsUnnecessary() = (sprintf "The 'h' or 'H' in this format specifier is unnecessary. You can use %%d, %%x, %%o or %%u instead, which are overloaded to work with all basic integer types." )
    /// '%s' does not support prefix '%s' flag
    /// (Originally from /src/fsharp/FSComp.txt:234)
    static member forDoesNotSupportPrefixFlag(a0 : System.String, a1 : System.String) = (sprintf "'%s' does not support prefix '%s' flag" a0 a1)
    /// Bad format specifier: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:235)
    static member forBadFormatSpecifierGeneral(a0 : System.String) = (sprintf "Bad format specifier: '%s'" a0)
    /// System.Environment.Exit did not exit
    /// (Originally from /src/fsharp/FSComp.txt:236)
    static member elSysEnvExitDidntExit() = (sprintf "System.Environment.Exit did not exit" )
    /// The treatment of this operator is now handled directly by the F# compiler and its meaning cannot be redefined
    /// (Originally from /src/fsharp/FSComp.txt:237)
    static member elDeprecatedOperator() = (sprintf "The treatment of this operator is now handled directly by the F# compiler and its meaning cannot be redefined" )
    /// A protected member is called or 'base' is being used. This is only allowed in the direct implementation of members since they could escape their object scope.
    /// (Originally from /src/fsharp/FSComp.txt:238)
    static member chkProtectedOrBaseCalled() = (405, sprintf "A protected member is called or 'base' is being used. This is only allowed in the direct implementation of members since they could escape their object scope." )
    /// The byref-typed variable '%s' is used in an invalid way. Byrefs cannot be captured by closures or passed to inner functions.
    /// (Originally from /src/fsharp/FSComp.txt:239)
    static member chkByrefUsedInInvalidWay(a0 : System.String) = (406, sprintf "The byref-typed variable '%s' is used in an invalid way. Byrefs cannot be captured by closures or passed to inner functions." a0)
    /// The 'base' keyword is used in an invalid way. Base calls cannot be used in closures. Consider using a private member to make base calls.
    /// (Originally from /src/fsharp/FSComp.txt:240)
    static member chkBaseUsedInInvalidWay() = (408, sprintf "The 'base' keyword is used in an invalid way. Base calls cannot be used in closures. Consider using a private member to make base calls." )
    /// The variable '%s' is used in an invalid way
    /// (Originally from /src/fsharp/FSComp.txt:241)
    static member chkVariableUsedInInvalidWay(a0 : System.String) = (sprintf "The variable '%s' is used in an invalid way" a0)
    /// The type '%s' is less accessible than the value, member or type '%s' it is used in.
    /// (Originally from /src/fsharp/FSComp.txt:242)
    static member chkTypeLessAccessibleThanType(a0 : System.String, a1 : System.String) = (410, sprintf "The type '%s' is less accessible than the value, member or type '%s' it is used in." a0 a1)
    /// 'System.Void' can only be used as 'typeof<System.Void>' in F#
    /// (Originally from /src/fsharp/FSComp.txt:243)
    static member chkSystemVoidOnlyInTypeof() = (411, sprintf "'System.Void' can only be used as 'typeof<System.Void>' in F#" )
    /// A type instantiation involves a byref type. This is not permitted by the rules of Common IL.
    /// (Originally from /src/fsharp/FSComp.txt:244)
    static member chkErrorUseOfByref() = (412, sprintf "A type instantiation involves a byref type. This is not permitted by the rules of Common IL." )
    /// Calls to 'reraise' may only occur directly in a handler of a try-with
    /// (Originally from /src/fsharp/FSComp.txt:245)
    static member chkErrorContainsCallToRethrow() = (413, sprintf "Calls to 'reraise' may only occur directly in a handler of a try-with" )
    /// Expression-splicing operators may only be used within quotations
    /// (Originally from /src/fsharp/FSComp.txt:246)
    static member chkSplicingOnlyInQuotations() = (414, sprintf "Expression-splicing operators may only be used within quotations" )
    /// First-class uses of the expression-splicing operator are not permitted
    /// (Originally from /src/fsharp/FSComp.txt:247)
    static member chkNoFirstClassSplicing() = (415, sprintf "First-class uses of the expression-splicing operator are not permitted" )
    /// First-class uses of the address-of operators are not permitted
    /// (Originally from /src/fsharp/FSComp.txt:248)
    static member chkNoFirstClassAddressOf() = (416, sprintf "First-class uses of the address-of operators are not permitted" )
    /// First-class uses of the 'reraise' function is not permitted
    /// (Originally from /src/fsharp/FSComp.txt:249)
    static member chkNoFirstClassRethrow() = (417, sprintf "First-class uses of the 'reraise' function is not permitted" )
    /// The byref typed value '%s' cannot be used at this point
    /// (Originally from /src/fsharp/FSComp.txt:250)
    static member chkNoByrefAtThisPoint(a0 : System.String) = (418, sprintf "The byref typed value '%s' cannot be used at this point" a0)
    /// 'base' values may only be used to make direct calls to the base implementations of overridden members
    /// (Originally from /src/fsharp/FSComp.txt:251)
    static member chkLimitationsOfBaseKeyword() = (419, sprintf "'base' values may only be used to make direct calls to the base implementations of overridden members" )
    /// Object constructors cannot directly use try/with and try/finally prior to the initialization of the object. This includes constructs such as 'for x in ...' that may elaborate to uses of these constructs. This is a limitation imposed by Common IL.
    /// (Originally from /src/fsharp/FSComp.txt:252)
    static member chkObjCtorsCantUseExceptionHandling() = (420, sprintf "Object constructors cannot directly use try/with and try/finally prior to the initialization of the object. This includes constructs such as 'for x in ...' that may elaborate to uses of these constructs. This is a limitation imposed by Common IL." )
    /// The address of the variable '%s' cannot be used at this point
    /// (Originally from /src/fsharp/FSComp.txt:253)
    static member chkNoAddressOfAtThisPoint(a0 : System.String) = (421, sprintf "The address of the variable '%s' cannot be used at this point" a0)
    /// The address of the static field '%s' cannot be used at this point
    /// (Originally from /src/fsharp/FSComp.txt:254)
    static member chkNoAddressStaticFieldAtThisPoint(a0 : System.String) = (422, sprintf "The address of the static field '%s' cannot be used at this point" a0)
    /// The address of the field '%s' cannot be used at this point
    /// (Originally from /src/fsharp/FSComp.txt:255)
    static member chkNoAddressFieldAtThisPoint(a0 : System.String) = (423, sprintf "The address of the field '%s' cannot be used at this point" a0)
    /// The address of an array element cannot be used at this point
    /// (Originally from /src/fsharp/FSComp.txt:256)
    static member chkNoAddressOfArrayElementAtThisPoint() = (424, sprintf "The address of an array element cannot be used at this point" )
    /// The type of a first-class function cannot contain byrefs
    /// (Originally from /src/fsharp/FSComp.txt:257)
    static member chkFirstClassFuncNoByref() = (425, sprintf "The type of a first-class function cannot contain byrefs" )
    /// A method return type would contain byrefs which is not permitted
    /// (Originally from /src/fsharp/FSComp.txt:258)
    static member chkReturnTypeNoByref() = (426, sprintf "A method return type would contain byrefs which is not permitted" )
    /// Invalid custom attribute value (not a constant or literal)
    /// (Originally from /src/fsharp/FSComp.txt:259)
    static member chkInvalidCustAttrVal() = (428, sprintf "Invalid custom attribute value (not a constant or literal)" )
    /// The attribute type '%s' has 'AllowMultiple=false'. Multiple instances of this attribute cannot be attached to a single language element.
    /// (Originally from /src/fsharp/FSComp.txt:260)
    static member chkAttrHasAllowMultiFalse(a0 : System.String) = (429, sprintf "The attribute type '%s' has 'AllowMultiple=false'. Multiple instances of this attribute cannot be attached to a single language element." a0)
    /// The member '%s' is used in an invalid way. A use of '%s' has been inferred prior to its definition at or near '%s'. This is an invalid forward reference.
    /// (Originally from /src/fsharp/FSComp.txt:261)
    static member chkMemberUsedInInvalidWay(a0 : System.String, a1 : System.String, a2 : System.String) = (430, sprintf "The member '%s' is used in an invalid way. A use of '%s' has been inferred prior to its definition at or near '%s'. This is an invalid forward reference." a0 a1 a2)
    /// A byref typed value would be stored here. Top-level let-bound byref values are not permitted.
    /// (Originally from /src/fsharp/FSComp.txt:262)
    static member chkNoByrefAsTopValue() = (431, sprintf "A byref typed value would be stored here. Top-level let-bound byref values are not permitted." )
    /// [<ReflectedDefinition>] terms cannot contain uses of the prefix splice operator '%%'
    /// (Originally from /src/fsharp/FSComp.txt:263)
    static member chkReflectedDefCantSplice() = (432, sprintf "[<ReflectedDefinition>] terms cannot contain uses of the prefix splice operator '%%'" )
    /// A function labeled with the 'EntryPointAttribute' attribute must be the last declaration in the last file in the compilation sequence.
    /// (Originally from /src/fsharp/FSComp.txt:264)
    static member chkEntryPointUsage() = (433, sprintf "A function labeled with the 'EntryPointAttribute' attribute must be the last declaration in the last file in the compilation sequence." )
    /// compiled form of the union case
    /// (Originally from /src/fsharp/FSComp.txt:265)
    static member chkUnionCaseCompiledForm() = (sprintf "compiled form of the union case" )
    /// default augmentation of the union case
    /// (Originally from /src/fsharp/FSComp.txt:266)
    static member chkUnionCaseDefaultAugmentation() = (sprintf "default augmentation of the union case" )
    /// The property '%s' has the same name as a method in type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:267)
    static member chkPropertySameNameMethod(a0 : System.String, a1 : System.String) = (434, sprintf "The property '%s' has the same name as a method in type '%s'." a0 a1)
    /// The property '%s' of type '%s' has a getter and a setter that do not match. If one is abstract then the other must be as well.
    /// (Originally from /src/fsharp/FSComp.txt:268)
    static member chkGetterSetterDoNotMatchAbstract(a0 : System.String, a1 : System.String) = (435, sprintf "The property '%s' of type '%s' has a getter and a setter that do not match. If one is abstract then the other must be as well." a0 a1)
    /// The property '%s' has the same name as another property in type '%s', but one takes indexer arguments and the other does not. You may be missing an indexer argument to one of your properties.
    /// (Originally from /src/fsharp/FSComp.txt:269)
    static member chkPropertySameNameIndexer(a0 : System.String, a1 : System.String) = (436, sprintf "The property '%s' has the same name as another property in type '%s', but one takes indexer arguments and the other does not. You may be missing an indexer argument to one of your properties." a0 a1)
    /// A type would store a byref typed value. This is not permitted by Common IL.
    /// (Originally from /src/fsharp/FSComp.txt:270)
    static member chkCantStoreByrefValue() = (437, sprintf "A type would store a byref typed value. This is not permitted by Common IL." )
    /// Duplicate method. The method '%s' has the same name and signature as another method in type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:272)
    static member chkDuplicateMethod(a0 : System.String, a1 : System.String) = (438, sprintf "Duplicate method. The method '%s' has the same name and signature as another method in type '%s'." a0 a1)
    /// Duplicate method. The method '%s' has the same name and signature as another method in type '%s' once tuples, functions, units of measure and/or provided types are erased.
    /// (Originally from /src/fsharp/FSComp.txt:273)
    static member chkDuplicateMethodWithSuffix(a0 : System.String, a1 : System.String) = (438, sprintf "Duplicate method. The method '%s' has the same name and signature as another method in type '%s' once tuples, functions, units of measure and/or provided types are erased." a0 a1)
    /// The method '%s' has curried arguments but has the same name as another method in type '%s'. Methods with curried arguments cannot be overloaded. Consider using a method taking tupled arguments.
    /// (Originally from /src/fsharp/FSComp.txt:274)
    static member chkDuplicateMethodCurried(a0 : System.String, a1 : System.String) = (439, sprintf "The method '%s' has curried arguments but has the same name as another method in type '%s'. Methods with curried arguments cannot be overloaded. Consider using a method taking tupled arguments." a0 a1)
    /// Methods with curried arguments cannot declare 'out', 'ParamArray', 'optional', 'ReflectedDefinition', 'byref', 'CallerLineNumber', 'CallerMemberName', or 'CallerFilePath' arguments
    /// (Originally from /src/fsharp/FSComp.txt:275)
    static member chkCurriedMethodsCantHaveOutParams() = (440, sprintf "Methods with curried arguments cannot declare 'out', 'ParamArray', 'optional', 'ReflectedDefinition', 'byref', 'CallerLineNumber', 'CallerMemberName', or 'CallerFilePath' arguments" )
    /// Duplicate property. The property '%s' has the same name and signature as another property in type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:276)
    static member chkDuplicateProperty(a0 : System.String, a1 : System.String) = (441, sprintf "Duplicate property. The property '%s' has the same name and signature as another property in type '%s'." a0 a1)
    /// Duplicate property. The property '%s' has the same name and signature as another property in type '%s' once tuples, functions, units of measure and/or provided types are erased.
    /// (Originally from /src/fsharp/FSComp.txt:277)
    static member chkDuplicatePropertyWithSuffix(a0 : System.String, a1 : System.String) = (441, sprintf "Duplicate property. The property '%s' has the same name and signature as another property in type '%s' once tuples, functions, units of measure and/or provided types are erased." a0 a1)
    /// Duplicate method. The abstract method '%s' has the same name and signature as an abstract method in an inherited type.
    /// (Originally from /src/fsharp/FSComp.txt:278)
    static member chkDuplicateMethodInheritedType(a0 : System.String) = (442, sprintf "Duplicate method. The abstract method '%s' has the same name and signature as an abstract method in an inherited type." a0)
    /// Duplicate method. The abstract method '%s' has the same name and signature as an abstract method in an inherited type once tuples, functions, units of measure and/or provided types are erased.
    /// (Originally from /src/fsharp/FSComp.txt:279)
    static member chkDuplicateMethodInheritedTypeWithSuffix(a0 : System.String) = (442, sprintf "Duplicate method. The abstract method '%s' has the same name and signature as an abstract method in an inherited type once tuples, functions, units of measure and/or provided types are erased." a0)
    /// This type implements the same interface at different generic instantiations '%s' and '%s'. This is not permitted in this version of F#.
    /// (Originally from /src/fsharp/FSComp.txt:280)
    static member chkMultipleGenericInterfaceInstantiations(a0 : System.String, a1 : System.String) = (443, sprintf "This type implements the same interface at different generic instantiations '%s' and '%s'. This is not permitted in this version of F#." a0 a1)
    /// The type of a field using the 'DefaultValue' attribute must admit default initialization, i.e. have 'null' as a proper value or be a struct type whose fields all admit default initialization. You can use 'DefaultValue(false)' to disable this check
    /// (Originally from /src/fsharp/FSComp.txt:281)
    static member chkValueWithDefaultValueMustHaveDefaultValue() = (444, sprintf "The type of a field using the 'DefaultValue' attribute must admit default initialization, i.e. have 'null' as a proper value or be a struct type whose fields all admit default initialization. You can use 'DefaultValue(false)' to disable this check" )
    /// The type abbreviation contains byrefs. This is not permitted by F#.
    /// (Originally from /src/fsharp/FSComp.txt:282)
    static member chkNoByrefInTypeAbbrev() = (445, sprintf "The type abbreviation contains byrefs. This is not permitted by F#." )
    /// The variable '%s' is bound in a quotation but is used as part of a spliced expression. This is not permitted since it may escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:283)
    static member crefBoundVarUsedInSplice(a0 : System.String) = (446, sprintf "The variable '%s' is bound in a quotation but is used as part of a spliced expression. This is not permitted since it may escape its scope." a0)
    /// Quotations cannot contain uses of generic expressions
    /// (Originally from /src/fsharp/FSComp.txt:284)
    static member crefQuotationsCantContainGenericExprs() = (447, sprintf "Quotations cannot contain uses of generic expressions" )
    /// Quotations cannot contain function definitions that are inferred or declared to be generic. Consider adding some type constraints to make this a valid quoted expression.
    /// (Originally from /src/fsharp/FSComp.txt:285)
    static member crefQuotationsCantContainGenericFunctions() = (448, sprintf "Quotations cannot contain function definitions that are inferred or declared to be generic. Consider adding some type constraints to make this a valid quoted expression." )
    /// Quotations cannot contain object expressions
    /// (Originally from /src/fsharp/FSComp.txt:286)
    static member crefQuotationsCantContainObjExprs() = (449, sprintf "Quotations cannot contain object expressions" )
    /// Quotations cannot contain expressions that take the address of a field
    /// (Originally from /src/fsharp/FSComp.txt:287)
    static member crefQuotationsCantContainAddressOf() = (450, sprintf "Quotations cannot contain expressions that take the address of a field" )
    /// Quotations cannot contain expressions that fetch static fields
    /// (Originally from /src/fsharp/FSComp.txt:288)
    static member crefQuotationsCantContainStaticFieldRef() = (451, sprintf "Quotations cannot contain expressions that fetch static fields" )
    /// Quotations cannot contain inline assembly code or pattern matching on arrays
    /// (Originally from /src/fsharp/FSComp.txt:289)
    static member crefQuotationsCantContainInlineIL() = (452, sprintf "Quotations cannot contain inline assembly code or pattern matching on arrays" )
    /// Quotations cannot contain descending for loops
    /// (Originally from /src/fsharp/FSComp.txt:290)
    static member crefQuotationsCantContainDescendingForLoops() = (453, sprintf "Quotations cannot contain descending for loops" )
    /// Quotations cannot contain expressions that fetch union case indexes
    /// (Originally from /src/fsharp/FSComp.txt:291)
    static member crefQuotationsCantFetchUnionIndexes() = (454, sprintf "Quotations cannot contain expressions that fetch union case indexes" )
    /// Quotations cannot contain expressions that set union case fields
    /// (Originally from /src/fsharp/FSComp.txt:292)
    static member crefQuotationsCantSetUnionFields() = (455, sprintf "Quotations cannot contain expressions that set union case fields" )
    /// Quotations cannot contain expressions that set fields in exception values
    /// (Originally from /src/fsharp/FSComp.txt:293)
    static member crefQuotationsCantSetExceptionFields() = (456, sprintf "Quotations cannot contain expressions that set fields in exception values" )
    /// Quotations cannot contain expressions that require byref pointers
    /// (Originally from /src/fsharp/FSComp.txt:294)
    static member crefQuotationsCantRequireByref() = (457, sprintf "Quotations cannot contain expressions that require byref pointers" )
    /// Quotations cannot contain expressions that make member constraint calls, or uses of operators that implicitly resolve to a member constraint call
    /// (Originally from /src/fsharp/FSComp.txt:295)
    static member crefQuotationsCantCallTraitMembers() = (458, sprintf "Quotations cannot contain expressions that make member constraint calls, or uses of operators that implicitly resolve to a member constraint call" )
    /// Quotations cannot contain this kind of constant
    /// (Originally from /src/fsharp/FSComp.txt:296)
    static member crefQuotationsCantContainThisConstant() = (459, sprintf "Quotations cannot contain this kind of constant" )
    /// Quotations cannot contain this kind of pattern match
    /// (Originally from /src/fsharp/FSComp.txt:297)
    static member crefQuotationsCantContainThisPatternMatch() = (460, sprintf "Quotations cannot contain this kind of pattern match" )
    /// Quotations cannot contain array pattern matching
    /// (Originally from /src/fsharp/FSComp.txt:298)
    static member crefQuotationsCantContainArrayPatternMatching() = (461, sprintf "Quotations cannot contain array pattern matching" )
    /// Quotations cannot contain this kind of type
    /// (Originally from /src/fsharp/FSComp.txt:299)
    static member crefQuotationsCantContainThisType() = (462, sprintf "Quotations cannot contain this kind of type" )
    /// The declared type parameter '%s' cannot be used here since the type parameter cannot be resolved at compile time
    /// (Originally from /src/fsharp/FSComp.txt:300)
    static member csTypeCannotBeResolvedAtCompileTime(a0 : System.String) = (sprintf "The declared type parameter '%s' cannot be used here since the type parameter cannot be resolved at compile time" a0)
    /// This code is less generic than indicated by its annotations. A unit-of-measure specified using '_' has been determined to be '1', i.e. dimensionless. Consider making the code generic, or removing the use of '_'.
    /// (Originally from /src/fsharp/FSComp.txt:301)
    static member csCodeLessGeneric() = (464, sprintf "This code is less generic than indicated by its annotations. A unit-of-measure specified using '_' has been determined to be '1', i.e. dimensionless. Consider making the code generic, or removing the use of '_'." )
    /// Type inference problem too complicated (maximum iteration depth reached). Consider adding further type annotations.
    /// (Originally from /src/fsharp/FSComp.txt:302)
    static member csTypeInferenceMaxDepth() = (465, sprintf "Type inference problem too complicated (maximum iteration depth reached). Consider adding further type annotations." )
    /// Expected arguments to an instance member
    /// (Originally from /src/fsharp/FSComp.txt:303)
    static member csExpectedArguments() = (sprintf "Expected arguments to an instance member" )
    /// This indexer expects %d arguments but is here given %d
    /// (Originally from /src/fsharp/FSComp.txt:304)
    static member csIndexArgumentMismatch(a0 : System.Int32, a1 : System.Int32) = (sprintf "This indexer expects %d arguments but is here given %d" a0 a1)
    /// Expecting a type supporting the operator '%s' but given a function type. You may be missing an argument to a function.
    /// (Originally from /src/fsharp/FSComp.txt:305)
    static member csExpectTypeWithOperatorButGivenFunction(a0 : System.String) = (sprintf "Expecting a type supporting the operator '%s' but given a function type. You may be missing an argument to a function." a0)
    /// Expecting a type supporting the operator '%s' but given a tuple type
    /// (Originally from /src/fsharp/FSComp.txt:306)
    static member csExpectTypeWithOperatorButGivenTuple(a0 : System.String) = (sprintf "Expecting a type supporting the operator '%s' but given a tuple type" a0)
    /// None of the types '%s' support the operator '%s'
    /// (Originally from /src/fsharp/FSComp.txt:307)
    static member csTypesDoNotSupportOperator(a0 : System.String, a1 : System.String) = (sprintf "None of the types '%s' support the operator '%s'" a0 a1)
    /// The type '%s' does not support the operator '%s'
    /// (Originally from /src/fsharp/FSComp.txt:308)
    static member csTypeDoesNotSupportOperator(a0 : System.String, a1 : System.String) = (sprintf "The type '%s' does not support the operator '%s'" a0 a1)
    /// None of the types '%s' support the operator '%s'. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'.
    /// (Originally from /src/fsharp/FSComp.txt:309)
    static member csTypesDoNotSupportOperatorNullable(a0 : System.String, a1 : System.String) = (sprintf "None of the types '%s' support the operator '%s'. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'." a0 a1)
    /// The type '%s' does not support the operator '%s'. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'.
    /// (Originally from /src/fsharp/FSComp.txt:310)
    static member csTypeDoesNotSupportOperatorNullable(a0 : System.String, a1 : System.String) = (sprintf "The type '%s' does not support the operator '%s'. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'." a0 a1)
    /// The type '%s' does not support a conversion to the type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:311)
    static member csTypeDoesNotSupportConversion(a0 : System.String, a1 : System.String) = (sprintf "The type '%s' does not support a conversion to the type '%s'" a0 a1)
    /// The type '%s' has a method '%s' (full name '%s'), but the method is static
    /// (Originally from /src/fsharp/FSComp.txt:312)
    static member csMethodFoundButIsStatic(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The type '%s' has a method '%s' (full name '%s'), but the method is static" a0 a1 a2)
    /// The type '%s' has a method '%s' (full name '%s'), but the method is not static
    /// (Originally from /src/fsharp/FSComp.txt:313)
    static member csMethodFoundButIsNotStatic(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The type '%s' has a method '%s' (full name '%s'), but the method is not static" a0 a1 a2)
    /// The constraints 'struct' and 'not struct' are inconsistent
    /// (Originally from /src/fsharp/FSComp.txt:314)
    static member csStructConstraintInconsistent() = (472, sprintf "The constraints 'struct' and 'not struct' are inconsistent" )
    /// The type '%s' does not have 'null' as a proper value
    /// (Originally from /src/fsharp/FSComp.txt:315)
    static member csTypeDoesNotHaveNull(a0 : System.String) = (sprintf "The type '%s' does not have 'null' as a proper value" a0)
    /// The type '%s' does not have 'null' as a proper value. To create a null value for a Nullable type use 'System.Nullable()'.
    /// (Originally from /src/fsharp/FSComp.txt:316)
    static member csNullableTypeDoesNotHaveNull(a0 : System.String) = (sprintf "The type '%s' does not have 'null' as a proper value. To create a null value for a Nullable type use 'System.Nullable()'." a0)
    /// The type '%s' does not support the 'comparison' constraint because it has the 'NoComparison' attribute
    /// (Originally from /src/fsharp/FSComp.txt:317)
    static member csTypeDoesNotSupportComparison1(a0 : System.String) = (sprintf "The type '%s' does not support the 'comparison' constraint because it has the 'NoComparison' attribute" a0)
    /// The type '%s' does not support the 'comparison' constraint. For example, it does not support the 'System.IComparable' interface
    /// (Originally from /src/fsharp/FSComp.txt:318)
    static member csTypeDoesNotSupportComparison2(a0 : System.String) = (sprintf "The type '%s' does not support the 'comparison' constraint. For example, it does not support the 'System.IComparable' interface" a0)
    /// The type '%s' does not support the 'comparison' constraint because it is a record, union or struct with one or more structural element types which do not support the 'comparison' constraint. Either avoid the use of comparison with this type, or add the 'StructuralComparison' attribute to the type to determine which field type does not support comparison
    /// (Originally from /src/fsharp/FSComp.txt:319)
    static member csTypeDoesNotSupportComparison3(a0 : System.String) = (sprintf "The type '%s' does not support the 'comparison' constraint because it is a record, union or struct with one or more structural element types which do not support the 'comparison' constraint. Either avoid the use of comparison with this type, or add the 'StructuralComparison' attribute to the type to determine which field type does not support comparison" a0)
    /// The type '%s' does not support the 'equality' constraint because it has the 'NoEquality' attribute
    /// (Originally from /src/fsharp/FSComp.txt:320)
    static member csTypeDoesNotSupportEquality1(a0 : System.String) = (sprintf "The type '%s' does not support the 'equality' constraint because it has the 'NoEquality' attribute" a0)
    /// The type '%s' does not support the 'equality' constraint because it is a function type
    /// (Originally from /src/fsharp/FSComp.txt:321)
    static member csTypeDoesNotSupportEquality2(a0 : System.String) = (sprintf "The type '%s' does not support the 'equality' constraint because it is a function type" a0)
    /// The type '%s' does not support the 'equality' constraint because it is a record, union or struct with one or more structural element types which do not support the 'equality' constraint. Either avoid the use of equality with this type, or add the 'StructuralEquality' attribute to the type to determine which field type does not support equality
    /// (Originally from /src/fsharp/FSComp.txt:322)
    static member csTypeDoesNotSupportEquality3(a0 : System.String) = (sprintf "The type '%s' does not support the 'equality' constraint because it is a record, union or struct with one or more structural element types which do not support the 'equality' constraint. Either avoid the use of equality with this type, or add the 'StructuralEquality' attribute to the type to determine which field type does not support equality" a0)
    /// The type '%s' is not a CLI enum type
    /// (Originally from /src/fsharp/FSComp.txt:323)
    static member csTypeIsNotEnumType(a0 : System.String) = (sprintf "The type '%s' is not a CLI enum type" a0)
    /// The type '%s' has a non-standard delegate type
    /// (Originally from /src/fsharp/FSComp.txt:324)
    static member csTypeHasNonStandardDelegateType(a0 : System.String) = (sprintf "The type '%s' has a non-standard delegate type" a0)
    /// The type '%s' is not a CLI delegate type
    /// (Originally from /src/fsharp/FSComp.txt:325)
    static member csTypeIsNotDelegateType(a0 : System.String) = (sprintf "The type '%s' is not a CLI delegate type" a0)
    /// This type parameter cannot be instantiated to 'Nullable'. This is a restriction imposed in order to ensure the meaning of 'null' in some CLI languages is not confusing when used in conjunction with 'Nullable' values.
    /// (Originally from /src/fsharp/FSComp.txt:326)
    static member csTypeParameterCannotBeNullable() = (sprintf "This type parameter cannot be instantiated to 'Nullable'. This is a restriction imposed in order to ensure the meaning of 'null' in some CLI languages is not confusing when used in conjunction with 'Nullable' values." )
    /// A generic construct requires that the type '%s' is a CLI or F# struct type
    /// (Originally from /src/fsharp/FSComp.txt:327)
    static member csGenericConstructRequiresStructType(a0 : System.String) = (sprintf "A generic construct requires that the type '%s' is a CLI or F# struct type" a0)
    /// A generic construct requires that the type '%s' is an unmanaged type
    /// (Originally from /src/fsharp/FSComp.txt:328)
    static member csGenericConstructRequiresUnmanagedType(a0 : System.String) = (sprintf "A generic construct requires that the type '%s' is an unmanaged type" a0)
    /// The type '%s' is not compatible with any of the types %s, arising from the use of a printf-style format string
    /// (Originally from /src/fsharp/FSComp.txt:329)
    static member csTypeNotCompatibleBecauseOfPrintf(a0 : System.String, a1 : System.String) = (sprintf "The type '%s' is not compatible with any of the types %s, arising from the use of a printf-style format string" a0 a1)
    /// A generic construct requires that the type '%s' have reference semantics, but it does not, i.e. it is a struct
    /// (Originally from /src/fsharp/FSComp.txt:330)
    static member csGenericConstructRequiresReferenceSemantics(a0 : System.String) = (sprintf "A generic construct requires that the type '%s' have reference semantics, but it does not, i.e. it is a struct" a0)
    /// A generic construct requires that the type '%s' be non-abstract
    /// (Originally from /src/fsharp/FSComp.txt:331)
    static member csGenericConstructRequiresNonAbstract(a0 : System.String) = (sprintf "A generic construct requires that the type '%s' be non-abstract" a0)
    /// A generic construct requires that the type '%s' have a public default constructor
    /// (Originally from /src/fsharp/FSComp.txt:332)
    static member csGenericConstructRequiresPublicDefaultConstructor(a0 : System.String) = (sprintf "A generic construct requires that the type '%s' have a public default constructor" a0)
    /// Type instantiation length mismatch
    /// (Originally from /src/fsharp/FSComp.txt:333)
    static member csTypeInstantiationLengthMismatch() = (483, sprintf "Type instantiation length mismatch" )
    /// Optional arguments not permitted here
    /// (Originally from /src/fsharp/FSComp.txt:334)
    static member csOptionalArgumentNotPermittedHere() = (484, sprintf "Optional arguments not permitted here" )
    /// %s is not a static member
    /// (Originally from /src/fsharp/FSComp.txt:335)
    static member csMemberIsNotStatic(a0 : System.String) = (485, sprintf "%s is not a static member" a0)
    /// %s is not an instance member
    /// (Originally from /src/fsharp/FSComp.txt:336)
    static member csMemberIsNotInstance(a0 : System.String) = (486, sprintf "%s is not an instance member" a0)
    /// Argument length mismatch
    /// (Originally from /src/fsharp/FSComp.txt:337)
    static member csArgumentLengthMismatch() = (487, sprintf "Argument length mismatch" )
    /// The argument types don't match
    /// (Originally from /src/fsharp/FSComp.txt:338)
    static member csArgumentTypesDoNotMatch() = (488, sprintf "The argument types don't match" )
    /// This method expects a CLI 'params' parameter in this position. 'params' is a way of passing a variable number of arguments to a method in languages such as C#. Consider passing an array for this argument
    /// (Originally from /src/fsharp/FSComp.txt:339)
    static member csMethodExpectsParams() = (489, sprintf "This method expects a CLI 'params' parameter in this position. 'params' is a way of passing a variable number of arguments to a method in languages such as C#. Consider passing an array for this argument" )
    /// The member or object constructor '%s' is not %s
    /// (Originally from /src/fsharp/FSComp.txt:340)
    static member csMemberIsNotAccessible(a0 : System.String, a1 : System.String) = (490, sprintf "The member or object constructor '%s' is not %s" a0 a1)
    /// The member or object constructor '%s' is not %s. Private members may only be accessed from within the declaring type. Protected members may only be accessed from an extending type and cannot be accessed from inner lambda expressions.
    /// (Originally from /src/fsharp/FSComp.txt:341)
    static member csMemberIsNotAccessible2(a0 : System.String, a1 : System.String) = (491, sprintf "The member or object constructor '%s' is not %s. Private members may only be accessed from within the declaring type. Protected members may only be accessed from an extending type and cannot be accessed from inner lambda expressions." a0 a1)
    /// %s is not a static method
    /// (Originally from /src/fsharp/FSComp.txt:342)
    static member csMethodIsNotAStaticMethod(a0 : System.String) = (492, sprintf "%s is not a static method" a0)
    /// %s is not an instance method
    /// (Originally from /src/fsharp/FSComp.txt:343)
    static member csMethodIsNotAnInstanceMethod(a0 : System.String) = (493, sprintf "%s is not an instance method" a0)
    /// The member or object constructor '%s' has no argument or settable return property '%s'. %s.
    /// (Originally from /src/fsharp/FSComp.txt:344)
    static member csMemberHasNoArgumentOrReturnProperty(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The member or object constructor '%s' has no argument or settable return property '%s'. %s." a0 a1 a2)
    /// The object constructor '%s' has no argument or settable return property '%s'. %s.
    /// (Originally from /src/fsharp/FSComp.txt:345)
    static member csCtorHasNoArgumentOrReturnProperty(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "The object constructor '%s' has no argument or settable return property '%s'. %s." a0 a1 a2)
    /// The required signature is %s
    /// (Originally from /src/fsharp/FSComp.txt:346)
    static member csRequiredSignatureIs(a0 : System.String) = (495, sprintf "The required signature is %s" a0)
    /// The member or object constructor '%s' requires %d argument(s). The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:347)
    static member csMemberSignatureMismatch(a0 : System.String, a1 : System.Int32, a2 : System.String) = (496, sprintf "The member or object constructor '%s' requires %d argument(s). The required signature is '%s'." a0 a1 a2)
    /// The member or object constructor '%s' requires %d additional argument(s). The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:348)
    static member csMemberSignatureMismatch2(a0 : System.String, a1 : System.Int32, a2 : System.String) = (497, sprintf "The member or object constructor '%s' requires %d additional argument(s). The required signature is '%s'." a0 a1 a2)
    /// The member or object constructor '%s' requires %d argument(s). The required signature is '%s'. Some names for missing arguments are %s.
    /// (Originally from /src/fsharp/FSComp.txt:349)
    static member csMemberSignatureMismatch3(a0 : System.String, a1 : System.Int32, a2 : System.String, a3 : System.String) = (498, sprintf "The member or object constructor '%s' requires %d argument(s). The required signature is '%s'. Some names for missing arguments are %s." a0 a1 a2 a3)
    /// The member or object constructor '%s' requires %d additional argument(s). The required signature is '%s'. Some names for missing arguments are %s.
    /// (Originally from /src/fsharp/FSComp.txt:350)
    static member csMemberSignatureMismatch4(a0 : System.String, a1 : System.Int32, a2 : System.String, a3 : System.String) = (499, sprintf "The member or object constructor '%s' requires %d additional argument(s). The required signature is '%s'. Some names for missing arguments are %s." a0 a1 a2 a3)
    /// The member or object constructor '%s' requires %d argument(s) but is here given %d unnamed and %d named argument(s). The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:351)
    static member csMemberSignatureMismatchArityNamed(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.Int32, a4 : System.String) = (500, sprintf "The member or object constructor '%s' requires %d argument(s) but is here given %d unnamed and %d named argument(s). The required signature is '%s'." a0 a1 a2 a3 a4)
    /// The member or object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:352)
    static member csMemberSignatureMismatchArity(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String) = (501, sprintf "The member or object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'." a0 a1 a2 a3)
    /// The object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:353)
    static member csCtorSignatureMismatchArity(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String) = (501, sprintf "The object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'." a0 a1 a2 a3)
    /// The object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'. If some of the arguments are meant to assign values to properties, consider separating those arguments with a comma (',').
    /// (Originally from /src/fsharp/FSComp.txt:354)
    static member csCtorSignatureMismatchArityProp(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String) = (501, sprintf "The object constructor '%s' takes %d argument(s) but is here given %d. The required signature is '%s'. If some of the arguments are meant to assign values to properties, consider separating those arguments with a comma (',')." a0 a1 a2 a3)
    /// The member or object constructor '%s' takes %d type argument(s) but is here given %d. The required signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:355)
    static member csMemberSignatureMismatchArityType(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String) = (502, sprintf "The member or object constructor '%s' takes %d type argument(s) but is here given %d. The required signature is '%s'." a0 a1 a2 a3)
    /// A member or object constructor '%s' taking %d arguments is not accessible from this code location. All accessible versions of method '%s' take %d arguments.
    /// (Originally from /src/fsharp/FSComp.txt:356)
    static member csMemberNotAccessible(a0 : System.String, a1 : System.Int32, a2 : System.String, a3 : System.Int32) = (503, sprintf "A member or object constructor '%s' taking %d arguments is not accessible from this code location. All accessible versions of method '%s' take %d arguments." a0 a1 a2 a3)
    /// Incorrect generic instantiation. No %s member named '%s' takes %d generic arguments.
    /// (Originally from /src/fsharp/FSComp.txt:357)
    static member csIncorrectGenericInstantiation(a0 : System.String, a1 : System.String, a2 : System.Int32) = (504, sprintf "Incorrect generic instantiation. No %s member named '%s' takes %d generic arguments." a0 a1 a2)
    /// The member or object constructor '%s' does not take %d argument(s). An overload was found taking %d arguments.
    /// (Originally from /src/fsharp/FSComp.txt:358)
    static member csMemberOverloadArityMismatch(a0 : System.String, a1 : System.Int32, a2 : System.Int32) = (505, sprintf "The member or object constructor '%s' does not take %d argument(s). An overload was found taking %d arguments." a0 a1 a2)
    /// No %s member or object constructor named '%s' takes %d arguments
    /// (Originally from /src/fsharp/FSComp.txt:359)
    static member csNoMemberTakesTheseArguments(a0 : System.String, a1 : System.String, a2 : System.Int32) = (506, sprintf "No %s member or object constructor named '%s' takes %d arguments" a0 a1 a2)
    /// No %s member or object constructor named '%s' takes %d arguments. Note the call to this member also provides %d named arguments.
    /// (Originally from /src/fsharp/FSComp.txt:360)
    static member csNoMemberTakesTheseArguments2(a0 : System.String, a1 : System.String, a2 : System.Int32, a3 : System.Int32) = (507, sprintf "No %s member or object constructor named '%s' takes %d arguments. Note the call to this member also provides %d named arguments." a0 a1 a2 a3)
    /// No %s member or object constructor named '%s' takes %d arguments. The named argument '%s' doesn't correspond to any argument or settable return property for any overload.
    /// (Originally from /src/fsharp/FSComp.txt:361)
    static member csNoMemberTakesTheseArguments3(a0 : System.String, a1 : System.String, a2 : System.Int32, a3 : System.String) = (508, sprintf "No %s member or object constructor named '%s' takes %d arguments. The named argument '%s' doesn't correspond to any argument or settable return property for any overload." a0 a1 a2 a3)
    /// Method or object constructor '%s' not found
    /// (Originally from /src/fsharp/FSComp.txt:362)
    static member csMethodNotFound(a0 : System.String) = (509, sprintf "Method or object constructor '%s' not found" a0)
    /// No overloads match for method '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:363)
    static member csNoOverloadsFound(a0 : System.String) = (sprintf "No overloads match for method '%s'." a0)
    /// A unique overload for method '%s' could not be determined based on type information prior to this program point. A type annotation may be needed.
    /// (Originally from /src/fsharp/FSComp.txt:364)
    static member csMethodIsOverloaded(a0 : System.String) = (sprintf "A unique overload for method '%s' could not be determined based on type information prior to this program point. A type annotation may be needed." a0)
    /// Candidates: %s
    /// (Originally from /src/fsharp/FSComp.txt:365)
    static member csCandidates(a0 : System.String) = (sprintf "Candidates: %s" a0)
    /// The available overloads are shown below.
    /// (Originally from /src/fsharp/FSComp.txt:366)
    static member csSeeAvailableOverloads() = (sprintf "The available overloads are shown below." )
    /// Accessibility modifiers are not permitted on 'do' bindings, but '%s' was given.
    /// (Originally from /src/fsharp/FSComp.txt:367)
    static member parsDoCannotHaveVisibilityDeclarations(a0 : System.String) = (512, sprintf "Accessibility modifiers are not permitted on 'do' bindings, but '%s' was given." a0)
    /// End of file in #if section begun at or after here
    /// (Originally from /src/fsharp/FSComp.txt:368)
    static member parsEofInHashIf() = (513, sprintf "End of file in #if section begun at or after here" )
    /// End of file in string begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:369)
    static member parsEofInString() = (514, sprintf "End of file in string begun at or before here" )
    /// End of file in verbatim string begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:370)
    static member parsEofInVerbatimString() = (515, sprintf "End of file in verbatim string begun at or before here" )
    /// End of file in comment begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:371)
    static member parsEofInComment() = (516, sprintf "End of file in comment begun at or before here" )
    /// End of file in string embedded in comment begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:372)
    static member parsEofInStringInComment() = (517, sprintf "End of file in string embedded in comment begun at or before here" )
    /// End of file in verbatim string embedded in comment begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:373)
    static member parsEofInVerbatimStringInComment() = (518, sprintf "End of file in verbatim string embedded in comment begun at or before here" )
    /// End of file in IF-OCAML section begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:374)
    static member parsEofInIfOcaml() = (519, sprintf "End of file in IF-OCAML section begun at or before here" )
    /// End of file in directive begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:375)
    static member parsEofInDirective() = (520, sprintf "End of file in directive begun at or before here" )
    /// No #endif found for #if or #else
    /// (Originally from /src/fsharp/FSComp.txt:376)
    static member parsNoHashEndIfFound() = (521, sprintf "No #endif found for #if or #else" )
    /// Attributes have been ignored in this construct
    /// (Originally from /src/fsharp/FSComp.txt:377)
    static member parsAttributesIgnored() = (522, sprintf "Attributes have been ignored in this construct" )
    /// 'use' bindings are not permitted in primary constructors
    /// (Originally from /src/fsharp/FSComp.txt:378)
    static member parsUseBindingsIllegalInImplicitClassConstructors() = (523, sprintf "'use' bindings are not permitted in primary constructors" )
    /// 'use' bindings are not permitted in modules and are treated as 'let' bindings
    /// (Originally from /src/fsharp/FSComp.txt:379)
    static member parsUseBindingsIllegalInModules() = (524, sprintf "'use' bindings are not permitted in modules and are treated as 'let' bindings" )
    /// An integer for loop must use a simple identifier
    /// (Originally from /src/fsharp/FSComp.txt:380)
    static member parsIntegerForLoopRequiresSimpleIdentifier() = (525, sprintf "An integer for loop must use a simple identifier" )
    /// At most one 'with' augmentation is permitted
    /// (Originally from /src/fsharp/FSComp.txt:381)
    static member parsOnlyOneWithAugmentationAllowed() = (526, sprintf "At most one 'with' augmentation is permitted" )
    /// A semicolon is not expected at this point
    /// (Originally from /src/fsharp/FSComp.txt:382)
    static member parsUnexpectedSemicolon() = (527, sprintf "A semicolon is not expected at this point" )
    /// Unexpected end of input
    /// (Originally from /src/fsharp/FSComp.txt:383)
    static member parsUnexpectedEndOfFile() = (528, sprintf "Unexpected end of input" )
    /// Accessibility modifiers are not permitted here, but '%s' was given.
    /// (Originally from /src/fsharp/FSComp.txt:384)
    static member parsUnexpectedVisibilityDeclaration(a0 : System.String) = (529, sprintf "Accessibility modifiers are not permitted here, but '%s' was given." a0)
    /// Only '#' compiler directives may occur prior to the first 'namespace' declaration
    /// (Originally from /src/fsharp/FSComp.txt:385)
    static member parsOnlyHashDirectivesAllowed() = (530, sprintf "Only '#' compiler directives may occur prior to the first 'namespace' declaration" )
    /// Accessibility modifiers should come immediately prior to the identifier naming a construct
    /// (Originally from /src/fsharp/FSComp.txt:386)
    static member parsVisibilityDeclarationsShouldComePriorToIdentifier() = (531, sprintf "Accessibility modifiers should come immediately prior to the identifier naming a construct" )
    /// Files should begin with either a namespace or module declaration, e.g. 'namespace SomeNamespace.SubNamespace' or 'module SomeNamespace.SomeModule', but not both. To define a module within a namespace use 'module SomeModule = ...'
    /// (Originally from /src/fsharp/FSComp.txt:387)
    static member parsNamespaceOrModuleNotBoth() = (532, sprintf "Files should begin with either a namespace or module declaration, e.g. 'namespace SomeNamespace.SubNamespace' or 'module SomeNamespace.SomeModule', but not both. To define a module within a namespace use 'module SomeModule = ...'" )
    /// A module abbreviation must be a simple name, not a path
    /// (Originally from /src/fsharp/FSComp.txt:388)
    static member parsModuleAbbreviationMustBeSimpleName() = (534, sprintf "A module abbreviation must be a simple name, not a path" )
    /// Ignoring attributes on module abbreviation
    /// (Originally from /src/fsharp/FSComp.txt:389)
    static member parsIgnoreAttributesOnModuleAbbreviation() = (535, sprintf "Ignoring attributes on module abbreviation" )
    /// The '%s' accessibility attribute is not allowed on module abbreviation. Module abbreviations are always private.
    /// (Originally from /src/fsharp/FSComp.txt:390)
    static member parsIgnoreAttributesOnModuleAbbreviationAlwaysPrivate(a0 : System.String) = (536, sprintf "The '%s' accessibility attribute is not allowed on module abbreviation. Module abbreviations are always private." a0)
    /// The '%s' visibility attribute is not allowed on module abbreviation. Module abbreviations are always private.
    /// (Originally from /src/fsharp/FSComp.txt:391)
    static member parsIgnoreVisibilityOnModuleAbbreviationAlwaysPrivate(a0 : System.String) = (537, sprintf "The '%s' visibility attribute is not allowed on module abbreviation. Module abbreviations are always private." a0)
    /// Unclosed block
    /// (Originally from /src/fsharp/FSComp.txt:392)
    static member parsUnClosedBlockInHashLight() = (538, sprintf "Unclosed block" )
    /// Unmatched 'begin' or 'struct'
    /// (Originally from /src/fsharp/FSComp.txt:393)
    static member parsUnmatchedBeginOrStruct() = (539, sprintf "Unmatched 'begin' or 'struct'" )
    /// A module name must be a simple name, not a path
    /// (Originally from /src/fsharp/FSComp.txt:394)
    static member parsModuleDefnMustBeSimpleName() = (541, sprintf "A module name must be a simple name, not a path" )
    /// Unexpected empty type moduleDefn list
    /// (Originally from /src/fsharp/FSComp.txt:395)
    static member parsUnexpectedEmptyModuleDefn() = (542, sprintf "Unexpected empty type moduleDefn list" )
    /// Attributes should be placed before 'val'
    /// (Originally from /src/fsharp/FSComp.txt:396)
    static member parsAttributesMustComeBeforeVal() = (sprintf "Attributes should be placed before 'val'" )
    /// Attributes are not permitted on interface implementations
    /// (Originally from /src/fsharp/FSComp.txt:397)
    static member parsAttributesAreNotPermittedOnInterfaceImplementations() = (543, sprintf "Attributes are not permitted on interface implementations" )
    /// Syntax error
    /// (Originally from /src/fsharp/FSComp.txt:398)
    static member parsSyntaxError() = (544, sprintf "Syntax error" )
    /// Augmentations are not permitted on delegate type moduleDefns
    /// (Originally from /src/fsharp/FSComp.txt:399)
    static member parsAugmentationsIllegalOnDelegateType() = (545, sprintf "Augmentations are not permitted on delegate type moduleDefns" )
    /// Unmatched 'class', 'interface' or 'struct'
    /// (Originally from /src/fsharp/FSComp.txt:400)
    static member parsUnmatchedClassInterfaceOrStruct() = (546, sprintf "Unmatched 'class', 'interface' or 'struct'" )
    /// A type definition requires one or more members or other declarations. If you intend to define an empty class, struct or interface, then use 'type ... = class end', 'interface end' or 'struct end'.
    /// (Originally from /src/fsharp/FSComp.txt:401)
    static member parsEmptyTypeDefinition() = (547, sprintf "A type definition requires one or more members or other declarations. If you intend to define an empty class, struct or interface, then use 'type ... = class end', 'interface end' or 'struct end'." )
    /// Unmatched 'with' or badly formatted 'with' block
    /// (Originally from /src/fsharp/FSComp.txt:402)
    static member parsUnmatchedWith() = (550, sprintf "Unmatched 'with' or badly formatted 'with' block" )
    /// 'get', 'set' or 'get,set' required
    /// (Originally from /src/fsharp/FSComp.txt:403)
    static member parsGetOrSetRequired() = (551, sprintf "'get', 'set' or 'get,set' required" )
    /// Only class types may take value arguments
    /// (Originally from /src/fsharp/FSComp.txt:404)
    static member parsOnlyClassCanTakeValueArguments() = (552, sprintf "Only class types may take value arguments" )
    /// Unmatched 'begin'
    /// (Originally from /src/fsharp/FSComp.txt:405)
    static member parsUnmatchedBegin() = (553, sprintf "Unmatched 'begin'" )
    /// Invalid declaration syntax
    /// (Originally from /src/fsharp/FSComp.txt:406)
    static member parsInvalidDeclarationSyntax() = (554, sprintf "Invalid declaration syntax" )
    /// 'get' and/or 'set' required
    /// (Originally from /src/fsharp/FSComp.txt:407)
    static member parsGetAndOrSetRequired() = (555, sprintf "'get' and/or 'set' required" )
    /// Type annotations on property getters and setters must be given after the 'get()' or 'set(v)', e.g. 'with get() : string = ...'
    /// (Originally from /src/fsharp/FSComp.txt:408)
    static member parsTypeAnnotationsOnGetSet() = (556, sprintf "Type annotations on property getters and setters must be given after the 'get()' or 'set(v)', e.g. 'with get() : string = ...'" )
    /// A getter property is expected to be a function, e.g. 'get() = ...' or 'get(index) = ...'
    /// (Originally from /src/fsharp/FSComp.txt:409)
    static member parsGetterMustHaveAtLeastOneArgument() = (557, sprintf "A getter property is expected to be a function, e.g. 'get() = ...' or 'get(index) = ...'" )
    /// Multiple accessibilities given for property getter or setter
    /// (Originally from /src/fsharp/FSComp.txt:410)
    static member parsMultipleAccessibilitiesForGetSet() = (558, sprintf "Multiple accessibilities given for property getter or setter" )
    /// Property setters must be defined using 'set value = ', 'set idx value = ' or 'set (idx1,...,idxN) value = ... '
    /// (Originally from /src/fsharp/FSComp.txt:411)
    static member parsSetSyntax() = (559, sprintf "Property setters must be defined using 'set value = ', 'set idx value = ' or 'set (idx1,...,idxN) value = ... '" )
    /// Interfaces always have the same visibility as the enclosing type
    /// (Originally from /src/fsharp/FSComp.txt:412)
    static member parsInterfacesHaveSameVisibilityAsEnclosingType() = (560, sprintf "Interfaces always have the same visibility as the enclosing type" )
    /// Accessibility modifiers are not allowed on this member. Abstract slots always have the same visibility as the enclosing type.
    /// (Originally from /src/fsharp/FSComp.txt:413)
    static member parsAccessibilityModsIllegalForAbstract() = (561, sprintf "Accessibility modifiers are not allowed on this member. Abstract slots always have the same visibility as the enclosing type." )
    /// Attributes are not permitted on 'inherit' declarations
    /// (Originally from /src/fsharp/FSComp.txt:414)
    static member parsAttributesIllegalOnInherit() = (562, sprintf "Attributes are not permitted on 'inherit' declarations" )
    /// Accessibility modifiers are not permitted on an 'inherits' declaration
    /// (Originally from /src/fsharp/FSComp.txt:415)
    static member parsVisibilityIllegalOnInherit() = (563, sprintf "Accessibility modifiers are not permitted on an 'inherits' declaration" )
    /// 'inherit' declarations cannot have 'as' bindings. To access members of the base class when overriding a method, the syntax 'base.SomeMember' may be used; 'base' is a keyword. Remove this 'as' binding.
    /// (Originally from /src/fsharp/FSComp.txt:416)
    static member parsInheritDeclarationsCannotHaveAsBindings() = (564, sprintf "'inherit' declarations cannot have 'as' bindings. To access members of the base class when overriding a method, the syntax 'base.SomeMember' may be used; 'base' is a keyword. Remove this 'as' binding." )
    /// Attributes are not allowed here
    /// (Originally from /src/fsharp/FSComp.txt:417)
    static member parsAttributesIllegalHere() = (565, sprintf "Attributes are not allowed here" )
    /// Accessibility modifiers are not permitted in this position for type abbreviations
    /// (Originally from /src/fsharp/FSComp.txt:418)
    static member parsTypeAbbreviationsCannotHaveVisibilityDeclarations() = (566, sprintf "Accessibility modifiers are not permitted in this position for type abbreviations" )
    /// Accessibility modifiers are not permitted in this position for enum types
    /// (Originally from /src/fsharp/FSComp.txt:419)
    static member parsEnumTypesCannotHaveVisibilityDeclarations() = (567, sprintf "Accessibility modifiers are not permitted in this position for enum types" )
    /// All enum fields must be given values
    /// (Originally from /src/fsharp/FSComp.txt:420)
    static member parsAllEnumFieldsRequireValues() = (568, sprintf "All enum fields must be given values" )
    /// Accessibility modifiers are not permitted on inline assembly code types
    /// (Originally from /src/fsharp/FSComp.txt:421)
    static member parsInlineAssemblyCannotHaveVisibilityDeclarations() = (569, sprintf "Accessibility modifiers are not permitted on inline assembly code types" )
    /// Unexpected identifier: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:422)
    static member parsUnexpectedIdentifier(a0 : System.String) = (571, sprintf "Unexpected identifier: '%s'" a0)
    /// Accessibility modifiers are not permitted on union cases. Use 'type U = internal ...' or 'type U = private ...' to give an accessibility to the whole representation.
    /// (Originally from /src/fsharp/FSComp.txt:423)
    static member parsUnionCasesCannotHaveVisibilityDeclarations() = (572, sprintf "Accessibility modifiers are not permitted on union cases. Use 'type U = internal ...' or 'type U = private ...' to give an accessibility to the whole representation." )
    /// Accessibility modifiers are not permitted on enumeration fields
    /// (Originally from /src/fsharp/FSComp.txt:424)
    static member parsEnumFieldsCannotHaveVisibilityDeclarations() = (573, sprintf "Accessibility modifiers are not permitted on enumeration fields" )
    /// Consider using a separate record type instead
    /// (Originally from /src/fsharp/FSComp.txt:425)
    static member parsConsiderUsingSeparateRecordType() = (sprintf "Consider using a separate record type instead" )
    /// Accessibility modifiers are not permitted on record fields. Use 'type R = internal ...' or 'type R = private ...' to give an accessibility to the whole representation.
    /// (Originally from /src/fsharp/FSComp.txt:426)
    static member parsRecordFieldsCannotHaveVisibilityDeclarations() = (575, sprintf "Accessibility modifiers are not permitted on record fields. Use 'type R = internal ...' or 'type R = private ...' to give an accessibility to the whole representation." )
    /// The declaration form 'let ... and ...' for non-recursive bindings is not used in F# code. Consider using a sequence of 'let' bindings
    /// (Originally from /src/fsharp/FSComp.txt:427)
    static member parsLetAndForNonRecBindings() = (576, sprintf "The declaration form 'let ... and ...' for non-recursive bindings is not used in F# code. Consider using a sequence of 'let' bindings" )
    /// Unmatched '('
    /// (Originally from /src/fsharp/FSComp.txt:428)
    static member parsUnmatchedParen() = (583, sprintf "Unmatched '('" )
    /// Successive patterns should be separated by spaces or tupled
    /// (Originally from /src/fsharp/FSComp.txt:429)
    static member parsSuccessivePatternsShouldBeSpacedOrTupled() = (584, sprintf "Successive patterns should be separated by spaces or tupled" )
    /// No matching 'in' found for this 'let'
    /// (Originally from /src/fsharp/FSComp.txt:430)
    static member parsNoMatchingInForLet() = (586, sprintf "No matching 'in' found for this 'let'" )
    /// Error in the return expression for this 'let'. Possible incorrect indentation.
    /// (Originally from /src/fsharp/FSComp.txt:431)
    static member parsErrorInReturnForLetIncorrectIndentation() = (587, sprintf "Error in the return expression for this 'let'. Possible incorrect indentation." )
    /// The block following this '%s' is unfinished. Every code block is an expression and must have a result. '%s' cannot be the final code element in a block. Consider giving this block an explicit result.
    /// (Originally from /src/fsharp/FSComp.txt:432)
    static member parsExpectedExpressionAfterLet(a0 : System.String, a1 : System.String) = (588, sprintf "The block following this '%s' is unfinished. Every code block is an expression and must have a result. '%s' cannot be the final code element in a block. Consider giving this block an explicit result." a0 a1)
    /// Incomplete conditional. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:433)
    static member parsIncompleteIf() = (589, sprintf "Incomplete conditional. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'." )
    /// 'assert' may not be used as a first class value. Use 'assert <expr>' instead.
    /// (Originally from /src/fsharp/FSComp.txt:434)
    static member parsAssertIsNotFirstClassValue() = (590, sprintf "'assert' may not be used as a first class value. Use 'assert <expr>' instead." )
    /// Identifier expected
    /// (Originally from /src/fsharp/FSComp.txt:435)
    static member parsIdentifierExpected() = (594, sprintf "Identifier expected" )
    /// 'in' or '=' expected
    /// (Originally from /src/fsharp/FSComp.txt:436)
    static member parsInOrEqualExpected() = (595, sprintf "'in' or '=' expected" )
    /// The use of '->' in sequence and computation expressions is limited to the form 'for pat in expr -> expr'. Use the syntax 'for ... in ... do ... yield...' to generate elements in more complex sequence expressions.
    /// (Originally from /src/fsharp/FSComp.txt:437)
    static member parsArrowUseIsLimited() = (596, sprintf "The use of '->' in sequence and computation expressions is limited to the form 'for pat in expr -> expr'. Use the syntax 'for ... in ... do ... yield...' to generate elements in more complex sequence expressions." )
    /// Successive arguments should be separated by spaces or tupled, and arguments involving function or method applications should be parenthesized
    /// (Originally from /src/fsharp/FSComp.txt:438)
    static member parsSuccessiveArgsShouldBeSpacedOrTupled() = (597, sprintf "Successive arguments should be separated by spaces or tupled, and arguments involving function or method applications should be parenthesized" )
    /// Unmatched '['
    /// (Originally from /src/fsharp/FSComp.txt:439)
    static member parsUnmatchedBracket() = (598, sprintf "Unmatched '['" )
    /// Missing qualification after '.'
    /// (Originally from /src/fsharp/FSComp.txt:440)
    static member parsMissingQualificationAfterDot() = (599, sprintf "Missing qualification after '.'" )
    /// In F# code you may use 'expr.[expr]'. A type annotation may be required to indicate the first expression is an array
    /// (Originally from /src/fsharp/FSComp.txt:441)
    static member parsParenFormIsForML() = (sprintf "In F# code you may use 'expr.[expr]'. A type annotation may be required to indicate the first expression is an array" )
    /// Mismatched quotation, beginning with '%s'
    /// (Originally from /src/fsharp/FSComp.txt:442)
    static member parsMismatchedQuote(a0 : System.String) = (601, sprintf "Mismatched quotation, beginning with '%s'" a0)
    /// Unmatched '%s'
    /// (Originally from /src/fsharp/FSComp.txt:443)
    static member parsUnmatched(a0 : System.String) = (602, sprintf "Unmatched '%s'" a0)
    /// Unmatched '[|'
    /// (Originally from /src/fsharp/FSComp.txt:444)
    static member parsUnmatchedBracketBar() = (603, sprintf "Unmatched '[|'" )
    /// Unmatched '{'
    /// (Originally from /src/fsharp/FSComp.txt:445)
    static member parsUnmatchedBrace() = (604, sprintf "Unmatched '{'" )
    /// Unmatched '{|'
    /// (Originally from /src/fsharp/FSComp.txt:446)
    static member parsUnmatchedBraceBar() = (605, sprintf "Unmatched '{|'" )
    /// Field bindings must have the form 'id = expr;'
    /// (Originally from /src/fsharp/FSComp.txt:447)
    static member parsFieldBinding() = (609, sprintf "Field bindings must have the form 'id = expr;'" )
    /// This member is not permitted in an object implementation
    /// (Originally from /src/fsharp/FSComp.txt:448)
    static member parsMemberIllegalInObjectImplementation() = (610, sprintf "This member is not permitted in an object implementation" )
    /// Missing function body
    /// (Originally from /src/fsharp/FSComp.txt:449)
    static member parsMissingFunctionBody() = (611, sprintf "Missing function body" )
    /// Syntax error in labelled type argument
    /// (Originally from /src/fsharp/FSComp.txt:450)
    static member parsSyntaxErrorInLabeledType() = (613, sprintf "Syntax error in labelled type argument" )
    /// Unexpected infix operator in type expression
    /// (Originally from /src/fsharp/FSComp.txt:451)
    static member parsUnexpectedInfixOperator() = (615, sprintf "Unexpected infix operator in type expression" )
    /// The syntax '(typ,...,typ) ident' is not used in F# code. Consider using 'ident<typ,...,typ>' instead
    /// (Originally from /src/fsharp/FSComp.txt:452)
    static member parsMultiArgumentGenericTypeFormDeprecated() = (sprintf "The syntax '(typ,...,typ) ident' is not used in F# code. Consider using 'ident<typ,...,typ>' instead" )
    /// Invalid literal in type
    /// (Originally from /src/fsharp/FSComp.txt:453)
    static member parsInvalidLiteralInType() = (618, sprintf "Invalid literal in type" )
    /// Unexpected infix operator in unit-of-measure expression. Legal operators are '*', '/' and '^'.
    /// (Originally from /src/fsharp/FSComp.txt:454)
    static member parsUnexpectedOperatorForUnitOfMeasure() = (619, sprintf "Unexpected infix operator in unit-of-measure expression. Legal operators are '*', '/' and '^'." )
    /// Unexpected integer literal in unit-of-measure expression
    /// (Originally from /src/fsharp/FSComp.txt:455)
    static member parsUnexpectedIntegerLiteralForUnitOfMeasure() = (620, sprintf "Unexpected integer literal in unit-of-measure expression" )
    /// Syntax error: unexpected type parameter specification
    /// (Originally from /src/fsharp/FSComp.txt:456)
    static member parsUnexpectedTypeParameter() = (621, sprintf "Syntax error: unexpected type parameter specification" )
    /// Mismatched quotation operator name, beginning with '%s'
    /// (Originally from /src/fsharp/FSComp.txt:457)
    static member parsMismatchedQuotationName(a0 : System.String) = (622, sprintf "Mismatched quotation operator name, beginning with '%s'" a0)
    /// Active pattern case identifiers must begin with an uppercase letter
    /// (Originally from /src/fsharp/FSComp.txt:458)
    static member parsActivePatternCaseMustBeginWithUpperCase() = (623, sprintf "Active pattern case identifiers must begin with an uppercase letter" )
    /// The '|' character is not permitted in active pattern case identifiers
    /// (Originally from /src/fsharp/FSComp.txt:459)
    static member parsActivePatternCaseContainsPipe() = (624, sprintf "The '|' character is not permitted in active pattern case identifiers" )
    /// Denominator must not be 0 in unit-of-measure exponent
    /// (Originally from /src/fsharp/FSComp.txt:460)
    static member parsIllegalDenominatorForMeasureExponent() = (625, sprintf "Denominator must not be 0 in unit-of-measure exponent" )
    /// No '=' symbol should follow a 'namespace' declaration
    /// (Originally from /src/fsharp/FSComp.txt:461)
    static member parsNoEqualShouldFollowNamespace() = (sprintf "No '=' symbol should follow a 'namespace' declaration" )
    /// The syntax 'module ... = struct .. end' is not used in F# code. Consider using 'module ... = begin .. end'
    /// (Originally from /src/fsharp/FSComp.txt:462)
    static member parsSyntaxModuleStructEndDeprecated() = (sprintf "The syntax 'module ... = struct .. end' is not used in F# code. Consider using 'module ... = begin .. end'" )
    /// The syntax 'module ... : sig .. end' is not used in F# code. Consider using 'module ... = begin .. end'
    /// (Originally from /src/fsharp/FSComp.txt:463)
    static member parsSyntaxModuleSigEndDeprecated() = (sprintf "The syntax 'module ... : sig .. end' is not used in F# code. Consider using 'module ... = begin .. end'" )
    /// A static field was used where an instance field is expected
    /// (Originally from /src/fsharp/FSComp.txt:464)
    static member tcStaticFieldUsedWhenInstanceFieldExpected() = (627, sprintf "A static field was used where an instance field is expected" )
    /// Method '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:465)
    static member tcMethodNotAccessible(a0 : System.String) = (629, sprintf "Method '%s' is not accessible from this code location" a0)
    /// Implicit product of measures following /
    /// (Originally from /src/fsharp/FSComp.txt:467)
    static member tcImplicitMeasureFollowingSlash() = (632, sprintf "Implicit product of measures following /" )
    /// Unexpected SynMeasure.Anon
    /// (Originally from /src/fsharp/FSComp.txt:468)
    static member tcUnexpectedMeasureAnon() = (633, sprintf "Unexpected SynMeasure.Anon" )
    /// Non-zero constants cannot have generic units. For generic zero, write 0.0<_>.
    /// (Originally from /src/fsharp/FSComp.txt:469)
    static member tcNonZeroConstantCannotHaveGenericUnit() = (634, sprintf "Non-zero constants cannot have generic units. For generic zero, write 0.0<_>." )
    /// In sequence expressions, results are generated using 'yield'
    /// (Originally from /src/fsharp/FSComp.txt:470)
    static member tcSeqResultsUseYield() = (635, sprintf "In sequence expressions, results are generated using 'yield'" )
    /// Unexpected big rational constant
    /// (Originally from /src/fsharp/FSComp.txt:471)
    static member tcUnexpectedBigRationalConstant() = (sprintf "Unexpected big rational constant" )
    /// Units-of-measure supported only on float, float32, decimal and signed integer types
    /// (Originally from /src/fsharp/FSComp.txt:472)
    static member tcInvalidTypeForUnitsOfMeasure() = (636, sprintf "Units-of-measure supported only on float, float32, decimal and signed integer types" )
    /// Unexpected Const_uint16array
    /// (Originally from /src/fsharp/FSComp.txt:473)
    static member tcUnexpectedConstUint16Array() = (sprintf "Unexpected Const_uint16array" )
    /// Unexpected Const_bytearray
    /// (Originally from /src/fsharp/FSComp.txt:474)
    static member tcUnexpectedConstByteArray() = (sprintf "Unexpected Const_bytearray" )
    /// A parameter with attributes must also be given a name, e.g. '[<Attribute>] Name : Type'
    /// (Originally from /src/fsharp/FSComp.txt:475)
    static member tcParameterRequiresName() = (640, sprintf "A parameter with attributes must also be given a name, e.g. '[<Attribute>] Name : Type'" )
    /// Return values cannot have names
    /// (Originally from /src/fsharp/FSComp.txt:476)
    static member tcReturnValuesCannotHaveNames() = (641, sprintf "Return values cannot have names" )
    /// MemberKind.PropertyGetSet only expected in parse trees
    /// (Originally from /src/fsharp/FSComp.txt:477)
    static member tcMemberKindPropertyGetSetNotExpected() = (sprintf "MemberKind.PropertyGetSet only expected in parse trees" )
    /// Namespaces cannot contain values. Consider using a module to hold your value declarations.
    /// (Originally from /src/fsharp/FSComp.txt:478)
    static member tcNamespaceCannotContainValues() = (201, sprintf "Namespaces cannot contain values. Consider using a module to hold your value declarations." )
    /// Namespaces cannot contain extension members except in the same file and namespace declaration group where the type is defined. Consider using a module to hold declarations of extension members.
    /// (Originally from /src/fsharp/FSComp.txt:479)
    static member tcNamespaceCannotContainExtensionMembers() = (644, sprintf "Namespaces cannot contain extension members except in the same file and namespace declaration group where the type is defined. Consider using a module to hold declarations of extension members." )
    /// Multiple visibility attributes have been specified for this identifier
    /// (Originally from /src/fsharp/FSComp.txt:480)
    static member tcMultipleVisibilityAttributes() = (645, sprintf "Multiple visibility attributes have been specified for this identifier" )
    /// Multiple visibility attributes have been specified for this identifier. 'let' bindings in classes are always private, as are any 'let' bindings inside expressions.
    /// (Originally from /src/fsharp/FSComp.txt:481)
    static member tcMultipleVisibilityAttributesWithLet() = (646, sprintf "Multiple visibility attributes have been specified for this identifier. 'let' bindings in classes are always private, as are any 'let' bindings inside expressions." )
    /// The name '(%s)' should not be used as a member name. To define comparison semantics for a type, implement the 'System.IComparable' interface. If defining a static member for use from other CLI languages then use the name '%s' instead.
    /// (Originally from /src/fsharp/FSComp.txt:482)
    static member tcInvalidMethodNameForRelationalOperator(a0 : System.String, a1 : System.String) = (sprintf "The name '(%s)' should not be used as a member name. To define comparison semantics for a type, implement the 'System.IComparable' interface. If defining a static member for use from other CLI languages then use the name '%s' instead." a0 a1)
    /// The name '(%s)' should not be used as a member name. To define equality semantics for a type, override the 'Object.Equals' member. If defining a static member for use from other CLI languages then use the name '%s' instead.
    /// (Originally from /src/fsharp/FSComp.txt:483)
    static member tcInvalidMethodNameForEquality(a0 : System.String, a1 : System.String) = (sprintf "The name '(%s)' should not be used as a member name. To define equality semantics for a type, override the 'Object.Equals' member. If defining a static member for use from other CLI languages then use the name '%s' instead." a0 a1)
    /// The name '(%s)' should not be used as a member name. If defining a static member for use from other CLI languages then use the name '%s' instead.
    /// (Originally from /src/fsharp/FSComp.txt:484)
    static member tcInvalidMemberName(a0 : System.String, a1 : System.String) = (sprintf "The name '(%s)' should not be used as a member name. If defining a static member for use from other CLI languages then use the name '%s' instead." a0 a1)
    /// The name '(%s)' should not be used as a member name because it is given a standard definition in the F# library over fixed types
    /// (Originally from /src/fsharp/FSComp.txt:485)
    static member tcInvalidMemberNameFixedTypes(a0 : System.String) = (sprintf "The name '(%s)' should not be used as a member name because it is given a standard definition in the F# library over fixed types" a0)
    /// The '%s' operator should not normally be redefined. To define overloaded comparison semantics for a particular type, implement the 'System.IComparable' interface in the definition of that type.
    /// (Originally from /src/fsharp/FSComp.txt:486)
    static member tcInvalidOperatorDefinitionRelational(a0 : System.String) = (sprintf "The '%s' operator should not normally be redefined. To define overloaded comparison semantics for a particular type, implement the 'System.IComparable' interface in the definition of that type." a0)
    /// The '%s' operator should not normally be redefined. To define equality semantics for a type, override the 'Object.Equals' member in the definition of that type.
    /// (Originally from /src/fsharp/FSComp.txt:487)
    static member tcInvalidOperatorDefinitionEquality(a0 : System.String) = (sprintf "The '%s' operator should not normally be redefined. To define equality semantics for a type, override the 'Object.Equals' member in the definition of that type." a0)
    /// The '%s' operator should not normally be redefined. Consider using a different operator name
    /// (Originally from /src/fsharp/FSComp.txt:488)
    static member tcInvalidOperatorDefinition(a0 : System.String) = (sprintf "The '%s' operator should not normally be redefined. Consider using a different operator name" a0)
    /// The '%s' operator cannot be redefined. Consider using a different operator name
    /// (Originally from /src/fsharp/FSComp.txt:489)
    static member tcInvalidIndexOperatorDefinition(a0 : System.String) = (sprintf "The '%s' operator cannot be redefined. Consider using a different operator name" a0)
    /// Expected module or namespace parent %s
    /// (Originally from /src/fsharp/FSComp.txt:490)
    static member tcExpectModuleOrNamespaceParent(a0 : System.String) = (sprintf "Expected module or namespace parent %s" a0)
    /// The struct, record or union type '%s' implements the interface 'System.IComparable' explicitly. You must apply the 'CustomComparison' attribute to the type.
    /// (Originally from /src/fsharp/FSComp.txt:491)
    static member tcImplementsIComparableExplicitly(a0 : System.String) = (647, sprintf "The struct, record or union type '%s' implements the interface 'System.IComparable' explicitly. You must apply the 'CustomComparison' attribute to the type." a0)
    /// The struct, record or union type '%s' implements the interface 'System.IComparable<_>' explicitly. You must apply the 'CustomComparison' attribute to the type, and should also provide a consistent implementation of the non-generic interface System.IComparable.
    /// (Originally from /src/fsharp/FSComp.txt:492)
    static member tcImplementsGenericIComparableExplicitly(a0 : System.String) = (648, sprintf "The struct, record or union type '%s' implements the interface 'System.IComparable<_>' explicitly. You must apply the 'CustomComparison' attribute to the type, and should also provide a consistent implementation of the non-generic interface System.IComparable." a0)
    /// The struct, record or union type '%s' implements the interface 'System.IStructuralComparable' explicitly. Apply the 'CustomComparison' attribute to the type.
    /// (Originally from /src/fsharp/FSComp.txt:493)
    static member tcImplementsIStructuralComparableExplicitly(a0 : System.String) = (649, sprintf "The struct, record or union type '%s' implements the interface 'System.IStructuralComparable' explicitly. Apply the 'CustomComparison' attribute to the type." a0)
    /// This record contains fields from inconsistent types
    /// (Originally from /src/fsharp/FSComp.txt:494)
    static member tcRecordFieldInconsistentTypes() = (656, sprintf "This record contains fields from inconsistent types" )
    /// DLLImport stubs cannot be inlined
    /// (Originally from /src/fsharp/FSComp.txt:495)
    static member tcDllImportStubsCannotBeInlined() = (657, sprintf "DLLImport stubs cannot be inlined" )
    /// Structs may only bind a 'this' parameter at member declarations
    /// (Originally from /src/fsharp/FSComp.txt:496)
    static member tcStructsCanOnlyBindThisAtMemberDeclaration() = (658, sprintf "Structs may only bind a 'this' parameter at member declarations" )
    /// Unexpected expression at recursive inference point
    /// (Originally from /src/fsharp/FSComp.txt:497)
    static member tcUnexpectedExprAtRecInfPoint() = (659, sprintf "Unexpected expression at recursive inference point" )
    /// This code is less generic than required by its annotations because the explicit type variable '%s' could not be generalized. It was constrained to be '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:498)
    static member tcLessGenericBecauseOfAnnotation(a0 : System.String, a1 : System.String) = (660, sprintf "This code is less generic than required by its annotations because the explicit type variable '%s' could not be generalized. It was constrained to be '%s'." a0 a1)
    /// One or more of the explicit class or function type variables for this binding could not be generalized, because they were constrained to other types
    /// (Originally from /src/fsharp/FSComp.txt:499)
    static member tcConstrainedTypeVariableCannotBeGeneralized() = (661, sprintf "One or more of the explicit class or function type variables for this binding could not be generalized, because they were constrained to other types" )
    /// A generic type parameter has been used in a way that constrains it to always be '%s'
    /// (Originally from /src/fsharp/FSComp.txt:500)
    static member tcGenericParameterHasBeenConstrained(a0 : System.String) = (662, sprintf "A generic type parameter has been used in a way that constrains it to always be '%s'" a0)
    /// This type parameter has been used in a way that constrains it to always be '%s'
    /// (Originally from /src/fsharp/FSComp.txt:501)
    static member tcTypeParameterHasBeenConstrained(a0 : System.String) = (663, sprintf "This type parameter has been used in a way that constrains it to always be '%s'" a0)
    /// The type parameters inferred for this value are not stable under the erasure of type abbreviations. This is due to the use of type abbreviations which drop or reorder type parameters, e.g. \n\ttype taggedInt<'a> = int or\n\ttype swap<'a,'b> = 'b * 'a.\nConsider declaring the type parameters for this value explicitly, e.g.\n\tlet f<'a,'b> ((x,y) : swap<'b,'a>) : swap<'a,'b> = (y,x).
    /// (Originally from /src/fsharp/FSComp.txt:502)
    static member tcTypeParametersInferredAreNotStable() = (664, sprintf "The type parameters inferred for this value are not stable under the erasure of type abbreviations. This is due to the use of type abbreviations which drop or reorder type parameters, e.g. \n\ttype taggedInt<'a> = int or\n\ttype swap<'a,'b> = 'b * 'a.\nConsider declaring the type parameters for this value explicitly, e.g.\n\tlet f<'a,'b> ((x,y) : swap<'b,'a>) : swap<'a,'b> = (y,x)." )
    /// Explicit type parameters may only be used on module or member bindings
    /// (Originally from /src/fsharp/FSComp.txt:503)
    static member tcExplicitTypeParameterInvalid() = (665, sprintf "Explicit type parameters may only be used on module or member bindings" )
    /// You must explicitly declare either all or no type parameters when overriding a generic abstract method
    /// (Originally from /src/fsharp/FSComp.txt:504)
    static member tcOverridingMethodRequiresAllOrNoTypeParameters() = (666, sprintf "You must explicitly declare either all or no type parameters when overriding a generic abstract method" )
    /// The field labels and expected type of this record expression or pattern do not uniquely determine a corresponding record type
    /// (Originally from /src/fsharp/FSComp.txt:505)
    static member tcFieldsDoNotDetermineUniqueRecordType() = (667, sprintf "The field labels and expected type of this record expression or pattern do not uniquely determine a corresponding record type" )
    /// The field '%s' appears twice in this record expression or pattern
    /// (Originally from /src/fsharp/FSComp.txt:506)
    static member tcFieldAppearsTwiceInRecord(a0 : System.String) = (668, sprintf "The field '%s' appears twice in this record expression or pattern" a0)
    /// Unknown union case
    /// (Originally from /src/fsharp/FSComp.txt:507)
    static member tcUnknownUnion() = (669, sprintf "Unknown union case" )
    /// This code is not sufficiently generic. The type variable %s could not be generalized because it would escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:508)
    static member tcNotSufficientlyGenericBecauseOfScope(a0 : System.String) = (670, sprintf "This code is not sufficiently generic. The type variable %s could not be generalized because it would escape its scope." a0)
    /// A property cannot have explicit type parameters. Consider using a method instead.
    /// (Originally from /src/fsharp/FSComp.txt:509)
    static member tcPropertyRequiresExplicitTypeParameters() = (671, sprintf "A property cannot have explicit type parameters. Consider using a method instead." )
    /// A constructor cannot have explicit type parameters. Consider using a static construction method instead.
    /// (Originally from /src/fsharp/FSComp.txt:510)
    static member tcConstructorCannotHaveTypeParameters() = (672, sprintf "A constructor cannot have explicit type parameters. Consider using a static construction method instead." )
    /// This instance member needs a parameter to represent the object being invoked. Make the member static or use the notation 'member x.Member(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:511)
    static member tcInstanceMemberRequiresTarget() = (673, sprintf "This instance member needs a parameter to represent the object being invoked. Make the member static or use the notation 'member x.Member(args) = ...'." )
    /// Unexpected source-level property specification in syntax tree
    /// (Originally from /src/fsharp/FSComp.txt:512)
    static member tcUnexpectedPropertyInSyntaxTree() = (674, sprintf "Unexpected source-level property specification in syntax tree" )
    /// A static initializer requires an argument
    /// (Originally from /src/fsharp/FSComp.txt:513)
    static member tcStaticInitializerRequiresArgument() = (675, sprintf "A static initializer requires an argument" )
    /// An object constructor requires an argument
    /// (Originally from /src/fsharp/FSComp.txt:514)
    static member tcObjectConstructorRequiresArgument() = (676, sprintf "An object constructor requires an argument" )
    /// This static member should not have a 'this' parameter. Consider using the notation 'member Member(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:515)
    static member tcStaticMemberShouldNotHaveThis() = (677, sprintf "This static member should not have a 'this' parameter. Consider using the notation 'member Member(args) = ...'." )
    /// An explicit static initializer should use the syntax 'static new(args) = expr'
    /// (Originally from /src/fsharp/FSComp.txt:516)
    static member tcExplicitStaticInitializerSyntax() = (678, sprintf "An explicit static initializer should use the syntax 'static new(args) = expr'" )
    /// An explicit object constructor should use the syntax 'new(args) = expr'
    /// (Originally from /src/fsharp/FSComp.txt:517)
    static member tcExplicitObjectConstructorSyntax() = (679, sprintf "An explicit object constructor should use the syntax 'new(args) = expr'" )
    /// Unexpected source-level property specification
    /// (Originally from /src/fsharp/FSComp.txt:518)
    static member tcUnexpectedPropertySpec() = (680, sprintf "Unexpected source-level property specification" )
    /// This form of object expression is not used in F#. Use 'member this.MemberName ... = ...' to define member implementations in object expressions.
    /// (Originally from /src/fsharp/FSComp.txt:519)
    static member tcObjectExpressionFormDeprecated() = (sprintf "This form of object expression is not used in F#. Use 'member this.MemberName ... = ...' to define member implementations in object expressions." )
    /// Invalid declaration
    /// (Originally from /src/fsharp/FSComp.txt:520)
    static member tcInvalidDeclaration() = (682, sprintf "Invalid declaration" )
    /// Attributes are not allowed within patterns
    /// (Originally from /src/fsharp/FSComp.txt:521)
    static member tcAttributesInvalidInPatterns() = (683, sprintf "Attributes are not allowed within patterns" )
    /// The generic function '%s' must be given explicit type argument(s)
    /// (Originally from /src/fsharp/FSComp.txt:522)
    static member tcFunctionRequiresExplicitTypeArguments(a0 : System.String) = (685, sprintf "The generic function '%s' must be given explicit type argument(s)" a0)
    /// The method or function '%s' should not be given explicit type argument(s) because it does not declare its type parameters explicitly
    /// (Originally from /src/fsharp/FSComp.txt:523)
    static member tcDoesNotAllowExplicitTypeArguments(a0 : System.String) = (686, sprintf "The method or function '%s' should not be given explicit type argument(s) because it does not declare its type parameters explicitly" a0)
    /// This value, type or method expects %d type parameter(s) but was given %d
    /// (Originally from /src/fsharp/FSComp.txt:524)
    static member tcTypeParameterArityMismatch(a0 : System.Int32, a1 : System.Int32) = (687, sprintf "This value, type or method expects %d type parameter(s) but was given %d" a0 a1)
    /// The default, zero-initializing constructor of a struct type may only be used if all the fields of the struct type admit default initialization
    /// (Originally from /src/fsharp/FSComp.txt:525)
    static member tcDefaultStructConstructorCall() = (688, sprintf "The default, zero-initializing constructor of a struct type may only be used if all the fields of the struct type admit default initialization" )
    /// Couldn't find Dispose on IDisposable, or it was overloaded
    /// (Originally from /src/fsharp/FSComp.txt:526)
    static member tcCouldNotFindIDisposable() = (sprintf "Couldn't find Dispose on IDisposable, or it was overloaded" )
    /// This value is not a literal and cannot be used in a pattern
    /// (Originally from /src/fsharp/FSComp.txt:527)
    static member tcNonLiteralCannotBeUsedInPattern() = (689, sprintf "This value is not a literal and cannot be used in a pattern" )
    /// This field is readonly
    /// (Originally from /src/fsharp/FSComp.txt:528)
    static member tcFieldIsReadonly() = (690, sprintf "This field is readonly" )
    /// Named arguments must appear after all other arguments
    /// (Originally from /src/fsharp/FSComp.txt:529)
    static member tcNameArgumentsMustAppearLast() = (691, sprintf "Named arguments must appear after all other arguments" )
    /// This function value is being used to construct a delegate type whose signature includes a byref argument. You must use an explicit lambda expression taking %d arguments.
    /// (Originally from /src/fsharp/FSComp.txt:530)
    static member tcFunctionRequiresExplicitLambda(a0 : System.Int32) = (692, sprintf "This function value is being used to construct a delegate type whose signature includes a byref argument. You must use an explicit lambda expression taking %d arguments." a0)
    /// The type '%s' is not a type whose values can be enumerated with this syntax, i.e. is not compatible with either seq<_>, IEnumerable<_> or IEnumerable and does not have a GetEnumerator method
    /// (Originally from /src/fsharp/FSComp.txt:531)
    static member tcTypeCannotBeEnumerated(a0 : System.String) = (693, sprintf "The type '%s' is not a type whose values can be enumerated with this syntax, i.e. is not compatible with either seq<_>, IEnumerable<_> or IEnumerable and does not have a GetEnumerator method" a0)
    /// This recursive binding uses an invalid mixture of recursive forms
    /// (Originally from /src/fsharp/FSComp.txt:532)
    static member tcInvalidMixtureOfRecursiveForms() = (695, sprintf "This recursive binding uses an invalid mixture of recursive forms" )
    /// This is not a valid object construction expression. Explicit object constructors must either call an alternate constructor or initialize all fields of the object and specify a call to a super class constructor.
    /// (Originally from /src/fsharp/FSComp.txt:533)
    static member tcInvalidObjectConstructionExpression() = (696, sprintf "This is not a valid object construction expression. Explicit object constructors must either call an alternate constructor or initialize all fields of the object and specify a call to a super class constructor." )
    /// Invalid constraint
    /// (Originally from /src/fsharp/FSComp.txt:534)
    static member tcInvalidConstraint() = (697, sprintf "Invalid constraint" )
    /// Invalid constraint: the type used for the constraint is sealed, which means the constraint could only be satisfied by at most one solution
    /// (Originally from /src/fsharp/FSComp.txt:535)
    static member tcInvalidConstraintTypeSealed() = (698, sprintf "Invalid constraint: the type used for the constraint is sealed, which means the constraint could only be satisfied by at most one solution" )
    /// An 'enum' constraint must be of the form 'enum<type>'
    /// (Originally from /src/fsharp/FSComp.txt:536)
    static member tcInvalidEnumConstraint() = (699, sprintf "An 'enum' constraint must be of the form 'enum<type>'" )
    /// 'new' constraints must take one argument of type 'unit' and return the constructed type
    /// (Originally from /src/fsharp/FSComp.txt:537)
    static member tcInvalidNewConstraint() = (700, sprintf "'new' constraints must take one argument of type 'unit' and return the constructed type" )
    /// This property has an invalid type. Properties taking multiple indexer arguments should have types of the form 'ty1 * ty2 -> ty3'. Properties returning functions should have types of the form '(ty1 -> ty2)'.
    /// (Originally from /src/fsharp/FSComp.txt:538)
    static member tcInvalidPropertyType() = (701, sprintf "This property has an invalid type. Properties taking multiple indexer arguments should have types of the form 'ty1 * ty2 -> ty3'. Properties returning functions should have types of the form '(ty1 -> ty2)'." )
    /// Expected unit-of-measure parameter, not type parameter. Explicit unit-of-measure parameters must be marked with the [<Measure>] attribute.
    /// (Originally from /src/fsharp/FSComp.txt:539)
    static member tcExpectedUnitOfMeasureMarkWithAttribute() = (702, sprintf "Expected unit-of-measure parameter, not type parameter. Explicit unit-of-measure parameters must be marked with the [<Measure>] attribute." )
    /// Expected type parameter, not unit-of-measure parameter
    /// (Originally from /src/fsharp/FSComp.txt:540)
    static member tcExpectedTypeParameter() = (703, sprintf "Expected type parameter, not unit-of-measure parameter" )
    /// Expected type, not unit-of-measure
    /// (Originally from /src/fsharp/FSComp.txt:541)
    static member tcExpectedTypeNotUnitOfMeasure() = (704, sprintf "Expected type, not unit-of-measure" )
    /// Expected unit-of-measure, not type
    /// (Originally from /src/fsharp/FSComp.txt:542)
    static member tcExpectedUnitOfMeasureNotType() = (705, sprintf "Expected unit-of-measure, not type" )
    /// Units-of-measure cannot be used as prefix arguments to a type. Rewrite as postfix arguments in angle brackets.
    /// (Originally from /src/fsharp/FSComp.txt:543)
    static member tcInvalidUnitsOfMeasurePrefix() = (706, sprintf "Units-of-measure cannot be used as prefix arguments to a type. Rewrite as postfix arguments in angle brackets." )
    /// Unit-of-measure cannot be used in type constructor application
    /// (Originally from /src/fsharp/FSComp.txt:544)
    static member tcUnitsOfMeasureInvalidInTypeConstructor() = (707, sprintf "Unit-of-measure cannot be used in type constructor application" )
    /// This control construct may only be used if the computation expression builder defines a '%s' method
    /// (Originally from /src/fsharp/FSComp.txt:545)
    static member tcRequireBuilderMethod(a0 : System.String) = (708, sprintf "This control construct may only be used if the computation expression builder defines a '%s' method" a0)
    /// This type has no nested types
    /// (Originally from /src/fsharp/FSComp.txt:546)
    static member tcTypeHasNoNestedTypes() = (709, sprintf "This type has no nested types" )
    /// Unexpected %s in type expression
    /// (Originally from /src/fsharp/FSComp.txt:547)
    static member tcUnexpectedSymbolInTypeExpression(a0 : System.String) = (711, sprintf "Unexpected %s in type expression" a0)
    /// Type parameter cannot be used as type constructor
    /// (Originally from /src/fsharp/FSComp.txt:548)
    static member tcTypeParameterInvalidAsTypeConstructor() = (712, sprintf "Type parameter cannot be used as type constructor" )
    /// Illegal syntax in type expression
    /// (Originally from /src/fsharp/FSComp.txt:549)
    static member tcIllegalSyntaxInTypeExpression() = (713, sprintf "Illegal syntax in type expression" )
    /// Anonymous unit-of-measure cannot be nested inside another unit-of-measure expression
    /// (Originally from /src/fsharp/FSComp.txt:550)
    static member tcAnonymousUnitsOfMeasureCannotBeNested() = (714, sprintf "Anonymous unit-of-measure cannot be nested inside another unit-of-measure expression" )
    /// Anonymous type variables are not permitted in this declaration
    /// (Originally from /src/fsharp/FSComp.txt:551)
    static member tcAnonymousTypeInvalidInDeclaration() = (715, sprintf "Anonymous type variables are not permitted in this declaration" )
    /// Unexpected / in type
    /// (Originally from /src/fsharp/FSComp.txt:552)
    static member tcUnexpectedSlashInType() = (716, sprintf "Unexpected / in type" )
    /// Unexpected type arguments
    /// (Originally from /src/fsharp/FSComp.txt:553)
    static member tcUnexpectedTypeArguments() = (717, sprintf "Unexpected type arguments" )
    /// Optional arguments are only permitted on type members
    /// (Originally from /src/fsharp/FSComp.txt:554)
    static member tcOptionalArgsOnlyOnMembers() = (718, sprintf "Optional arguments are only permitted on type members" )
    /// Name '%s' not bound in pattern context
    /// (Originally from /src/fsharp/FSComp.txt:555)
    static member tcNameNotBoundInPattern(a0 : System.String) = (719, sprintf "Name '%s' not bound in pattern context" a0)
    /// Non-primitive numeric literal constants cannot be used in pattern matches because they can be mapped to multiple different types through the use of a NumericLiteral module. Consider using replacing with a variable, and use 'when <variable> = <constant>' at the end of the match clause.
    /// (Originally from /src/fsharp/FSComp.txt:556)
    static member tcInvalidNonPrimitiveLiteralInPatternMatch() = (720, sprintf "Non-primitive numeric literal constants cannot be used in pattern matches because they can be mapped to multiple different types through the use of a NumericLiteral module. Consider using replacing with a variable, and use 'when <variable> = <constant>' at the end of the match clause." )
    /// Type arguments cannot be specified here
    /// (Originally from /src/fsharp/FSComp.txt:557)
    static member tcInvalidTypeArgumentUsage() = (721, sprintf "Type arguments cannot be specified here" )
    /// Only active patterns returning exactly one result may accept arguments
    /// (Originally from /src/fsharp/FSComp.txt:558)
    static member tcRequireActivePatternWithOneResult() = (722, sprintf "Only active patterns returning exactly one result may accept arguments" )
    /// Invalid argument to parameterized pattern label
    /// (Originally from /src/fsharp/FSComp.txt:559)
    static member tcInvalidArgForParameterizedPattern() = (723, sprintf "Invalid argument to parameterized pattern label" )
    /// Internal error. Invalid index into active pattern array
    /// (Originally from /src/fsharp/FSComp.txt:560)
    static member tcInvalidIndexIntoActivePatternArray() = (724, sprintf "Internal error. Invalid index into active pattern array" )
    /// This union case does not take arguments
    /// (Originally from /src/fsharp/FSComp.txt:561)
    static member tcUnionCaseDoesNotTakeArguments() = (725, sprintf "This union case does not take arguments" )
    /// This union case takes one argument
    /// (Originally from /src/fsharp/FSComp.txt:562)
    static member tcUnionCaseRequiresOneArgument() = (726, sprintf "This union case takes one argument" )
    /// This union case expects %d arguments in tupled form
    /// (Originally from /src/fsharp/FSComp.txt:563)
    static member tcUnionCaseExpectsTupledArguments(a0 : System.Int32) = (727, sprintf "This union case expects %d arguments in tupled form" a0)
    /// Field '%s' is not static
    /// (Originally from /src/fsharp/FSComp.txt:564)
    static member tcFieldIsNotStatic(a0 : System.String) = (728, sprintf "Field '%s' is not static" a0)
    /// This field is not a literal and cannot be used in a pattern
    /// (Originally from /src/fsharp/FSComp.txt:565)
    static member tcFieldNotLiteralCannotBeUsedInPattern() = (729, sprintf "This field is not a literal and cannot be used in a pattern" )
    /// This is not a variable, constant, active recognizer or literal
    /// (Originally from /src/fsharp/FSComp.txt:566)
    static member tcRequireVarConstRecogOrLiteral() = (730, sprintf "This is not a variable, constant, active recognizer or literal" )
    /// This is not a valid pattern
    /// (Originally from /src/fsharp/FSComp.txt:567)
    static member tcInvalidPattern() = (731, sprintf "This is not a valid pattern" )
    /// Character range matches have been removed in F#. Consider using a 'when' pattern guard instead.
    /// (Originally from /src/fsharp/FSComp.txt:568)
    static member tcUseWhenPatternGuard() = (sprintf "Character range matches have been removed in F#. Consider using a 'when' pattern guard instead." )
    /// Illegal pattern
    /// (Originally from /src/fsharp/FSComp.txt:569)
    static member tcIllegalPattern() = (733, sprintf "Illegal pattern" )
    /// Syntax error - unexpected '?' symbol
    /// (Originally from /src/fsharp/FSComp.txt:570)
    static member tcSyntaxErrorUnexpectedQMark() = (734, sprintf "Syntax error - unexpected '?' symbol" )
    /// Expected %d expressions, got %d
    /// (Originally from /src/fsharp/FSComp.txt:571)
    static member tcExpressionCountMisMatch(a0 : System.Int32, a1 : System.Int32) = (735, sprintf "Expected %d expressions, got %d" a0 a1)
    /// TcExprUndelayed: delayed
    /// (Originally from /src/fsharp/FSComp.txt:572)
    static member tcExprUndelayed() = (736, sprintf "TcExprUndelayed: delayed" )
    /// This expression form may only be used in sequence and computation expressions
    /// (Originally from /src/fsharp/FSComp.txt:573)
    static member tcExpressionRequiresSequence() = (737, sprintf "This expression form may only be used in sequence and computation expressions" )
    /// Invalid object expression. Objects without overrides or interfaces should use the expression form 'new Type(args)' without braces.
    /// (Originally from /src/fsharp/FSComp.txt:574)
    static member tcInvalidObjectExpressionSyntaxForm() = (738, sprintf "Invalid object expression. Objects without overrides or interfaces should use the expression form 'new Type(args)' without braces." )
    /// Invalid object, sequence or record expression
    /// (Originally from /src/fsharp/FSComp.txt:575)
    static member tcInvalidObjectSequenceOrRecordExpression() = (739, sprintf "Invalid object, sequence or record expression" )
    /// Invalid record, sequence or computation expression. Sequence expressions should be of the form 'seq { ... }'
    /// (Originally from /src/fsharp/FSComp.txt:576)
    static member tcInvalidSequenceExpressionSyntaxForm() = (740, sprintf "Invalid record, sequence or computation expression. Sequence expressions should be of the form 'seq { ... }'" )
    /// This list or array expression includes an element of the form 'if ... then ... else'. Parenthesize this expression to indicate it is an individual element of the list or array, to disambiguate this from a list generated using a sequence expression
    /// (Originally from /src/fsharp/FSComp.txt:577)
    static member tcExpressionWithIfRequiresParenthesis() = (sprintf "This list or array expression includes an element of the form 'if ... then ... else'. Parenthesize this expression to indicate it is an individual element of the list or array, to disambiguate this from a list generated using a sequence expression" )
    /// Unable to parse format string '%s'
    /// (Originally from /src/fsharp/FSComp.txt:578)
    static member tcUnableToParseFormatString(a0 : System.String) = (741, sprintf "Unable to parse format string '%s'" a0)
    /// This list expression exceeds the maximum size for list literals. Use an array for larger literals and call Array.ToList.
    /// (Originally from /src/fsharp/FSComp.txt:579)
    static member tcListLiteralMaxSize() = (742, sprintf "This list expression exceeds the maximum size for list literals. Use an array for larger literals and call Array.ToList." )
    /// The expression form 'expr then expr' may only be used as part of an explicit object constructor
    /// (Originally from /src/fsharp/FSComp.txt:580)
    static member tcExpressionFormRequiresObjectConstructor() = (743, sprintf "The expression form 'expr then expr' may only be used as part of an explicit object constructor" )
    /// Named arguments cannot be given to member trait calls
    /// (Originally from /src/fsharp/FSComp.txt:581)
    static member tcNamedArgumentsCannotBeUsedInMemberTraits() = (744, sprintf "Named arguments cannot be given to member trait calls" )
    /// This is not a valid name for an enumeration case
    /// (Originally from /src/fsharp/FSComp.txt:582)
    static member tcNotValidEnumCaseName() = (745, sprintf "This is not a valid name for an enumeration case" )
    /// This field is not mutable
    /// (Originally from /src/fsharp/FSComp.txt:583)
    static member tcFieldIsNotMutable() = (746, sprintf "This field is not mutable" )
    /// This construct may only be used within list, array and sequence expressions, e.g. expressions of the form 'seq { ... }', '[ ... ]' or '[| ... |]'. These use the syntax 'for ... in ... do ... yield...' to generate elements
    /// (Originally from /src/fsharp/FSComp.txt:584)
    static member tcConstructRequiresListArrayOrSequence() = (747, sprintf "This construct may only be used within list, array and sequence expressions, e.g. expressions of the form 'seq { ... }', '[ ... ]' or '[| ... |]'. These use the syntax 'for ... in ... do ... yield...' to generate elements" )
    /// This construct may only be used within computation expressions. To return a value from an ordinary function simply write the expression without 'return'.
    /// (Originally from /src/fsharp/FSComp.txt:585)
    static member tcConstructRequiresComputationExpressions() = (748, sprintf "This construct may only be used within computation expressions. To return a value from an ordinary function simply write the expression without 'return'." )
    /// This construct may only be used within sequence or computation expressions
    /// (Originally from /src/fsharp/FSComp.txt:586)
    static member tcConstructRequiresSequenceOrComputations() = (749, sprintf "This construct may only be used within sequence or computation expressions" )
    /// This construct may only be used within computation expressions
    /// (Originally from /src/fsharp/FSComp.txt:587)
    static member tcConstructRequiresComputationExpression() = (750, sprintf "This construct may only be used within computation expressions" )
    /// Invalid indexer expression
    /// (Originally from /src/fsharp/FSComp.txt:588)
    static member tcInvalidIndexerExpression() = (751, sprintf "Invalid indexer expression" )
    /// The operator 'expr.[idx]' has been used on an object of indeterminate type based on information prior to this program point. Consider adding further type constraints
    /// (Originally from /src/fsharp/FSComp.txt:589)
    static member tcObjectOfIndeterminateTypeUsedRequireTypeConstraint() = (752, sprintf "The operator 'expr.[idx]' has been used on an object of indeterminate type based on information prior to this program point. Consider adding further type constraints" )
    /// Cannot inherit from a variable type
    /// (Originally from /src/fsharp/FSComp.txt:590)
    static member tcCannotInheritFromVariableType() = (753, sprintf "Cannot inherit from a variable type" )
    /// Calls to object constructors on type parameters cannot be given arguments
    /// (Originally from /src/fsharp/FSComp.txt:591)
    static member tcObjectConstructorsOnTypeParametersCannotTakeArguments() = (754, sprintf "Calls to object constructors on type parameters cannot be given arguments" )
    /// The 'CompiledName' attribute cannot be used with this language element
    /// (Originally from /src/fsharp/FSComp.txt:592)
    static member tcCompiledNameAttributeMisused() = (755, sprintf "The 'CompiledName' attribute cannot be used with this language element" )
    /// '%s' may only be used with named types
    /// (Originally from /src/fsharp/FSComp.txt:593)
    static member tcNamedTypeRequired(a0 : System.String) = (756, sprintf "'%s' may only be used with named types" a0)
    /// 'inherit' cannot be used on interface types. Consider implementing the interface by using 'interface ... with ... end' instead.
    /// (Originally from /src/fsharp/FSComp.txt:594)
    static member tcInheritCannotBeUsedOnInterfaceType() = (757, sprintf "'inherit' cannot be used on interface types. Consider implementing the interface by using 'interface ... with ... end' instead." )
    /// 'new' cannot be used on interface types. Consider using an object expression '{ new ... with ... }' instead.
    /// (Originally from /src/fsharp/FSComp.txt:595)
    static member tcNewCannotBeUsedOnInterfaceType() = (758, sprintf "'new' cannot be used on interface types. Consider using an object expression '{ new ... with ... }' instead." )
    /// Instances of this type cannot be created since it has been marked abstract or not all methods have been given implementations. Consider using an object expression '{ new ... with ... }' instead.
    /// (Originally from /src/fsharp/FSComp.txt:596)
    static member tcAbstractTypeCannotBeInstantiated() = (759, sprintf "Instances of this type cannot be created since it has been marked abstract or not all methods have been given implementations. Consider using an object expression '{ new ... with ... }' instead." )
    /// It is recommended that objects supporting the IDisposable interface are created using the syntax 'new Type(args)', rather than 'Type(args)' or 'Type' as a function value representing the constructor, to indicate that resources may be owned by the generated value
    /// (Originally from /src/fsharp/FSComp.txt:597)
    static member tcIDisposableTypeShouldUseNew() = (760, sprintf "It is recommended that objects supporting the IDisposable interface are created using the syntax 'new Type(args)', rather than 'Type(args)' or 'Type' as a function value representing the constructor, to indicate that resources may be owned by the generated value" )
    /// '%s' may only be used to construct object types
    /// (Originally from /src/fsharp/FSComp.txt:598)
    static member tcSyntaxCanOnlyBeUsedToCreateObjectTypes(a0 : System.String) = (761, sprintf "'%s' may only be used to construct object types" a0)
    /// Constructors for the type '%s' must directly or indirectly call its implicit object constructor. Use a call to the implicit object constructor instead of a record expression.
    /// (Originally from /src/fsharp/FSComp.txt:599)
    static member tcConstructorRequiresCall(a0 : System.String) = (762, sprintf "Constructors for the type '%s' must directly or indirectly call its implicit object constructor. Use a call to the implicit object constructor instead of a record expression." a0)
    /// The field '%s' has been given a value, but is not present in the type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:600)
    static member tcUndefinedField(a0 : System.String, a1 : System.String) = (763, sprintf "The field '%s' has been given a value, but is not present in the type '%s'" a0 a1)
    /// No assignment given for field '%s' of type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:601)
    static member tcFieldRequiresAssignment(a0 : System.String, a1 : System.String) = (764, sprintf "No assignment given for field '%s' of type '%s'" a0 a1)
    /// Extraneous fields have been given values
    /// (Originally from /src/fsharp/FSComp.txt:602)
    static member tcExtraneousFieldsGivenValues() = (765, sprintf "Extraneous fields have been given values" )
    /// Only overrides of abstract and virtual members may be specified in object expressions
    /// (Originally from /src/fsharp/FSComp.txt:603)
    static member tcObjectExpressionsCanOnlyOverrideAbstractOrVirtual() = (766, sprintf "Only overrides of abstract and virtual members may be specified in object expressions" )
    /// The member '%s' does not correspond to any abstract or virtual method available to override or implement.
    /// (Originally from /src/fsharp/FSComp.txt:604)
    static member tcNoAbstractOrVirtualMemberFound(a0 : System.String) = (767, sprintf "The member '%s' does not correspond to any abstract or virtual method available to override or implement." a0)
    /// The type %s contains the member '%s' but it is not a virtual or abstract method that is available to override or implement.
    /// (Originally from /src/fsharp/FSComp.txt:605)
    static member tcMemberFoundIsNotAbstractOrVirtual(a0 : System.String, a1 : System.String) = (767, sprintf "The type %s contains the member '%s' but it is not a virtual or abstract method that is available to override or implement." a0 a1)
    /// The member '%s' does not accept the correct number of arguments. %d argument(s) are expected, but %d were given. The required signature is '%s'.%s
    /// (Originally from /src/fsharp/FSComp.txt:606)
    static member tcArgumentArityMismatch(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String, a4 : System.String) = (768, sprintf "The member '%s' does not accept the correct number of arguments. %d argument(s) are expected, but %d were given. The required signature is '%s'.%s" a0 a1 a2 a3 a4)
    /// The member '%s' does not accept the correct number of arguments. One overload accepts %d arguments, but %d were given. The required signature is '%s'.%s
    /// (Originally from /src/fsharp/FSComp.txt:607)
    static member tcArgumentArityMismatchOneOverload(a0 : System.String, a1 : System.Int32, a2 : System.Int32, a3 : System.String, a4 : System.String) = (769, sprintf "The member '%s' does not accept the correct number of arguments. One overload accepts %d arguments, but %d were given. The required signature is '%s'.%s" a0 a1 a2 a3 a4)
    /// A simple method name is required here
    /// (Originally from /src/fsharp/FSComp.txt:608)
    static member tcSimpleMethodNameRequired() = (770, sprintf "A simple method name is required here" )
    /// The types System.ValueType, System.Enum, System.Delegate, System.MulticastDelegate and System.Array cannot be used as super types in an object expression or class
    /// (Originally from /src/fsharp/FSComp.txt:609)
    static member tcPredefinedTypeCannotBeUsedAsSuperType() = (771, sprintf "The types System.ValueType, System.Enum, System.Delegate, System.MulticastDelegate and System.Array cannot be used as super types in an object expression or class" )
    /// 'new' must be used with a named type
    /// (Originally from /src/fsharp/FSComp.txt:610)
    static member tcNewMustBeUsedWithNamedType() = (772, sprintf "'new' must be used with a named type" )
    /// Cannot create an extension of a sealed type
    /// (Originally from /src/fsharp/FSComp.txt:611)
    static member tcCannotCreateExtensionOfSealedType() = (773, sprintf "Cannot create an extension of a sealed type" )
    /// No arguments may be given when constructing a record value
    /// (Originally from /src/fsharp/FSComp.txt:612)
    static member tcNoArgumentsForRecordValue() = (774, sprintf "No arguments may be given when constructing a record value" )
    /// Interface implementations cannot be given on construction expressions
    /// (Originally from /src/fsharp/FSComp.txt:613)
    static member tcNoInterfaceImplementationForConstructionExpression() = (775, sprintf "Interface implementations cannot be given on construction expressions" )
    /// Object construction expressions may only be used to implement constructors in class types
    /// (Originally from /src/fsharp/FSComp.txt:614)
    static member tcObjectConstructionCanOnlyBeUsedInClassTypes() = (776, sprintf "Object construction expressions may only be used to implement constructors in class types" )
    /// Only simple bindings of the form 'id = expr' can be used in construction expressions
    /// (Originally from /src/fsharp/FSComp.txt:615)
    static member tcOnlySimpleBindingsCanBeUsedInConstructionExpressions() = (777, sprintf "Only simple bindings of the form 'id = expr' can be used in construction expressions" )
    /// Objects must be initialized by an object construction expression that calls an inherited object constructor and assigns a value to each field
    /// (Originally from /src/fsharp/FSComp.txt:616)
    static member tcObjectsMustBeInitializedWithObjectExpression() = (778, sprintf "Objects must be initialized by an object construction expression that calls an inherited object constructor and assigns a value to each field" )
    /// Expected an interface type
    /// (Originally from /src/fsharp/FSComp.txt:617)
    static member tcExpectedInterfaceType() = (779, sprintf "Expected an interface type" )
    /// Constructor expressions for interfaces do not take arguments
    /// (Originally from /src/fsharp/FSComp.txt:618)
    static member tcConstructorForInterfacesDoNotTakeArguments() = (780, sprintf "Constructor expressions for interfaces do not take arguments" )
    /// This object constructor requires arguments
    /// (Originally from /src/fsharp/FSComp.txt:619)
    static member tcConstructorRequiresArguments() = (781, sprintf "This object constructor requires arguments" )
    /// 'new' may only be used with object constructors
    /// (Originally from /src/fsharp/FSComp.txt:620)
    static member tcNewRequiresObjectConstructor() = (782, sprintf "'new' may only be used with object constructors" )
    /// At least one override did not correctly implement its corresponding abstract member
    /// (Originally from /src/fsharp/FSComp.txt:621)
    static member tcAtLeastOneOverrideIsInvalid() = (783, sprintf "At least one override did not correctly implement its corresponding abstract member" )
    /// This numeric literal requires that a module '%s' defining functions FromZero, FromOne, FromInt32, FromInt64 and FromString be in scope
    /// (Originally from /src/fsharp/FSComp.txt:622)
    static member tcNumericLiteralRequiresModule(a0 : System.String) = (784, sprintf "This numeric literal requires that a module '%s' defining functions FromZero, FromOne, FromInt32, FromInt64 and FromString be in scope" a0)
    /// Invalid record construction
    /// (Originally from /src/fsharp/FSComp.txt:623)
    static member tcInvalidRecordConstruction() = (785, sprintf "Invalid record construction" )
    /// The expression form { expr with ... } may only be used with record types. To build object types use { new Type(...) with ... }
    /// (Originally from /src/fsharp/FSComp.txt:624)
    static member tcExpressionFormRequiresRecordTypes() = (786, sprintf "The expression form { expr with ... } may only be used with record types. To build object types use { new Type(...) with ... }" )
    /// The inherited type is not an object model type
    /// (Originally from /src/fsharp/FSComp.txt:625)
    static member tcInheritedTypeIsNotObjectModelType() = (787, sprintf "The inherited type is not an object model type" )
    /// Object construction expressions (i.e. record expressions with inheritance specifications) may only be used to implement constructors in object model types. Use 'new ObjectType(args)' to construct instances of object model types outside of constructors
    /// (Originally from /src/fsharp/FSComp.txt:626)
    static member tcObjectConstructionExpressionCanOnlyImplementConstructorsInObjectModelTypes() = (788, sprintf "Object construction expressions (i.e. record expressions with inheritance specifications) may only be used to implement constructors in object model types. Use 'new ObjectType(args)' to construct instances of object model types outside of constructors" )
    /// '{ }' is not a valid expression. Records must include at least one field. Empty sequences are specified by using Seq.empty or an empty list '[]'.
    /// (Originally from /src/fsharp/FSComp.txt:627)
    static member tcEmptyRecordInvalid() = (789, sprintf "'{ }' is not a valid expression. Records must include at least one field. Empty sequences are specified by using Seq.empty or an empty list '[]'." )
    /// This type is not a record type. Values of class and struct types must be created using calls to object constructors.
    /// (Originally from /src/fsharp/FSComp.txt:628)
    static member tcTypeIsNotARecordTypeNeedConstructor() = (790, sprintf "This type is not a record type. Values of class and struct types must be created using calls to object constructors." )
    /// This type is not a record type
    /// (Originally from /src/fsharp/FSComp.txt:629)
    static member tcTypeIsNotARecordType() = (791, sprintf "This type is not a record type" )
    /// This construct is ambiguous as part of a computation expression. Nested expressions may be written using 'let _ = (...)' and nested computations using 'let! res = builder { ... }'.
    /// (Originally from /src/fsharp/FSComp.txt:630)
    static member tcConstructIsAmbiguousInComputationExpression() = (792, sprintf "This construct is ambiguous as part of a computation expression. Nested expressions may be written using 'let _ = (...)' and nested computations using 'let! res = builder { ... }'." )
    /// This construct is ambiguous as part of a sequence expression. Nested expressions may be written using 'let _ = (...)' and nested sequences using 'yield! seq {... }'.
    /// (Originally from /src/fsharp/FSComp.txt:631)
    static member tcConstructIsAmbiguousInSequenceExpression() = (793, sprintf "This construct is ambiguous as part of a sequence expression. Nested expressions may be written using 'let _ = (...)' and nested sequences using 'yield! seq {... }'." )
    /// 'do!' cannot be used within sequence expressions
    /// (Originally from /src/fsharp/FSComp.txt:632)
    static member tcDoBangIllegalInSequenceExpression() = (794, sprintf "'do!' cannot be used within sequence expressions" )
    /// The use of 'let! x = coll' in sequence expressions is not permitted. Use 'for x in coll' instead.
    /// (Originally from /src/fsharp/FSComp.txt:633)
    static member tcUseForInSequenceExpression() = (795, sprintf "The use of 'let! x = coll' in sequence expressions is not permitted. Use 'for x in coll' instead." )
    /// 'try'/'with' cannot be used within sequence expressions
    /// (Originally from /src/fsharp/FSComp.txt:634)
    static member tcTryIllegalInSequenceExpression() = (796, sprintf "'try'/'with' cannot be used within sequence expressions" )
    /// In sequence expressions, multiple results are generated using 'yield!'
    /// (Originally from /src/fsharp/FSComp.txt:635)
    static member tcUseYieldBangForMultipleResults() = (797, sprintf "In sequence expressions, multiple results are generated using 'yield!'" )
    /// Invalid assignment
    /// (Originally from /src/fsharp/FSComp.txt:636)
    static member tcInvalidAssignment() = (799, sprintf "Invalid assignment" )
    /// Invalid use of a type name
    /// (Originally from /src/fsharp/FSComp.txt:637)
    static member tcInvalidUseOfTypeName() = (800, sprintf "Invalid use of a type name" )
    /// This type has no accessible object constructors
    /// (Originally from /src/fsharp/FSComp.txt:638)
    static member tcTypeHasNoAccessibleConstructor() = (801, sprintf "This type has no accessible object constructors" )
    /// Invalid use of an interface type
    /// (Originally from /src/fsharp/FSComp.txt:641)
    static member tcInvalidUseOfInterfaceType() = (804, sprintf "Invalid use of an interface type" )
    /// Invalid use of a delegate constructor. Use the syntax 'new Type(args)' or just 'Type(args)'.
    /// (Originally from /src/fsharp/FSComp.txt:642)
    static member tcInvalidUseOfDelegate() = (805, sprintf "Invalid use of a delegate constructor. Use the syntax 'new Type(args)' or just 'Type(args)'." )
    /// Property '%s' is not static
    /// (Originally from /src/fsharp/FSComp.txt:643)
    static member tcPropertyIsNotStatic(a0 : System.String) = (806, sprintf "Property '%s' is not static" a0)
    /// Property '%s' is not readable
    /// (Originally from /src/fsharp/FSComp.txt:644)
    static member tcPropertyIsNotReadable(a0 : System.String) = (807, sprintf "Property '%s' is not readable" a0)
    /// This lookup cannot be used here
    /// (Originally from /src/fsharp/FSComp.txt:645)
    static member tcLookupMayNotBeUsedHere() = (808, sprintf "This lookup cannot be used here" )
    /// Property '%s' is static
    /// (Originally from /src/fsharp/FSComp.txt:646)
    static member tcPropertyIsStatic(a0 : System.String) = (809, sprintf "Property '%s' is static" a0)
    /// Property '%s' cannot be set
    /// (Originally from /src/fsharp/FSComp.txt:647)
    static member tcPropertyCannotBeSet1(a0 : System.String) = (810, sprintf "Property '%s' cannot be set" a0)
    /// Constructors must be applied to arguments and cannot be used as first-class values. If necessary use an anonymous function '(fun arg1 ... argN -> new Type(arg1,...,argN))'.
    /// (Originally from /src/fsharp/FSComp.txt:648)
    static member tcConstructorsCannotBeFirstClassValues() = (811, sprintf "Constructors must be applied to arguments and cannot be used as first-class values. If necessary use an anonymous function '(fun arg1 ... argN -> new Type(arg1,...,argN))'." )
    /// The syntax 'expr.id' may only be used with record labels, properties and fields
    /// (Originally from /src/fsharp/FSComp.txt:649)
    static member tcSyntaxFormUsedOnlyWithRecordLabelsPropertiesAndFields() = (812, sprintf "The syntax 'expr.id' may only be used with record labels, properties and fields" )
    /// Event '%s' is static
    /// (Originally from /src/fsharp/FSComp.txt:650)
    static member tcEventIsStatic(a0 : System.String) = (813, sprintf "Event '%s' is static" a0)
    /// Event '%s' is not static
    /// (Originally from /src/fsharp/FSComp.txt:651)
    static member tcEventIsNotStatic(a0 : System.String) = (814, sprintf "Event '%s' is not static" a0)
    /// The named argument '%s' did not match any argument or mutable property
    /// (Originally from /src/fsharp/FSComp.txt:652)
    static member tcNamedArgumentDidNotMatch(a0 : System.String) = (815, sprintf "The named argument '%s' did not match any argument or mutable property" a0)
    /// One or more of the overloads of this method has curried arguments. Consider redesigning these members to take arguments in tupled form.
    /// (Originally from /src/fsharp/FSComp.txt:653)
    static member tcOverloadsCannotHaveCurriedArguments() = (816, sprintf "One or more of the overloads of this method has curried arguments. Consider redesigning these members to take arguments in tupled form." )
    /// The unnamed arguments do not form a prefix of the arguments of the method called
    /// (Originally from /src/fsharp/FSComp.txt:654)
    static member tcUnnamedArgumentsDoNotFormPrefix() = (sprintf "The unnamed arguments do not form a prefix of the arguments of the method called" )
    /// Static optimization conditionals are only for use within the F# library
    /// (Originally from /src/fsharp/FSComp.txt:655)
    static member tcStaticOptimizationConditionalsOnlyForFSharpLibrary() = (817, sprintf "Static optimization conditionals are only for use within the F# library" )
    /// The corresponding formal argument is not optional
    /// (Originally from /src/fsharp/FSComp.txt:656)
    static member tcFormalArgumentIsNotOptional() = (818, sprintf "The corresponding formal argument is not optional" )
    /// Invalid optional assignment to a property or field
    /// (Originally from /src/fsharp/FSComp.txt:657)
    static member tcInvalidOptionalAssignmentToPropertyOrField() = (819, sprintf "Invalid optional assignment to a property or field" )
    /// A delegate constructor must be passed a single function value
    /// (Originally from /src/fsharp/FSComp.txt:658)
    static member tcDelegateConstructorMustBePassed() = (820, sprintf "A delegate constructor must be passed a single function value" )
    /// A binding cannot be marked both 'use' and 'rec'
    /// (Originally from /src/fsharp/FSComp.txt:659)
    static member tcBindingCannotBeUseAndRec() = (821, sprintf "A binding cannot be marked both 'use' and 'rec'" )
    /// The 'VolatileField' attribute may only be used on 'let' bindings in classes
    /// (Originally from /src/fsharp/FSComp.txt:660)
    static member tcVolatileOnlyOnClassLetBindings() = (823, sprintf "The 'VolatileField' attribute may only be used on 'let' bindings in classes" )
    /// Attributes are not permitted on 'let' bindings in expressions
    /// (Originally from /src/fsharp/FSComp.txt:661)
    static member tcAttributesAreNotPermittedOnLetBindings() = (824, sprintf "Attributes are not permitted on 'let' bindings in expressions" )
    /// The 'DefaultValue' attribute may only be used on 'val' declarations
    /// (Originally from /src/fsharp/FSComp.txt:662)
    static member tcDefaultValueAttributeRequiresVal() = (825, sprintf "The 'DefaultValue' attribute may only be used on 'val' declarations" )
    /// The 'ConditionalAttribute' attribute may only be used on members
    /// (Originally from /src/fsharp/FSComp.txt:663)
    static member tcConditionalAttributeRequiresMembers() = (826, sprintf "The 'ConditionalAttribute' attribute may only be used on members" )
    /// This is not a valid name for an active pattern
    /// (Originally from /src/fsharp/FSComp.txt:664)
    static member tcInvalidActivePatternName() = (827, sprintf "This is not a valid name for an active pattern" )
    /// The 'EntryPointAttribute' attribute may only be used on function definitions in modules
    /// (Originally from /src/fsharp/FSComp.txt:665)
    static member tcEntryPointAttributeRequiresFunctionInModule() = (828, sprintf "The 'EntryPointAttribute' attribute may only be used on function definitions in modules" )
    /// Mutable values cannot be marked 'inline'
    /// (Originally from /src/fsharp/FSComp.txt:666)
    static member tcMutableValuesCannotBeInline() = (829, sprintf "Mutable values cannot be marked 'inline'" )
    /// Mutable values cannot have generic parameters
    /// (Originally from /src/fsharp/FSComp.txt:667)
    static member tcMutableValuesMayNotHaveGenericParameters() = (830, sprintf "Mutable values cannot have generic parameters" )
    /// Mutable function values should be written 'let mutable f = (fun args -> ...)'
    /// (Originally from /src/fsharp/FSComp.txt:668)
    static member tcMutableValuesSyntax() = (831, sprintf "Mutable function values should be written 'let mutable f = (fun args -> ...)'" )
    /// Only functions may be marked 'inline'
    /// (Originally from /src/fsharp/FSComp.txt:669)
    static member tcOnlyFunctionsCanBeInline() = (832, sprintf "Only functions may be marked 'inline'" )
    /// A literal value cannot be given the [<ThreadStatic>] or [<ContextStatic>] attributes
    /// (Originally from /src/fsharp/FSComp.txt:670)
    static member tcIllegalAttributesForLiteral() = (833, sprintf "A literal value cannot be given the [<ThreadStatic>] or [<ContextStatic>] attributes" )
    /// A literal value cannot be marked 'mutable'
    /// (Originally from /src/fsharp/FSComp.txt:671)
    static member tcLiteralCannotBeMutable() = (834, sprintf "A literal value cannot be marked 'mutable'" )
    /// A literal value cannot be marked 'inline'
    /// (Originally from /src/fsharp/FSComp.txt:672)
    static member tcLiteralCannotBeInline() = (835, sprintf "A literal value cannot be marked 'inline'" )
    /// Literal values cannot have generic parameters
    /// (Originally from /src/fsharp/FSComp.txt:673)
    static member tcLiteralCannotHaveGenericParameters() = (836, sprintf "Literal values cannot have generic parameters" )
    /// This is not a valid constant expression
    /// (Originally from /src/fsharp/FSComp.txt:674)
    static member tcInvalidConstantExpression() = (837, sprintf "This is not a valid constant expression" )
    /// This type is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:675)
    static member tcTypeIsInaccessible() = (838, sprintf "This type is not accessible from this code location" )
    /// Unexpected condition in imported assembly: failed to decode AttributeUsage attribute
    /// (Originally from /src/fsharp/FSComp.txt:676)
    static member tcUnexpectedConditionInImportedAssembly() = (839, sprintf "Unexpected condition in imported assembly: failed to decode AttributeUsage attribute" )
    /// Unrecognized attribute target. Valid attribute targets are 'assembly', 'module', 'type', 'method', 'property', 'return', 'param', 'field', 'event', 'constructor'.
    /// (Originally from /src/fsharp/FSComp.txt:677)
    static member tcUnrecognizedAttributeTarget() = (840, sprintf "Unrecognized attribute target. Valid attribute targets are 'assembly', 'module', 'type', 'method', 'property', 'return', 'param', 'field', 'event', 'constructor'." )
    /// This attribute is not valid for use on this language element. Assembly attributes should be attached to a 'do ()' declaration, if necessary within an F# module.
    /// (Originally from /src/fsharp/FSComp.txt:678)
    static member tcAttributeIsNotValidForLanguageElementUseDo() = (841, sprintf "This attribute is not valid for use on this language element. Assembly attributes should be attached to a 'do ()' declaration, if necessary within an F# module." )
    /// This attribute is not valid for use on this language element
    /// (Originally from /src/fsharp/FSComp.txt:679)
    static member tcAttributeIsNotValidForLanguageElement() = (842, sprintf "This attribute is not valid for use on this language element" )
    /// Optional arguments cannot be used in custom attributes
    /// (Originally from /src/fsharp/FSComp.txt:680)
    static member tcOptionalArgumentsCannotBeUsedInCustomAttribute() = (843, sprintf "Optional arguments cannot be used in custom attributes" )
    /// This property cannot be set
    /// (Originally from /src/fsharp/FSComp.txt:681)
    static member tcPropertyCannotBeSet0() = (844, sprintf "This property cannot be set" )
    /// This property or field was not found on this custom attribute type
    /// (Originally from /src/fsharp/FSComp.txt:682)
    static member tcPropertyOrFieldNotFoundInAttribute() = (845, sprintf "This property or field was not found on this custom attribute type" )
    /// A custom attribute must be a reference type
    /// (Originally from /src/fsharp/FSComp.txt:683)
    static member tcCustomAttributeMustBeReferenceType() = (846, sprintf "A custom attribute must be a reference type" )
    /// The number of args for a custom attribute does not match the expected number of args for the attribute constructor
    /// (Originally from /src/fsharp/FSComp.txt:684)
    static member tcCustomAttributeArgumentMismatch() = (847, sprintf "The number of args for a custom attribute does not match the expected number of args for the attribute constructor" )
    /// A custom attribute must invoke an object constructor
    /// (Originally from /src/fsharp/FSComp.txt:685)
    static member tcCustomAttributeMustInvokeConstructor() = (848, sprintf "A custom attribute must invoke an object constructor" )
    /// Attribute expressions must be calls to object constructors
    /// (Originally from /src/fsharp/FSComp.txt:686)
    static member tcAttributeExpressionsMustBeConstructorCalls() = (849, sprintf "Attribute expressions must be calls to object constructors" )
    /// This attribute cannot be used in this version of F#
    /// (Originally from /src/fsharp/FSComp.txt:687)
    static member tcUnsupportedAttribute() = (850, sprintf "This attribute cannot be used in this version of F#" )
    /// Invalid inline specification
    /// (Originally from /src/fsharp/FSComp.txt:688)
    static member tcInvalidInlineSpecification() = (851, sprintf "Invalid inline specification" )
    /// 'use' bindings must be of the form 'use <var> = <expr>'
    /// (Originally from /src/fsharp/FSComp.txt:689)
    static member tcInvalidUseBinding() = (852, sprintf "'use' bindings must be of the form 'use <var> = <expr>'" )
    /// Abstract members are not permitted in an augmentation - they must be defined as part of the type itself
    /// (Originally from /src/fsharp/FSComp.txt:690)
    static member tcAbstractMembersIllegalInAugmentation() = (853, sprintf "Abstract members are not permitted in an augmentation - they must be defined as part of the type itself" )
    /// Method overrides and interface implementations are not permitted here
    /// (Originally from /src/fsharp/FSComp.txt:691)
    static member tcMethodOverridesIllegalHere() = (854, sprintf "Method overrides and interface implementations are not permitted here" )
    /// No abstract or interface member was found that corresponds to this override
    /// (Originally from /src/fsharp/FSComp.txt:692)
    static member tcNoMemberFoundForOverride() = (855, sprintf "No abstract or interface member was found that corresponds to this override" )
    /// This override takes a different number of arguments to the corresponding abstract member. The following abstract members were found:%s
    /// (Originally from /src/fsharp/FSComp.txt:693)
    static member tcOverrideArityMismatch(a0 : System.String) = (856, sprintf "This override takes a different number of arguments to the corresponding abstract member. The following abstract members were found:%s" a0)
    /// This method already has a default implementation
    /// (Originally from /src/fsharp/FSComp.txt:694)
    static member tcDefaultImplementationAlreadyExists() = (857, sprintf "This method already has a default implementation" )
    /// The method implemented by this default is ambiguous
    /// (Originally from /src/fsharp/FSComp.txt:695)
    static member tcDefaultAmbiguous() = (858, sprintf "The method implemented by this default is ambiguous" )
    /// No abstract property was found that corresponds to this override
    /// (Originally from /src/fsharp/FSComp.txt:696)
    static member tcNoPropertyFoundForOverride() = (859, sprintf "No abstract property was found that corresponds to this override" )
    /// This property overrides or implements an abstract property but the abstract property doesn't have a corresponding %s
    /// (Originally from /src/fsharp/FSComp.txt:697)
    static member tcAbstractPropertyMissingGetOrSet(a0 : System.String) = (860, sprintf "This property overrides or implements an abstract property but the abstract property doesn't have a corresponding %s" a0)
    /// Invalid signature for set member
    /// (Originally from /src/fsharp/FSComp.txt:698)
    static member tcInvalidSignatureForSet() = (861, sprintf "Invalid signature for set member" )
    /// This new member hides the abstract member '%s'. Rename the member or use 'override' instead.
    /// (Originally from /src/fsharp/FSComp.txt:699)
    static member tcNewMemberHidesAbstractMember(a0 : System.String) = (864, sprintf "This new member hides the abstract member '%s'. Rename the member or use 'override' instead." a0)
    /// This new member hides the abstract member '%s' once tuples, functions, units of measure and/or provided types are erased. Rename the member or use 'override' instead.
    /// (Originally from /src/fsharp/FSComp.txt:700)
    static member tcNewMemberHidesAbstractMemberWithSuffix(a0 : System.String) = (864, sprintf "This new member hides the abstract member '%s' once tuples, functions, units of measure and/or provided types are erased. Rename the member or use 'override' instead." a0)
    /// Interfaces cannot contain definitions of static initializers
    /// (Originally from /src/fsharp/FSComp.txt:701)
    static member tcStaticInitializersIllegalInInterface() = (865, sprintf "Interfaces cannot contain definitions of static initializers" )
    /// Interfaces cannot contain definitions of object constructors
    /// (Originally from /src/fsharp/FSComp.txt:702)
    static member tcObjectConstructorsIllegalInInterface() = (866, sprintf "Interfaces cannot contain definitions of object constructors" )
    /// Interfaces cannot contain definitions of member overrides
    /// (Originally from /src/fsharp/FSComp.txt:703)
    static member tcMemberOverridesIllegalInInterface() = (867, sprintf "Interfaces cannot contain definitions of member overrides" )
    /// Interfaces cannot contain definitions of concrete members. You may need to define a constructor on your type to indicate that the type is a class.
    /// (Originally from /src/fsharp/FSComp.txt:704)
    static member tcConcreteMembersIllegalInInterface() = (868, sprintf "Interfaces cannot contain definitions of concrete members. You may need to define a constructor on your type to indicate that the type is a class." )
    /// Constructors cannot be specified in exception augmentations
    /// (Originally from /src/fsharp/FSComp.txt:705)
    static member tcConstructorsDisallowedInExceptionAugmentation() = (869, sprintf "Constructors cannot be specified in exception augmentations" )
    /// Structs cannot have an object constructor with no arguments. This is a restriction imposed on all CLI languages as structs automatically support a default constructor.
    /// (Originally from /src/fsharp/FSComp.txt:706)
    static member tcStructsCannotHaveConstructorWithNoArguments() = (870, sprintf "Structs cannot have an object constructor with no arguments. This is a restriction imposed on all CLI languages as structs automatically support a default constructor." )
    /// Constructors cannot be defined for this type
    /// (Originally from /src/fsharp/FSComp.txt:707)
    static member tcConstructorsIllegalForThisType() = (871, sprintf "Constructors cannot be defined for this type" )
    /// Recursive bindings that include member specifications can only occur as a direct augmentation of a type
    /// (Originally from /src/fsharp/FSComp.txt:708)
    static member tcRecursiveBindingsWithMembersMustBeDirectAugmentation() = (872, sprintf "Recursive bindings that include member specifications can only occur as a direct augmentation of a type" )
    /// Only simple variable patterns can be bound in 'let rec' constructs
    /// (Originally from /src/fsharp/FSComp.txt:709)
    static member tcOnlySimplePatternsInLetRec() = (873, sprintf "Only simple variable patterns can be bound in 'let rec' constructs" )
    /// Only record fields and simple, non-recursive 'let' bindings may be marked mutable
    /// (Originally from /src/fsharp/FSComp.txt:710)
    static member tcOnlyRecordFieldsAndSimpleLetCanBeMutable() = (874, sprintf "Only record fields and simple, non-recursive 'let' bindings may be marked mutable" )
    /// This member is not sufficiently generic
    /// (Originally from /src/fsharp/FSComp.txt:711)
    static member tcMemberIsNotSufficientlyGeneric() = (875, sprintf "This member is not sufficiently generic" )
    /// A declaration may only be the [<Literal>] attribute if a constant value is also given, e.g. 'val x : int = 1'
    /// (Originally from /src/fsharp/FSComp.txt:712)
    static member tcLiteralAttributeRequiresConstantValue() = (876, sprintf "A declaration may only be the [<Literal>] attribute if a constant value is also given, e.g. 'val x : int = 1'" )
    /// A declaration may only be given a value in a signature if the declaration has the [<Literal>] attribute
    /// (Originally from /src/fsharp/FSComp.txt:713)
    static member tcValueInSignatureRequiresLiteralAttribute() = (877, sprintf "A declaration may only be given a value in a signature if the declaration has the [<Literal>] attribute" )
    /// Thread-static and context-static variables must be static and given the [<DefaultValue>] attribute to indicate that the value is initialized to the default value on each new thread
    /// (Originally from /src/fsharp/FSComp.txt:714)
    static member tcThreadStaticAndContextStaticMustBeStatic() = (878, sprintf "Thread-static and context-static variables must be static and given the [<DefaultValue>] attribute to indicate that the value is initialized to the default value on each new thread" )
    /// Volatile fields must be marked 'mutable' and cannot be thread-static
    /// (Originally from /src/fsharp/FSComp.txt:715)
    static member tcVolatileFieldsMustBeMutable() = (879, sprintf "Volatile fields must be marked 'mutable' and cannot be thread-static" )
    /// Uninitialized 'val' fields must be mutable and marked with the '[<DefaultValue>]' attribute. Consider using a 'let' binding instead of a 'val' field.
    /// (Originally from /src/fsharp/FSComp.txt:716)
    static member tcUninitializedValFieldsMustBeMutable() = (880, sprintf "Uninitialized 'val' fields must be mutable and marked with the '[<DefaultValue>]' attribute. Consider using a 'let' binding instead of a 'val' field." )
    /// Static 'val' fields in types must be mutable, private and marked with the '[<DefaultValue>]' attribute. They are initialized to the 'null' or 'zero' value for their type. Consider also using a 'static let mutable' binding in a class type.
    /// (Originally from /src/fsharp/FSComp.txt:717)
    static member tcStaticValFieldsMustBeMutableAndPrivate() = (881, sprintf "Static 'val' fields in types must be mutable, private and marked with the '[<DefaultValue>]' attribute. They are initialized to the 'null' or 'zero' value for their type. Consider also using a 'static let mutable' binding in a class type." )
    /// This field requires a name
    /// (Originally from /src/fsharp/FSComp.txt:718)
    static member tcFieldRequiresName() = (882, sprintf "This field requires a name" )
    /// Invalid namespace, module, type or union case name
    /// (Originally from /src/fsharp/FSComp.txt:719)
    static member tcInvalidNamespaceModuleTypeUnionName() = (883, sprintf "Invalid namespace, module, type or union case name" )
    /// Explicit type declarations for constructors must be of the form 'ty1 * ... * tyN -> resTy'. Parentheses may be required around 'resTy'
    /// (Originally from /src/fsharp/FSComp.txt:720)
    static member tcIllegalFormForExplicitTypeDeclaration() = (884, sprintf "Explicit type declarations for constructors must be of the form 'ty1 * ... * tyN -> resTy'. Parentheses may be required around 'resTy'" )
    /// Return types of union cases must be identical to the type being defined, up to abbreviations
    /// (Originally from /src/fsharp/FSComp.txt:721)
    static member tcReturnTypesForUnionMustBeSameAsType() = (885, sprintf "Return types of union cases must be identical to the type being defined, up to abbreviations" )
    /// This is not a valid value for an enumeration literal
    /// (Originally from /src/fsharp/FSComp.txt:722)
    static member tcInvalidEnumerationLiteral() = (886, sprintf "This is not a valid value for an enumeration literal" )
    /// The type '%s' is not an interface type
    /// (Originally from /src/fsharp/FSComp.txt:723)
    static member tcTypeIsNotInterfaceType1(a0 : System.String) = (887, sprintf "The type '%s' is not an interface type" a0)
    /// Duplicate specification of an interface
    /// (Originally from /src/fsharp/FSComp.txt:724)
    static member tcDuplicateSpecOfInterface() = (888, sprintf "Duplicate specification of an interface" )
    /// A field/val declaration is not permitted here
    /// (Originally from /src/fsharp/FSComp.txt:725)
    static member tcFieldValIllegalHere() = (889, sprintf "A field/val declaration is not permitted here" )
    /// A inheritance declaration is not permitted here
    /// (Originally from /src/fsharp/FSComp.txt:726)
    static member tcInheritIllegalHere() = (890, sprintf "A inheritance declaration is not permitted here" )
    /// This declaration opens the module '%s', which is marked as 'RequireQualifiedAccess'. Adjust your code to use qualified references to the elements of the module instead, e.g. 'List.map' instead of 'map'. This change will ensure that your code is robust as new constructs are added to libraries.
    /// (Originally from /src/fsharp/FSComp.txt:727)
    static member tcModuleRequiresQualifiedAccess(a0 : System.String) = (892, sprintf "This declaration opens the module '%s', which is marked as 'RequireQualifiedAccess'. Adjust your code to use qualified references to the elements of the module instead, e.g. 'List.map' instead of 'map'. This change will ensure that your code is robust as new constructs are added to libraries." a0)
    /// This declaration opens the namespace or module '%s' through a partially qualified path. Adjust this code to use the full path of the namespace. This change will make your code more robust as new constructs are added to the F# and CLI libraries.
    /// (Originally from /src/fsharp/FSComp.txt:728)
    static member tcOpenUsedWithPartiallyQualifiedPath(a0 : System.String) = (893, sprintf "This declaration opens the namespace or module '%s' through a partially qualified path. Adjust this code to use the full path of the namespace. This change will make your code more robust as new constructs are added to the F# and CLI libraries." a0)
    /// Local class bindings cannot be marked inline. Consider lifting the definition out of the class or else do not mark it as inline.
    /// (Originally from /src/fsharp/FSComp.txt:729)
    static member tcLocalClassBindingsCannotBeInline() = (894, sprintf "Local class bindings cannot be marked inline. Consider lifting the definition out of the class or else do not mark it as inline." )
    /// Type abbreviations cannot have members
    /// (Originally from /src/fsharp/FSComp.txt:730)
    static member tcTypeAbbreviationsMayNotHaveMembers() = (895, sprintf "Type abbreviations cannot have members" )
    /// As of F# 4.1, the accessibility of type abbreviations is checked at compile-time. Consider changing the accessibility of the type abbreviation. Ignoring this warning might lead to runtime errors.
    /// (Originally from /src/fsharp/FSComp.txt:731)
    static member tcTypeAbbreviationsCheckedAtCompileTime() = (sprintf "As of F# 4.1, the accessibility of type abbreviations is checked at compile-time. Consider changing the accessibility of the type abbreviation. Ignoring this warning might lead to runtime errors." )
    /// Enumerations cannot have members
    /// (Originally from /src/fsharp/FSComp.txt:732)
    static member tcEnumerationsMayNotHaveMembers() = (896, sprintf "Enumerations cannot have members" )
    /// Measure declarations may have only static members
    /// (Originally from /src/fsharp/FSComp.txt:733)
    static member tcMeasureDeclarationsRequireStaticMembers() = (897, sprintf "Measure declarations may have only static members" )
    /// Structs cannot contain 'do' bindings because the default constructor for structs would not execute these bindings
    /// (Originally from /src/fsharp/FSComp.txt:734)
    static member tcStructsMayNotContainDoBindings() = (sprintf "Structs cannot contain 'do' bindings because the default constructor for structs would not execute these bindings" )
    /// Structs cannot contain value definitions because the default constructor for structs will not execute these bindings. Consider adding additional arguments to the primary constructor for the type.
    /// (Originally from /src/fsharp/FSComp.txt:735)
    static member tcStructsMayNotContainLetBindings() = (901, sprintf "Structs cannot contain value definitions because the default constructor for structs will not execute these bindings. Consider adding additional arguments to the primary constructor for the type." )
    /// Static value definitions may only be used in types with a primary constructor. Consider adding arguments to the type definition, e.g. 'type X(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:736)
    static member tcStaticLetBindingsRequireClassesWithImplicitConstructors() = (902, sprintf "Static value definitions may only be used in types with a primary constructor. Consider adding arguments to the type definition, e.g. 'type X(args) = ...'." )
    /// Measure declarations may have only static members: constructors are not available
    /// (Originally from /src/fsharp/FSComp.txt:737)
    static member tcMeasureDeclarationsRequireStaticMembersNotConstructors() = (904, sprintf "Measure declarations may have only static members: constructors are not available" )
    /// A member and a local class binding both have the name '%s'
    /// (Originally from /src/fsharp/FSComp.txt:738)
    static member tcMemberAndLocalClassBindingHaveSameName(a0 : System.String) = (905, sprintf "A member and a local class binding both have the name '%s'" a0)
    /// Type abbreviations cannot have interface declarations
    /// (Originally from /src/fsharp/FSComp.txt:739)
    static member tcTypeAbbreviationsCannotHaveInterfaceDeclaration() = (906, sprintf "Type abbreviations cannot have interface declarations" )
    /// Enumerations cannot have interface declarations
    /// (Originally from /src/fsharp/FSComp.txt:740)
    static member tcEnumerationsCannotHaveInterfaceDeclaration() = (907, sprintf "Enumerations cannot have interface declarations" )
    /// This type is not an interface type
    /// (Originally from /src/fsharp/FSComp.txt:741)
    static member tcTypeIsNotInterfaceType0() = (908, sprintf "This type is not an interface type" )
    /// All implemented interfaces should be declared on the initial declaration of the type
    /// (Originally from /src/fsharp/FSComp.txt:742)
    static member tcAllImplementedInterfacesShouldBeDeclared() = (909, sprintf "All implemented interfaces should be declared on the initial declaration of the type" )
    /// A default implementation of this interface has already been added because the explicit implementation of the interface was not specified at the definition of the type
    /// (Originally from /src/fsharp/FSComp.txt:743)
    static member tcDefaultImplementationForInterfaceHasAlreadyBeenAdded() = (910, sprintf "A default implementation of this interface has already been added because the explicit implementation of the interface was not specified at the definition of the type" )
    /// This member is not permitted in an interface implementation
    /// (Originally from /src/fsharp/FSComp.txt:744)
    static member tcMemberNotPermittedInInterfaceImplementation() = (911, sprintf "This member is not permitted in an interface implementation" )
    /// This declaration element is not permitted in an augmentation
    /// (Originally from /src/fsharp/FSComp.txt:745)
    static member tcDeclarationElementNotPermittedInAugmentation() = (912, sprintf "This declaration element is not permitted in an augmentation" )
    /// Types cannot contain nested type definitions
    /// (Originally from /src/fsharp/FSComp.txt:746)
    static member tcTypesCannotContainNestedTypes() = (913, sprintf "Types cannot contain nested type definitions" )
    /// type, exception or module
    /// (Originally from /src/fsharp/FSComp.txt:747)
    static member tcTypeExceptionOrModule() = (sprintf "type, exception or module" )
    /// type or module
    /// (Originally from /src/fsharp/FSComp.txt:748)
    static member tcTypeOrModule() = (sprintf "type or module" )
    /// The struct, record or union type '%s' implements the interface 'System.IStructuralEquatable' explicitly. Apply the 'CustomEquality' attribute to the type.
    /// (Originally from /src/fsharp/FSComp.txt:749)
    static member tcImplementsIStructuralEquatableExplicitly(a0 : System.String) = (914, sprintf "The struct, record or union type '%s' implements the interface 'System.IStructuralEquatable' explicitly. Apply the 'CustomEquality' attribute to the type." a0)
    /// The struct, record or union type '%s' implements the interface 'System.IEquatable<_>' explicitly. Apply the 'CustomEquality' attribute to the type and provide a consistent implementation of the non-generic override 'System.Object.Equals(obj)'.
    /// (Originally from /src/fsharp/FSComp.txt:750)
    static member tcImplementsIEquatableExplicitly(a0 : System.String) = (915, sprintf "The struct, record or union type '%s' implements the interface 'System.IEquatable<_>' explicitly. Apply the 'CustomEquality' attribute to the type and provide a consistent implementation of the non-generic override 'System.Object.Equals(obj)'." a0)
    /// Explicit type specifications cannot be used for exception constructors
    /// (Originally from /src/fsharp/FSComp.txt:751)
    static member tcExplicitTypeSpecificationCannotBeUsedForExceptionConstructors() = (916, sprintf "Explicit type specifications cannot be used for exception constructors" )
    /// Exception abbreviations should not have argument lists
    /// (Originally from /src/fsharp/FSComp.txt:752)
    static member tcExceptionAbbreviationsShouldNotHaveArgumentList() = (917, sprintf "Exception abbreviations should not have argument lists" )
    /// Abbreviations for Common IL exceptions cannot take arguments
    /// (Originally from /src/fsharp/FSComp.txt:753)
    static member tcAbbreviationsFordotNetExceptionsCannotTakeArguments() = (918, sprintf "Abbreviations for Common IL exceptions cannot take arguments" )
    /// Exception abbreviations must refer to existing exceptions or F# types deriving from System.Exception
    /// (Originally from /src/fsharp/FSComp.txt:754)
    static member tcExceptionAbbreviationsMustReferToValidExceptions() = (919, sprintf "Exception abbreviations must refer to existing exceptions or F# types deriving from System.Exception" )
    /// Abbreviations for Common IL exception types must have a matching object constructor
    /// (Originally from /src/fsharp/FSComp.txt:755)
    static member tcAbbreviationsFordotNetExceptionsMustHaveMatchingObjectConstructor() = (920, sprintf "Abbreviations for Common IL exception types must have a matching object constructor" )
    /// Not an exception
    /// (Originally from /src/fsharp/FSComp.txt:756)
    static member tcNotAnException() = (921, sprintf "Not an exception" )
    /// Invalid module name
    /// (Originally from /src/fsharp/FSComp.txt:758)
    static member tcInvalidModuleName() = (924, sprintf "Invalid module name" )
    /// Invalid type extension
    /// (Originally from /src/fsharp/FSComp.txt:759)
    static member tcInvalidTypeExtension() = (925, sprintf "Invalid type extension" )
    /// The attributes of this type specify multiple kinds for the type
    /// (Originally from /src/fsharp/FSComp.txt:760)
    static member tcAttributesOfTypeSpecifyMultipleKindsForType() = (926, sprintf "The attributes of this type specify multiple kinds for the type" )
    /// The kind of the type specified by its attributes does not match the kind implied by its definition
    /// (Originally from /src/fsharp/FSComp.txt:761)
    static member tcKindOfTypeSpecifiedDoesNotMatchDefinition() = (927, sprintf "The kind of the type specified by its attributes does not match the kind implied by its definition" )
    /// Measure definitions cannot have type parameters
    /// (Originally from /src/fsharp/FSComp.txt:762)
    static member tcMeasureDefinitionsCannotHaveTypeParameters() = (928, sprintf "Measure definitions cannot have type parameters" )
    /// This type requires a definition
    /// (Originally from /src/fsharp/FSComp.txt:763)
    static member tcTypeRequiresDefinition() = (929, sprintf "This type requires a definition" )
    /// This type abbreviation has one or more declared type parameters that do not appear in the type being abbreviated. Type abbreviations must use all declared type parameters in the type being abbreviated. Consider removing one or more type parameters, or use a concrete type definition that wraps an underlying type, such as 'type C<'a> = C of ...'.
    /// (Originally from /src/fsharp/FSComp.txt:764)
    static member tcTypeAbbreviationHasTypeParametersMissingOnType() = (sprintf "This type abbreviation has one or more declared type parameters that do not appear in the type being abbreviated. Type abbreviations must use all declared type parameters in the type being abbreviated. Consider removing one or more type parameters, or use a concrete type definition that wraps an underlying type, such as 'type C<'a> = C of ...'." )
    /// Structs, interfaces, enums and delegates cannot inherit from other types
    /// (Originally from /src/fsharp/FSComp.txt:765)
    static member tcStructsInterfacesEnumsDelegatesMayNotInheritFromOtherTypes() = (931, sprintf "Structs, interfaces, enums and delegates cannot inherit from other types" )
    /// Types cannot inherit from multiple concrete types
    /// (Originally from /src/fsharp/FSComp.txt:766)
    static member tcTypesCannotInheritFromMultipleConcreteTypes() = (932, sprintf "Types cannot inherit from multiple concrete types" )
    /// Records, union, abbreviations and struct types cannot have the 'AllowNullLiteral' attribute
    /// (Originally from /src/fsharp/FSComp.txt:767)
    static member tcRecordsUnionsAbbreviationsStructsMayNotHaveAllowNullLiteralAttribute() = (934, sprintf "Records, union, abbreviations and struct types cannot have the 'AllowNullLiteral' attribute" )
    /// Types with the 'AllowNullLiteral' attribute may only inherit from or implement types which also allow the use of the null literal
    /// (Originally from /src/fsharp/FSComp.txt:768)
    static member tcAllowNullTypesMayOnlyInheritFromAllowNullTypes() = (935, sprintf "Types with the 'AllowNullLiteral' attribute may only inherit from or implement types which also allow the use of the null literal" )
    /// Generic types cannot be given the 'StructLayout' attribute
    /// (Originally from /src/fsharp/FSComp.txt:769)
    static member tcGenericTypesCannotHaveStructLayout() = (936, sprintf "Generic types cannot be given the 'StructLayout' attribute" )
    /// Only structs and classes without primary constructors may be given the 'StructLayout' attribute
    /// (Originally from /src/fsharp/FSComp.txt:770)
    static member tcOnlyStructsCanHaveStructLayout() = (937, sprintf "Only structs and classes without primary constructors may be given the 'StructLayout' attribute" )
    /// The representation of this type is hidden by the signature. It must be given an attribute such as [<Sealed>], [<Class>] or [<Interface>] to indicate the characteristics of the type.
    /// (Originally from /src/fsharp/FSComp.txt:771)
    static member tcRepresentationOfTypeHiddenBySignature() = (938, sprintf "The representation of this type is hidden by the signature. It must be given an attribute such as [<Sealed>], [<Class>] or [<Interface>] to indicate the characteristics of the type." )
    /// Only classes may be given the 'AbstractClass' attribute
    /// (Originally from /src/fsharp/FSComp.txt:772)
    static member tcOnlyClassesCanHaveAbstract() = (939, sprintf "Only classes may be given the 'AbstractClass' attribute" )
    /// Only types representing units-of-measure may be given the 'Measure' attribute
    /// (Originally from /src/fsharp/FSComp.txt:773)
    static member tcOnlyTypesRepresentingUnitsOfMeasureCanHaveMeasure() = (940, sprintf "Only types representing units-of-measure may be given the 'Measure' attribute" )
    /// Accessibility modifiers are not permitted on overrides or interface implementations
    /// (Originally from /src/fsharp/FSComp.txt:774)
    static member tcOverridesCannotHaveVisibilityDeclarations() = (941, sprintf "Accessibility modifiers are not permitted on overrides or interface implementations" )
    /// Discriminated union types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:775)
    static member tcTypesAreAlwaysSealedDU() = (942, sprintf "Discriminated union types are always sealed" )
    /// Record types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:776)
    static member tcTypesAreAlwaysSealedRecord() = (942, sprintf "Record types are always sealed" )
    /// Assembly code types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:777)
    static member tcTypesAreAlwaysSealedAssemblyCode() = (942, sprintf "Assembly code types are always sealed" )
    /// Struct types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:778)
    static member tcTypesAreAlwaysSealedStruct() = (942, sprintf "Struct types are always sealed" )
    /// Delegate types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:779)
    static member tcTypesAreAlwaysSealedDelegate() = (942, sprintf "Delegate types are always sealed" )
    /// Enum types are always sealed
    /// (Originally from /src/fsharp/FSComp.txt:780)
    static member tcTypesAreAlwaysSealedEnum() = (942, sprintf "Enum types are always sealed" )
    /// Interface types and delegate types cannot contain fields
    /// (Originally from /src/fsharp/FSComp.txt:781)
    static member tcInterfaceTypesAndDelegatesCannotContainFields() = (943, sprintf "Interface types and delegate types cannot contain fields" )
    /// Abbreviated types cannot be given the 'Sealed' attribute
    /// (Originally from /src/fsharp/FSComp.txt:782)
    static member tcAbbreviatedTypesCannotBeSealed() = (944, sprintf "Abbreviated types cannot be given the 'Sealed' attribute" )
    /// Cannot inherit a sealed type
    /// (Originally from /src/fsharp/FSComp.txt:783)
    static member tcCannotInheritFromSealedType() = (945, sprintf "Cannot inherit a sealed type" )
    /// Cannot inherit from interface type. Use interface ... with instead.
    /// (Originally from /src/fsharp/FSComp.txt:784)
    static member tcCannotInheritFromInterfaceType() = (946, sprintf "Cannot inherit from interface type. Use interface ... with instead." )
    /// Struct types cannot contain abstract members
    /// (Originally from /src/fsharp/FSComp.txt:785)
    static member tcStructTypesCannotContainAbstractMembers() = (947, sprintf "Struct types cannot contain abstract members" )
    /// Interface types cannot be sealed
    /// (Originally from /src/fsharp/FSComp.txt:786)
    static member tcInterfaceTypesCannotBeSealed() = (948, sprintf "Interface types cannot be sealed" )
    /// Delegate specifications must be of the form 'typ -> typ'
    /// (Originally from /src/fsharp/FSComp.txt:787)
    static member tcInvalidDelegateSpecification() = (949, sprintf "Delegate specifications must be of the form 'typ -> typ'" )
    /// Delegate specifications must not be curried types. Use 'typ * ... * typ -> typ' for multi-argument delegates, and 'typ -> (typ -> typ)' for delegates returning function values.
    /// (Originally from /src/fsharp/FSComp.txt:788)
    static member tcDelegatesCannotBeCurried() = (950, sprintf "Delegate specifications must not be curried types. Use 'typ * ... * typ -> typ' for multi-argument delegates, and 'typ -> (typ -> typ)' for delegates returning function values." )
    /// Literal enumerations must have type int, uint, int16, uint16, int64, uint64, byte, sbyte or char
    /// (Originally from /src/fsharp/FSComp.txt:789)
    static member tcInvalidTypeForLiteralEnumeration() = (951, sprintf "Literal enumerations must have type int, uint, int16, uint16, int64, uint64, byte, sbyte or char" )
    /// This type definition involves an immediate cyclic reference through an abbreviation
    /// (Originally from /src/fsharp/FSComp.txt:791)
    static member tcTypeDefinitionIsCyclic() = (953, sprintf "This type definition involves an immediate cyclic reference through an abbreviation" )
    /// This type definition involves an immediate cyclic reference through a struct field or inheritance relation
    /// (Originally from /src/fsharp/FSComp.txt:792)
    static member tcTypeDefinitionIsCyclicThroughInheritance() = (954, sprintf "This type definition involves an immediate cyclic reference through a struct field or inheritance relation" )
    /// The syntax 'type X with ...' is reserved for augmentations. Types whose representations are hidden but which have members are now declared in signatures using 'type X = ...'. You may also need to add the '[<Sealed>] attribute to the type definition in the signature
    /// (Originally from /src/fsharp/FSComp.txt:793)
    static member tcReservedSyntaxForAugmentation() = (sprintf "The syntax 'type X with ...' is reserved for augmentations. Types whose representations are hidden but which have members are now declared in signatures using 'type X = ...'. You may also need to add the '[<Sealed>] attribute to the type definition in the signature" )
    /// Members that extend interface, delegate or enum types must be placed in a module separate to the definition of the type. This module must either have the AutoOpen attribute or be opened explicitly by client code to bring the extension members into scope.
    /// (Originally from /src/fsharp/FSComp.txt:794)
    static member tcMembersThatExtendInterfaceMustBePlacedInSeparateModule() = (956, sprintf "Members that extend interface, delegate or enum types must be placed in a module separate to the definition of the type. This module must either have the AutoOpen attribute or be opened explicitly by client code to bring the extension members into scope." )
    /// One or more of the declared type parameters for this type extension have a missing or wrong type constraint not matching the original type constraints on '%s'
    /// (Originally from /src/fsharp/FSComp.txt:795)
    static member tcDeclaredTypeParametersForExtensionDoNotMatchOriginal(a0 : System.String) = (957, sprintf "One or more of the declared type parameters for this type extension have a missing or wrong type constraint not matching the original type constraints on '%s'" a0)
    /// Type definitions may only have one 'inherit' specification and it must be the first declaration
    /// (Originally from /src/fsharp/FSComp.txt:796)
    static member tcTypeDefinitionsWithImplicitConstructionMustHaveOneInherit() = (959, sprintf "Type definitions may only have one 'inherit' specification and it must be the first declaration" )
    /// 'let' and 'do' bindings must come before member and interface definitions in type definitions
    /// (Originally from /src/fsharp/FSComp.txt:797)
    static member tcTypeDefinitionsWithImplicitConstructionMustHaveLocalBindingsBeforeMembers() = (960, sprintf "'let' and 'do' bindings must come before member and interface definitions in type definitions" )
    /// This 'inherit' declaration specifies the inherited type but no arguments. Consider supplying arguments, e.g. 'inherit BaseType(args)'.
    /// (Originally from /src/fsharp/FSComp.txt:798)
    static member tcInheritDeclarationMissingArguments() = (961, sprintf "This 'inherit' declaration specifies the inherited type but no arguments. Consider supplying arguments, e.g. 'inherit BaseType(args)'." )
    /// This 'inherit' declaration has arguments, but is not in a type with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:799)
    static member tcInheritConstructionCallNotPartOfImplicitSequence() = (962, sprintf "This 'inherit' declaration has arguments, but is not in a type with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'." )
    /// This definition may only be used in a type with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:800)
    static member tcLetAndDoRequiresImplicitConstructionSequence() = (963, sprintf "This definition may only be used in a type with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'." )
    /// Type abbreviations cannot have augmentations
    /// (Originally from /src/fsharp/FSComp.txt:801)
    static member tcTypeAbbreviationsCannotHaveAugmentations() = (964, sprintf "Type abbreviations cannot have augmentations" )
    /// The path '%s' is a namespace. A module abbreviation may not abbreviate a namespace.
    /// (Originally from /src/fsharp/FSComp.txt:802)
    static member tcModuleAbbreviationForNamespace(a0 : System.String) = (965, sprintf "The path '%s' is a namespace. A module abbreviation may not abbreviate a namespace." a0)
    /// The type '%s' is used in an invalid way. A value prior to '%s' has an inferred type involving '%s', which is an invalid forward reference.
    /// (Originally from /src/fsharp/FSComp.txt:803)
    static member tcTypeUsedInInvalidWay(a0 : System.String, a1 : System.String, a2 : System.String) = (966, sprintf "The type '%s' is used in an invalid way. A value prior to '%s' has an inferred type involving '%s', which is an invalid forward reference." a0 a1 a2)
    /// The member '%s' is used in an invalid way. A use of '%s' has been inferred prior to the definition of '%s', which is an invalid forward reference.
    /// (Originally from /src/fsharp/FSComp.txt:804)
    static member tcMemberUsedInInvalidWay(a0 : System.String, a1 : System.String, a2 : System.String) = (967, sprintf "The member '%s' is used in an invalid way. A use of '%s' has been inferred prior to the definition of '%s', which is an invalid forward reference." a0 a1 a2)
    /// The attribute 'AutoOpen(\"%s\")' in the assembly '%s' did not refer to a valid module or namespace in that assembly and has been ignored
    /// (Originally from /src/fsharp/FSComp.txt:807)
    static member tcAttributeAutoOpenWasIgnored(a0 : System.String, a1 : System.String) = (970, sprintf "The attribute 'AutoOpen(\"%s\")' in the assembly '%s' did not refer to a valid module or namespace in that assembly and has been ignored" a0 a1)
    /// Undefined value '%s'
    /// (Originally from /src/fsharp/FSComp.txt:808)
    static member ilUndefinedValue(a0 : System.String) = (971, sprintf "Undefined value '%s'" a0)
    /// Label %s not found
    /// (Originally from /src/fsharp/FSComp.txt:809)
    static member ilLabelNotFound(a0 : System.String) = (972, sprintf "Label %s not found" a0)
    /// Incorrect number of type arguments to local call
    /// (Originally from /src/fsharp/FSComp.txt:810)
    static member ilIncorrectNumberOfTypeArguments() = (973, sprintf "Incorrect number of type arguments to local call" )
    /// Dynamic invocation of %s is not supported
    /// (Originally from /src/fsharp/FSComp.txt:811)
    static member ilDynamicInvocationNotSupported(a0 : System.String) = (sprintf "Dynamic invocation of %s is not supported" a0)
    /// Taking the address of a literal field is invalid
    /// (Originally from /src/fsharp/FSComp.txt:812)
    static member ilAddressOfLiteralFieldIsInvalid() = (975, sprintf "Taking the address of a literal field is invalid" )
    /// This operation involves taking the address of a value '%s' represented using a local variable or other special representation. This is invalid.
    /// (Originally from /src/fsharp/FSComp.txt:813)
    static member ilAddressOfValueHereIsInvalid(a0 : System.String) = (976, sprintf "This operation involves taking the address of a value '%s' represented using a local variable or other special representation. This is invalid." a0)
    /// Custom marshallers cannot be specified in F# code. Consider using a C# helper function.
    /// (Originally from /src/fsharp/FSComp.txt:814)
    static member ilCustomMarshallersCannotBeUsedInFSharp() = (980, sprintf "Custom marshallers cannot be specified in F# code. Consider using a C# helper function." )
    /// The MarshalAs attribute could not be decoded
    /// (Originally from /src/fsharp/FSComp.txt:815)
    static member ilMarshalAsAttributeCannotBeDecoded() = (981, sprintf "The MarshalAs attribute could not be decoded" )
    /// The signature for this external function contains type parameters. Constrain the argument and return types to indicate the types of the corresponding C function.
    /// (Originally from /src/fsharp/FSComp.txt:816)
    static member ilSignatureForExternalFunctionContainsTypeParameters() = (982, sprintf "The signature for this external function contains type parameters. Constrain the argument and return types to indicate the types of the corresponding C function." )
    /// The DllImport attribute could not be decoded
    /// (Originally from /src/fsharp/FSComp.txt:817)
    static member ilDllImportAttributeCouldNotBeDecoded() = (983, sprintf "The DllImport attribute could not be decoded" )
    /// Literal fields cannot be set
    /// (Originally from /src/fsharp/FSComp.txt:818)
    static member ilLiteralFieldsCannotBeSet() = (984, sprintf "Literal fields cannot be set" )
    /// GenSetStorage: %s was represented as a static method but was not an appropriate lambda expression
    /// (Originally from /src/fsharp/FSComp.txt:819)
    static member ilStaticMethodIsNotLambda(a0 : System.String) = (985, sprintf "GenSetStorage: %s was represented as a static method but was not an appropriate lambda expression" a0)
    /// Mutable variables cannot escape their method
    /// (Originally from /src/fsharp/FSComp.txt:820)
    static member ilMutableVariablesCannotEscapeMethod() = (986, sprintf "Mutable variables cannot escape their method" )
    /// Compiler error: unexpected unrealized value
    /// (Originally from /src/fsharp/FSComp.txt:821)
    static member ilUnexpectedUnrealizedValue() = (987, sprintf "Compiler error: unexpected unrealized value" )
    /// Main module of program is empty: nothing will happen when it is run
    /// (Originally from /src/fsharp/FSComp.txt:822)
    static member ilMainModuleEmpty() = (988, sprintf "Main module of program is empty: nothing will happen when it is run" )
    /// This type cannot be used for a literal field
    /// (Originally from /src/fsharp/FSComp.txt:823)
    static member ilTypeCannotBeUsedForLiteralField() = (989, sprintf "This type cannot be used for a literal field" )
    /// Unexpected GetSet annotation on a property
    /// (Originally from /src/fsharp/FSComp.txt:824)
    static member ilUnexpectedGetSetAnnotation() = (990, sprintf "Unexpected GetSet annotation on a property" )
    /// The FieldOffset attribute could not be decoded
    /// (Originally from /src/fsharp/FSComp.txt:825)
    static member ilFieldOffsetAttributeCouldNotBeDecoded() = (991, sprintf "The FieldOffset attribute could not be decoded" )
    /// The StructLayout attribute could not be decoded
    /// (Originally from /src/fsharp/FSComp.txt:826)
    static member ilStructLayoutAttributeCouldNotBeDecoded() = (992, sprintf "The StructLayout attribute could not be decoded" )
    /// The DefaultAugmentation attribute could not be decoded
    /// (Originally from /src/fsharp/FSComp.txt:827)
    static member ilDefaultAugmentationAttributeCouldNotBeDecoded() = (993, sprintf "The DefaultAugmentation attribute could not be decoded" )
    /// Reflected definitions cannot contain uses of the prefix splice operator '%%'
    /// (Originally from /src/fsharp/FSComp.txt:828)
    static member ilReflectedDefinitionsCannotUseSliceOperator() = (994, sprintf "Reflected definitions cannot contain uses of the prefix splice operator '%%'" )
    /// Problem with codepage '%d': %s
    /// (Originally from /src/fsharp/FSComp.txt:829)
    static member optsProblemWithCodepage(a0 : System.Int32, a1 : System.String) = (1000, sprintf "Problem with codepage '%d': %s" a0 a1)
    /// Copyright (c) Microsoft Corporation. All Rights Reserved.
    /// (Originally from /src/fsharp/FSComp.txt:830)
    static member optsCopyright() = (sprintf "Copyright (c) Microsoft Corporation. All Rights Reserved." )
    /// Freely distributed under the MIT Open Source License.  https://github.com/Microsoft/visualfsharp/blob/master/License.txt
    /// (Originally from /src/fsharp/FSComp.txt:831)
    static member optsCopyrightCommunity() = (sprintf "Freely distributed under the MIT Open Source License.  https://github.com/Microsoft/visualfsharp/blob/master/License.txt" )
    /// Name of the output file (Short form: -o)
    /// (Originally from /src/fsharp/FSComp.txt:832)
    static member optsNameOfOutputFile() = (sprintf "Name of the output file (Short form: -o)" )
    /// Build a console executable
    /// (Originally from /src/fsharp/FSComp.txt:833)
    static member optsBuildConsole() = (sprintf "Build a console executable" )
    /// Build a Windows executable
    /// (Originally from /src/fsharp/FSComp.txt:834)
    static member optsBuildWindows() = (sprintf "Build a Windows executable" )
    /// Build a library (Short form: -a)
    /// (Originally from /src/fsharp/FSComp.txt:835)
    static member optsBuildLibrary() = (sprintf "Build a library (Short form: -a)" )
    /// Build a module that can be added to another assembly
    /// (Originally from /src/fsharp/FSComp.txt:836)
    static member optsBuildModule() = (sprintf "Build a module that can be added to another assembly" )
    /// Delay-sign the assembly using only the public portion of the strong name key
    /// (Originally from /src/fsharp/FSComp.txt:837)
    static member optsDelaySign() = (sprintf "Delay-sign the assembly using only the public portion of the strong name key" )
    /// Public-sign the assembly using only the public portion of the strong name key, and mark the assembly as signed
    /// (Originally from /src/fsharp/FSComp.txt:838)
    static member optsPublicSign() = (sprintf "Public-sign the assembly using only the public portion of the strong name key, and mark the assembly as signed" )
    /// Write the xmldoc of the assembly to the given file
    /// (Originally from /src/fsharp/FSComp.txt:839)
    static member optsWriteXml() = (sprintf "Write the xmldoc of the assembly to the given file" )
    /// Specify a strong name key file
    /// (Originally from /src/fsharp/FSComp.txt:840)
    static member optsStrongKeyFile() = (sprintf "Specify a strong name key file" )
    /// Specify a strong name key container
    /// (Originally from /src/fsharp/FSComp.txt:841)
    static member optsStrongKeyContainer() = (sprintf "Specify a strong name key container" )
    /// Limit which platforms this code can run on: x86, Itanium, x64, anycpu32bitpreferred, or anycpu. The default is anycpu.
    /// (Originally from /src/fsharp/FSComp.txt:842)
    static member optsPlatform() = (sprintf "Limit which platforms this code can run on: x86, Itanium, x64, anycpu32bitpreferred, or anycpu. The default is anycpu." )
    /// Only include optimization information essential for implementing inlined constructs. Inhibits cross-module inlining but improves binary compatibility.
    /// (Originally from /src/fsharp/FSComp.txt:843)
    static member optsNoOpt() = (sprintf "Only include optimization information essential for implementing inlined constructs. Inhibits cross-module inlining but improves binary compatibility." )
    /// Don't add a resource to the generated assembly containing F#-specific metadata
    /// (Originally from /src/fsharp/FSComp.txt:844)
    static member optsNoInterface() = (sprintf "Don't add a resource to the generated assembly containing F#-specific metadata" )
    /// Print the inferred interface of the assembly to a file
    /// (Originally from /src/fsharp/FSComp.txt:845)
    static member optsSig() = (sprintf "Print the inferred interface of the assembly to a file" )
    /// Reference an assembly (Short form: -r)
    /// (Originally from /src/fsharp/FSComp.txt:846)
    static member optsReference() = (sprintf "Reference an assembly (Short form: -r)" )
    /// Specify a Win32 resource file (.res)
    /// (Originally from /src/fsharp/FSComp.txt:847)
    static member optsWin32res() = (sprintf "Specify a Win32 resource file (.res)" )
    /// Specify a Win32 manifest file
    /// (Originally from /src/fsharp/FSComp.txt:848)
    static member optsWin32manifest() = (sprintf "Specify a Win32 manifest file" )
    /// Do not include the default Win32 manifest
    /// (Originally from /src/fsharp/FSComp.txt:849)
    static member optsNowin32manifest() = (sprintf "Do not include the default Win32 manifest" )
    /// Embed all source files in the portable PDB file
    /// (Originally from /src/fsharp/FSComp.txt:850)
    static member optsEmbedAllSource() = (sprintf "Embed all source files in the portable PDB file" )
    /// Embed specific source files in the portable PDB file
    /// (Originally from /src/fsharp/FSComp.txt:851)
    static member optsEmbedSource() = (sprintf "Embed specific source files in the portable PDB file" )
    /// Source link information file to embed in the portable PDB file
    /// (Originally from /src/fsharp/FSComp.txt:852)
    static member optsSourceLink() = (sprintf "Source link information file to embed in the portable PDB file" )
    /// --embed switch only supported when emitting a Portable PDB (--debug:portable or --debug:embedded)
    /// (Originally from /src/fsharp/FSComp.txt:853)
    static member optsEmbeddedSourceRequirePortablePDBs() = (1501, sprintf "--embed switch only supported when emitting a Portable PDB (--debug:portable or --debug:embedded)" )
    /// --sourcelink switch only supported when emitting a Portable PDB (--debug:portable or --debug:embedded)
    /// (Originally from /src/fsharp/FSComp.txt:854)
    static member optsSourceLinkRequirePortablePDBs() = (1502, sprintf "--sourcelink switch only supported when emitting a Portable PDB (--debug:portable or --debug:embedded)" )
    /// Source file is too large to embed in a portable PDB
    /// (Originally from /src/fsharp/FSComp.txt:855)
    static member srcFileTooLarge() = (sprintf "Source file is too large to embed in a portable PDB" )
    /// Embed the specified managed resource
    /// (Originally from /src/fsharp/FSComp.txt:856)
    static member optsResource() = (sprintf "Embed the specified managed resource" )
    /// Link the specified resource to this assembly where the resinfo format is <file>[,<string name>[,public|private]]
    /// (Originally from /src/fsharp/FSComp.txt:857)
    static member optsLinkresource() = (sprintf "Link the specified resource to this assembly where the resinfo format is <file>[,<string name>[,public|private]]" )
    /// Emit debug information (Short form: -g)
    /// (Originally from /src/fsharp/FSComp.txt:858)
    static member optsDebugPM() = (sprintf "Emit debug information (Short form: -g)" )
    /// Specify debugging type: full, portable, embedded, pdbonly. ('%s' is the default if no debuggging type specified and enables attaching a debugger to a running program, 'portable' is a cross-platform format, 'embedded' is a cross-platform format embedded into the output file).
    /// (Originally from /src/fsharp/FSComp.txt:859)
    static member optsDebug(a0 : System.String) = (sprintf "Specify debugging type: full, portable, embedded, pdbonly. ('%s' is the default if no debuggging type specified and enables attaching a debugger to a running program, 'portable' is a cross-platform format, 'embedded' is a cross-platform format embedded into the output file)." a0)
    /// Enable optimizations (Short form: -O)
    /// (Originally from /src/fsharp/FSComp.txt:860)
    static member optsOptimize() = (sprintf "Enable optimizations (Short form: -O)" )
    /// Enable or disable tailcalls
    /// (Originally from /src/fsharp/FSComp.txt:861)
    static member optsTailcalls() = (sprintf "Enable or disable tailcalls" )
    /// Produce a deterministic assembly (including module version GUID and timestamp)
    /// (Originally from /src/fsharp/FSComp.txt:862)
    static member optsDeterministic() = (sprintf "Produce a deterministic assembly (including module version GUID and timestamp)" )
    /// Maps physical paths to source path names output by the compiler
    /// (Originally from /src/fsharp/FSComp.txt:863)
    static member optsPathMap() = (sprintf "Maps physical paths to source path names output by the compiler" )
    /// Enable or disable cross-module optimizations
    /// (Originally from /src/fsharp/FSComp.txt:864)
    static member optsCrossoptimize() = (sprintf "Enable or disable cross-module optimizations" )
    /// Report all warnings as errors
    /// (Originally from /src/fsharp/FSComp.txt:865)
    static member optsWarnaserrorPM() = (sprintf "Report all warnings as errors" )
    /// Report specific warnings as errors
    /// (Originally from /src/fsharp/FSComp.txt:866)
    static member optsWarnaserror() = (sprintf "Report specific warnings as errors" )
    /// Set a warning level (0-5)
    /// (Originally from /src/fsharp/FSComp.txt:867)
    static member optsWarn() = (sprintf "Set a warning level (0-5)" )
    /// Disable specific warning messages
    /// (Originally from /src/fsharp/FSComp.txt:868)
    static member optsNowarn() = (sprintf "Disable specific warning messages" )
    /// Enable specific warnings that may be off by default
    /// (Originally from /src/fsharp/FSComp.txt:869)
    static member optsWarnOn() = (sprintf "Enable specific warnings that may be off by default" )
    /// Generate overflow checks
    /// (Originally from /src/fsharp/FSComp.txt:870)
    static member optsChecked() = (sprintf "Generate overflow checks" )
    /// Define conditional compilation symbols (Short form: -d)
    /// (Originally from /src/fsharp/FSComp.txt:871)
    static member optsDefine() = (sprintf "Define conditional compilation symbols (Short form: -d)" )
    /// Ignore ML compatibility warnings
    /// (Originally from /src/fsharp/FSComp.txt:872)
    static member optsMlcompatibility() = (sprintf "Ignore ML compatibility warnings" )
    /// Suppress compiler copyright message
    /// (Originally from /src/fsharp/FSComp.txt:873)
    static member optsNologo() = (sprintf "Suppress compiler copyright message" )
    /// Display this usage message (Short form: -?)
    /// (Originally from /src/fsharp/FSComp.txt:874)
    static member optsHelp() = (sprintf "Display this usage message (Short form: -?)" )
    /// Read response file for more options
    /// (Originally from /src/fsharp/FSComp.txt:875)
    static member optsResponseFile() = (sprintf "Read response file for more options" )
    /// Specify the codepage used to read source files
    /// (Originally from /src/fsharp/FSComp.txt:876)
    static member optsCodepage() = (sprintf "Specify the codepage used to read source files" )
    /// Output messages in UTF-8 encoding
    /// (Originally from /src/fsharp/FSComp.txt:877)
    static member optsUtf8output() = (sprintf "Output messages in UTF-8 encoding" )
    /// Output messages with fully qualified paths
    /// (Originally from /src/fsharp/FSComp.txt:878)
    static member optsFullpaths() = (sprintf "Output messages with fully qualified paths" )
    /// Specify a directory for the include path which is used to resolve source files and assemblies (Short form: -I)
    /// (Originally from /src/fsharp/FSComp.txt:879)
    static member optsLib() = (sprintf "Specify a directory for the include path which is used to resolve source files and assemblies (Short form: -I)" )
    /// Base address for the library to be built
    /// (Originally from /src/fsharp/FSComp.txt:880)
    static member optsBaseaddress() = (sprintf "Base address for the library to be built" )
    /// Do not reference the default CLI assemblies by default
    /// (Originally from /src/fsharp/FSComp.txt:881)
    static member optsNoframework() = (sprintf "Do not reference the default CLI assemblies by default" )
    /// Statically link the F# library and all referenced DLLs that depend on it into the assembly being generated
    /// (Originally from /src/fsharp/FSComp.txt:882)
    static member optsStandalone() = (sprintf "Statically link the F# library and all referenced DLLs that depend on it into the assembly being generated" )
    /// Statically link the given assembly and all referenced DLLs that depend on this assembly. Use an assembly name e.g. mylib, not a DLL name.
    /// (Originally from /src/fsharp/FSComp.txt:883)
    static member optsStaticlink() = (sprintf "Statically link the given assembly and all referenced DLLs that depend on this assembly. Use an assembly name e.g. mylib, not a DLL name." )
    /// Use a resident background compilation service to improve compiler startup times.
    /// (Originally from /src/fsharp/FSComp.txt:884)
    static member optsResident() = (sprintf "Use a resident background compilation service to improve compiler startup times." )
    /// Name the output debug file
    /// (Originally from /src/fsharp/FSComp.txt:885)
    static member optsPdb() = (sprintf "Name the output debug file" )
    /// Resolve assembly references using directory-based rules rather than MSBuild resolution
    /// (Originally from /src/fsharp/FSComp.txt:886)
    static member optsSimpleresolution() = (sprintf "Resolve assembly references using directory-based rules rather than MSBuild resolution" )
    /// Unrecognized target '%s', expected 'exe', 'winexe', 'library' or 'module'
    /// (Originally from /src/fsharp/FSComp.txt:887)
    static member optsUnrecognizedTarget(a0 : System.String) = (1048, sprintf "Unrecognized target '%s', expected 'exe', 'winexe', 'library' or 'module'" a0)
    /// Unrecognized debug type '%s', expected 'pdbonly' or 'full'
    /// (Originally from /src/fsharp/FSComp.txt:888)
    static member optsUnrecognizedDebugType(a0 : System.String) = (1049, sprintf "Unrecognized debug type '%s', expected 'pdbonly' or 'full'" a0)
    /// Invalid warning level '%d'
    /// (Originally from /src/fsharp/FSComp.txt:889)
    static member optsInvalidWarningLevel(a0 : System.Int32) = (1050, sprintf "Invalid warning level '%d'" a0)
    /// Short form of '%s'
    /// (Originally from /src/fsharp/FSComp.txt:890)
    static member optsShortFormOf(a0 : System.String) = (sprintf "Short form of '%s'" a0)
    /// The command-line option '--cliroot' has been deprecated. Use an explicit reference to a specific copy of mscorlib.dll instead.
    /// (Originally from /src/fsharp/FSComp.txt:891)
    static member optsClirootDeprecatedMsg() = (sprintf "The command-line option '--cliroot' has been deprecated. Use an explicit reference to a specific copy of mscorlib.dll instead." )
    /// Use to override where the compiler looks for mscorlib.dll and framework components
    /// (Originally from /src/fsharp/FSComp.txt:892)
    static member optsClirootDescription() = (sprintf "Use to override where the compiler looks for mscorlib.dll and framework components" )
    /// - OUTPUT FILES -
    /// (Originally from /src/fsharp/FSComp.txt:893)
    static member optsHelpBannerOutputFiles() = (sprintf "- OUTPUT FILES -" )
    /// - INPUT FILES -
    /// (Originally from /src/fsharp/FSComp.txt:894)
    static member optsHelpBannerInputFiles() = (sprintf "- INPUT FILES -" )
    /// - RESOURCES -
    /// (Originally from /src/fsharp/FSComp.txt:895)
    static member optsHelpBannerResources() = (sprintf "- RESOURCES -" )
    /// - CODE GENERATION -
    /// (Originally from /src/fsharp/FSComp.txt:896)
    static member optsHelpBannerCodeGen() = (sprintf "- CODE GENERATION -" )
    /// - ADVANCED -
    /// (Originally from /src/fsharp/FSComp.txt:897)
    static member optsHelpBannerAdvanced() = (sprintf "- ADVANCED -" )
    /// - MISCELLANEOUS -
    /// (Originally from /src/fsharp/FSComp.txt:898)
    static member optsHelpBannerMisc() = (sprintf "- MISCELLANEOUS -" )
    /// - LANGUAGE -
    /// (Originally from /src/fsharp/FSComp.txt:899)
    static member optsHelpBannerLanguage() = (sprintf "- LANGUAGE -" )
    /// - ERRORS AND WARNINGS -
    /// (Originally from /src/fsharp/FSComp.txt:900)
    static member optsHelpBannerErrsAndWarns() = (sprintf "- ERRORS AND WARNINGS -" )
    /// Unknown --test argument: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:901)
    static member optsUnknownArgumentToTheTestSwitch(a0 : System.String) = (1063, sprintf "Unknown --test argument: '%s'" a0)
    /// Unrecognized platform '%s', valid values are 'x86', 'x64', 'Itanium', 'anycpu32bitpreferred', and 'anycpu'
    /// (Originally from /src/fsharp/FSComp.txt:902)
    static member optsUnknownPlatform(a0 : System.String) = (1064, sprintf "Unrecognized platform '%s', valid values are 'x86', 'x64', 'Itanium', 'anycpu32bitpreferred', and 'anycpu'" a0)
    /// The command-line option '%s' is for test purposes only
    /// (Originally from /src/fsharp/FSComp.txt:903)
    static member optsInternalNoDescription(a0 : System.String) = (sprintf "The command-line option '%s' is for test purposes only" a0)
    /// The command-line option '%s' has been deprecated
    /// (Originally from /src/fsharp/FSComp.txt:904)
    static member optsDCLONoDescription(a0 : System.String) = (sprintf "The command-line option '%s' has been deprecated" a0)
    /// The command-line option '%s' has been deprecated. Use '%s' instead.
    /// (Originally from /src/fsharp/FSComp.txt:905)
    static member optsDCLODeprecatedSuggestAlternative(a0 : System.String, a1 : System.String) = (sprintf "The command-line option '%s' has been deprecated. Use '%s' instead." a0 a1)
    /// The command-line option '%s' has been deprecated. HTML document generation is now part of the F# Power Pack, via the tool FsHtmlDoc.exe.
    /// (Originally from /src/fsharp/FSComp.txt:906)
    static member optsDCLOHtmlDoc(a0 : System.String) = (sprintf "The command-line option '%s' has been deprecated. HTML document generation is now part of the F# Power Pack, via the tool FsHtmlDoc.exe." a0)
    /// Output warning and error messages in color
    /// (Originally from /src/fsharp/FSComp.txt:907)
    static member optsConsoleColors() = (sprintf "Output warning and error messages in color" )
    /// Enable high-entropy ASLR
    /// (Originally from /src/fsharp/FSComp.txt:908)
    static member optsUseHighEntropyVA() = (sprintf "Enable high-entropy ASLR" )
    /// Specify subsystem version of this assembly
    /// (Originally from /src/fsharp/FSComp.txt:909)
    static member optsSubSystemVersion() = (sprintf "Specify subsystem version of this assembly" )
    /// Specify target framework profile of this assembly. Valid values are mscorlib, netcore or netstandard. Default - mscorlib
    /// (Originally from /src/fsharp/FSComp.txt:910)
    static member optsTargetProfile() = (sprintf "Specify target framework profile of this assembly. Valid values are mscorlib, netcore or netstandard. Default - mscorlib" )
    /// Emit debug information in quotations
    /// (Originally from /src/fsharp/FSComp.txt:911)
    static member optsEmitDebugInfoInQuotations() = (sprintf "Emit debug information in quotations" )
    /// Specify the preferred output language culture name (e.g. es-ES, ja-JP)
    /// (Originally from /src/fsharp/FSComp.txt:912)
    static member optsPreferredUiLang() = (sprintf "Specify the preferred output language culture name (e.g. es-ES, ja-JP)" )
    /// Don't copy FSharp.Core.dll along the produced binaries
    /// (Originally from /src/fsharp/FSComp.txt:913)
    static member optsNoCopyFsharpCore() = (sprintf "Don't copy FSharp.Core.dll along the produced binaries" )
    /// Invalid version '%s' for '--subsystemversion'. The version must be 4.00 or greater.
    /// (Originally from /src/fsharp/FSComp.txt:914)
    static member optsInvalidSubSystemVersion(a0 : System.String) = (1051, sprintf "Invalid version '%s' for '--subsystemversion'. The version must be 4.00 or greater." a0)
    /// Invalid value '%s' for '--targetprofile', valid values are 'mscorlib', 'netcore' or 'netstandard'.
    /// (Originally from /src/fsharp/FSComp.txt:915)
    static member optsInvalidTargetProfile(a0 : System.String) = (1052, sprintf "Invalid value '%s' for '--targetprofile', valid values are 'mscorlib', 'netcore' or 'netstandard'." a0)
    /// Full name
    /// (Originally from /src/fsharp/FSComp.txt:916)
    static member typeInfoFullName() = (sprintf "Full name" )
    /// and %d other overloads
    /// (Originally from /src/fsharp/FSComp.txt:920)
    static member typeInfoOtherOverloads(a0 : System.Int32) = (sprintf "and %d other overloads" a0)
    /// union case
    /// (Originally from /src/fsharp/FSComp.txt:921)
    static member typeInfoUnionCase() = (sprintf "union case" )
    /// active pattern result
    /// (Originally from /src/fsharp/FSComp.txt:922)
    static member typeInfoActivePatternResult() = (sprintf "active pattern result" )
    /// active recognizer
    /// (Originally from /src/fsharp/FSComp.txt:923)
    static member typeInfoActiveRecognizer() = (sprintf "active recognizer" )
    /// field
    /// (Originally from /src/fsharp/FSComp.txt:924)
    static member typeInfoField() = (sprintf "field" )
    /// event
    /// (Originally from /src/fsharp/FSComp.txt:925)
    static member typeInfoEvent() = (sprintf "event" )
    /// property
    /// (Originally from /src/fsharp/FSComp.txt:926)
    static member typeInfoProperty() = (sprintf "property" )
    /// extension
    /// (Originally from /src/fsharp/FSComp.txt:927)
    static member typeInfoExtension() = (sprintf "extension" )
    /// custom operation
    /// (Originally from /src/fsharp/FSComp.txt:928)
    static member typeInfoCustomOperation() = (sprintf "custom operation" )
    /// argument
    /// (Originally from /src/fsharp/FSComp.txt:929)
    static member typeInfoArgument() = (sprintf "argument" )
    /// anonymous record field
    /// (Originally from /src/fsharp/FSComp.txt:930)
    static member typeInfoAnonRecdField() = (sprintf "anonymous record field" )
    /// patvar
    /// (Originally from /src/fsharp/FSComp.txt:931)
    static member typeInfoPatternVariable() = (sprintf "patvar" )
    /// namespace
    /// (Originally from /src/fsharp/FSComp.txt:932)
    static member typeInfoNamespace() = (sprintf "namespace" )
    /// module
    /// (Originally from /src/fsharp/FSComp.txt:933)
    static member typeInfoModule() = (sprintf "module" )
    /// namespace/module
    /// (Originally from /src/fsharp/FSComp.txt:934)
    static member typeInfoNamespaceOrModule() = (sprintf "namespace/module" )
    /// from %s
    /// (Originally from /src/fsharp/FSComp.txt:935)
    static member typeInfoFromFirst(a0 : System.String) = (sprintf "from %s" a0)
    /// also from %s
    /// (Originally from /src/fsharp/FSComp.txt:936)
    static member typeInfoFromNext(a0 : System.String) = (sprintf "also from %s" a0)
    /// generated property
    /// (Originally from /src/fsharp/FSComp.txt:937)
    static member typeInfoGeneratedProperty() = (sprintf "generated property" )
    /// generated type
    /// (Originally from /src/fsharp/FSComp.txt:938)
    static member typeInfoGeneratedType() = (sprintf "generated type" )
    /// Found by AssemblyFolders registry key
    /// (Originally from /src/fsharp/FSComp.txt:939)
    static member assemblyResolutionFoundByAssemblyFoldersKey() = (sprintf "Found by AssemblyFolders registry key" )
    /// Found by AssemblyFoldersEx registry key
    /// (Originally from /src/fsharp/FSComp.txt:940)
    static member assemblyResolutionFoundByAssemblyFoldersExKey() = (sprintf "Found by AssemblyFoldersEx registry key" )
    /// .NET Framework
    /// (Originally from /src/fsharp/FSComp.txt:941)
    static member assemblyResolutionNetFramework() = (sprintf ".NET Framework" )
    /// Global Assembly Cache
    /// (Originally from /src/fsharp/FSComp.txt:942)
    static member assemblyResolutionGAC() = (sprintf "Global Assembly Cache" )
    /// Recursive class hierarchy in type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:943)
    static member recursiveClassHierarchy(a0 : System.String) = (1089, sprintf "Recursive class hierarchy in type '%s'" a0)
    /// Invalid recursive reference to an abstract slot
    /// (Originally from /src/fsharp/FSComp.txt:944)
    static member InvalidRecursiveReferenceToAbstractSlot() = (1090, sprintf "Invalid recursive reference to an abstract slot" )
    /// The event '%s' has a non-standard type. If this event is declared in another CLI language, you may need to access this event using the explicit %s and %s methods for the event. If this event is declared in F#, make the type of the event an instantiation of either 'IDelegateEvent<_>' or 'IEvent<_,_>'.
    /// (Originally from /src/fsharp/FSComp.txt:945)
    static member eventHasNonStandardType(a0 : System.String, a1 : System.String, a2 : System.String) = (1091, sprintf "The event '%s' has a non-standard type. If this event is declared in another CLI language, you may need to access this event using the explicit %s and %s methods for the event. If this event is declared in F#, make the type of the event an instantiation of either 'IDelegateEvent<_>' or 'IEvent<_,_>'." a0 a1 a2)
    /// The type '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:946)
    static member typeIsNotAccessible(a0 : System.String) = (1092, sprintf "The type '%s' is not accessible from this code location" a0)
    /// The union cases or fields of the type '%s' are not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:947)
    static member unionCasesAreNotAccessible(a0 : System.String) = (1093, sprintf "The union cases or fields of the type '%s' are not accessible from this code location" a0)
    /// The value '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:948)
    static member valueIsNotAccessible(a0 : System.String) = (1094, sprintf "The value '%s' is not accessible from this code location" a0)
    /// The union case '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:949)
    static member unionCaseIsNotAccessible(a0 : System.String) = (1095, sprintf "The union case '%s' is not accessible from this code location" a0)
    /// The record, struct or class field '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:950)
    static member fieldIsNotAccessible(a0 : System.String) = (1096, sprintf "The record, struct or class field '%s' is not accessible from this code location" a0)
    /// The struct or class field '%s' is not accessible from this code location
    /// (Originally from /src/fsharp/FSComp.txt:951)
    static member structOrClassFieldIsNotAccessible(a0 : System.String) = (1097, sprintf "The struct or class field '%s' is not accessible from this code location" a0)
    /// This construct is experimental
    /// (Originally from /src/fsharp/FSComp.txt:952)
    static member experimentalConstruct() = (sprintf "This construct is experimental" )
    /// No Invoke methods found for delegate type
    /// (Originally from /src/fsharp/FSComp.txt:953)
    static member noInvokeMethodsFound() = (1099, sprintf "No Invoke methods found for delegate type" )
    /// More than one Invoke method found for delegate type
    /// (Originally from /src/fsharp/FSComp.txt:954)
    static member moreThanOneInvokeMethodFound() = (sprintf "More than one Invoke method found for delegate type" )
    /// Delegates are not allowed to have curried signatures
    /// (Originally from /src/fsharp/FSComp.txt:955)
    static member delegatesNotAllowedToHaveCurriedSignatures() = (1101, sprintf "Delegates are not allowed to have curried signatures" )
    /// Unexpected Expr.TyChoose
    /// (Originally from /src/fsharp/FSComp.txt:956)
    static member tlrUnexpectedTExpr() = (1102, sprintf "Unexpected Expr.TyChoose" )
    /// Note: Lambda-lifting optimizations have not been applied because of the use of this local constrained generic function as a first class value. Adding type constraints may resolve this condition.
    /// (Originally from /src/fsharp/FSComp.txt:957)
    static member tlrLambdaLiftingOptimizationsNotApplied() = (1103, sprintf "Note: Lambda-lifting optimizations have not been applied because of the use of this local constrained generic function as a first class value. Adding type constraints may resolve this condition." )
    /// Identifiers containing '@' are reserved for use in F# code generation
    /// (Originally from /src/fsharp/FSComp.txt:958)
    static member lexhlpIdentifiersContainingAtSymbolReserved() = (1104, sprintf "Identifiers containing '@' are reserved for use in F# code generation" )
    /// The identifier '%s' is reserved for future use by F#
    /// (Originally from /src/fsharp/FSComp.txt:959)
    static member lexhlpIdentifierReserved(a0 : System.String) = (sprintf "The identifier '%s' is reserved for future use by F#" a0)
    /// Missing variable '%s'
    /// (Originally from /src/fsharp/FSComp.txt:960)
    static member patcMissingVariable(a0 : System.String) = (1106, sprintf "Missing variable '%s'" a0)
    /// Partial active patterns may only generate one result
    /// (Originally from /src/fsharp/FSComp.txt:961)
    static member patcPartialActivePatternsGenerateOneResult() = (1107, sprintf "Partial active patterns may only generate one result" )
    /// The type '%s' is required here and is unavailable. You must add a reference to assembly '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:962)
    static member impTypeRequiredUnavailable(a0 : System.String, a1 : System.String) = (1108, sprintf "The type '%s' is required here and is unavailable. You must add a reference to assembly '%s'." a0 a1)
    /// A reference to the type '%s' in assembly '%s' was found, but the type could not be found in that assembly
    /// (Originally from /src/fsharp/FSComp.txt:963)
    static member impReferencedTypeCouldNotBeFoundInAssembly(a0 : System.String, a1 : System.String) = (1109, sprintf "A reference to the type '%s' in assembly '%s' was found, but the type could not be found in that assembly" a0 a1)
    /// Internal error or badly formed metadata: not enough type parameters were in scope while importing
    /// (Originally from /src/fsharp/FSComp.txt:964)
    static member impNotEnoughTypeParamsInScopeWhileImporting() = (1110, sprintf "Internal error or badly formed metadata: not enough type parameters were in scope while importing" )
    /// A reference to the DLL %s is required by assembly %s. The imported type %s is located in the first assembly and could not be resolved.
    /// (Originally from /src/fsharp/FSComp.txt:965)
    static member impReferenceToDllRequiredByAssembly(a0 : System.String, a1 : System.String, a2 : System.String) = (1111, sprintf "A reference to the DLL %s is required by assembly %s. The imported type %s is located in the first assembly and could not be resolved." a0 a1 a2)
    /// An imported assembly uses the type '%s' but that type is not public
    /// (Originally from /src/fsharp/FSComp.txt:966)
    static member impImportedAssemblyUsesNotPublicType(a0 : System.String) = (1112, sprintf "An imported assembly uses the type '%s' but that type is not public" a0)
    /// The value '%s' was marked inline but its implementation makes use of an internal or private function which is not sufficiently accessible
    /// (Originally from /src/fsharp/FSComp.txt:967)
    static member optValueMarkedInlineButIncomplete(a0 : System.String) = (1113, sprintf "The value '%s' was marked inline but its implementation makes use of an internal or private function which is not sufficiently accessible" a0)
    /// The value '%s' was marked inline but was not bound in the optimization environment
    /// (Originally from /src/fsharp/FSComp.txt:968)
    static member optValueMarkedInlineButWasNotBoundInTheOptEnv(a0 : System.String) = (1114, sprintf "The value '%s' was marked inline but was not bound in the optimization environment" a0)
    /// Local value %s not found during optimization
    /// (Originally from /src/fsharp/FSComp.txt:969)
    static member optLocalValueNotFoundDuringOptimization(a0 : System.String) = (1115, sprintf "Local value %s not found during optimization" a0)
    /// A value marked as 'inline' has an unexpected value
    /// (Originally from /src/fsharp/FSComp.txt:970)
    static member optValueMarkedInlineHasUnexpectedValue() = (1116, sprintf "A value marked as 'inline' has an unexpected value" )
    /// A value marked as 'inline' could not be inlined
    /// (Originally from /src/fsharp/FSComp.txt:971)
    static member optValueMarkedInlineCouldNotBeInlined() = (1117, sprintf "A value marked as 'inline' could not be inlined" )
    /// Failed to inline the value '%s' marked 'inline', perhaps because a recursive value was marked 'inline'
    /// (Originally from /src/fsharp/FSComp.txt:972)
    static member optFailedToInlineValue(a0 : System.String) = (1118, sprintf "Failed to inline the value '%s' marked 'inline', perhaps because a recursive value was marked 'inline'" a0)
    /// Recursive ValValue %s
    /// (Originally from /src/fsharp/FSComp.txt:973)
    static member optRecursiveValValue(a0 : System.String) = (1119, sprintf "Recursive ValValue %s" a0)
    /// The indentation of this 'in' token is incorrect with respect to the corresponding 'let'
    /// (Originally from /src/fsharp/FSComp.txt:974)
    static member lexfltIncorrentIndentationOfIn() = (sprintf "The indentation of this 'in' token is incorrect with respect to the corresponding 'let'" )
    /// Possible incorrect indentation: this token is offside of context started at position %s. Try indenting this token further or using standard formatting conventions.
    /// (Originally from /src/fsharp/FSComp.txt:975)
    static member lexfltTokenIsOffsideOfContextStartedEarlier(a0 : System.String) = (sprintf "Possible incorrect indentation: this token is offside of context started at position %s. Try indenting this token further or using standard formatting conventions." a0)
    /// The '|' tokens separating rules of this pattern match are misaligned by one column. Consider realigning your code or using further indentation.
    /// (Originally from /src/fsharp/FSComp.txt:976)
    static member lexfltSeparatorTokensOfPatternMatchMisaligned() = (sprintf "The '|' tokens separating rules of this pattern match are misaligned by one column. Consider realigning your code or using further indentation." )
    /// Invalid module/expression/type
    /// (Originally from /src/fsharp/FSComp.txt:977)
    static member nrInvalidModuleExprType() = (1123, sprintf "Invalid module/expression/type" )
    /// Multiple types exist called '%s', taking different numbers of generic parameters. Provide a type instantiation to disambiguate the type resolution, e.g. '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:978)
    static member nrTypeInstantiationNeededToDisambiguateTypesWithSameName(a0 : System.String, a1 : System.String) = (1124, sprintf "Multiple types exist called '%s', taking different numbers of generic parameters. Provide a type instantiation to disambiguate the type resolution, e.g. '%s'." a0 a1)
    /// The instantiation of the generic type '%s' is missing and can't be inferred from the arguments or return type of this member. Consider providing a type instantiation when accessing this type, e.g. '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:979)
    static member nrTypeInstantiationIsMissingAndCouldNotBeInferred(a0 : System.String, a1 : System.String) = (1125, sprintf "The instantiation of the generic type '%s' is missing and can't be inferred from the arguments or return type of this member. Consider providing a type instantiation when accessing this type, e.g. '%s'." a0 a1)
    /// 'global' may only be used as the first name in a qualified path
    /// (Originally from /src/fsharp/FSComp.txt:980)
    static member nrGlobalUsedOnlyAsFirstName() = (1126, sprintf "'global' may only be used as the first name in a qualified path" )
    /// This is not a constructor or literal, or a constructor is being used incorrectly
    /// (Originally from /src/fsharp/FSComp.txt:981)
    static member nrIsNotConstructorOrLiteral() = (1127, sprintf "This is not a constructor or literal, or a constructor is being used incorrectly" )
    /// Unexpected empty long identifier
    /// (Originally from /src/fsharp/FSComp.txt:982)
    static member nrUnexpectedEmptyLongId() = (1128, sprintf "Unexpected empty long identifier" )
    /// The record type '%s' does not contain a label '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:983)
    static member nrRecordDoesNotContainSuchLabel(a0 : System.String, a1 : System.String) = (1129, sprintf "The record type '%s' does not contain a label '%s'." a0 a1)
    /// Invalid field label
    /// (Originally from /src/fsharp/FSComp.txt:984)
    static member nrInvalidFieldLabel() = (1130, sprintf "Invalid field label" )
    /// Invalid expression '%s'
    /// (Originally from /src/fsharp/FSComp.txt:985)
    static member nrInvalidExpression(a0 : System.String) = (1132, sprintf "Invalid expression '%s'" a0)
    /// No constructors are available for the type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:986)
    static member nrNoConstructorsAvailableForType(a0 : System.String) = (1133, sprintf "No constructors are available for the type '%s'" a0)
    /// The union type for union case '%s' was defined with the RequireQualifiedAccessAttribute. Include the name of the union type ('%s') in the name you are using.
    /// (Originally from /src/fsharp/FSComp.txt:987)
    static member nrUnionTypeNeedsQualifiedAccess(a0 : System.String, a1 : System.String) = (1134, sprintf "The union type for union case '%s' was defined with the RequireQualifiedAccessAttribute. Include the name of the union type ('%s') in the name you are using." a0 a1)
    /// The record type for the record field '%s' was defined with the RequireQualifiedAccessAttribute. Include the name of the record type ('%s') in the name you are using.
    /// (Originally from /src/fsharp/FSComp.txt:988)
    static member nrRecordTypeNeedsQualifiedAccess(a0 : System.String, a1 : System.String) = (1135, sprintf "The record type for the record field '%s' was defined with the RequireQualifiedAccessAttribute. Include the name of the record type ('%s') in the name you are using." a0 a1)
    /// Unexpected error creating debug information file '%s'
    /// (Originally from /src/fsharp/FSComp.txt:989)
    static member ilwriteErrorCreatingPdb(a0 : System.String) = (1136, sprintf "Unexpected error creating debug information file '%s'" a0)
    /// This number is outside the allowable range for this integer type
    /// (Originally from /src/fsharp/FSComp.txt:990)
    static member lexOutsideIntegerRange() = (1138, sprintf "This number is outside the allowable range for this integer type" )
    /// '%s' is not permitted as a character in operator names and is reserved for future use
    /// (Originally from /src/fsharp/FSComp.txt:994)
    static member lexCharNotAllowedInOperatorNames(a0 : System.String) = (sprintf "'%s' is not permitted as a character in operator names and is reserved for future use" a0)
    /// Unexpected character '%s'
    /// (Originally from /src/fsharp/FSComp.txt:995)
    static member lexUnexpectedChar(a0 : System.String) = (sprintf "Unexpected character '%s'" a0)
    /// This byte array literal contains characters that do not encode as a single byte
    /// (Originally from /src/fsharp/FSComp.txt:996)
    static member lexByteArrayCannotEncode() = (1140, sprintf "This byte array literal contains characters that do not encode as a single byte" )
    /// Identifiers followed by '%s' are reserved for future use
    /// (Originally from /src/fsharp/FSComp.txt:997)
    static member lexIdentEndInMarkReserved(a0 : System.String) = (1141, sprintf "Identifiers followed by '%s' are reserved for future use" a0)
    /// This number is outside the allowable range for 8-bit signed integers
    /// (Originally from /src/fsharp/FSComp.txt:998)
    static member lexOutsideEightBitSigned() = (1142, sprintf "This number is outside the allowable range for 8-bit signed integers" )
    /// This number is outside the allowable range for hexadecimal 8-bit signed integers
    /// (Originally from /src/fsharp/FSComp.txt:999)
    static member lexOutsideEightBitSignedHex() = (1143, sprintf "This number is outside the allowable range for hexadecimal 8-bit signed integers" )
    /// This number is outside the allowable range for 8-bit unsigned integers
    /// (Originally from /src/fsharp/FSComp.txt:1000)
    static member lexOutsideEightBitUnsigned() = (1144, sprintf "This number is outside the allowable range for 8-bit unsigned integers" )
    /// This number is outside the allowable range for 16-bit signed integers
    /// (Originally from /src/fsharp/FSComp.txt:1001)
    static member lexOutsideSixteenBitSigned() = (1145, sprintf "This number is outside the allowable range for 16-bit signed integers" )
    /// This number is outside the allowable range for 16-bit unsigned integers
    /// (Originally from /src/fsharp/FSComp.txt:1002)
    static member lexOutsideSixteenBitUnsigned() = (1146, sprintf "This number is outside the allowable range for 16-bit unsigned integers" )
    /// This number is outside the allowable range for 32-bit signed integers
    /// (Originally from /src/fsharp/FSComp.txt:1003)
    static member lexOutsideThirtyTwoBitSigned() = (1147, sprintf "This number is outside the allowable range for 32-bit signed integers" )
    /// This number is outside the allowable range for 32-bit unsigned integers
    /// (Originally from /src/fsharp/FSComp.txt:1004)
    static member lexOutsideThirtyTwoBitUnsigned() = (1148, sprintf "This number is outside the allowable range for 32-bit unsigned integers" )
    /// This number is outside the allowable range for 64-bit signed integers
    /// (Originally from /src/fsharp/FSComp.txt:1005)
    static member lexOutsideSixtyFourBitSigned() = (1149, sprintf "This number is outside the allowable range for 64-bit signed integers" )
    /// This number is outside the allowable range for 64-bit unsigned integers
    /// (Originally from /src/fsharp/FSComp.txt:1006)
    static member lexOutsideSixtyFourBitUnsigned() = (1150, sprintf "This number is outside the allowable range for 64-bit unsigned integers" )
    /// This number is outside the allowable range for signed native integers
    /// (Originally from /src/fsharp/FSComp.txt:1007)
    static member lexOutsideNativeSigned() = (1151, sprintf "This number is outside the allowable range for signed native integers" )
    /// This number is outside the allowable range for unsigned native integers
    /// (Originally from /src/fsharp/FSComp.txt:1008)
    static member lexOutsideNativeUnsigned() = (1152, sprintf "This number is outside the allowable range for unsigned native integers" )
    /// Invalid floating point number
    /// (Originally from /src/fsharp/FSComp.txt:1009)
    static member lexInvalidFloat() = (1153, sprintf "Invalid floating point number" )
    /// This number is outside the allowable range for decimal literals
    /// (Originally from /src/fsharp/FSComp.txt:1010)
    static member lexOusideDecimal() = (1154, sprintf "This number is outside the allowable range for decimal literals" )
    /// This number is outside the allowable range for 32-bit floats
    /// (Originally from /src/fsharp/FSComp.txt:1011)
    static member lexOusideThirtyTwoBitFloat() = (1155, sprintf "This number is outside the allowable range for 32-bit floats" )
    /// This is not a valid numeric literal. Valid numeric literals include 1, 0x1, 0b0001 (int), 1u (uint32), 1L (int64), 1UL (uint64), 1s (int16), 1y (sbyte), 1uy (byte), 1.0 (float), 1.0f (float32), 1.0m (decimal), 1I (BigInteger).
    /// (Originally from /src/fsharp/FSComp.txt:1012)
    static member lexInvalidNumericLiteral() = (1156, sprintf "This is not a valid numeric literal. Valid numeric literals include 1, 0x1, 0b0001 (int), 1u (uint32), 1L (int64), 1UL (uint64), 1s (int16), 1y (sbyte), 1uy (byte), 1.0 (float), 1.0f (float32), 1.0m (decimal), 1I (BigInteger)." )
    /// This is not a valid byte literal
    /// (Originally from /src/fsharp/FSComp.txt:1013)
    static member lexInvalidByteLiteral() = (1157, sprintf "This is not a valid byte literal" )
    /// This is not a valid character literal
    /// (Originally from /src/fsharp/FSComp.txt:1014)
    static member lexInvalidCharLiteral() = (1158, sprintf "This is not a valid character literal" )
    /// This Unicode encoding is only valid in string literals
    /// (Originally from /src/fsharp/FSComp.txt:1015)
    static member lexThisUnicodeOnlyInStringLiterals() = (1159, sprintf "This Unicode encoding is only valid in string literals" )
    /// This token is reserved for future use
    /// (Originally from /src/fsharp/FSComp.txt:1016)
    static member lexTokenReserved() = (1160, sprintf "This token is reserved for future use" )
    /// TABs are not allowed in F# code unless the #indent \"off\" option is used
    /// (Originally from /src/fsharp/FSComp.txt:1017)
    static member lexTabsNotAllowed() = (1161, sprintf "TABs are not allowed in F# code unless the #indent \"off\" option is used" )
    /// Invalid line number: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1018)
    static member lexInvalidLineNumber(a0 : System.String) = (1162, sprintf "Invalid line number: '%s'" a0)
    /// #if directive must appear as the first non-whitespace character on a line
    /// (Originally from /src/fsharp/FSComp.txt:1019)
    static member lexHashIfMustBeFirst() = (1163, sprintf "#if directive must appear as the first non-whitespace character on a line" )
    /// #else has no matching #if
    /// (Originally from /src/fsharp/FSComp.txt:1020)
    static member lexHashElseNoMatchingIf() = (sprintf "#else has no matching #if" )
    /// #endif required for #else
    /// (Originally from /src/fsharp/FSComp.txt:1021)
    static member lexHashEndifRequiredForElse() = (sprintf "#endif required for #else" )
    /// #else directive must appear as the first non-whitespace character on a line
    /// (Originally from /src/fsharp/FSComp.txt:1022)
    static member lexHashElseMustBeFirst() = (1166, sprintf "#else directive must appear as the first non-whitespace character on a line" )
    /// #endif has no matching #if
    /// (Originally from /src/fsharp/FSComp.txt:1023)
    static member lexHashEndingNoMatchingIf() = (sprintf "#endif has no matching #if" )
    /// #endif directive must appear as the first non-whitespace character on a line
    /// (Originally from /src/fsharp/FSComp.txt:1024)
    static member lexHashEndifMustBeFirst() = (1168, sprintf "#endif directive must appear as the first non-whitespace character on a line" )
    /// #if directive should be immediately followed by an identifier
    /// (Originally from /src/fsharp/FSComp.txt:1025)
    static member lexHashIfMustHaveIdent() = (1169, sprintf "#if directive should be immediately followed by an identifier" )
    /// Syntax error. Wrong nested #endif, unexpected tokens before it.
    /// (Originally from /src/fsharp/FSComp.txt:1026)
    static member lexWrongNestedHashEndif() = (1170, sprintf "Syntax error. Wrong nested #endif, unexpected tokens before it." )
    /// #! may only appear as the first line at the start of a file.
    /// (Originally from /src/fsharp/FSComp.txt:1027)
    static member lexHashBangMustBeFirstInFile() = (sprintf "#! may only appear as the first line at the start of a file." )
    /// Expected single line comment or end of line
    /// (Originally from /src/fsharp/FSComp.txt:1028)
    static member pplexExpectedSingleLineComment() = (1171, sprintf "Expected single line comment or end of line" )
    /// Infix operator member '%s' has no arguments. Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ...
    /// (Originally from /src/fsharp/FSComp.txt:1029)
    static member memberOperatorDefinitionWithNoArguments(a0 : System.String) = (1172, sprintf "Infix operator member '%s' has no arguments. Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ..." a0)
    /// Infix operator member '%s' has %d initial argument(s). Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ...
    /// (Originally from /src/fsharp/FSComp.txt:1030)
    static member memberOperatorDefinitionWithNonPairArgument(a0 : System.String, a1 : System.Int32) = (1173, sprintf "Infix operator member '%s' has %d initial argument(s). Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ..." a0 a1)
    /// Infix operator member '%s' has extra curried arguments. Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ...
    /// (Originally from /src/fsharp/FSComp.txt:1031)
    static member memberOperatorDefinitionWithCurriedArguments(a0 : System.String) = (1174, sprintf "Infix operator member '%s' has extra curried arguments. Expected a tuple of 2 arguments, e.g. static member (+) (x,y) = ..." a0)
    /// All record, union and struct types in FSharp.Core.dll must be explicitly labelled with 'StructuralComparison' or 'NoComparison'
    /// (Originally from /src/fsharp/FSComp.txt:1032)
    static member tcFSharpCoreRequiresExplicit() = (1175, sprintf "All record, union and struct types in FSharp.Core.dll must be explicitly labelled with 'StructuralComparison' or 'NoComparison'" )
    /// The struct, record or union type '%s' has the 'StructuralComparison' attribute but the type parameter '%s' does not satisfy the 'comparison' constraint. Consider adding the 'comparison' constraint to the type parameter
    /// (Originally from /src/fsharp/FSComp.txt:1033)
    static member tcStructuralComparisonNotSatisfied1(a0 : System.String, a1 : System.String) = (1176, sprintf "The struct, record or union type '%s' has the 'StructuralComparison' attribute but the type parameter '%s' does not satisfy the 'comparison' constraint. Consider adding the 'comparison' constraint to the type parameter" a0 a1)
    /// The struct, record or union type '%s' has the 'StructuralComparison' attribute but the component type '%s' does not satisfy the 'comparison' constraint
    /// (Originally from /src/fsharp/FSComp.txt:1034)
    static member tcStructuralComparisonNotSatisfied2(a0 : System.String, a1 : System.String) = (1177, sprintf "The struct, record or union type '%s' has the 'StructuralComparison' attribute but the component type '%s' does not satisfy the 'comparison' constraint" a0 a1)
    /// The struct, record or union type '%s' is not structurally comparable because the type parameter %s does not satisfy the 'comparison' constraint. Consider adding the 'NoComparison' attribute to the type '%s' to clarify that the type is not comparable
    /// (Originally from /src/fsharp/FSComp.txt:1035)
    static member tcNoComparisonNeeded1(a0 : System.String, a1 : System.String, a2 : System.String) = (1178, sprintf "The struct, record or union type '%s' is not structurally comparable because the type parameter %s does not satisfy the 'comparison' constraint. Consider adding the 'NoComparison' attribute to the type '%s' to clarify that the type is not comparable" a0 a1 a2)
    /// The struct, record or union type '%s' is not structurally comparable because the type '%s' does not satisfy the 'comparison' constraint. Consider adding the 'NoComparison' attribute to the type '%s' to clarify that the type is not comparable
    /// (Originally from /src/fsharp/FSComp.txt:1036)
    static member tcNoComparisonNeeded2(a0 : System.String, a1 : System.String, a2 : System.String) = (1178, sprintf "The struct, record or union type '%s' is not structurally comparable because the type '%s' does not satisfy the 'comparison' constraint. Consider adding the 'NoComparison' attribute to the type '%s' to clarify that the type is not comparable" a0 a1 a2)
    /// The struct, record or union type '%s' does not support structural equality because the type parameter %s does not satisfy the 'equality' constraint. Consider adding the 'NoEquality' attribute to the type '%s' to clarify that the type does not support structural equality
    /// (Originally from /src/fsharp/FSComp.txt:1037)
    static member tcNoEqualityNeeded1(a0 : System.String, a1 : System.String, a2 : System.String) = (1178, sprintf "The struct, record or union type '%s' does not support structural equality because the type parameter %s does not satisfy the 'equality' constraint. Consider adding the 'NoEquality' attribute to the type '%s' to clarify that the type does not support structural equality" a0 a1 a2)
    /// The struct, record or union type '%s' does not support structural equality because the type '%s' does not satisfy the 'equality' constraint. Consider adding the 'NoEquality' attribute to the type '%s' to clarify that the type does not support structural equality
    /// (Originally from /src/fsharp/FSComp.txt:1038)
    static member tcNoEqualityNeeded2(a0 : System.String, a1 : System.String, a2 : System.String) = (1178, sprintf "The struct, record or union type '%s' does not support structural equality because the type '%s' does not satisfy the 'equality' constraint. Consider adding the 'NoEquality' attribute to the type '%s' to clarify that the type does not support structural equality" a0 a1 a2)
    /// The struct, record or union type '%s' has the 'StructuralEquality' attribute but the type parameter '%s' does not satisfy the 'equality' constraint. Consider adding the 'equality' constraint to the type parameter
    /// (Originally from /src/fsharp/FSComp.txt:1039)
    static member tcStructuralEqualityNotSatisfied1(a0 : System.String, a1 : System.String) = (1179, sprintf "The struct, record or union type '%s' has the 'StructuralEquality' attribute but the type parameter '%s' does not satisfy the 'equality' constraint. Consider adding the 'equality' constraint to the type parameter" a0 a1)
    /// The struct, record or union type '%s' has the 'StructuralEquality' attribute but the component type '%s' does not satisfy the 'equality' constraint
    /// (Originally from /src/fsharp/FSComp.txt:1040)
    static member tcStructuralEqualityNotSatisfied2(a0 : System.String, a1 : System.String) = (1180, sprintf "The struct, record or union type '%s' has the 'StructuralEquality' attribute but the component type '%s' does not satisfy the 'equality' constraint" a0 a1)
    /// Each argument of the primary constructor for a struct must be given a type, for example 'type S(x1:int, x2: int) = ...'. These arguments determine the fields of the struct.
    /// (Originally from /src/fsharp/FSComp.txt:1041)
    static member tcStructsMustDeclareTypesOfImplicitCtorArgsExplicitly() = (1181, sprintf "Each argument of the primary constructor for a struct must be given a type, for example 'type S(x1:int, x2: int) = ...'. These arguments determine the fields of the struct." )
    /// The value '%s' is unused
    /// (Originally from /src/fsharp/FSComp.txt:1042)
    static member chkUnusedValue(a0 : System.String) = (1182, sprintf "The value '%s' is unused" a0)
    /// The recursive object reference '%s' is unused. The presence of a recursive object reference adds runtime initialization checks to members in this and derived types. Consider removing this recursive object reference.
    /// (Originally from /src/fsharp/FSComp.txt:1043)
    static member chkUnusedThisVariable(a0 : System.String) = (1183, sprintf "The recursive object reference '%s' is unused. The presence of a recursive object reference adds runtime initialization checks to members in this and derived types. Consider removing this recursive object reference." a0)
    /// A getter property may have at most one argument group
    /// (Originally from /src/fsharp/FSComp.txt:1044)
    static member parsGetterAtMostOneArgument() = (1184, sprintf "A getter property may have at most one argument group" )
    /// A setter property may have at most two argument groups
    /// (Originally from /src/fsharp/FSComp.txt:1045)
    static member parsSetterAtMostTwoArguments() = (1185, sprintf "A setter property may have at most two argument groups" )
    /// Invalid property getter or setter
    /// (Originally from /src/fsharp/FSComp.txt:1046)
    static member parsInvalidProperty() = (1186, sprintf "Invalid property getter or setter" )
    /// An indexer property must be given at least one argument
    /// (Originally from /src/fsharp/FSComp.txt:1047)
    static member parsIndexerPropertyRequiresAtLeastOneArgument() = (1187, sprintf "An indexer property must be given at least one argument" )
    /// This operation accesses a mutable top-level value defined in another assembly in an unsupported way. The value cannot be accessed through its address. Consider copying the expression to a mutable local, e.g. 'let mutable x = ...', and if necessary assigning the value back after the completion of the operation
    /// (Originally from /src/fsharp/FSComp.txt:1048)
    static member tastInvalidAddressOfMutableAcrossAssemblyBoundary() = (1188, sprintf "This operation accesses a mutable top-level value defined in another assembly in an unsupported way. The value cannot be accessed through its address. Consider copying the expression to a mutable local, e.g. 'let mutable x = ...', and if necessary assigning the value back after the completion of the operation" )
    /// Remove spaces between the type name and type parameter, e.g. \"type C<'T>\", not type \"C   <'T>\". Type parameters must be placed directly adjacent to the type name.
    /// (Originally from /src/fsharp/FSComp.txt:1049)
    static member parsNonAdjacentTypars() = (1189, sprintf "Remove spaces between the type name and type parameter, e.g. \"type C<'T>\", not type \"C   <'T>\". Type parameters must be placed directly adjacent to the type name." )
    /// Remove spaces between the type name and type parameter, e.g. \"C<'T>\", not \"C <'T>\". Type parameters must be placed directly adjacent to the type name.
    /// (Originally from /src/fsharp/FSComp.txt:1050)
    static member parsNonAdjacentTyargs() = (1190, sprintf "Remove spaces between the type name and type parameter, e.g. \"C<'T>\", not \"C <'T>\". Type parameters must be placed directly adjacent to the type name." )
    /// The use of the type syntax 'int C' and 'C  <int>' is not permitted here. Consider adjusting this type to be written in the form 'C<int>'
    /// (Originally from /src/fsharp/FSComp.txt:1051)
    static member parsNonAtomicType() = (sprintf "The use of the type syntax 'int C' and 'C  <int>' is not permitted here. Consider adjusting this type to be written in the form 'C<int>'" )
    /// The module/namespace '%s' from compilation unit '%s' did not contain the module/namespace '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1054)
    static member tastUndefinedItemRefModuleNamespace(a0 : System.String, a1 : System.String, a2 : System.String) = (1193, sprintf "The module/namespace '%s' from compilation unit '%s' did not contain the module/namespace '%s'" a0 a1 a2)
    /// The module/namespace '%s' from compilation unit '%s' did not contain the val '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1055)
    static member tastUndefinedItemRefVal(a0 : System.String, a1 : System.String, a2 : System.String) = (1194, sprintf "The module/namespace '%s' from compilation unit '%s' did not contain the val '%s'" a0 a1 a2)
    /// The module/namespace '%s' from compilation unit '%s' did not contain the namespace, module or type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1056)
    static member tastUndefinedItemRefModuleNamespaceType(a0 : System.String, a1 : System.String, a2 : System.String) = (1195, sprintf "The module/namespace '%s' from compilation unit '%s' did not contain the namespace, module or type '%s'" a0 a1 a2)
    /// The 'UseNullAsTrueValue' attribute flag may only be used with union types that have one nullary case and at least one non-nullary case
    /// (Originally from /src/fsharp/FSComp.txt:1057)
    static member tcInvalidUseNullAsTrueValue() = (1196, sprintf "The 'UseNullAsTrueValue' attribute flag may only be used with union types that have one nullary case and at least one non-nullary case" )
    /// The parameter '%s' was inferred to have byref type. Parameters of byref type must be given an explicit type annotation, e.g. 'x1: byref<int>'. When used, a byref parameter is implicitly dereferenced.
    /// (Originally from /src/fsharp/FSComp.txt:1058)
    static member tcParameterInferredByref(a0 : System.String) = (1197, sprintf "The parameter '%s' was inferred to have byref type. Parameters of byref type must be given an explicit type annotation, e.g. 'x1: byref<int>'. When used, a byref parameter is implicitly dereferenced." a0)
    /// The generic member '%s' has been used at a non-uniform instantiation prior to this program point. Consider reordering the members so this member occurs first. Alternatively, specify the full type of the member explicitly, including argument types, return type and any additional generic parameters and constraints.
    /// (Originally from /src/fsharp/FSComp.txt:1059)
    static member tcNonUniformMemberUse(a0 : System.String) = (1198, sprintf "The generic member '%s' has been used at a non-uniform instantiation prior to this program point. Consider reordering the members so this member occurs first. Alternatively, specify the full type of the member explicitly, including argument types, return type and any additional generic parameters and constraints." a0)
    /// The attribute '%s' appears in both the implementation and the signature, but the attribute arguments differ. Only the attribute from the signature will be included in the compiled code.
    /// (Originally from /src/fsharp/FSComp.txt:1060)
    static member tcAttribArgsDiffer(a0 : System.String) = (1200, sprintf "The attribute '%s' appears in both the implementation and the signature, but the attribute arguments differ. Only the attribute from the signature will be included in the compiled code." a0)
    /// Cannot call an abstract base member: '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1061)
    static member tcCannotCallAbstractBaseMember(a0 : System.String) = (1201, sprintf "Cannot call an abstract base member: '%s'" a0)
    /// Could not resolve the ambiguity in the use of a generic construct with an 'unmanaged' constraint at or near this position
    /// (Originally from /src/fsharp/FSComp.txt:1062)
    static member typrelCannotResolveAmbiguityInUnmanaged() = (1202, sprintf "Could not resolve the ambiguity in the use of a generic construct with an 'unmanaged' constraint at or near this position" )
    /// This construct is for ML compatibility. %s. You can disable this warning by using '--mlcompatibility' or '--nowarn:62'.
    /// (Originally from /src/fsharp/FSComp.txt:1065)
    static member mlCompatMessage(a0 : System.String) = (sprintf "This construct is for ML compatibility. %s. You can disable this warning by using '--mlcompatibility' or '--nowarn:62'." a0)
    /// The type '%s' has been marked as having an Explicit layout, but the field '%s' has not been marked with the 'FieldOffset' attribute
    /// (Originally from /src/fsharp/FSComp.txt:1067)
    static member ilFieldDoesNotHaveValidOffsetForStructureLayout(a0 : System.String, a1 : System.String) = (1206, sprintf "The type '%s' has been marked as having an Explicit layout, but the field '%s' has not been marked with the 'FieldOffset' attribute" a0 a1)
    /// Interfaces inherited by other interfaces should be declared using 'inherit ...' instead of 'interface ...'
    /// (Originally from /src/fsharp/FSComp.txt:1068)
    static member tcInterfacesShouldUseInheritNotInterface() = (1207, sprintf "Interfaces inherited by other interfaces should be declared using 'inherit ...' instead of 'interface ...'" )
    /// Invalid prefix operator
    /// (Originally from /src/fsharp/FSComp.txt:1069)
    static member parsInvalidPrefixOperator() = (1208, sprintf "Invalid prefix operator" )
    /// Invalid operator definition. Prefix operator definitions must use a valid prefix operator name.
    /// (Originally from /src/fsharp/FSComp.txt:1070)
    static member parsInvalidPrefixOperatorDefinition() = (1208, sprintf "Invalid operator definition. Prefix operator definitions must use a valid prefix operator name." )
    /// The file extensions '.ml' and '.mli' are for ML compatibility
    /// (Originally from /src/fsharp/FSComp.txt:1071)
    static member buildCompilingExtensionIsForML() = (sprintf "The file extensions '.ml' and '.mli' are for ML compatibility" )
    /// Consider using a file with extension '.ml' or '.mli' instead
    /// (Originally from /src/fsharp/FSComp.txt:1072)
    static member lexIndentOffForML() = (sprintf "Consider using a file with extension '.ml' or '.mli' instead" )
    /// Active pattern '%s' is not a function
    /// (Originally from /src/fsharp/FSComp.txt:1073)
    static member activePatternIdentIsNotFunctionTyped(a0 : System.String) = (1209, sprintf "Active pattern '%s' is not a function" a0)
    /// Active pattern '%s' has a result type containing type variables that are not determined by the input. The common cause is a when a result case is not mentioned, e.g. 'let (|A|B|) (x:int) = A x'. This can be fixed with a type constraint, e.g. 'let (|A|B|) (x:int) : Choice<int,unit> = A x'
    /// (Originally from /src/fsharp/FSComp.txt:1074)
    static member activePatternChoiceHasFreeTypars(a0 : System.String) = (1210, sprintf "Active pattern '%s' has a result type containing type variables that are not determined by the input. The common cause is a when a result case is not mentioned, e.g. 'let (|A|B|) (x:int) = A x'. This can be fixed with a type constraint, e.g. 'let (|A|B|) (x:int) : Choice<int,unit> = A x'" a0)
    /// The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)
    /// (Originally from /src/fsharp/FSComp.txt:1075)
    static member ilFieldHasOffsetForSequentialLayout() = (1211, sprintf "The FieldOffset attribute can only be placed on members of types marked with the StructLayout(LayoutKind.Explicit)" )
    /// Optional arguments must come at the end of the argument list, after any non-optional arguments
    /// (Originally from /src/fsharp/FSComp.txt:1076)
    static member tcOptionalArgsMustComeAfterNonOptionalArgs() = (1212, sprintf "Optional arguments must come at the end of the argument list, after any non-optional arguments" )
    /// Attribute 'System.Diagnostics.ConditionalAttribute' is only valid on methods or attribute classes
    /// (Originally from /src/fsharp/FSComp.txt:1077)
    static member tcConditionalAttributeUsage() = (1213, sprintf "Attribute 'System.Diagnostics.ConditionalAttribute' is only valid on methods or attribute classes" )
    /// Extension members cannot provide operator overloads.  Consider defining the operator as part of the type definition instead.
    /// (Originally from /src/fsharp/FSComp.txt:1079)
    static member tcMemberOperatorDefinitionInExtrinsic() = (1215, sprintf "Extension members cannot provide operator overloads.  Consider defining the operator as part of the type definition instead." )
    /// The name of the MDB file must be <assembly-file-name>.mdb. The --pdb option will be ignored.
    /// (Originally from /src/fsharp/FSComp.txt:1080)
    static member ilwriteMDBFileNameCannotBeChangedWarning() = (1216, sprintf "The name of the MDB file must be <assembly-file-name>.mdb. The --pdb option will be ignored." )
    /// MDB generation failed. Could not find compatible member %s
    /// (Originally from /src/fsharp/FSComp.txt:1081)
    static member ilwriteMDBMemberMissing(a0 : System.String) = (1217, sprintf "MDB generation failed. Could not find compatible member %s" a0)
    /// Cannot generate MDB debug information. Failed to load the 'MonoSymbolWriter' type from the 'Mono.CompilerServices.SymbolWriter.dll' assembly.
    /// (Originally from /src/fsharp/FSComp.txt:1082)
    static member ilwriteErrorCreatingMdb() = (1218, sprintf "Cannot generate MDB debug information. Failed to load the 'MonoSymbolWriter' type from the 'Mono.CompilerServices.SymbolWriter.dll' assembly." )
    /// The union case named '%s' conflicts with the generated type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1083)
    static member tcUnionCaseNameConflictsWithGeneratedType(a0 : System.String, a1 : System.String) = (1219, sprintf "The union case named '%s' conflicts with the generated type '%s'" a0 a1)
    /// ReflectedDefinitionAttribute may not be applied to an instance member on a struct type, because the instance member takes an implicit 'this' byref parameter
    /// (Originally from /src/fsharp/FSComp.txt:1084)
    static member chkNoReflectedDefinitionOnStructMember() = (1220, sprintf "ReflectedDefinitionAttribute may not be applied to an instance member on a struct type, because the instance member takes an implicit 'this' byref parameter" )
    /// DLLImport bindings must be static members in a class or function definitions in a module
    /// (Originally from /src/fsharp/FSComp.txt:1085)
    static member tcDllImportNotAllowed() = (1221, sprintf "DLLImport bindings must be static members in a class or function definitions in a module" )
    /// When mscorlib.dll or FSharp.Core.dll is explicitly referenced the %s option must also be passed
    /// (Originally from /src/fsharp/FSComp.txt:1086)
    static member buildExplicitCoreLibRequiresNoFramework(a0 : System.String) = (1222, sprintf "When mscorlib.dll or FSharp.Core.dll is explicitly referenced the %s option must also be passed" a0)
    /// FSharp.Core.sigdata not found alongside FSharp.Core. File expected in %s. Consider upgrading to a more recent version of FSharp.Core, where this file is no longer be required.
    /// (Originally from /src/fsharp/FSComp.txt:1087)
    static member buildExpectedSigdataFile(a0 : System.String) = (1223, sprintf "FSharp.Core.sigdata not found alongside FSharp.Core. File expected in %s. Consider upgrading to a more recent version of FSharp.Core, where this file is no longer be required." a0)
    /// File '%s' not found alongside FSharp.Core. File expected in %s. Consider upgrading to a more recent version of FSharp.Core, where this file is no longer be required.
    /// (Originally from /src/fsharp/FSComp.txt:1088)
    static member buildExpectedFileAlongSideFSharpCore(a0 : System.String, a1 : System.String) = (1225, sprintf "File '%s' not found alongside FSharp.Core. File expected in %s. Consider upgrading to a more recent version of FSharp.Core, where this file is no longer be required." a0 a1)
    /// Filename '%s' contains invalid character '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1089)
    static member buildUnexpectedFileNameCharacter(a0 : System.String, a1 : System.String) = (1227, sprintf "Filename '%s' contains invalid character '%s'" a0 a1)
    /// 'use!' bindings must be of the form 'use! <var> = <expr>'
    /// (Originally from /src/fsharp/FSComp.txt:1090)
    static member tcInvalidUseBangBinding() = (1228, sprintf "'use!' bindings must be of the form 'use! <var> = <expr>'" )
    /// Inner generic functions are not permitted in quoted expressions. Consider adding some type constraints until this function is no longer generic.
    /// (Originally from /src/fsharp/FSComp.txt:1091)
    static member crefNoInnerGenericsInQuotations() = (1230, sprintf "Inner generic functions are not permitted in quoted expressions. Consider adding some type constraints until this function is no longer generic." )
    /// The type '%s' is not a valid enumerator type , i.e. does not have a 'MoveNext()' method returning a bool, and a 'Current' property
    /// (Originally from /src/fsharp/FSComp.txt:1092)
    static member tcEnumTypeCannotBeEnumerated(a0 : System.String) = (1231, sprintf "The type '%s' is not a valid enumerator type , i.e. does not have a 'MoveNext()' method returning a bool, and a 'Current' property" a0)
    /// End of file in triple-quote string begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:1093)
    static member parsEofInTripleQuoteString() = (1232, sprintf "End of file in triple-quote string begun at or before here" )
    /// End of file in triple-quote string embedded in comment begun at or before here
    /// (Originally from /src/fsharp/FSComp.txt:1094)
    static member parsEofInTripleQuoteStringInComment() = (1233, sprintf "End of file in triple-quote string embedded in comment begun at or before here" )
    /// This type test or downcast will ignore the unit-of-measure '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1095)
    static member tcTypeTestLosesMeasures(a0 : System.String) = (1240, sprintf "This type test or downcast will ignore the unit-of-measure '%s'" a0)
    /// Expected type argument or static argument
    /// (Originally from /src/fsharp/FSComp.txt:1096)
    static member parsMissingTypeArgs() = (1241, sprintf "Expected type argument or static argument" )
    /// Unmatched '<'. Expected closing '>'
    /// (Originally from /src/fsharp/FSComp.txt:1097)
    static member parsMissingGreaterThan() = (1242, sprintf "Unmatched '<'. Expected closing '>'" )
    /// Unexpected quotation operator '<@' in type definition. If you intend to pass a verbatim string as a static argument to a type provider, put a space between the '<' and '@' characters.
    /// (Originally from /src/fsharp/FSComp.txt:1098)
    static member parsUnexpectedQuotationOperatorInTypeAliasDidYouMeanVerbatimString() = (1243, sprintf "Unexpected quotation operator '<@' in type definition. If you intend to pass a verbatim string as a static argument to a type provider, put a space between the '<' and '@' characters." )
    /// Attempted to parse this as an operator name, but failed
    /// (Originally from /src/fsharp/FSComp.txt:1099)
    static member parsErrorParsingAsOperatorName() = (1244, sprintf "Attempted to parse this as an operator name, but failed" )
    /// \U%s is not a valid Unicode character escape sequence
    /// (Originally from /src/fsharp/FSComp.txt:1100)
    static member lexInvalidUnicodeLiteral(a0 : System.String) = (1245, sprintf "\U%s is not a valid Unicode character escape sequence" a0)
    /// '%s' must be applied to an argument of type '%s', but has been applied to an argument of type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1101)
    static member tcCallerInfoWrongType(a0 : System.String, a1 : System.String, a2 : System.String) = (1246, sprintf "'%s' must be applied to an argument of type '%s', but has been applied to an argument of type '%s'" a0 a1 a2)
    /// '%s' can only be applied to optional arguments
    /// (Originally from /src/fsharp/FSComp.txt:1102)
    static member tcCallerInfoNotOptional(a0 : System.String) = (1247, sprintf "'%s' can only be applied to optional arguments" a0)
    /// The specified .NET Framework version '%s' is not supported. Please specify a value from the enumeration Microsoft.Build.Utilities.TargetDotNetFrameworkVersion.
    /// (Originally from /src/fsharp/FSComp.txt:1104)
    static member toolLocationHelperUnsupportedFrameworkVersion(a0 : System.String) = (1300, sprintf "The specified .NET Framework version '%s' is not supported. Please specify a value from the enumeration Microsoft.Build.Utilities.TargetDotNetFrameworkVersion." a0)
    /// Invalid Magic value in CLR Header
    /// (Originally from /src/fsharp/FSComp.txt:1108)
    static member ilSignInvalidMagicValue() = (1301, sprintf "Invalid Magic value in CLR Header" )
    /// Bad image format
    /// (Originally from /src/fsharp/FSComp.txt:1109)
    static member ilSignBadImageFormat() = (1302, sprintf "Bad image format" )
    /// Private key expected
    /// (Originally from /src/fsharp/FSComp.txt:1110)
    static member ilSignPrivateKeyExpected() = (1303, sprintf "Private key expected" )
    /// RSA key expected
    /// (Originally from /src/fsharp/FSComp.txt:1111)
    static member ilSignRsaKeyExpected() = (1304, sprintf "RSA key expected" )
    /// Invalid bit Length
    /// (Originally from /src/fsharp/FSComp.txt:1112)
    static member ilSignInvalidBitLen() = (1305, sprintf "Invalid bit Length" )
    /// Invalid RSAParameters structure - '{0}' expected
    /// (Originally from /src/fsharp/FSComp.txt:1113)
    static member ilSignInvalidRSAParams() = (1306, sprintf "Invalid RSAParameters structure - '{0}' expected" )
    /// Invalid algId - 'Exponent' expected
    /// (Originally from /src/fsharp/FSComp.txt:1114)
    static member ilSignInvalidAlgId() = (1307, sprintf "Invalid algId - 'Exponent' expected" )
    /// Invalid signature size
    /// (Originally from /src/fsharp/FSComp.txt:1115)
    static member ilSignInvalidSignatureSize() = (1308, sprintf "Invalid signature size" )
    /// No signature directory
    /// (Originally from /src/fsharp/FSComp.txt:1116)
    static member ilSignNoSignatureDirectory() = (1309, sprintf "No signature directory" )
    /// Invalid Public Key blob
    /// (Originally from /src/fsharp/FSComp.txt:1117)
    static member ilSignInvalidPKBlob() = (1310, sprintf "Invalid Public Key blob" )
    /// Exiting - too many errors
    /// (Originally from /src/fsharp/FSComp.txt:1119)
    static member fscTooManyErrors() = (sprintf "Exiting - too many errors" )
    /// The documentation file has no .xml suffix
    /// (Originally from /src/fsharp/FSComp.txt:1120)
    static member docfileNoXmlSuffix() = (2001, sprintf "The documentation file has no .xml suffix" )
    /// No implementation files specified
    /// (Originally from /src/fsharp/FSComp.txt:1121)
    static member fscNoImplementationFiles() = (2002, sprintf "No implementation files specified" )
    /// The attribute %s specified version '%s', but this value is invalid and has been ignored
    /// (Originally from /src/fsharp/FSComp.txt:1122)
    static member fscBadAssemblyVersion(a0 : System.String, a1 : System.String) = (2003, sprintf "The attribute %s specified version '%s', but this value is invalid and has been ignored" a0 a1)
    /// Conflicting options specified: 'win32manifest' and 'win32res'. Only one of these can be used.
    /// (Originally from /src/fsharp/FSComp.txt:1123)
    static member fscTwoResourceManifests() = (2004, sprintf "Conflicting options specified: 'win32manifest' and 'win32res'. Only one of these can be used." )
    /// The code in assembly '%s' makes uses of quotation literals. Static linking may not include components that make use of quotation literals unless all assemblies are compiled with at least F# 4.0.
    /// (Originally from /src/fsharp/FSComp.txt:1124)
    static member fscQuotationLiteralsStaticLinking(a0 : System.String) = (2005, sprintf "The code in assembly '%s' makes uses of quotation literals. Static linking may not include components that make use of quotation literals unless all assemblies are compiled with at least F# 4.0." a0)
    /// Code in this assembly makes uses of quotation literals. Static linking may not include components that make use of quotation literals unless all assemblies are compiled with at least F# 4.0.
    /// (Originally from /src/fsharp/FSComp.txt:1125)
    static member fscQuotationLiteralsStaticLinking0() = (2006, sprintf "Code in this assembly makes uses of quotation literals. Static linking may not include components that make use of quotation literals unless all assemblies are compiled with at least F# 4.0." )
    /// Static linking may not include a .EXE
    /// (Originally from /src/fsharp/FSComp.txt:1126)
    static member fscStaticLinkingNoEXE() = (2007, sprintf "Static linking may not include a .EXE" )
    /// Static linking may not include a mixed managed/unmanaged DLL
    /// (Originally from /src/fsharp/FSComp.txt:1127)
    static member fscStaticLinkingNoMixedDLL() = (2008, sprintf "Static linking may not include a mixed managed/unmanaged DLL" )
    /// Ignoring mixed managed/unmanaged assembly '%s' during static linking
    /// (Originally from /src/fsharp/FSComp.txt:1128)
    static member fscIgnoringMixedWhenLinking(a0 : System.String) = (2009, sprintf "Ignoring mixed managed/unmanaged assembly '%s' during static linking" a0)
    /// Assembly '%s' was referenced transitively and the assembly could not be resolved automatically. Static linking will assume this DLL has no dependencies on the F# library or other statically linked DLLs. Consider adding an explicit reference to this DLL.
    /// (Originally from /src/fsharp/FSComp.txt:1129)
    static member fscAssumeStaticLinkContainsNoDependencies(a0 : System.String) = (2011, sprintf "Assembly '%s' was referenced transitively and the assembly could not be resolved automatically. Static linking will assume this DLL has no dependencies on the F# library or other statically linked DLLs. Consider adding an explicit reference to this DLL." a0)
    /// Assembly '%s' not found in dependency set of target binary. Statically linked roots should be specified using an assembly name, without a DLL or EXE extension. If this assembly was referenced explicitly then it is possible the assembly was not actually required by the generated binary, in which case it should not be statically linked.
    /// (Originally from /src/fsharp/FSComp.txt:1130)
    static member fscAssemblyNotFoundInDependencySet(a0 : System.String) = (2012, sprintf "Assembly '%s' not found in dependency set of target binary. Statically linked roots should be specified using an assembly name, without a DLL or EXE extension. If this assembly was referenced explicitly then it is possible the assembly was not actually required by the generated binary, in which case it should not be statically linked." a0)
    /// The key file '%s' could not be opened
    /// (Originally from /src/fsharp/FSComp.txt:1131)
    static member fscKeyFileCouldNotBeOpened(a0 : System.String) = (2013, sprintf "The key file '%s' could not be opened" a0)
    /// A problem occurred writing the binary '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:1132)
    static member fscProblemWritingBinary(a0 : System.String, a1 : System.String) = (2014, sprintf "A problem occurred writing the binary '%s': %s" a0 a1)
    /// The 'AssemblyVersionAttribute' has been ignored because a version was given using a command line option
    /// (Originally from /src/fsharp/FSComp.txt:1133)
    static member fscAssemblyVersionAttributeIgnored() = (2015, sprintf "The 'AssemblyVersionAttribute' has been ignored because a version was given using a command line option" )
    /// Error emitting 'System.Reflection.AssemblyCultureAttribute' attribute -- 'Executables cannot be satellite assemblies, Culture should always be empty'
    /// (Originally from /src/fsharp/FSComp.txt:1134)
    static member fscAssemblyCultureAttributeError() = (2016, sprintf "Error emitting 'System.Reflection.AssemblyCultureAttribute' attribute -- 'Executables cannot be satellite assemblies, Culture should always be empty'" )
    /// Option '--delaysign' overrides attribute 'System.Reflection.AssemblyDelaySignAttribute' given in a source file or added module
    /// (Originally from /src/fsharp/FSComp.txt:1135)
    static member fscDelaySignWarning() = (2017, sprintf "Option '--delaysign' overrides attribute 'System.Reflection.AssemblyDelaySignAttribute' given in a source file or added module" )
    /// Option '--keyfile' overrides attribute 'System.Reflection.AssemblyKeyFileAttribute' given in a source file or added module
    /// (Originally from /src/fsharp/FSComp.txt:1136)
    static member fscKeyFileWarning() = (2018, sprintf "Option '--keyfile' overrides attribute 'System.Reflection.AssemblyKeyFileAttribute' given in a source file or added module" )
    /// Option '--keycontainer' overrides attribute 'System.Reflection.AssemblyNameAttribute' given in a source file or added module
    /// (Originally from /src/fsharp/FSComp.txt:1137)
    static member fscKeyNameWarning() = (2019, sprintf "Option '--keycontainer' overrides attribute 'System.Reflection.AssemblyNameAttribute' given in a source file or added module" )
    /// The assembly '%s' is listed on the command line. Assemblies should be referenced using a command line flag such as '-r'.
    /// (Originally from /src/fsharp/FSComp.txt:1138)
    static member fscReferenceOnCommandLine(a0 : System.String) = (2020, sprintf "The assembly '%s' is listed on the command line. Assemblies should be referenced using a command line flag such as '-r'." a0)
    /// The resident compilation service was not used because a problem occured in communicating with the server.
    /// (Originally from /src/fsharp/FSComp.txt:1139)
    static member fscRemotingError() = (2021, sprintf "The resident compilation service was not used because a problem occured in communicating with the server." )
    /// Problem with filename '%s': Illegal characters in path.
    /// (Originally from /src/fsharp/FSComp.txt:1140)
    static member pathIsInvalid(a0 : System.String) = (2022, sprintf "Problem with filename '%s': Illegal characters in path." a0)
    /// Passing a .resx file (%s) as a source file to the compiler is deprecated. Use resgen.exe to transform the .resx file into a .resources file to pass as a --resource option. If you are using MSBuild, this can be done via an <EmbeddedResource> item in the .fsproj project file.
    /// (Originally from /src/fsharp/FSComp.txt:1141)
    static member fscResxSourceFileDeprecated(a0 : System.String) = (2023, sprintf "Passing a .resx file (%s) as a source file to the compiler is deprecated. Use resgen.exe to transform the .resx file into a .resources file to pass as a --resource option. If you are using MSBuild, this can be done via an <EmbeddedResource> item in the .fsproj project file." a0)
    /// Static linking may not be used on an assembly referencing mscorlib (e.g. a .NET Framework assembly) when generating an assembly that references System.Runtime (e.g. a .NET Core or Portable assembly).
    /// (Originally from /src/fsharp/FSComp.txt:1142)
    static member fscStaticLinkingNoProfileMismatches() = (2024, sprintf "Static linking may not be used on an assembly referencing mscorlib (e.g. a .NET Framework assembly) when generating an assembly that references System.Runtime (e.g. a .NET Core or Portable assembly)." )
    /// An %s specified version '%s', but this value is a wildcard, and you have requested a deterministic build, these are in conflict.
    /// (Originally from /src/fsharp/FSComp.txt:1143)
    static member fscAssemblyWildcardAndDeterminism(a0 : System.String, a1 : System.String) = (2025, sprintf "An %s specified version '%s', but this value is a wildcard, and you have requested a deterministic build, these are in conflict." a0 a1)
    /// Deterministic builds only support portable PDBs (--debug:portable or --debug:embedded)
    /// (Originally from /src/fsharp/FSComp.txt:1144)
    static member fscDeterministicDebugRequiresPortablePdb() = (2026, sprintf "Deterministic builds only support portable PDBs (--debug:portable or --debug:embedded)" )
    /// --pathmap can only be used with portable PDBs (--debug:portable or --debug:embedded)
    /// (Originally from /src/fsharp/FSComp.txt:1145)
    static member fscPathMapDebugRequiresPortablePdb() = (2027, sprintf "--pathmap can only be used with portable PDBs (--debug:portable or --debug:embedded)" )
    /// Invalid path map. Mappings must be comma separated and of the format 'path=sourcePath'
    /// (Originally from /src/fsharp/FSComp.txt:1146)
    static member optsInvalidPathMapFormat() = (2028, sprintf "Invalid path map. Mappings must be comma separated and of the format 'path=sourcePath'" )
    /// Character '%s' is not allowed in provided namespace name '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1147)
    static member etIllegalCharactersInNamespaceName(a0 : System.String, a1 : System.String) = (3000, sprintf "Character '%s' is not allowed in provided namespace name '%s'" a0 a1)
    /// The provided type '%s' returned a member with a null or empty member name
    /// (Originally from /src/fsharp/FSComp.txt:1148)
    static member etNullOrEmptyMemberName(a0 : System.String) = (3001, sprintf "The provided type '%s' returned a member with a null or empty member name" a0)
    /// The provided type '%s' returned a null member
    /// (Originally from /src/fsharp/FSComp.txt:1149)
    static member etNullMember(a0 : System.String) = (3002, sprintf "The provided type '%s' returned a null member" a0)
    /// The provided type '%s' member info '%s' has null declaring type
    /// (Originally from /src/fsharp/FSComp.txt:1150)
    static member etNullMemberDeclaringType(a0 : System.String, a1 : System.String) = (3003, sprintf "The provided type '%s' member info '%s' has null declaring type" a0 a1)
    /// The provided type '%s' has member '%s' which has declaring type '%s'. Expected declaring type to be the same as provided type.
    /// (Originally from /src/fsharp/FSComp.txt:1151)
    static member etNullMemberDeclaringTypeDifferentFromProvidedType(a0 : System.String, a1 : System.String, a2 : System.String) = (3004, sprintf "The provided type '%s' has member '%s' which has declaring type '%s'. Expected declaring type to be the same as provided type." a0 a1 a2)
    /// Referenced assembly '%s' has assembly level attribute '%s' but no public type provider classes were found
    /// (Originally from /src/fsharp/FSComp.txt:1152)
    static member etHostingAssemblyFoundWithoutHosts(a0 : System.String, a1 : System.String) = (3005, sprintf "Referenced assembly '%s' has assembly level attribute '%s' but no public type provider classes were found" a0 a1)
    /// Type '%s' from type provider '%s' has an empty namespace. Use 'null' for the global namespace.
    /// (Originally from /src/fsharp/FSComp.txt:1153)
    static member etEmptyNamespaceOfTypeNotAllowed(a0 : System.String, a1 : System.String) = (3006, sprintf "Type '%s' from type provider '%s' has an empty namespace. Use 'null' for the global namespace." a0 a1)
    /// Empty namespace found from the type provider '%s'. Use 'null' for the global namespace.
    /// (Originally from /src/fsharp/FSComp.txt:1154)
    static member etEmptyNamespaceNotAllowed(a0 : System.String) = (3007, sprintf "Empty namespace found from the type provider '%s'. Use 'null' for the global namespace." a0)
    /// Provided type '%s' has 'IsGenericType' as true, but generic types are not supported.
    /// (Originally from /src/fsharp/FSComp.txt:1155)
    static member etMustNotBeGeneric(a0 : System.String) = (3011, sprintf "Provided type '%s' has 'IsGenericType' as true, but generic types are not supported." a0)
    /// Provided type '%s' has 'IsArray' as true, but array types are not supported.
    /// (Originally from /src/fsharp/FSComp.txt:1156)
    static member etMustNotBeAnArray(a0 : System.String) = (3013, sprintf "Provided type '%s' has 'IsArray' as true, but array types are not supported." a0)
    /// Invalid member '%s' on provided type '%s'. Provided type members must be public, and not be generic, virtual, or abstract.
    /// (Originally from /src/fsharp/FSComp.txt:1157)
    static member etMethodHasRequirements(a0 : System.String, a1 : System.String) = (3014, sprintf "Invalid member '%s' on provided type '%s'. Provided type members must be public, and not be generic, virtual, or abstract." a0 a1)
    /// Invalid member '%s' on provided type '%s'. Only properties, methods and constructors are allowed
    /// (Originally from /src/fsharp/FSComp.txt:1158)
    static member etUnsupportedMemberKind(a0 : System.String, a1 : System.String) = (3015, sprintf "Invalid member '%s' on provided type '%s'. Only properties, methods and constructors are allowed" a0 a1)
    /// Property '%s' on provided type '%s' has CanRead=true but there was no value from GetGetMethod()
    /// (Originally from /src/fsharp/FSComp.txt:1159)
    static member etPropertyCanReadButHasNoGetter(a0 : System.String, a1 : System.String) = (3016, sprintf "Property '%s' on provided type '%s' has CanRead=true but there was no value from GetGetMethod()" a0 a1)
    /// Property '%s' on provided type '%s' has CanRead=false but GetGetMethod() returned a method
    /// (Originally from /src/fsharp/FSComp.txt:1160)
    static member etPropertyHasGetterButNoCanRead(a0 : System.String, a1 : System.String) = (3017, sprintf "Property '%s' on provided type '%s' has CanRead=false but GetGetMethod() returned a method" a0 a1)
    /// Property '%s' on provided type '%s' has CanWrite=true but there was no value from GetSetMethod()
    /// (Originally from /src/fsharp/FSComp.txt:1161)
    static member etPropertyCanWriteButHasNoSetter(a0 : System.String, a1 : System.String) = (3018, sprintf "Property '%s' on provided type '%s' has CanWrite=true but there was no value from GetSetMethod()" a0 a1)
    /// Property '%s' on provided type '%s' has CanWrite=false but GetSetMethod() returned a method
    /// (Originally from /src/fsharp/FSComp.txt:1162)
    static member etPropertyHasSetterButNoCanWrite(a0 : System.String, a1 : System.String) = (3019, sprintf "Property '%s' on provided type '%s' has CanWrite=false but GetSetMethod() returned a method" a0 a1)
    /// One or more errors seen during provided type setup
    /// (Originally from /src/fsharp/FSComp.txt:1163)
    static member etOneOrMoreErrorsSeenDuringExtensionTypeSetting() = (3020, sprintf "One or more errors seen during provided type setup" )
    /// Unexpected exception from provided type '%s' member '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:1164)
    static member etUnexpectedExceptionFromProvidedTypeMember(a0 : System.String, a1 : System.String, a2 : System.String) = (3021, sprintf "Unexpected exception from provided type '%s' member '%s': %s" a0 a1 a2)
    /// Unsupported constant type '%s'. Quotations provided by type providers can only contain simple constants. The implementation of the type provider may need to be adjusted by moving a value declared outside a provided quotation literal to be a 'let' binding inside the quotation literal.
    /// (Originally from /src/fsharp/FSComp.txt:1165)
    static member etUnsupportedConstantType(a0 : System.String) = (3022, sprintf "Unsupported constant type '%s'. Quotations provided by type providers can only contain simple constants. The implementation of the type provider may need to be adjusted by moving a value declared outside a provided quotation literal to be a 'let' binding inside the quotation literal." a0)
    /// Unsupported expression '%s' from type provider. If you are the author of this type provider, consider adjusting it to provide a different provided expression.
    /// (Originally from /src/fsharp/FSComp.txt:1166)
    static member etUnsupportedProvidedExpression(a0 : System.String) = (3025, sprintf "Unsupported expression '%s' from type provider. If you are the author of this type provider, consider adjusting it to provide a different provided expression." a0)
    /// Expected provided type named '%s' but provided type has 'Name' with value '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1167)
    static member etProvidedTypeHasUnexpectedName(a0 : System.String, a1 : System.String) = (3028, sprintf "Expected provided type named '%s' but provided type has 'Name' with value '%s'" a0 a1)
    /// Event '%s' on provided type '%s' has no value from GetAddMethod()
    /// (Originally from /src/fsharp/FSComp.txt:1168)
    static member etEventNoAdd(a0 : System.String, a1 : System.String) = (3029, sprintf "Event '%s' on provided type '%s' has no value from GetAddMethod()" a0 a1)
    /// Event '%s' on provided type '%s' has no value from GetRemoveMethod()
    /// (Originally from /src/fsharp/FSComp.txt:1169)
    static member etEventNoRemove(a0 : System.String, a1 : System.String) = (3030, sprintf "Event '%s' on provided type '%s' has no value from GetRemoveMethod()" a0 a1)
    /// Assembly attribute '%s' refers to a designer assembly '%s' which cannot be loaded or doesn't exist. %s
    /// (Originally from /src/fsharp/FSComp.txt:1170)
    static member etProviderHasWrongDesignerAssembly(a0 : System.String, a1 : System.String, a2 : System.String) = (3031, sprintf "Assembly attribute '%s' refers to a designer assembly '%s' which cannot be loaded or doesn't exist. %s" a0 a1 a2)
    /// The type provider does not have a valid constructor. A constructor taking either no arguments or one argument of type 'TypeProviderConfig' was expected.
    /// (Originally from /src/fsharp/FSComp.txt:1171)
    static member etProviderDoesNotHaveValidConstructor() = (3032, sprintf "The type provider does not have a valid constructor. A constructor taking either no arguments or one argument of type 'TypeProviderConfig' was expected." )
    /// The type provider '%s' reported an error: %s
    /// (Originally from /src/fsharp/FSComp.txt:1172)
    static member etProviderError(a0 : System.String, a1 : System.String) = (3033, sprintf "The type provider '%s' reported an error: %s" a0 a1)
    /// The type provider '%s' used an invalid parameter in the ParameterExpression: %s
    /// (Originally from /src/fsharp/FSComp.txt:1173)
    static member etIncorrectParameterExpression(a0 : System.String, a1 : System.String) = (3034, sprintf "The type provider '%s' used an invalid parameter in the ParameterExpression: %s" a0 a1)
    /// The type provider '%s' provided a method with a name '%s' and metadata token '%d', which is not reported among its methods of its declaring type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1174)
    static member etIncorrectProvidedMethod(a0 : System.String, a1 : System.String, a2 : System.Int32, a3 : System.String) = (3035, sprintf "The type provider '%s' provided a method with a name '%s' and metadata token '%d', which is not reported among its methods of its declaring type '%s'" a0 a1 a2 a3)
    /// The type provider '%s' provided a constructor which is not reported among the constructors of its declaring type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1175)
    static member etIncorrectProvidedConstructor(a0 : System.String, a1 : System.String) = (3036, sprintf "The type provider '%s' provided a constructor which is not reported among the constructors of its declaring type '%s'" a0 a1)
    /// A direct reference to the generated type '%s' is not permitted. Instead, use a type definition, e.g. 'type TypeAlias = <path>'. This indicates that a type provider adds generated types to your assembly.
    /// (Originally from /src/fsharp/FSComp.txt:1176)
    static member etDirectReferenceToGeneratedTypeNotAllowed(a0 : System.String) = (3039, sprintf "A direct reference to the generated type '%s' is not permitted. Instead, use a type definition, e.g. 'type TypeAlias = <path>'. This indicates that a type provider adds generated types to your assembly." a0)
    /// Expected provided type with path '%s' but provided type has path '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1177)
    static member etProvidedTypeHasUnexpectedPath(a0 : System.String, a1 : System.String) = (3041, sprintf "Expected provided type with path '%s' but provided type has path '%s'" a0 a1)
    /// Unexpected 'null' return value from provided type '%s' member '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1178)
    static member etUnexpectedNullFromProvidedTypeMember(a0 : System.String, a1 : System.String) = (3042, sprintf "Unexpected 'null' return value from provided type '%s' member '%s'" a0 a1)
    /// Unexpected exception from member '%s' of provided type '%s' member '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:1179)
    static member etUnexpectedExceptionFromProvidedMemberMember(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (3043, sprintf "Unexpected exception from member '%s' of provided type '%s' member '%s': %s" a0 a1 a2 a3)
    /// Nested provided types do not take static arguments or generic parameters
    /// (Originally from /src/fsharp/FSComp.txt:1180)
    static member etNestedProvidedTypesDoNotTakeStaticArgumentsOrGenericParameters() = (3044, sprintf "Nested provided types do not take static arguments or generic parameters" )
    /// Invalid static argument to provided type. Expected an argument of kind '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1181)
    static member etInvalidStaticArgument(a0 : System.String) = (3045, sprintf "Invalid static argument to provided type. Expected an argument of kind '%s'." a0)
    /// An error occured applying the static arguments to a provided type
    /// (Originally from /src/fsharp/FSComp.txt:1182)
    static member etErrorApplyingStaticArgumentsToType() = (3046, sprintf "An error occured applying the static arguments to a provided type" )
    /// Unknown static argument kind '%s' when resolving a reference to a provided type or method '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1183)
    static member etUnknownStaticArgumentKind(a0 : System.String, a1 : System.String) = (3047, sprintf "Unknown static argument kind '%s' when resolving a reference to a provided type or method '%s'" a0 a1)
    /// invalid namespace for provided type
    /// (Originally from /src/fsharp/FSComp.txt:1184)
    static member invalidNamespaceForProvidedType() = (sprintf "invalid namespace for provided type" )
    /// invalid full name for provided type
    /// (Originally from /src/fsharp/FSComp.txt:1185)
    static member invalidFullNameForProvidedType() = (sprintf "invalid full name for provided type" )
    /// The type provider returned 'null', which is not a valid return value from '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1187)
    static member etProviderReturnedNull(a0 : System.String) = (3051, sprintf "The type provider returned 'null', which is not a valid return value from '%s'" a0)
    /// The type provider constructor has thrown an exception: %s
    /// (Originally from /src/fsharp/FSComp.txt:1188)
    static member etTypeProviderConstructorException(a0 : System.String) = (3053, sprintf "The type provider constructor has thrown an exception: %s" a0)
    /// Type provider '%s' returned null from GetInvokerExpression.
    /// (Originally from /src/fsharp/FSComp.txt:1189)
    static member etNullProvidedExpression(a0 : System.String) = (3056, sprintf "Type provider '%s' returned null from GetInvokerExpression." a0)
    /// The type provider '%s' returned an invalid type from 'ApplyStaticArguments'. A type with name '%s' was expected, but a type with name '%s' was returned.
    /// (Originally from /src/fsharp/FSComp.txt:1190)
    static member etProvidedAppliedTypeHadWrongName(a0 : System.String, a1 : System.String, a2 : System.String) = (3057, sprintf "The type provider '%s' returned an invalid type from 'ApplyStaticArguments'. A type with name '%s' was expected, but a type with name '%s' was returned." a0 a1 a2)
    /// The type provider '%s' returned an invalid method from 'ApplyStaticArgumentsForMethod'. A method with name '%s' was expected, but a method with name '%s' was returned.
    /// (Originally from /src/fsharp/FSComp.txt:1191)
    static member etProvidedAppliedMethodHadWrongName(a0 : System.String, a1 : System.String, a2 : System.String) = (3058, sprintf "The type provider '%s' returned an invalid method from 'ApplyStaticArgumentsForMethod'. A method with name '%s' was expected, but a method with name '%s' was returned." a0 a1 a2)
    /// This type test or downcast will erase the provided type '%s' to the type '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1192)
    static member tcTypeTestLossy(a0 : System.String, a1 : System.String) = (3060, sprintf "This type test or downcast will erase the provided type '%s' to the type '%s'" a0 a1)
    /// This downcast will erase the provided type '%s' to the type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1193)
    static member tcTypeCastErased(a0 : System.String, a1 : System.String) = (3061, sprintf "This downcast will erase the provided type '%s' to the type '%s'." a0 a1)
    /// This type test with a provided type '%s' is not allowed because this provided type will be erased to '%s' at runtime.
    /// (Originally from /src/fsharp/FSComp.txt:1194)
    static member tcTypeTestErased(a0 : System.String, a1 : System.String) = (3062, sprintf "This type test with a provided type '%s' is not allowed because this provided type will be erased to '%s' at runtime." a0 a1)
    /// Cannot inherit from erased provided type
    /// (Originally from /src/fsharp/FSComp.txt:1195)
    static member tcCannotInheritFromErasedType() = (3063, sprintf "Cannot inherit from erased provided type" )
    /// Assembly '%s' hase TypeProviderAssembly attribute with invalid value '%s'. The value should be a valid assembly name
    /// (Originally from /src/fsharp/FSComp.txt:1196)
    static member etInvalidTypeProviderAssemblyName(a0 : System.String, a1 : System.String) = (3065, sprintf "Assembly '%s' hase TypeProviderAssembly attribute with invalid value '%s'. The value should be a valid assembly name" a0 a1)
    /// Invalid member name. Members may not have name '.ctor' or '.cctor'
    /// (Originally from /src/fsharp/FSComp.txt:1197)
    static member tcInvalidMemberNameCtor() = (3066, sprintf "Invalid member name. Members may not have name '.ctor' or '.cctor'" )
    /// The function or member '%s' is used in a way that requires further type annotations at its definition to ensure consistency of inferred types. The inferred signature is '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1198)
    static member tcInferredGenericTypeGivesRiseToInconsistency(a0 : System.String, a1 : System.String) = (3068, sprintf "The function or member '%s' is used in a way that requires further type annotations at its definition to ensure consistency of inferred types. The inferred signature is '%s'." a0 a1)
    /// The number of type arguments did not match: '%d' given, '%d' expected. This may be related to a previously reported error.
    /// (Originally from /src/fsharp/FSComp.txt:1199)
    static member tcInvalidTypeArgumentCount(a0 : System.Int32, a1 : System.Int32) = (3069, sprintf "The number of type arguments did not match: '%d' given, '%d' expected. This may be related to a previously reported error." a0 a1)
    /// Cannot override inherited member '%s' because it is sealed
    /// (Originally from /src/fsharp/FSComp.txt:1200)
    static member tcCannotOverrideSealedMethod(a0 : System.String) = (3070, sprintf "Cannot override inherited member '%s' because it is sealed" a0)
    /// The type provider '%s' reported an error in the context of provided type '%s', member '%s'. The error: %s
    /// (Originally from /src/fsharp/FSComp.txt:1201)
    static member etProviderErrorWithContext(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (3071, sprintf "The type provider '%s' reported an error in the context of provided type '%s', member '%s'. The error: %s" a0 a1 a2 a3)
    /// An exception occurred when accessing the '%s' of a provided type: %s
    /// (Originally from /src/fsharp/FSComp.txt:1202)
    static member etProvidedTypeWithNameException(a0 : System.String, a1 : System.String) = (3072, sprintf "An exception occurred when accessing the '%s' of a provided type: %s" a0 a1)
    /// The '%s' of a provided type was null or empty.
    /// (Originally from /src/fsharp/FSComp.txt:1203)
    static member etProvidedTypeWithNullOrEmptyName(a0 : System.String) = (3073, sprintf "The '%s' of a provided type was null or empty." a0)
    /// Character '%s' is not allowed in provided type name '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1204)
    static member etIllegalCharactersInTypeName(a0 : System.String, a1 : System.String) = (3075, sprintf "Character '%s' is not allowed in provided type name '%s'" a0 a1)
    /// In queries, '%s' must use a simple pattern
    /// (Originally from /src/fsharp/FSComp.txt:1205)
    static member tcJoinMustUseSimplePattern(a0 : System.String) = (3077, sprintf "In queries, '%s' must use a simple pattern" a0)
    /// A custom query operation for '%s' is required but not specified
    /// (Originally from /src/fsharp/FSComp.txt:1206)
    static member tcMissingCustomOperation(a0 : System.String) = (3078, sprintf "A custom query operation for '%s' is required but not specified" a0)
    /// Named static arguments must come after all unnamed static arguments
    /// (Originally from /src/fsharp/FSComp.txt:1207)
    static member etBadUnnamedStaticArgs() = (3080, sprintf "Named static arguments must come after all unnamed static arguments" )
    /// The static parameter '%s' of the provided type or method '%s' requires a value. Static parameters to type providers may be optionally specified using named arguments, e.g. '%s<%s=...>'.
    /// (Originally from /src/fsharp/FSComp.txt:1208)
    static member etStaticParameterRequiresAValue(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (3081, sprintf "The static parameter '%s' of the provided type or method '%s' requires a value. Static parameters to type providers may be optionally specified using named arguments, e.g. '%s<%s=...>'." a0 a1 a2 a3)
    /// No static parameter exists with name '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1209)
    static member etNoStaticParameterWithName(a0 : System.String) = (3082, sprintf "No static parameter exists with name '%s'" a0)
    /// The static parameter '%s' has already been given a value
    /// (Originally from /src/fsharp/FSComp.txt:1210)
    static member etStaticParameterAlreadyHasValue(a0 : System.String) = (3083, sprintf "The static parameter '%s' has already been given a value" a0)
    /// Multiple static parameters exist with name '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1211)
    static member etMultipleStaticParameterWithName(a0 : System.String) = (3084, sprintf "Multiple static parameters exist with name '%s'" a0)
    /// A custom operation may not be used in conjunction with a non-value or recursive 'let' binding in another part of this computation expression
    /// (Originally from /src/fsharp/FSComp.txt:1212)
    static member tcCustomOperationMayNotBeUsedInConjunctionWithNonSimpleLetBindings() = (3085, sprintf "A custom operation may not be used in conjunction with a non-value or recursive 'let' binding in another part of this computation expression" )
    /// A custom operation may not be used in conjunction with 'use', 'try/with', 'try/finally', 'if/then/else' or 'match' operators within this computation expression
    /// (Originally from /src/fsharp/FSComp.txt:1213)
    static member tcCustomOperationMayNotBeUsedHere() = (3086, sprintf "A custom operation may not be used in conjunction with 'use', 'try/with', 'try/finally', 'if/then/else' or 'match' operators within this computation expression" )
    /// The custom operation '%s' refers to a method which is overloaded. The implementations of custom operations may not be overloaded.
    /// (Originally from /src/fsharp/FSComp.txt:1214)
    static member tcCustomOperationMayNotBeOverloaded(a0 : System.String) = (3087, sprintf "The custom operation '%s' refers to a method which is overloaded. The implementations of custom operations may not be overloaded." a0)
    /// An if/then/else expression may not be used within queries. Consider using either an if/then expression, or use a sequence expression instead.
    /// (Originally from /src/fsharp/FSComp.txt:1215)
    static member tcIfThenElseMayNotBeUsedWithinQueries() = (3090, sprintf "An if/then/else expression may not be used within queries. Consider using either an if/then expression, or use a sequence expression instead." )
    /// Invalid argument to 'methodhandleof' during codegen
    /// (Originally from /src/fsharp/FSComp.txt:1216)
    static member ilxgenUnexpectedArgumentToMethodHandleOfDuringCodegen() = (3091, sprintf "Invalid argument to 'methodhandleof' during codegen" )
    /// A reference to a provided type was missing a value for the static parameter '%s'. You may need to recompile one or more referenced assemblies.
    /// (Originally from /src/fsharp/FSComp.txt:1217)
    static member etProvidedTypeReferenceMissingArgument(a0 : System.String) = (3092, sprintf "A reference to a provided type was missing a value for the static parameter '%s'. You may need to recompile one or more referenced assemblies." a0)
    /// A reference to a provided type had an invalid value '%s' for a static parameter. You may need to recompile one or more referenced assemblies.
    /// (Originally from /src/fsharp/FSComp.txt:1218)
    static member etProvidedTypeReferenceInvalidText(a0 : System.String) = (3093, sprintf "A reference to a provided type had an invalid value '%s' for a static parameter. You may need to recompile one or more referenced assemblies." a0)
    /// '%s' is not used correctly. This is a custom operation in this query or computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1219)
    static member tcCustomOperationNotUsedCorrectly(a0 : System.String) = (3095, sprintf "'%s' is not used correctly. This is a custom operation in this query or computation expression." a0)
    /// '%s' is not used correctly. Usage: %s. This is a custom operation in this query or computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1220)
    static member tcCustomOperationNotUsedCorrectly2(a0 : System.String, a1 : System.String) = (3095, sprintf "'%s' is not used correctly. Usage: %s. This is a custom operation in this query or computation expression." a0 a1)
    /// %s var in collection %s (outerKey = innerKey). Note that parentheses are required after '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1221)
    static member customOperationTextLikeJoin(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "%s var in collection %s (outerKey = innerKey). Note that parentheses are required after '%s'" a0 a1 a2)
    /// %s var in collection %s (outerKey = innerKey) into group. Note that parentheses are required after '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1222)
    static member customOperationTextLikeGroupJoin(a0 : System.String, a1 : System.String, a2 : System.String) = (sprintf "%s var in collection %s (outerKey = innerKey) into group. Note that parentheses are required after '%s'" a0 a1 a2)
    /// %s var in collection
    /// (Originally from /src/fsharp/FSComp.txt:1223)
    static member customOperationTextLikeZip(a0 : System.String) = (sprintf "%s var in collection" a0)
    /// '%s' must be followed by a variable name. Usage: %s.
    /// (Originally from /src/fsharp/FSComp.txt:1224)
    static member tcBinaryOperatorRequiresVariable(a0 : System.String, a1 : System.String) = (3096, sprintf "'%s' must be followed by a variable name. Usage: %s." a0 a1)
    /// Incorrect syntax for '%s'. Usage: %s.
    /// (Originally from /src/fsharp/FSComp.txt:1225)
    static member tcOperatorIncorrectSyntax(a0 : System.String, a1 : System.String) = (3097, sprintf "Incorrect syntax for '%s'. Usage: %s." a0 a1)
    /// '%s' must come after a 'for' selection clause and be followed by the rest of the query. Syntax: ... %s ...
    /// (Originally from /src/fsharp/FSComp.txt:1226)
    static member tcBinaryOperatorRequiresBody(a0 : System.String, a1 : System.String) = (3098, sprintf "'%s' must come after a 'for' selection clause and be followed by the rest of the query. Syntax: ... %s ..." a0 a1)
    /// '%s' is used with an incorrect number of arguments. This is a custom operation in this query or computation expression. Expected %d argument(s), but given %d.
    /// (Originally from /src/fsharp/FSComp.txt:1227)
    static member tcCustomOperationHasIncorrectArgCount(a0 : System.String, a1 : System.Int32, a2 : System.Int32) = (3099, sprintf "'%s' is used with an incorrect number of arguments. This is a custom operation in this query or computation expression. Expected %d argument(s), but given %d." a0 a1 a2)
    /// Expected an expression after this point
    /// (Originally from /src/fsharp/FSComp.txt:1228)
    static member parsExpectedExpressionAfterToken() = (3100, sprintf "Expected an expression after this point" )
    /// Expected a type after this point
    /// (Originally from /src/fsharp/FSComp.txt:1229)
    static member parsExpectedTypeAfterToken() = (3101, sprintf "Expected a type after this point" )
    /// Unmatched '[<'. Expected closing '>]'
    /// (Originally from /src/fsharp/FSComp.txt:1230)
    static member parsUnmatchedLBrackLess() = (3102, sprintf "Unmatched '[<'. Expected closing '>]'" )
    /// Unexpected end of input in 'match' expression. Expected 'match <expr> with | <pat> -> <expr> | <pat> -> <expr> ...'.
    /// (Originally from /src/fsharp/FSComp.txt:1231)
    static member parsUnexpectedEndOfFileMatch() = (3103, sprintf "Unexpected end of input in 'match' expression. Expected 'match <expr> with | <pat> -> <expr> | <pat> -> <expr> ...'." )
    /// Unexpected end of input in 'try' expression. Expected 'try <expr> with <rules>' or 'try <expr> finally <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1232)
    static member parsUnexpectedEndOfFileTry() = (3104, sprintf "Unexpected end of input in 'try' expression. Expected 'try <expr> with <rules>' or 'try <expr> finally <expr>'." )
    /// Unexpected end of input in 'while' expression. Expected 'while <expr> do <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1233)
    static member parsUnexpectedEndOfFileWhile() = (3105, sprintf "Unexpected end of input in 'while' expression. Expected 'while <expr> do <expr>'." )
    /// Unexpected end of input in 'for' expression. Expected 'for <pat> in <expr> do <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1234)
    static member parsUnexpectedEndOfFileFor() = (3106, sprintf "Unexpected end of input in 'for' expression. Expected 'for <pat> in <expr> do <expr>'." )
    /// Unexpected end of input in 'match' or 'try' expression
    /// (Originally from /src/fsharp/FSComp.txt:1235)
    static member parsUnexpectedEndOfFileWith() = (3107, sprintf "Unexpected end of input in 'match' or 'try' expression" )
    /// Unexpected end of input in 'then' branch of conditional expression. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1236)
    static member parsUnexpectedEndOfFileThen() = (3108, sprintf "Unexpected end of input in 'then' branch of conditional expression. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'." )
    /// Unexpected end of input in 'else' branch of conditional expression. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1237)
    static member parsUnexpectedEndOfFileElse() = (3109, sprintf "Unexpected end of input in 'else' branch of conditional expression. Expected 'if <expr> then <expr>' or 'if <expr> then <expr> else <expr>'." )
    /// Unexpected end of input in body of lambda expression. Expected 'fun <pat> ... <pat> -> <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1238)
    static member parsUnexpectedEndOfFileFunBody() = (3110, sprintf "Unexpected end of input in body of lambda expression. Expected 'fun <pat> ... <pat> -> <expr>'." )
    /// Unexpected end of input in type arguments
    /// (Originally from /src/fsharp/FSComp.txt:1239)
    static member parsUnexpectedEndOfFileTypeArgs() = (3111, sprintf "Unexpected end of input in type arguments" )
    /// Unexpected end of input in type signature
    /// (Originally from /src/fsharp/FSComp.txt:1240)
    static member parsUnexpectedEndOfFileTypeSignature() = (3112, sprintf "Unexpected end of input in type signature" )
    /// Unexpected end of input in type definition
    /// (Originally from /src/fsharp/FSComp.txt:1241)
    static member parsUnexpectedEndOfFileTypeDefinition() = (3113, sprintf "Unexpected end of input in type definition" )
    /// Unexpected end of input in object members
    /// (Originally from /src/fsharp/FSComp.txt:1242)
    static member parsUnexpectedEndOfFileObjectMembers() = (3114, sprintf "Unexpected end of input in object members" )
    /// Unexpected end of input in value, function or member definition
    /// (Originally from /src/fsharp/FSComp.txt:1243)
    static member parsUnexpectedEndOfFileDefinition() = (3115, sprintf "Unexpected end of input in value, function or member definition" )
    /// Unexpected end of input in expression
    /// (Originally from /src/fsharp/FSComp.txt:1244)
    static member parsUnexpectedEndOfFileExpression() = (3116, sprintf "Unexpected end of input in expression" )
    /// Unexpected end of type. Expected a name after this point.
    /// (Originally from /src/fsharp/FSComp.txt:1245)
    static member parsExpectedNameAfterToken() = (3117, sprintf "Unexpected end of type. Expected a name after this point." )
    /// Incomplete value or function definition. If this is in an expression, the body of the expression must be indented to the same column as the 'let' keyword.
    /// (Originally from /src/fsharp/FSComp.txt:1246)
    static member parsUnmatchedLet() = (3118, sprintf "Incomplete value or function definition. If this is in an expression, the body of the expression must be indented to the same column as the 'let' keyword." )
    /// Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'let!' keyword.
    /// (Originally from /src/fsharp/FSComp.txt:1247)
    static member parsUnmatchedLetBang() = (3119, sprintf "Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'let!' keyword." )
    /// Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'use!' keyword.
    /// (Originally from /src/fsharp/FSComp.txt:1248)
    static member parsUnmatchedUseBang() = (3120, sprintf "Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'use!' keyword." )
    /// Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'use' keyword.
    /// (Originally from /src/fsharp/FSComp.txt:1249)
    static member parsUnmatchedUse() = (3121, sprintf "Incomplete value definition. If this is in an expression, the body of the expression must be indented to the same column as the 'use' keyword." )
    /// Missing 'do' in 'while' expression. Expected 'while <expr> do <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1250)
    static member parsWhileDoExpected() = (3122, sprintf "Missing 'do' in 'while' expression. Expected 'while <expr> do <expr>'." )
    /// Missing 'do' in 'for' expression. Expected 'for <pat> in <expr> do <expr>'.
    /// (Originally from /src/fsharp/FSComp.txt:1251)
    static member parsForDoExpected() = (3123, sprintf "Missing 'do' in 'for' expression. Expected 'for <pat> in <expr> do <expr>'." )
    /// Invalid join relation in '%s'. Expected 'expr <op> expr', where <op> is =, =?, ?= or ?=?.
    /// (Originally from /src/fsharp/FSComp.txt:1252)
    static member tcInvalidRelationInJoin(a0 : System.String) = (3125, sprintf "Invalid join relation in '%s'. Expected 'expr <op> expr', where <op> is =, =?, ?= or ?=?." a0)
    /// Calls
    /// (Originally from /src/fsharp/FSComp.txt:1253)
    static member typeInfoCallsWord() = (sprintf "Calls" )
    /// Invalid number of generic arguments to type '%s' in provided type. Expected '%d' arguments, given '%d'.
    /// (Originally from /src/fsharp/FSComp.txt:1254)
    static member impInvalidNumberOfGenericArguments(a0 : System.String, a1 : System.Int32, a2 : System.Int32) = (3126, sprintf "Invalid number of generic arguments to type '%s' in provided type. Expected '%d' arguments, given '%d'." a0 a1 a2)
    /// Invalid value '%s' for unit-of-measure parameter '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1255)
    static member impInvalidMeasureArgument1(a0 : System.String, a1 : System.String) = (3127, sprintf "Invalid value '%s' for unit-of-measure parameter '%s'" a0 a1)
    /// Invalid value unit-of-measure parameter '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1256)
    static member impInvalidMeasureArgument2(a0 : System.String) = (3127, sprintf "Invalid value unit-of-measure parameter '%s'" a0)
    /// Property '%s' on provided type '%s' is neither readable nor writable as it has CanRead=false and CanWrite=false
    /// (Originally from /src/fsharp/FSComp.txt:1257)
    static member etPropertyNeedsCanWriteOrCanRead(a0 : System.String, a1 : System.String) = (3128, sprintf "Property '%s' on provided type '%s' is neither readable nor writable as it has CanRead=false and CanWrite=false" a0 a1)
    /// A use of 'into' must be followed by the remainder of the computation
    /// (Originally from /src/fsharp/FSComp.txt:1258)
    static member tcIntoNeedsRestOfQuery() = (3129, sprintf "A use of 'into' must be followed by the remainder of the computation" )
    /// The operator '%s' does not accept the use of 'into'
    /// (Originally from /src/fsharp/FSComp.txt:1259)
    static member tcOperatorDoesntAcceptInto(a0 : System.String) = (3130, sprintf "The operator '%s' does not accept the use of 'into'" a0)
    /// The definition of the custom operator '%s' does not use a valid combination of attribute flags
    /// (Originally from /src/fsharp/FSComp.txt:1260)
    static member tcCustomOperationInvalid(a0 : System.String) = (3131, sprintf "The definition of the custom operator '%s' does not use a valid combination of attribute flags" a0)
    /// This type definition may not have the 'CLIMutable' attribute. Only record types may have this attribute.
    /// (Originally from /src/fsharp/FSComp.txt:1261)
    static member tcThisTypeMayNotHaveACLIMutableAttribute() = (3132, sprintf "This type definition may not have the 'CLIMutable' attribute. Only record types may have this attribute." )
    /// 'member val' definitions are only permitted in types with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:1262)
    static member tcAutoPropertyRequiresImplicitConstructionSequence() = (3133, sprintf "'member val' definitions are only permitted in types with a primary constructor. Consider adding arguments to your type definition, e.g. 'type X(args) = ...'." )
    /// Property definitions may not be declared mutable. To indicate that this property can be set, use 'member val PropertyName = expr with get,set'.
    /// (Originally from /src/fsharp/FSComp.txt:1263)
    static member parsMutableOnAutoPropertyShouldBeGetSet() = (3134, sprintf "Property definitions may not be declared mutable. To indicate that this property can be set, use 'member val PropertyName = expr with get,set'." )
    /// To indicate that this property can be set, use 'member val PropertyName = expr with get,set'.
    /// (Originally from /src/fsharp/FSComp.txt:1264)
    static member parsMutableOnAutoPropertyShouldBeGetSetNotJustSet() = (3135, sprintf "To indicate that this property can be set, use 'member val PropertyName = expr with get,set'." )
    /// Type '%s' is illegal because in byref<T>, T cannot contain byref types.
    /// (Originally from /src/fsharp/FSComp.txt:1265)
    static member chkNoByrefsOfByrefs(a0 : System.String) = (3136, sprintf "Type '%s' is illegal because in byref<T>, T cannot contain byref types." a0)
    /// F# supports array ranks between 1 and 32. The value %d is not allowed.
    /// (Originally from /src/fsharp/FSComp.txt:1266)
    static member tastopsMaxArrayThirtyTwo(a0 : System.Int32) = (3138, sprintf "F# supports array ranks between 1 and 32. The value %d is not allowed." a0)
    /// In queries, use the form 'for x in n .. m do ...' for ranging over integers
    /// (Originally from /src/fsharp/FSComp.txt:1267)
    static member tcNoIntegerForLoopInQuery() = (3139, sprintf "In queries, use the form 'for x in n .. m do ...' for ranging over integers" )
    /// 'while' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1268)
    static member tcNoWhileInQuery() = (3140, sprintf "'while' expressions may not be used in queries" )
    /// 'try/finally' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1269)
    static member tcNoTryFinallyInQuery() = (3141, sprintf "'try/finally' expressions may not be used in queries" )
    /// 'use' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1270)
    static member tcUseMayNotBeUsedInQueries() = (3142, sprintf "'use' expressions may not be used in queries" )
    /// 'let!', 'use!' and 'do!' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1271)
    static member tcBindMayNotBeUsedInQueries() = (3143, sprintf "'let!', 'use!' and 'do!' expressions may not be used in queries" )
    /// 'return' and 'return!' may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1272)
    static member tcReturnMayNotBeUsedInQueries() = (3144, sprintf "'return' and 'return!' may not be used in queries" )
    /// This is not a known query operator. Query operators are identifiers such as 'select', 'where', 'sortBy', 'thenBy', 'groupBy', 'groupValBy', 'join', 'groupJoin', 'sumBy' and 'averageBy', defined using corresponding methods on the 'QueryBuilder' type.
    /// (Originally from /src/fsharp/FSComp.txt:1273)
    static member tcUnrecognizedQueryOperator() = (3145, sprintf "This is not a known query operator. Query operators are identifiers such as 'select', 'where', 'sortBy', 'thenBy', 'groupBy', 'groupValBy', 'join', 'groupJoin', 'sumBy' and 'averageBy', defined using corresponding methods on the 'QueryBuilder' type." )
    /// 'try/with' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1274)
    static member tcTryWithMayNotBeUsedInQueries() = (3146, sprintf "'try/with' expressions may not be used in queries" )
    /// This 'let' definition may not be used in a query. Only simple value definitions may be used in queries.
    /// (Originally from /src/fsharp/FSComp.txt:1275)
    static member tcNonSimpleLetBindingInQuery() = (3147, sprintf "This 'let' definition may not be used in a query. Only simple value definitions may be used in queries." )
    /// Too many static parameters. Expected at most %d parameters, but got %d unnamed and %d named parameters.
    /// (Originally from /src/fsharp/FSComp.txt:1276)
    static member etTooManyStaticParameters(a0 : System.Int32, a1 : System.Int32, a2 : System.Int32) = (3148, sprintf "Too many static parameters. Expected at most %d parameters, but got %d unnamed and %d named parameters." a0 a1 a2)
    /// Invalid provided literal value '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1277)
    static member infosInvalidProvidedLiteralValue(a0 : System.String) = (3149, sprintf "Invalid provided literal value '%s'" a0)
    /// The 'anycpu32bitpreferred' platform can only be used with EXE targets. You must use 'anycpu' instead.
    /// (Originally from /src/fsharp/FSComp.txt:1278)
    static member invalidPlatformTarget() = (3150, sprintf "The 'anycpu32bitpreferred' platform can only be used with EXE targets. You must use 'anycpu' instead." )
    /// This member, function or value declaration may not be declared 'inline'
    /// (Originally from /src/fsharp/FSComp.txt:1279)
    static member tcThisValueMayNotBeInlined() = (3151, sprintf "This member, function or value declaration may not be declared 'inline'" )
    /// The provider '%s' returned a non-generated type '%s' in the context of a set of generated types. Consider adjusting the type provider to only return generated types.
    /// (Originally from /src/fsharp/FSComp.txt:1280)
    static member etErasedTypeUsedInGeneration(a0 : System.String, a1 : System.String) = (3152, sprintf "The provider '%s' returned a non-generated type '%s' in the context of a set of generated types. Consider adjusting the type provider to only return generated types." a0 a1)
    /// Arguments to query operators may require parentheses, e.g. 'where (x > y)' or 'groupBy (x.Length / 10)'
    /// (Originally from /src/fsharp/FSComp.txt:1281)
    static member tcUnrecognizedQueryBinaryOperator() = (3153, sprintf "Arguments to query operators may require parentheses, e.g. 'where (x > y)' or 'groupBy (x.Length / 10)'" )
    /// A quotation may not involve an assignment to or taking the address of a captured local variable
    /// (Originally from /src/fsharp/FSComp.txt:1282)
    static member crefNoSetOfHole() = (3155, sprintf "A quotation may not involve an assignment to or taking the address of a captured local variable" )
    /// + 1 overload
    /// (Originally from /src/fsharp/FSComp.txt:1283)
    static member nicePrintOtherOverloads1() = (sprintf "+ 1 overload" )
    /// + %d overloads
    /// (Originally from /src/fsharp/FSComp.txt:1284)
    static member nicePrintOtherOverloadsN(a0 : System.Int32) = (sprintf "+ %d overloads" a0)
    /// Erased to
    /// (Originally from /src/fsharp/FSComp.txt:1285)
    static member erasedTo() = (sprintf "Erased to" )
    /// Unexpected token '%s' or incomplete expression
    /// (Originally from /src/fsharp/FSComp.txt:1286)
    static member parsUnfinishedExpression(a0 : System.String) = (3156, sprintf "Unexpected token '%s' or incomplete expression" a0)
    /// Cannot find code target for this attribute, possibly because the code after the attribute is incomplete.
    /// (Originally from /src/fsharp/FSComp.txt:1287)
    static member parsAttributeOnIncompleteCode() = (3158, sprintf "Cannot find code target for this attribute, possibly because the code after the attribute is incomplete." )
    /// Type name cannot be empty.
    /// (Originally from /src/fsharp/FSComp.txt:1288)
    static member parsTypeNameCannotBeEmpty() = (3159, sprintf "Type name cannot be empty." )
    /// Problem reading assembly '%s': %s
    /// (Originally from /src/fsharp/FSComp.txt:1289)
    static member buildProblemReadingAssembly(a0 : System.String, a1 : System.String) = (3160, sprintf "Problem reading assembly '%s': %s" a0 a1)
    /// Invalid provided field. Provided fields of erased provided types must be literals.
    /// (Originally from /src/fsharp/FSComp.txt:1290)
    static member tcTPFieldMustBeLiteral() = (3161, sprintf "Invalid provided field. Provided fields of erased provided types must be literals." )
    /// (loading description...)
    /// (Originally from /src/fsharp/FSComp.txt:1291)
    static member loadingDescription() = (sprintf "(loading description...)" )
    /// (description unavailable...)
    /// (Originally from /src/fsharp/FSComp.txt:1292)
    static member descriptionUnavailable() = (sprintf "(description unavailable...)" )
    /// A type variable has been constrained by multiple different class types. A type variable may only have one class constraint.
    /// (Originally from /src/fsharp/FSComp.txt:1293)
    static member chkTyparMultipleClassConstraints() = (3162, sprintf "A type variable has been constrained by multiple different class types. A type variable may only have one class constraint." )
    /// 'match' expressions may not be used in queries
    /// (Originally from /src/fsharp/FSComp.txt:1294)
    static member tcMatchMayNotBeUsedWithQuery() = (3163, sprintf "'match' expressions may not be used in queries" )
    /// Infix operator member '%s' has %d initial argument(s). Expected a tuple of 3 arguments
    /// (Originally from /src/fsharp/FSComp.txt:1295)
    static member memberOperatorDefinitionWithNonTripleArgument(a0 : System.String, a1 : System.Int32) = (3164, sprintf "Infix operator member '%s' has %d initial argument(s). Expected a tuple of 3 arguments" a0 a1)
    /// The operator '%s' cannot be resolved. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'.
    /// (Originally from /src/fsharp/FSComp.txt:1296)
    static member cannotResolveNullableOperators(a0 : System.String) = (3165, sprintf "The operator '%s' cannot be resolved. Consider opening the module 'Microsoft.FSharp.Linq.NullableOperators'." a0)
    /// '%s' must be followed by 'in'. Usage: %s.
    /// (Originally from /src/fsharp/FSComp.txt:1297)
    static member tcOperatorRequiresIn(a0 : System.String, a1 : System.String) = (3167, sprintf "'%s' must be followed by 'in'. Usage: %s." a0 a1)
    /// Neither 'member val' nor 'override val' definitions are permitted in object expressions.
    /// (Originally from /src/fsharp/FSComp.txt:1298)
    static member parsIllegalMemberVarInObjectImplementation() = (3168, sprintf "Neither 'member val' nor 'override val' definitions are permitted in object expressions." )
    /// Copy-and-update record expressions must include at least one field.
    /// (Originally from /src/fsharp/FSComp.txt:1299)
    static member tcEmptyCopyAndUpdateRecordInvalid() = (3169, sprintf "Copy-and-update record expressions must include at least one field." )
    /// '_' cannot be used as field name
    /// (Originally from /src/fsharp/FSComp.txt:1300)
    static member parsUnderscoreInvalidFieldName() = (3170, sprintf "'_' cannot be used as field name" )
    /// The provided types generated by this use of a type provider may not be used from other F# assemblies and should be marked internal or private. Consider using 'type internal TypeName = ...' or 'type private TypeName = ...'.
    /// (Originally from /src/fsharp/FSComp.txt:1301)
    static member tcGeneratedTypesShouldBeInternalOrPrivate() = (3171, sprintf "The provided types generated by this use of a type provider may not be used from other F# assemblies and should be marked internal or private. Consider using 'type internal TypeName = ...' or 'type private TypeName = ...'." )
    /// A property's getter and setter must have the same type. Property '%s' has getter of type '%s' but setter of type '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1302)
    static member chkGetterAndSetterHaveSamePropertyType(a0 : System.String, a1 : System.String, a2 : System.String) = (3172, sprintf "A property's getter and setter must have the same type. Property '%s' has getter of type '%s' but setter of type '%s'." a0 a1 a2)
    /// Array method '%s' is supplied by the runtime and cannot be directly used in code. For operations with array elements consider using family of GetArray/SetArray functions from LanguagePrimitives.IntrinsicFunctions module.
    /// (Originally from /src/fsharp/FSComp.txt:1303)
    static member tcRuntimeSuppliedMethodCannotBeUsedInUserCode(a0 : System.String) = (3173, sprintf "Array method '%s' is supplied by the runtime and cannot be directly used in code. For operations with array elements consider using family of GetArray/SetArray functions from LanguagePrimitives.IntrinsicFunctions module." a0)
    /// The union case '%s' does not have a field named '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1304)
    static member tcUnionCaseConstructorDoesNotHaveFieldWithGivenName(a0 : System.String, a1 : System.String) = (3174, sprintf "The union case '%s' does not have a field named '%s'." a0 a1)
    /// The exception '%s' does not have a field named '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1305)
    static member tcExceptionConstructorDoesNotHaveFieldWithGivenName(a0 : System.String, a1 : System.String) = (3174, sprintf "The exception '%s' does not have a field named '%s'." a0 a1)
    /// Active patterns do not have fields. This syntax is invalid.
    /// (Originally from /src/fsharp/FSComp.txt:1306)
    static member tcActivePatternsDoNotHaveFields() = (3174, sprintf "Active patterns do not have fields. This syntax is invalid." )
    /// The constructor does not have a field named '%s'.
    /// (Originally from /src/fsharp/FSComp.txt:1307)
    static member tcConstructorDoesNotHaveFieldWithGivenName(a0 : System.String) = (3174, sprintf "The constructor does not have a field named '%s'." a0)
    /// Union case/exception field '%s' cannot be used more than once.
    /// (Originally from /src/fsharp/FSComp.txt:1308)
    static member tcUnionCaseFieldCannotBeUsedMoreThanOnce(a0 : System.String) = (3175, sprintf "Union case/exception field '%s' cannot be used more than once." a0)
    /// Named field '%s' is used more than once.
    /// (Originally from /src/fsharp/FSComp.txt:1309)
    static member tcFieldNameIsUsedModeThanOnce(a0 : System.String) = (3176, sprintf "Named field '%s' is used more than once." a0)
    /// Named field '%s' conflicts with autogenerated name for anonymous field.
    /// (Originally from /src/fsharp/FSComp.txt:1310)
    static member tcFieldNameConflictsWithGeneratedNameForAnonymousField(a0 : System.String) = (3176, sprintf "Named field '%s' conflicts with autogenerated name for anonymous field." a0)
    /// This literal expression or attribute argument results in an arithmetic overflow.
    /// (Originally from /src/fsharp/FSComp.txt:1311)
    static member tastConstantExpressionOverflow() = (3177, sprintf "This literal expression or attribute argument results in an arithmetic overflow." )
    /// This is not valid literal expression. The [<Literal>] attribute will be ignored.
    /// (Originally from /src/fsharp/FSComp.txt:1312)
    static member tcIllegalStructTypeForConstantExpression() = (3178, sprintf "This is not valid literal expression. The [<Literal>] attribute will be ignored." )
    /// System.Runtime.InteropServices assembly is required to use UnknownWrapper\DispatchWrapper classes.
    /// (Originally from /src/fsharp/FSComp.txt:1313)
    static member fscSystemRuntimeInteropServicesIsRequired() = (3179, sprintf "System.Runtime.InteropServices assembly is required to use UnknownWrapper\DispatchWrapper classes." )
    /// The mutable local '%s' is implicitly allocated as a reference cell because it has been captured by a closure. This warning is for informational purposes only to indicate where implicit allocations are performed.
    /// (Originally from /src/fsharp/FSComp.txt:1314)
    static member abImplicitHeapAllocation(a0 : System.String) = (3180, sprintf "The mutable local '%s' is implicitly allocated as a reference cell because it has been captured by a closure. This warning is for informational purposes only to indicate where implicit allocations are performed." a0)
    /// A type provider implemented GetStaticParametersForMethod, but ApplyStaticArgumentsForMethod was not implemented or invalid
    /// (Originally from /src/fsharp/FSComp.txt:1315)
    static member estApplyStaticArgumentsForMethodNotImplemented() = (sprintf "A type provider implemented GetStaticParametersForMethod, but ApplyStaticArgumentsForMethod was not implemented or invalid" )
    /// An error occured applying the static arguments to a provided method
    /// (Originally from /src/fsharp/FSComp.txt:1316)
    static member etErrorApplyingStaticArgumentsToMethod() = (3181, sprintf "An error occured applying the static arguments to a provided method" )
    /// Unexpected character '%s' in preprocessor expression
    /// (Originally from /src/fsharp/FSComp.txt:1317)
    static member pplexUnexpectedChar(a0 : System.String) = (3182, sprintf "Unexpected character '%s' in preprocessor expression" a0)
    /// Unexpected token '%s' in preprocessor expression
    /// (Originally from /src/fsharp/FSComp.txt:1318)
    static member ppparsUnexpectedToken(a0 : System.String) = (3183, sprintf "Unexpected token '%s' in preprocessor expression" a0)
    /// Incomplete preprocessor expression
    /// (Originally from /src/fsharp/FSComp.txt:1319)
    static member ppparsIncompleteExpression() = (3184, sprintf "Incomplete preprocessor expression" )
    /// Missing token '%s' in preprocessor expression
    /// (Originally from /src/fsharp/FSComp.txt:1320)
    static member ppparsMissingToken(a0 : System.String) = (3185, sprintf "Missing token '%s' in preprocessor expression" a0)
    /// An error occurred while reading the F# metadata node at position %d in table '%s' of assembly '%s'. The node had no matching declaration. Please report this warning. You may need to recompile the F# assembly you are using.
    /// (Originally from /src/fsharp/FSComp.txt:1321)
    static member pickleMissingDefinition(a0 : System.Int32, a1 : System.String, a2 : System.String) = (3186, sprintf "An error occurred while reading the F# metadata node at position %d in table '%s' of assembly '%s'. The node had no matching declaration. Please report this warning. You may need to recompile the F# assembly you are using." a0 a1 a2)
    /// Type inference caused the type variable %s to escape its scope. Consider adding an explicit type parameter declaration or adjusting your code to be less generic.
    /// (Originally from /src/fsharp/FSComp.txt:1322)
    static member checkNotSufficientlyGenericBecauseOfScope(a0 : System.String) = (3187, sprintf "Type inference caused the type variable %s to escape its scope. Consider adding an explicit type parameter declaration or adjusting your code to be less generic." a0)
    /// Type inference caused an inference type variable to escape its scope. Consider adding type annotations to make your code less generic.
    /// (Originally from /src/fsharp/FSComp.txt:1323)
    static member checkNotSufficientlyGenericBecauseOfScopeAnon() = (3188, sprintf "Type inference caused an inference type variable to escape its scope. Consider adding type annotations to make your code less generic." )
    /// Redundant arguments are being ignored in function '%s'. Expected %d but got %d arguments.
    /// (Originally from /src/fsharp/FSComp.txt:1324)
    static member checkRaiseFamilyFunctionArgumentCount(a0 : System.String, a1 : System.Int32, a2 : System.Int32) = (3189, sprintf "Redundant arguments are being ignored in function '%s'. Expected %d but got %d arguments." a0 a1 a2)
    /// Lowercase literal '%s' is being shadowed by a new pattern with the same name. Only uppercase and module-prefixed literals can be used as named patterns.
    /// (Originally from /src/fsharp/FSComp.txt:1325)
    static member checkLowercaseLiteralBindingInPattern(a0 : System.String) = (3190, sprintf "Lowercase literal '%s' is being shadowed by a new pattern with the same name. Only uppercase and module-prefixed literals can be used as named patterns." a0)
    /// This literal pattern does not take arguments
    /// (Originally from /src/fsharp/FSComp.txt:1326)
    static member tcLiteralDoesNotTakeArguments() = (3191, sprintf "This literal pattern does not take arguments" )
    /// Constructors are not permitted as extension members - they must be defined as part of the original definition of the type
    /// (Originally from /src/fsharp/FSComp.txt:1327)
    static member tcConstructorsIllegalInAugmentation() = (3192, sprintf "Constructors are not permitted as extension members - they must be defined as part of the original definition of the type" )
    /// Invalid response file '%s' ( '%s' )
    /// (Originally from /src/fsharp/FSComp.txt:1328)
    static member optsInvalidResponseFile(a0 : System.String, a1 : System.String) = (3193, sprintf "Invalid response file '%s' ( '%s' )" a0 a1)
    /// Response file '%s' not found in '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1329)
    static member optsResponseFileNotFound(a0 : System.String, a1 : System.String) = (3194, sprintf "Response file '%s' not found in '%s'" a0 a1)
    /// Response file name '%s' is empty, contains invalid characters, has a drive specification without an absolute path, or is too long
    /// (Originally from /src/fsharp/FSComp.txt:1330)
    static member optsResponseFileNameInvalid(a0 : System.String) = (3195, sprintf "Response file name '%s' is empty, contains invalid characters, has a drive specification without an absolute path, or is too long" a0)
    /// Cannot find FSharp.Core.dll in compiler's directory
    /// (Originally from /src/fsharp/FSComp.txt:1331)
    static member fsharpCoreNotFoundToBeCopied() = (3196, sprintf "Cannot find FSharp.Core.dll in compiler's directory" )
    /// One tuple type is a struct tuple, the other is a reference tuple
    /// (Originally from /src/fsharp/FSComp.txt:1332)
    static member tcTupleStructMismatch() = (sprintf "One tuple type is a struct tuple, the other is a reference tuple" )
    /// This provided method requires static parameters
    /// (Originally from /src/fsharp/FSComp.txt:1333)
    static member etMissingStaticArgumentsToMethod() = (3197, sprintf "This provided method requires static parameters" )
    /// The conversion from %s to %s is a compile-time safe upcast, not a downcast. Consider using 'upcast' instead of 'downcast'.
    /// (Originally from /src/fsharp/FSComp.txt:1334)
    static member considerUpcast(a0 : System.String, a1 : System.String) = (3198, sprintf "The conversion from %s to %s is a compile-time safe upcast, not a downcast. Consider using 'upcast' instead of 'downcast'." a0 a1)
    /// The conversion from %s to %s is a compile-time safe upcast, not a downcast. Consider using the :> (upcast) operator instead of the :?> (downcast) operator.
    /// (Originally from /src/fsharp/FSComp.txt:1335)
    static member considerUpcastOperator(a0 : System.String, a1 : System.String) = (3198, sprintf "The conversion from %s to %s is a compile-time safe upcast, not a downcast. Consider using the :> (upcast) operator instead of the :?> (downcast) operator." a0 a1)
    /// The 'rec' on this module is implied by an outer 'rec' declaration and is being ignored
    /// (Originally from /src/fsharp/FSComp.txt:1336)
    static member tcRecImplied() = (3199, sprintf "The 'rec' on this module is implied by an outer 'rec' declaration and is being ignored" )
    /// In a recursive declaration group, 'open' declarations must come first in each module
    /// (Originally from /src/fsharp/FSComp.txt:1337)
    static member tcOpenFirstInMutRec() = (3200, sprintf "In a recursive declaration group, 'open' declarations must come first in each module" )
    /// In a recursive declaration group, module abbreviations must come after all 'open' declarations and before other declarations
    /// (Originally from /src/fsharp/FSComp.txt:1338)
    static member tcModuleAbbrevFirstInMutRec() = (3201, sprintf "In a recursive declaration group, module abbreviations must come after all 'open' declarations and before other declarations" )
    /// This declaration is not supported in recursive declaration groups
    /// (Originally from /src/fsharp/FSComp.txt:1339)
    static member tcUnsupportedMutRecDecl() = (3202, sprintf "This declaration is not supported in recursive declaration groups" )
    /// Invalid use of 'rec' keyword
    /// (Originally from /src/fsharp/FSComp.txt:1340)
    static member parsInvalidUseOfRec() = (3203, sprintf "Invalid use of 'rec' keyword" )
    /// If a union type has more than one case and is a struct, then all fields within the union type must be given unique names.
    /// (Originally from /src/fsharp/FSComp.txt:1341)
    static member tcStructUnionMultiCaseDistinctFields() = (3204, sprintf "If a union type has more than one case and is a struct, then all fields within the union type must be given unique names." )
    /// The CallerMemberNameAttribute applied to parameter '%s' will have no effect. It is overridden by the CallerFilePathAttribute.
    /// (Originally from /src/fsharp/FSComp.txt:1342)
    static member CallerMemberNameIsOverriden(a0 : System.String) = (3206, sprintf "The CallerMemberNameAttribute applied to parameter '%s' will have no effect. It is overridden by the CallerFilePathAttribute." a0)
    /// Invalid use of 'fixed'. 'fixed' may only be used in a declaration of the form 'use x = fixed expr' where the expression is an array, the address of a field, the address of an array element or a string'
    /// (Originally from /src/fsharp/FSComp.txt:1343)
    static member tcFixedNotAllowed() = (3207, sprintf "Invalid use of 'fixed'. 'fixed' may only be used in a declaration of the form 'use x = fixed expr' where the expression is an array, the address of a field, the address of an array element or a string'" )
    /// Could not find method System.Runtime.CompilerServices.OffsetToStringData in references when building 'fixed' expression.
    /// (Originally from /src/fsharp/FSComp.txt:1344)
    static member tcCouldNotFindOffsetToStringData() = (3208, sprintf "Could not find method System.Runtime.CompilerServices.OffsetToStringData in references when building 'fixed' expression." )
    /// The address of the variable '%s' or a related expression cannot be used at this point. This is to ensure the address of the local value does not escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:1345)
    static member chkNoByrefAddressOfLocal(a0 : System.String) = (3209, sprintf "The address of the variable '%s' or a related expression cannot be used at this point. This is to ensure the address of the local value does not escape its scope." a0)
    /// %s is an active pattern and cannot be treated as a discriminated union case with named fields.
    /// (Originally from /src/fsharp/FSComp.txt:1346)
    static member tcNamedActivePattern(a0 : System.String) = (3210, sprintf "%s is an active pattern and cannot be treated as a discriminated union case with named fields." a0)
    /// The default value does not have the same type as the argument. The DefaultParameterValue attribute and any Optional attribute will be ignored. Note: 'null' needs to be annotated with the correct type, e.g. 'DefaultParameterValue(null:obj)'.
    /// (Originally from /src/fsharp/FSComp.txt:1347)
    static member DefaultParameterValueNotAppropriateForArgument() = (3211, sprintf "The default value does not have the same type as the argument. The DefaultParameterValue attribute and any Optional attribute will be ignored. Note: 'null' needs to be annotated with the correct type, e.g. 'DefaultParameterValue(null:obj)'." )
    /// The system type '%s' was required but no referenced system DLL contained this type
    /// (Originally from /src/fsharp/FSComp.txt:1348)
    static member tcGlobalsSystemTypeNotFound(a0 : System.String) = (sprintf "The system type '%s' was required but no referenced system DLL contained this type" a0)
    /// The member '%s' matches multiple overloads of the same method.\nPlease restrict it to one of the following:%s.
    /// (Originally from /src/fsharp/FSComp.txt:1349)
    static member typrelMemberHasMultiplePossibleDispatchSlots(a0 : System.String, a1 : System.String) = (3213, sprintf "The member '%s' matches multiple overloads of the same method.\nPlease restrict it to one of the following:%s." a0 a1)
    /// Method or object constructor '%s' is not static
    /// (Originally from /src/fsharp/FSComp.txt:1350)
    static member methodIsNotStatic(a0 : System.String) = (3214, sprintf "Method or object constructor '%s' is not static" a0)
    /// Unexpected symbol '=' in expression. Did you intend to use 'for x in y .. z do' instead?
    /// (Originally from /src/fsharp/FSComp.txt:1351)
    static member parsUnexpectedSymbolEqualsInsteadOfIn() = (3215, sprintf "Unexpected symbol '=' in expression. Did you intend to use 'for x in y .. z do' instead?" )
    /// Two anonymous record types are from different assemblies '%s' and '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1352)
    static member tcAnonRecdCcuMismatch(a0 : System.String, a1 : System.String) = (sprintf "Two anonymous record types are from different assemblies '%s' and '%s'" a0 a1)
    /// Two anonymous record types have mismatched sets of field names '%s' and '%s'
    /// (Originally from /src/fsharp/FSComp.txt:1353)
    static member tcAnonRecdFieldNameMismatch(a0 : System.String, a1 : System.String) = (sprintf "Two anonymous record types have mismatched sets of field names '%s' and '%s'" a0 a1)
    /// Indicates a method that either has no implementation in the type in which it is declared or that is virtual and has a default implementation.
    /// (Originally from /src/fsharp/FSComp.txt:1354)
    static member keywordDescriptionAbstract() = (sprintf "Indicates a method that either has no implementation in the type in which it is declared or that is virtual and has a default implementation." )
    /// Used in mutually recursive bindings, in property declarations, and with multiple constraints on generic parameters.
    /// (Originally from /src/fsharp/FSComp.txt:1355)
    static member keyworkDescriptionAnd() = (sprintf "Used in mutually recursive bindings, in property declarations, and with multiple constraints on generic parameters." )
    /// Used to give the current class object an object name. Also used to give a name to a whole pattern within a pattern match.
    /// (Originally from /src/fsharp/FSComp.txt:1356)
    static member keywordDescriptionAs() = (sprintf "Used to give the current class object an object name. Also used to give a name to a whole pattern within a pattern match." )
    /// Used to verify code during debugging.
    /// (Originally from /src/fsharp/FSComp.txt:1357)
    static member keywordDescriptionAssert() = (sprintf "Used to verify code during debugging." )
    /// Used as the name of the base class object.
    /// (Originally from /src/fsharp/FSComp.txt:1358)
    static member keywordDescriptionBase() = (sprintf "Used as the name of the base class object." )
    /// In verbose syntax, indicates the start of a code block.
    /// (Originally from /src/fsharp/FSComp.txt:1359)
    static member keywordDescriptionBegin() = (sprintf "In verbose syntax, indicates the start of a code block." )
    /// In verbose syntax, indicates the start of a class definition.
    /// (Originally from /src/fsharp/FSComp.txt:1360)
    static member keywordDescriptionClass() = (sprintf "In verbose syntax, indicates the start of a class definition." )
    /// Indicates an implementation of an abstract method; used together with an abstract method declaration to create a virtual method.
    /// (Originally from /src/fsharp/FSComp.txt:1361)
    static member keywordDescriptionDefault() = (sprintf "Indicates an implementation of an abstract method; used together with an abstract method declaration to create a virtual method." )
    /// Used to declare a delegate.
    /// (Originally from /src/fsharp/FSComp.txt:1362)
    static member keywordDescriptionDelegate() = (sprintf "Used to declare a delegate." )
    /// Used in looping constructs or to execute imperative code.
    /// (Originally from /src/fsharp/FSComp.txt:1363)
    static member keywordDescriptionDo() = (sprintf "Used in looping constructs or to execute imperative code." )
    /// In verbose syntax, indicates the end of a block of code in a looping expression.
    /// (Originally from /src/fsharp/FSComp.txt:1364)
    static member keywordDescriptionDone() = (sprintf "In verbose syntax, indicates the end of a block of code in a looping expression." )
    /// Used to convert to a type that is lower in the inheritance chain.
    /// (Originally from /src/fsharp/FSComp.txt:1365)
    static member keywordDescriptionDowncast() = (sprintf "Used to convert to a type that is lower in the inheritance chain." )
    /// In a for expression, used when counting in reverse.
    /// (Originally from /src/fsharp/FSComp.txt:1366)
    static member keywordDescriptionDownto() = (sprintf "In a for expression, used when counting in reverse." )
    /// Used in conditional branching. A short form of else if.
    /// (Originally from /src/fsharp/FSComp.txt:1367)
    static member keywordDescriptionElif() = (sprintf "Used in conditional branching. A short form of else if." )
    /// Used in conditional branching.
    /// (Originally from /src/fsharp/FSComp.txt:1368)
    static member keywordDescriptionElse() = (sprintf "Used in conditional branching." )
    /// In type definitions and type extensions, indicates the end of a section of member definitions. In verbose syntax, used to specify the end of a code block that starts with the begin keyword.
    /// (Originally from /src/fsharp/FSComp.txt:1369)
    static member keywordDescriptionEnd() = (sprintf "In type definitions and type extensions, indicates the end of a section of member definitions. In verbose syntax, used to specify the end of a code block that starts with the begin keyword." )
    /// Used to declare an exception type.
    /// (Originally from /src/fsharp/FSComp.txt:1370)
    static member keywordDescriptionException() = (sprintf "Used to declare an exception type." )
    /// Indicates that a declared program element is defined in another binary or assembly.
    /// (Originally from /src/fsharp/FSComp.txt:1371)
    static member keywordDescriptionExtern() = (sprintf "Indicates that a declared program element is defined in another binary or assembly." )
    /// Used as a Boolean literal.
    /// (Originally from /src/fsharp/FSComp.txt:1372)
    static member keywordDescriptionTrueFalse() = (sprintf "Used as a Boolean literal." )
    /// Used together with try to introduce a block of code that executes regardless of whether an exception occurs.
    /// (Originally from /src/fsharp/FSComp.txt:1373)
    static member keywordDescriptionFinally() = (sprintf "Used together with try to introduce a block of code that executes regardless of whether an exception occurs." )
    /// Used in looping constructs.
    /// (Originally from /src/fsharp/FSComp.txt:1374)
    static member keywordDescriptionFor() = (sprintf "Used in looping constructs." )
    /// Used in lambda expressions, also known as anonymous functions.
    /// (Originally from /src/fsharp/FSComp.txt:1375)
    static member keywordDescriptionFun() = (sprintf "Used in lambda expressions, also known as anonymous functions." )
    /// Used as a shorter alternative to the fun keyword and a match expression in a lambda expression that has pattern matching on a single argument.
    /// (Originally from /src/fsharp/FSComp.txt:1376)
    static member keywordDescriptionFunction() = (sprintf "Used as a shorter alternative to the fun keyword and a match expression in a lambda expression that has pattern matching on a single argument." )
    /// Used to reference the top-level .NET namespace.
    /// (Originally from /src/fsharp/FSComp.txt:1377)
    static member keywordDescriptionGlobal() = (sprintf "Used to reference the top-level .NET namespace." )
    /// Used in conditional branching constructs.
    /// (Originally from /src/fsharp/FSComp.txt:1378)
    static member keywordDescriptionIf() = (sprintf "Used in conditional branching constructs." )
    /// Used for sequence expressions and, in verbose syntax, to separate expressions from bindings.
    /// (Originally from /src/fsharp/FSComp.txt:1379)
    static member keywordDescriptionIn() = (sprintf "Used for sequence expressions and, in verbose syntax, to separate expressions from bindings." )
    /// Used to specify a base class or base interface.
    /// (Originally from /src/fsharp/FSComp.txt:1380)
    static member keywordDescriptionInherit() = (sprintf "Used to specify a base class or base interface." )
    /// Used to indicate a function that should be integrated directly into the caller's code.
    /// (Originally from /src/fsharp/FSComp.txt:1381)
    static member keywordDescriptionInline() = (sprintf "Used to indicate a function that should be integrated directly into the caller's code." )
    /// Used to declare and implement interfaces.
    /// (Originally from /src/fsharp/FSComp.txt:1382)
    static member keywordDescriptionInterface() = (sprintf "Used to declare and implement interfaces." )
    /// Used to specify that a member is visible inside an assembly but not outside it.
    /// (Originally from /src/fsharp/FSComp.txt:1383)
    static member keywordDescriptionInternal() = (sprintf "Used to specify that a member is visible inside an assembly but not outside it." )
    /// Used to specify a computation that is to be performed only when a result is needed.
    /// (Originally from /src/fsharp/FSComp.txt:1384)
    static member keywordDescriptionLazy() = (sprintf "Used to specify a computation that is to be performed only when a result is needed." )
    /// Used to associate, or bind, a name to a value or function.
    /// (Originally from /src/fsharp/FSComp.txt:1385)
    static member keywordDescriptionLet() = (sprintf "Used to associate, or bind, a name to a value or function." )
    /// Used in computation expressions to bind a name to the result of another computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1386)
    static member keywordDescriptionLetBang() = (sprintf "Used in computation expressions to bind a name to the result of another computation expression." )
    /// Used to branch by comparing a value to a pattern.
    /// (Originally from /src/fsharp/FSComp.txt:1387)
    static member keywordDescriptionMatch() = (sprintf "Used to branch by comparing a value to a pattern." )
    /// Used in computation expressions to pattern match directly over the result of another computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1388)
    static member keywordDescriptionMatchBang() = (sprintf "Used in computation expressions to pattern match directly over the result of another computation expression." )
    /// Used to declare a property or method in an object type.
    /// (Originally from /src/fsharp/FSComp.txt:1389)
    static member keywordDescriptionMember() = (sprintf "Used to declare a property or method in an object type." )
    /// Used to associate a name with a group of related types, values, and functions, to logically separate it from other code.
    /// (Originally from /src/fsharp/FSComp.txt:1390)
    static member keywordDescriptionModule() = (sprintf "Used to associate a name with a group of related types, values, and functions, to logically separate it from other code." )
    /// Used to declare a variable, that is, a value that can be changed.
    /// (Originally from /src/fsharp/FSComp.txt:1391)
    static member keywordDescriptionMutable() = (sprintf "Used to declare a variable, that is, a value that can be changed." )
    /// Used to associate a name with a group of related types and modules, to logically separate it from other code.
    /// (Originally from /src/fsharp/FSComp.txt:1392)
    static member keywordDescriptionNamespace() = (sprintf "Used to associate a name with a group of related types and modules, to logically separate it from other code." )
    /// Used to declare, define, or invoke a constructor that creates or that can create an object. Also used in generic parameter constraints to indicate that a type must have a certain constructor.
    /// (Originally from /src/fsharp/FSComp.txt:1393)
    static member keywordDescriptionNew() = (sprintf "Used to declare, define, or invoke a constructor that creates or that can create an object. Also used in generic parameter constraints to indicate that a type must have a certain constructor." )
    /// Not actually a keyword. However, not struct in combination is used as a generic parameter constraint.
    /// (Originally from /src/fsharp/FSComp.txt:1394)
    static member keywordDescriptionNot() = (sprintf "Not actually a keyword. However, not struct in combination is used as a generic parameter constraint." )
    /// Indicates the absence of an object. Also used in generic parameter constraints.
    /// (Originally from /src/fsharp/FSComp.txt:1395)
    static member keywordDescriptionNull() = (sprintf "Indicates the absence of an object. Also used in generic parameter constraints." )
    /// Used in discriminated unions to indicate the type of categories of values, and in delegate and exception declarations.
    /// (Originally from /src/fsharp/FSComp.txt:1396)
    static member keywordDescriptionOf() = (sprintf "Used in discriminated unions to indicate the type of categories of values, and in delegate and exception declarations." )
    /// Used to make the contents of a namespace or module available without qualification.
    /// (Originally from /src/fsharp/FSComp.txt:1397)
    static member keywordDescriptionOpen() = (sprintf "Used to make the contents of a namespace or module available without qualification." )
    /// Used with Boolean conditions as a Boolean or operator. Equivalent to ||. Also used in member constraints.
    /// (Originally from /src/fsharp/FSComp.txt:1398)
    static member keywordDescriptionOr() = (sprintf "Used with Boolean conditions as a Boolean or operator. Equivalent to ||. Also used in member constraints." )
    /// Used to implement a version of an abstract or virtual method that differs from the base version.
    /// (Originally from /src/fsharp/FSComp.txt:1399)
    static member keywordDescriptionOverride() = (sprintf "Used to implement a version of an abstract or virtual method that differs from the base version." )
    /// Restricts access to a member to code in the same type or module.
    /// (Originally from /src/fsharp/FSComp.txt:1400)
    static member keywordDescriptionPrivate() = (sprintf "Restricts access to a member to code in the same type or module." )
    /// Allows access to a member from outside the type.
    /// (Originally from /src/fsharp/FSComp.txt:1401)
    static member keywordDescriptionPublic() = (sprintf "Allows access to a member from outside the type." )
    /// Used to indicate that a function is recursive.
    /// (Originally from /src/fsharp/FSComp.txt:1402)
    static member keywordDescriptionRec() = (sprintf "Used to indicate that a function is recursive." )
    /// Used to provide a value for the result of the containing computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1403)
    static member keywordDescriptionReturn() = (sprintf "Used to provide a value for the result of the containing computation expression." )
    /// Used to provide a value for the result of the containing computation expression, where that value itself comes from the result another computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1404)
    static member keywordDescriptionReturnBang() = (sprintf "Used to provide a value for the result of the containing computation expression, where that value itself comes from the result another computation expression." )
    /// Used in query expressions to specify what fields or columns to extract. Note that this is a contextual keyword, which means that it is not actually a reserved word and it only acts like a keyword in appropriate context.
    /// (Originally from /src/fsharp/FSComp.txt:1405)
    static member keywordDescriptionSelect() = (sprintf "Used in query expressions to specify what fields or columns to extract. Note that this is a contextual keyword, which means that it is not actually a reserved word and it only acts like a keyword in appropriate context." )
    /// Used to indicate a method or property that can be called without an instance of a type, or a value member that is shared among all instances of a type.
    /// (Originally from /src/fsharp/FSComp.txt:1406)
    static member keywordDescriptionStatic() = (sprintf "Used to indicate a method or property that can be called without an instance of a type, or a value member that is shared among all instances of a type." )
    /// Used to declare a structure type. Also used in generic parameter constraints. Used for OCaml compatibility in module definitions.
    /// (Originally from /src/fsharp/FSComp.txt:1407)
    static member keywordDescriptionStruct() = (sprintf "Used to declare a structure type. Also used in generic parameter constraints. Used for OCaml compatibility in module definitions." )
    /// Used in conditional expressions. Also used to perform side effects after object construction.
    /// (Originally from /src/fsharp/FSComp.txt:1408)
    static member keywordDescriptionThen() = (sprintf "Used in conditional expressions. Also used to perform side effects after object construction." )
    /// Used in for loops to indicate a range.
    /// (Originally from /src/fsharp/FSComp.txt:1409)
    static member keywordDescriptionTo() = (sprintf "Used in for loops to indicate a range." )
    /// Used to introduce a block of code that might generate an exception. Used together with with or finally.
    /// (Originally from /src/fsharp/FSComp.txt:1410)
    static member keywordDescriptionTry() = (sprintf "Used to introduce a block of code that might generate an exception. Used together with with or finally." )
    /// Used to declare a class, record, structure, discriminated union, enumeration type, unit of measure, or type abbreviation.
    /// (Originally from /src/fsharp/FSComp.txt:1411)
    static member keywordDescriptionType() = (sprintf "Used to declare a class, record, structure, discriminated union, enumeration type, unit of measure, or type abbreviation." )
    /// Used to convert to a type that is higher in the inheritance chain.
    /// (Originally from /src/fsharp/FSComp.txt:1412)
    static member keywordDescriptionUpcast() = (sprintf "Used to convert to a type that is higher in the inheritance chain." )
    /// Used instead of let for values that implement IDisposable
    /// (Originally from /src/fsharp/FSComp.txt:1413)
    static member keywordDescriptionUse() = (sprintf "Used instead of let for values that implement IDisposable" )
    /// Used instead of let! in computation expressions for computation expression results that implement IDisposable.
    /// (Originally from /src/fsharp/FSComp.txt:1414)
    static member keywordDescriptionUseBang() = (sprintf "Used instead of let! in computation expressions for computation expression results that implement IDisposable." )
    /// Used in a signature to indicate a value, or in a type to declare a member, in limited situations.
    /// (Originally from /src/fsharp/FSComp.txt:1415)
    static member keywordDescriptionVal() = (sprintf "Used in a signature to indicate a value, or in a type to declare a member, in limited situations." )
    /// Indicates the .NET void type. Used when interoperating with other .NET languages.
    /// (Originally from /src/fsharp/FSComp.txt:1416)
    static member keywordDescriptionVoid() = (sprintf "Indicates the .NET void type. Used when interoperating with other .NET languages." )
    /// Used for Boolean conditions (when guards) on pattern matches and to introduce a constraint clause for a generic type parameter.
    /// (Originally from /src/fsharp/FSComp.txt:1417)
    static member keywordDescriptionWhen() = (sprintf "Used for Boolean conditions (when guards) on pattern matches and to introduce a constraint clause for a generic type parameter." )
    /// Introduces a looping construct.
    /// (Originally from /src/fsharp/FSComp.txt:1418)
    static member keywordDescriptionWhile() = (sprintf "Introduces a looping construct." )
    /// Used together with the match keyword in pattern matching expressions. Also used in object expressions, record copying expressions, and type extensions to introduce member definitions, and to introduce exception handlers.
    /// (Originally from /src/fsharp/FSComp.txt:1419)
    static member keywordDescriptionWith() = (sprintf "Used together with the match keyword in pattern matching expressions. Also used in object expressions, record copying expressions, and type extensions to introduce member definitions, and to introduce exception handlers." )
    /// Used in a sequence expression to produce a value for a sequence.
    /// (Originally from /src/fsharp/FSComp.txt:1420)
    static member keywordDescriptionYield() = (sprintf "Used in a sequence expression to produce a value for a sequence." )
    /// Used in a computation expression to append the result of a given computation expression to a collection of results for the containing computation expression.
    /// (Originally from /src/fsharp/FSComp.txt:1421)
    static member keywordDescriptionYieldBang() = (sprintf "Used in a computation expression to append the result of a given computation expression to a collection of results for the containing computation expression." )
    /// In function types, delimits arguments and return values. Yields an expression (in sequence expressions); equivalent to the yield keyword. Used in match expressions
    /// (Originally from /src/fsharp/FSComp.txt:1422)
    static member keywordDescriptionRightArrow() = (sprintf "In function types, delimits arguments and return values. Yields an expression (in sequence expressions); equivalent to the yield keyword. Used in match expressions" )
    /// Assigns a value to a variable.
    /// (Originally from /src/fsharp/FSComp.txt:1423)
    static member keywordDescriptionLeftArrow() = (sprintf "Assigns a value to a variable." )
    /// Converts a type to type that is higher in the hierarchy.
    /// (Originally from /src/fsharp/FSComp.txt:1424)
    static member keywordDescriptionCast() = (sprintf "Converts a type to type that is higher in the hierarchy." )
    /// Converts a type to a type that is lower in the hierarchy.
    /// (Originally from /src/fsharp/FSComp.txt:1425)
    static member keywordDescriptionDynamicCast() = (sprintf "Converts a type to a type that is lower in the hierarchy." )
    /// Delimits a typed code quotation.
    /// (Originally from /src/fsharp/FSComp.txt:1426)
    static member keywordDescriptionTypedQuotation() = (sprintf "Delimits a typed code quotation." )
    /// Delimits a untyped code quotation.
    /// (Originally from /src/fsharp/FSComp.txt:1427)
    static member keywordDescriptionUntypedQuotation() = (sprintf "Delimits a untyped code quotation." )
    /// %s '%s' not found in assembly '%s'. A possible cause may be a version incompatibility. You may need to explicitly reference the correct version of this assembly to allow all referenced components to use the correct version.
    /// (Originally from /src/fsharp/FSComp.txt:1428)
    static member itemNotFoundDuringDynamicCodeGen(a0 : System.String, a1 : System.String, a2 : System.String) = (3216, sprintf "%s '%s' not found in assembly '%s'. A possible cause may be a version incompatibility. You may need to explicitly reference the correct version of this assembly to allow all referenced components to use the correct version." a0 a1 a2)
    /// %s '%s' not found in type '%s' from assembly '%s'. A possible cause may be a version incompatibility. You may need to explicitly reference the correct version of this assembly to allow all referenced components to use the correct version.
    /// (Originally from /src/fsharp/FSComp.txt:1429)
    static member itemNotFoundInTypeDuringDynamicCodeGen(a0 : System.String, a1 : System.String, a2 : System.String, a3 : System.String) = (3216, sprintf "%s '%s' not found in type '%s' from assembly '%s'. A possible cause may be a version incompatibility. You may need to explicitly reference the correct version of this assembly to allow all referenced components to use the correct version." a0 a1 a2 a3)
    /// is
    /// (Originally from /src/fsharp/FSComp.txt:1430)
    static member descriptionWordIs() = (sprintf "is" )
    /// This value is not a function and cannot be applied.
    /// (Originally from /src/fsharp/FSComp.txt:1431)
    static member notAFunction() = (sprintf "This value is not a function and cannot be applied." )
    /// This value is not a function and cannot be applied. Did you intend to access the indexer via %s.[index] instead?
    /// (Originally from /src/fsharp/FSComp.txt:1432)
    static member notAFunctionButMaybeIndexerWithName(a0 : System.String) = (sprintf "This value is not a function and cannot be applied. Did you intend to access the indexer via %s.[index] instead?" a0)
    /// This expression is not a function and cannot be applied. Did you intend to access the indexer via expr.[index] instead?
    /// (Originally from /src/fsharp/FSComp.txt:1433)
    static member notAFunctionButMaybeIndexer() = (sprintf "This expression is not a function and cannot be applied. Did you intend to access the indexer via expr.[index] instead?" )
    /// 
    /// (Originally from /src/fsharp/FSComp.txt:1434)
    static member notAFunctionButMaybeIndexerErrorCode() = (3217, sprintf "" )
    /// This value is not a function and cannot be applied. Did you forget to terminate a declaration?
    /// (Originally from /src/fsharp/FSComp.txt:1435)
    static member notAFunctionButMaybeDeclaration() = (sprintf "This value is not a function and cannot be applied. Did you forget to terminate a declaration?" )
    /// The argument names in the signature '%s' and implementation '%s' do not match. The argument name from the signature file will be used. This may cause problems when debugging or profiling.
    /// (Originally from /src/fsharp/FSComp.txt:1436)
    static member ArgumentsInSigAndImplMismatch(a0 : System.String, a1 : System.String) = (3218, sprintf "The argument names in the signature '%s' and implementation '%s' do not match. The argument name from the signature file will be used. This may cause problems when debugging or profiling." a0 a1)
    /// An error occurred while reading the F# metadata of assembly '%s'. A reserved construct was utilized. You may need to upgrade your F# compiler or use an earlier version of the assembly that doesn't make use of a specific construct.
    /// (Originally from /src/fsharp/FSComp.txt:1437)
    static member pickleUnexpectedNonZero(a0 : System.String) = (3219, sprintf "An error occurred while reading the F# metadata of assembly '%s'. A reserved construct was utilized. You may need to upgrade your F# compiler or use an earlier version of the assembly that doesn't make use of a specific construct." a0)
    /// This method or property is not normally used from F# code, use an explicit tuple pattern for deconstruction instead.
    /// (Originally from /src/fsharp/FSComp.txt:1438)
    static member tcTupleMemberNotNormallyUsed() = (3220, sprintf "This method or property is not normally used from F# code, use an explicit tuple pattern for deconstruction instead." )
    /// This expression returns a value of type '%s' but is implicitly discarded. Consider using 'let' to bind the result to a name, e.g. 'let result = expression'. If you intended to use the expression as a value in the sequence then use an explicit 'yield'.
    /// (Originally from /src/fsharp/FSComp.txt:1439)
    static member implicitlyDiscardedInSequenceExpression(a0 : System.String) = (3221, sprintf "This expression returns a value of type '%s' but is implicitly discarded. Consider using 'let' to bind the result to a name, e.g. 'let result = expression'. If you intended to use the expression as a value in the sequence then use an explicit 'yield'." a0)
    /// This expression returns a value of type '%s' but is implicitly discarded. Consider using 'let' to bind the result to a name, e.g. 'let result = expression'. If you intended to use the expression as a value in the sequence then use an explicit 'yield!'.
    /// (Originally from /src/fsharp/FSComp.txt:1440)
    static member implicitlyDiscardedSequenceInSequenceExpression(a0 : System.String) = (3222, sprintf "This expression returns a value of type '%s' but is implicitly discarded. Consider using 'let' to bind the result to a name, e.g. 'let result = expression'. If you intended to use the expression as a value in the sequence then use an explicit 'yield!'." a0)
    /// The file '%s' changed on disk unexpectedly, please reload.
    /// (Originally from /src/fsharp/FSComp.txt:1441)
    static member ilreadFileChanged(a0 : System.String) = (3223, sprintf "The file '%s' changed on disk unexpectedly, please reload." a0)
    /// The byref pointer is readonly, so this write is not permitted.
    /// (Originally from /src/fsharp/FSComp.txt:1442)
    static member writeToReadOnlyByref() = (3224, sprintf "The byref pointer is readonly, so this write is not permitted." )
    /// A ReadOnly attribute has been applied to a struct type with a mutable field.
    /// (Originally from /src/fsharp/FSComp.txt:1443)
    static member readOnlyAttributeOnStructWithMutableField() = (3225, sprintf "A ReadOnly attribute has been applied to a struct type with a mutable field." )
    /// A byref pointer returned by a function or method is implicitly dereferenced as of F# 4.5. To acquire the return value as a pointer, use the address-of operator, e.g. '&f(x)' or '&obj.Method(arg1, arg2)'.
    /// (Originally from /src/fsharp/FSComp.txt:1444)
    static member tcByrefReturnImplicitlyDereferenced() = (3226, sprintf "A byref pointer returned by a function or method is implicitly dereferenced as of F# 4.5. To acquire the return value as a pointer, use the address-of operator, e.g. '&f(x)' or '&obj.Method(arg1, arg2)'." )
    /// A type annotated with IsByRefLike must also be a struct. Consider adding the [<Struct>] attribute to the type.
    /// (Originally from /src/fsharp/FSComp.txt:1445)
    static member tcByRefLikeNotStruct() = (3227, sprintf "A type annotated with IsByRefLike must also be a struct. Consider adding the [<Struct>] attribute to the type." )
    /// The address of a value returned from the expression cannot be used at this point. This is to ensure the address of the local value does not escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:1446)
    static member chkNoByrefAddressOfValueFromExpression() = (3228, sprintf "The address of a value returned from the expression cannot be used at this point. This is to ensure the address of the local value does not escape its scope." )
    /// This value can't be assigned because the target '%s' may refer to non-stack-local memory, while the expression being assigned is assessed to potentially refer to stack-local memory. This is to help prevent pointers to stack-bound memory escaping their scope.
    /// (Originally from /src/fsharp/FSComp.txt:1447)
    static member chkNoWriteToLimitedSpan(a0 : System.String) = (3229, sprintf "This value can't be assigned because the target '%s' may refer to non-stack-local memory, while the expression being assigned is assessed to potentially refer to stack-local memory. This is to help prevent pointers to stack-bound memory escaping their scope." a0)
    /// A value defined in a module must be mutable in order to take its address, e.g. 'let mutable x = ...'
    /// (Originally from /src/fsharp/FSComp.txt:1448)
    static member tastValueMustBeLocal() = (3230, sprintf "A value defined in a module must be mutable in order to take its address, e.g. 'let mutable x = ...'" )
    /// A type annotated with IsReadOnly must also be a struct. Consider adding the [<Struct>] attribute to the type.
    /// (Originally from /src/fsharp/FSComp.txt:1449)
    static member tcIsReadOnlyNotStruct() = (3231, sprintf "A type annotated with IsReadOnly must also be a struct. Consider adding the [<Struct>] attribute to the type." )
    /// Struct members cannot return the address of fields of the struct by reference
    /// (Originally from /src/fsharp/FSComp.txt:1450)
    static member chkStructsMayNotReturnAddressesOfContents() = (3232, sprintf "Struct members cannot return the address of fields of the struct by reference" )
    /// The function or method call cannot be used at this point, because one argument that is a byref of a non-stack-local Span or IsByRefLike type is used with another argument that is a stack-local Span or IsByRefLike type. This is to ensure the address of the local value does not escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:1451)
    static member chkNoByrefLikeFunctionCall() = (3233, sprintf "The function or method call cannot be used at this point, because one argument that is a byref of a non-stack-local Span or IsByRefLike type is used with another argument that is a stack-local Span or IsByRefLike type. This is to ensure the address of the local value does not escape its scope." )
    /// The Span or IsByRefLike variable '%s' cannot be used at this point. This is to ensure the address of the local value does not escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:1452)
    static member chkNoSpanLikeVariable(a0 : System.String) = (3234, sprintf "The Span or IsByRefLike variable '%s' cannot be used at this point. This is to ensure the address of the local value does not escape its scope." a0)
    /// A Span or IsByRefLike value returned from the expression cannot be used at ths point. This is to ensure the address of the local value does not escape its scope.
    /// (Originally from /src/fsharp/FSComp.txt:1453)
    static member chkNoSpanLikeValueFromExpression() = (3235, sprintf "A Span or IsByRefLike value returned from the expression cannot be used at ths point. This is to ensure the address of the local value does not escape its scope." )
    /// Cannot take the address of the value returned from the expression. Assign the returned value to a let-bound value before taking the address.
    /// (Originally from /src/fsharp/FSComp.txt:1454)
    static member tastCantTakeAddressOfExpression() = (3236, sprintf "Cannot take the address of the value returned from the expression. Assign the returned value to a let-bound value before taking the address." )
    /// Cannot call the byref extension method '%s. The first parameter requires the value to be mutable or a non-readonly byref type.
    /// (Originally from /src/fsharp/FSComp.txt:1455)
    static member tcCannotCallExtensionMethodInrefToByref(a0 : System.String) = (3237, sprintf "Cannot call the byref extension method '%s. The first parameter requires the value to be mutable or a non-readonly byref type." a0)
    /// Byref types are not allowed to have optional type extensions.
    /// (Originally from /src/fsharp/FSComp.txt:1456)
    static member tcByrefsMayNotHaveTypeExtensions() = (3238, sprintf "Byref types are not allowed to have optional type extensions." )
    /// Cannot partially apply the extension method '%s' because the first parameter is a byref type.
    /// (Originally from /src/fsharp/FSComp.txt:1457)
    static member tcCannotPartiallyApplyExtensionMethodForByref(a0 : System.String) = (3239, sprintf "Cannot partially apply the extension method '%s' because the first parameter is a byref type." a0)
    /// This type does not inherit Attribute, it will not work correctly with other .NET languages.
    /// (Originally from /src/fsharp/FSComp.txt:1458)
    static member tcTypeDoesNotInheritAttribute() = (3242, sprintf "This type does not inherit Attribute, it will not work correctly with other .NET languages." )
    /// Invalid anonymous record expression
    /// (Originally from /src/fsharp/FSComp.txt:1459)
    static member parsInvalidAnonRecdExpr() = (3243, sprintf "Invalid anonymous record expression" )
    /// Invalid anonymous record type
    /// (Originally from /src/fsharp/FSComp.txt:1460)
    static member parsInvalidAnonRecdType() = (3244, sprintf "Invalid anonymous record type" )
    /// The input to a copy-and-update expression that creates an anonymous record must be either an anonymous record or a record
    /// (Originally from /src/fsharp/FSComp.txt:1461)
    static member tcCopyAndUpdateNeedsRecordType() = (3245, sprintf "The input to a copy-and-update expression that creates an anonymous record must be either an anonymous record or a record" )
    /// The parameter '%s' has an invalid type '%s'. This is not permitted by the rules of Common IL.
    /// (Originally from /src/fsharp/FSComp.txt:1462)
    static member chkInvalidFunctionParameterType(a0 : System.String, a1 : System.String) = (3300, sprintf "The parameter '%s' has an invalid type '%s'. This is not permitted by the rules of Common IL." a0 a1)
    /// The function or method has an invalid return type '%s'. This is not permitted by the rules of Common IL.
    /// (Originally from /src/fsharp/FSComp.txt:1463)
    static member chkInvalidFunctionReturnType(a0 : System.String) = (3301, sprintf "The function or method has an invalid return type '%s'. This is not permitted by the rules of Common IL." a0)
    /// Use reference assemblies for .NET framework references when available (Enabled by default).
    /// (Originally from /src/fsharp/FSComp.txt:1464)
    static member useSdkRefs() = (sprintf "Use reference assemblies for .NET framework references when available (Enabled by default)." )
