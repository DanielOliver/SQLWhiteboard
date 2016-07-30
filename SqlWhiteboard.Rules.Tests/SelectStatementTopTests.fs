module SqlWhiteboard.Rules.Tests.SelectStatementTopTests

open NUnit.Framework

let private rule = SqlWhiteboard.Rules.SelectStatementTop().AsRule()
let private getWarnings = CreateEngine rule

[<Test>]
let ``SelectStatementTop should catch a simple query``() = 
  let warnings = getWarnings "SELECT TOP 50 * FROM People"
  Assert.IsNotEmpty warnings

[<Test>]
let ``SelectStatementTop should allow a valid simple query ORDER BY ``() = 
  let warnings = getWarnings "SELECT TOP 50 * FROM People ORDER BY FirstName"
  Assert.IsEmpty warnings
  
[<Test>]
let ``SelectStatementTop should allow a valid simple query``() = 
  let warnings = getWarnings "SELECT * FROM People"
  Assert.IsEmpty warnings

[<Test>]
let ``SelectStatementTop should catch a UNION``() = 
  let first = "SELECT TOP 50 FirstName FROM People"
  let second = "SELECT FirstName FROM Employees"
  let union = first + " UNION " + second
  Assert.IsNotEmpty (getWarnings first)
  Assert.IsEmpty (getWarnings second)
  Assert.IsNotEmpty (getWarnings union)
  
[<Test>]
let ``SelectStatementTop should catch nested queries``() = 
  let first = "SELECT TOP 50 FirstName FROM People"
  let second = "SELECT FirstName FROM Employees"
  let union = "SELECT * FROM ( " + first + " UNION " + second + ") p"
  let third = "SELECT TOP 500  FirstName From Customers ORDER BY FirstName"
  let intersect = "SELECT * FROM ( " + union + " INTERSECT " + third + ") p"

  let thirdWarnings = getWarnings third

  Assert.IsNotEmpty (getWarnings first, "1")
  Assert.IsEmpty (getWarnings second, "2")
  Assert.IsNotEmpty (getWarnings union, "3")
  Assert.IsEmpty (thirdWarnings, "4")
  Assert.IsNotEmpty (getWarnings intersect, "5")
