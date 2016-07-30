namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom

type RuleEngineResults = 
  { ParseErrors : System.Collections.Generic.IList<ParseError>
    Warnings : RuleWarning array }

type RuleEngine(rules : Rule array) = 
  
  ///Gets warnings on final results
  member this.GetWarnings(script : TSqlScript) = rules |> Array.collect (fun rule -> rule.GetWarnings script)
  
  ///Uses the given TSqlParser
  member this.GetWarnings(text : string, parser : #TSqlParser) = 
    use reader = new System.IO.StringReader(text)
    match parser.Parse reader with
    | fragment, parseErrors -> 
      let warnings = this.GetWarnings(fragment :?> TSqlScript)
      { RuleEngineResults.ParseErrors = parseErrors
        Warnings = warnings }
  
  ///Uses the default TSql120Parser
  member this.GetWarnings(text : string) = 
    let parser = new TSql120Parser(true)
    use reader = new System.IO.StringReader(text)
    match parser.Parse reader with
    | fragment, parseErrors -> 
      let warnings = this.GetWarnings(fragment :?> TSqlScript)
      { RuleEngineResults.ParseErrors = parseErrors
        Warnings = warnings }
