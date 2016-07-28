module SqlWhiteboard.Lexical.Tests.TSQLKeywordTests

open SqlWhiteboard.Lexical
open NUnit.Framework

[<Test>]
let ``All tsql keyword union cases have a defined string mapping``() = 
  let mappedValues = set TSQLKeywordModule.TSQLKeywordLookup.Values
  let tsqlKeywordCases = TSQLKeywordModule.GetTSQLKeywordCases()
  for case in tsqlKeywordCases do
    Assert.IsTrue(mappedValues.Contains(case))
    
[<Test>]
let ``TSQL Keyword parsing has a failure and success case``() = 
  Assert.AreEqual(Some(TSQLKeyword.SELECT), TSQLKeywordModule.ParseTSQLKeyword "SELECT")
  Assert.AreEqual(None, TSQLKeywordModule.ParseTSQLKeyword "DANIEL")
  