module SqlWhiteboard.Rules.Tests.UpdateStatementWhereTests

open NUnit.Framework

let private rule = SqlWhiteboard.Rules.UpdateStatementWhere().AsRule()
let private getWarnings = CreateEngine rule

[<Test>]
let ``UpdateStatementWhere should catch a simple update``() = 
  let warnings = getWarnings "UPDATE People SET FirstName = 'Daniel'"
  Assert.IsNotEmpty warnings

[<Test>]
let ``UpdateStatementWhere should allow a simple update with where clause``() = 
  let warnings = getWarnings "UPDATE People SET FirstName = 'Daniel' WHERE ID = 5"
  Assert.IsEmpty warnings

[<Test>]
let ``UpdateStatementWhere should catch a simple from clause``() = 
  let warnings = getWarnings "UPDATE p SET FirstName = 'Daniel' FROM People"
  Assert.IsNotEmpty warnings
  
[<Test>]
let ``UpdateStatementWhere should catch a subquery in from clause``() = 
  let warnings = getWarnings "UPDATE p SET FirstName = 'Daniel' FROM (SELECT * FROM People) p"
  Assert.IsNotEmpty warnings
