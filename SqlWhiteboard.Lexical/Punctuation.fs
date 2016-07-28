namespace SqlWhiteboard.Lexical

type Punctuation = 
  | Comma
  | SemiColon
  | Colon
  | Period
  | LeftBracket
  | RightBracket
  | StarSymbol
  | LeftParentheses
  | RightParentheses
  | AtSymbol
  | Equals
  | Plus
  | Minus
  | LeftArrow
  | RightArrow
  | SingleQuote
  | DoubleQuote
  | ForwardSlash
  | BackwardsSlash
  | Underscore

module PunctuationModule = 
  ///Use for unit tests ONLY
  let GetPunctuationCases() = SqlWhiteboard.Core.Reflection.GetUnionCases<Punctuation>()
  
  let PunctuationLookup = 
    [| ',', Punctuation.Comma
       ';', Punctuation.SemiColon
       ':', Punctuation.Colon
       '.', Punctuation.Period
       '[', Punctuation.LeftBracket
       ']', Punctuation.RightBracket
       '*', Punctuation.StarSymbol
       '(', Punctuation.LeftParentheses
       ')', Punctuation.RightParentheses
       '@', Punctuation.AtSymbol
       '=', Punctuation.Equals
       '+', Punctuation.Plus
       '-', Punctuation.Minus
       '<', Punctuation.LeftArrow
       '>', Punctuation.RightArrow
       '\'', Punctuation.SingleQuote
       '"', Punctuation.DoubleQuote
       '/', Punctuation.ForwardSlash
       '\\', Punctuation.BackwardsSlash
       '_', Punctuation.Underscore |]
    |> dict
  
  ///Gets the appropriate Union Case from mapping, if any.
  let ParsePunctuation character = 
    match PunctuationLookup.TryGetValue character with
    | true, result -> Some(result)
    | _ -> None
