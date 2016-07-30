[<AutoOpen>]
module SqlWhiteboard.Rules.Tests.Helpers

let CreateEngine(rule) = 
  let rules = [| rule |]
  let ruleEngine = SqlWhiteboard.Logic.RuleEngine(rules)
  let getWarnings (sql : string) = (ruleEngine.GetWarnings sql).Warnings
  getWarnings
