module SqlWhiteboard.Lexical.Tests.SymbolTests

open NUnit.Framework
open SqlWhiteboard.Lexical

[<Test>]
let ``Symbol Possibilities has one answer for left parentheses``() = 
  let symbolList = [| Punctuation.LeftParentheses |]
  let possibilities = SymbolModule.GetPossibilities symbolList
  Assert.AreEqual(1, possibilities.Length)
  let (symbol, punctuation) = possibilities.[0]
  Assert.AreEqual(Symbol.LeftScope, symbol)
  Assert.AreEqual(Punctuation.LeftParentheses, punctuation.[0])
