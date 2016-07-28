module SqlWhiteboard.Core.Reflection

open FSharp.Reflection

///Generates the cases for a union.
///Only works if called within same project that union is defined (IE: before it gets translated to generic .NET)
///Each union cases should not require any arguments.
let inline GetUnionCases<'T>() = 
  let unionType = typeof<'T>
  match FSharpType.IsUnion(unionType, true) with
  | false -> failwithf "Type %s in assembly %s is not a union" unionType.Name unionType.Assembly.FullName
  | true -> 
    seq { 
      for rawCase in FSharpType.GetUnionCases(unionType, true) do
        yield (FSharpValue.MakeUnion(rawCase, [||]) :?> 'T)
    }
