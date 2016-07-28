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
    |> dict
  
  let GetPossibilities(fragment : Punctuation array) = 
    let startsWith (complete : Punctuation array) = 
      0 = (complete
           |> Seq.take (fragment.Length)
           |> Seq.compareWith Operators.compare fragment)
    Combinations
    |> Seq.where (fun keyV -> startsWith keyV.Value)
    |> Seq.map (fun keyV -> keyV.Key)
    |> Seq.toArray
