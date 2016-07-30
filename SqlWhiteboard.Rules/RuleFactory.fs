module SqlWhiteboard.Rules.RuleFactory

let GetAllRules() =
  [|  UpdateStatementWhere().AsRule()
      SelectStatementTop().AsRule()
  |]

