﻿module SqlWhiteboard.Rules.Tests.UpdateStatementWhereTests

open NUnit.Framework

let private rule = SqlWhiteboard.Rules.UpdateStatementWhere().AsRule()
let private getWarnings = CreateEngine rule

[<Test>]
let ``UpdateStatementWhere should catch a simple update``() = 
  let sql = "UPDATE People SET FirstName = 'Daniel'"
  let warnings = getWarnings sql
  Assert.IsNotEmpty(warnings, sql)

[<Test>]
let ``UpdateStatementWhere should allow a simple update with where clause``() = 
  let sql = "UPDATE People SET FirstName = 'Daniel' WHERE ID = 5"
  let warnings = getWarnings sql
  Assert.IsEmpty(warnings, sql)

[<Test>]
let ``UpdateStatementWhere should catch a simple from clause``() = 
  let sql = "UPDATE p SET FirstName = 'Daniel' FROM People"
  let warnings = getWarnings sql
  Assert.IsNotEmpty(warnings, sql)

[<Test>]
let ``UpdateStatementWhere should catch a subquery in from clause``() = 
  let sql = "UPDATE p SET FirstName = 'Daniel' FROM (SELECT * FROM People) p"
  let warnings = getWarnings sql
  Assert.IsNotEmpty(warnings, sql)
