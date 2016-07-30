module SqlWhiteboard.Rules.Tests.SelectStatementTopTests

open NUnit.Framework

let private rule = SqlWhiteboard.Rules.SelectStatementTop().AsRule()
let private getWarnings = CreateEngine rule

[<Test>]
let ``SelectStatementTop should catch a simple query``() = 
  let sql = "SELECT TOP 50 * FROM People"
  let warnings = getWarnings sql
  Assert.IsNotEmpty(warnings, sql)

[<Test>]
let ``SelectStatementTop should allow a valid simple query ORDER BY ``() = 
  let sql = "SELECT TOP 50 * FROM People ORDER BY FirstName"
  let warnings = getWarnings sql
  Assert.IsEmpty(warnings, sql)

[<Test>]
let ``SelectStatementTop should allow a valid simple query``() = 
  let sql = "SELECT * FROM People"
  let warnings = getWarnings sql
  Assert.IsEmpty(warnings, sql)

[<Test>]
let ``SelectStatementTop should catch a UNION``() = 
  let first = "SELECT TOP 50 FirstName FROM People"
  let second = "SELECT FirstName FROM Employees"
  let union = first + " UNION " + second
  Assert.IsNotEmpty(getWarnings first, first)
  Assert.IsEmpty(getWarnings second, second)
  Assert.IsNotEmpty(getWarnings union, union)

[<Test>]
let ``SelectStatementTop should catch nested queries``() = 
  let first = "SELECT TOP 50 FirstName FROM People"
  let second = "SELECT FirstName FROM Employees"
  let union = "SELECT * FROM ( " + first + " UNION " + second + ") p"
  let third = "SELECT TOP 500  FirstName From Customers ORDER BY FirstName"
  let intersect = "SELECT * FROM ( " + union + " INTERSECT " + third + ") p"
  Assert.IsNotEmpty(getWarnings first, first)
  Assert.IsEmpty(getWarnings second, second)
  Assert.IsNotEmpty(getWarnings union, union)
  Assert.IsEmpty(getWarnings third, third)
  Assert.IsNotEmpty(getWarnings intersect, intersect)
