module SqlWhiteboard.Core.ReflectionTests

open NUnit.Framework

type UnionTestCase = 
  | One
  | Two

[<Test>]
let ``Union Reflection should return cases``() = 
  Assert.IsNotEmpty(SqlWhiteboard.Core.Reflection.GetUnionCases<UnionTestCase>())

[<Test>]
let ``Union Reflection should recognize invalid types``() = 
  Assert.Throws<System.Exception>(fun () -> SqlWhiteboard.Core.Reflection.GetUnionCases<int>() |> ignore) |> ignore
