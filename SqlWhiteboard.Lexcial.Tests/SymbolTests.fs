﻿module SqlWhiteboard.Lexical.Tests.SymbolTests

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

[<Test>]
let ``Symbol Possibilities has no answer for super crazy punctuation``() = 
  let symbolList = [| Punctuation.Plus; Punctuation.LeftArrow; Punctuation.DoubleQuote |]
  let possibilities = SymbolModule.GetPossibilities symbolList
  Assert.IsEmpty(possibilities)