module SqlWhiteboard.Rules.RuleFactory

open SqlWhiteboard.Logic
///Complicating it because I can
let inline private createVisitorRule< ^T when ^T : (member AsRule : unit -> Rule) and ^T : (new : unit -> ^T)>() = 
  let x = new ^T()
  (^T : (member AsRule : unit -> Rule) x)

let GetAllRules() = 
  [| createVisitorRule<UpdateStatementWhere>()
     createVisitorRule<SelectStatementTop>() |]
