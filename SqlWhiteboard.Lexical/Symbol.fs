namespace SqlWhiteboard.Lexical

type Symbol = 
  | EqualOperator
  | Separator
  | LeftScope
  | RightScope
  | LessThanOrEqualToOperator

module SymbolModule = 
  let Combinations = 
    [| Symbol.EqualOperator, [| Punctuation.Equals |]
       Symbol.LessThanOrEqualToOperator, [| Punctuation.LeftArrow; Punctuation.Equals |]
       Symbol.LeftScope, [| Punctuation.LeftParentheses |] |]
  
  let GetPossibilities(fragment : Punctuation array) = 
    let startsWith (complete : Punctuation array) = 
      0 = (complete
           |> Seq.take (fragment.Length)
           |> Seq.compareWith Operators.compare fragment)
    Combinations
    |> Seq.where (fun (symb, punc) -> startsWith punc)
    |> Seq.toArray
