module SqlWhiteboard.Lexical.Tests.ODBCKeywordTests


open SqlWhiteboard.Lexical
open NUnit.Framework

[<Test>]
let ``All odbc keyword union case have a defined string mapping``() = 
  let mappedValues = set ODBCKeywordModule.ODBCKeywordLookup.Values
  let odbcKeywordCases = ODBCKeywordModule.GetODBCKeywordCases()
  for case in odbcKeywordCases do
    Assert.IsTrue(mappedValues.Contains(case))
    
[<Test>]
let ``ODBC Keyword parsing has a failure and success case``() = 
  Assert.AreEqual(Some(ODBCKeyword.SELECT), ODBCKeywordModule.ParseODBCKeyword "SELECT")
  Assert.AreEqual(None, ODBCKeywordModule.ParseODBCKeyword "DANIEL")
  
[<Test>]
let ``ODBC Keyword parsing lists correct possibilities``() = 
  let possibilities = ODBCKeywordModule.GetPossibilities "ValUE"
  Assert.AreEqual(2, possibilities.Length)
  Assert.Contains(ODBCKeyword.VALUE, possibilities)
  Assert.Contains(ODBCKeyword.VALUES, possibilities)
