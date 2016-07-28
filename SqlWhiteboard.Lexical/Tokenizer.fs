namespace SqlWhiteboard.Lexical

open System

type private CharacterTokenTypes =
  | Letter
  | Digit
  | Punctuation
  | WhiteSpace


type Tokenizer(lineNumber: int, line: string) =
  let standardizeWhitespace input = System.Text.RegularExpressions.Regex.Replace(input, "\s+", " ")
  
  let mutable currentColumn = -1
  let mutable currentString = String.Empty

  member this.PArse = line


  

