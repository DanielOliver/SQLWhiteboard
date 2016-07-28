module SqlWhiteboard.Lexical.Tests.PunctuationTests

open SqlWhiteboard.Lexical
open NUnit.Framework

[<Test>]
let ``All punctuation union cases have a defined character mapping``() = 
  let mappedValues = PunctuationModule.PunctuationLookup.Values
  let punctuationCases = PunctuationModule.GetPunctuationCases()
  for case in punctuationCases do
    Assert.IsTrue(mappedValues.Contains(case))

[<Test>]
let ``Punctuation parsing has a failure and success case``() = 
  Assert.AreEqual(PunctuationModule.ParsePunctuation ',', Some(Punctuation.Comma))
  Assert.AreEqual(PunctuationModule.ParsePunctuation 'a', None)
