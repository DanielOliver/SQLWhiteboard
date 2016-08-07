namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom

type RuleEngineResults = 
  { ParseErrors : System.Collections.Generic.IList<ParseError>
    Warnings : RuleWarning array }

type RuleEngine(rules : Rule array, parser : TSqlParser) = 
  
  ///If less than this many rules, do not run in parallel.
  let _parallelCutoffPoint = 12

  new (rules: Rule array) = RuleEngine(rules, new TSql120Parser(true))
  new () = RuleEngine([||])
  
  ///Gets warnings on final results
  member this.GetWarnings(script : TSqlScript) = 
    if rules.Length < _parallelCutoffPoint then rules |> Array.collect (fun rule -> rule.GetWarnings script)
    else rules |> Array.Parallel.collect (fun rule -> rule.GetWarnings script)
  
  ///Uses the given TSqlParser
  member this.GetWarnings(text : string) = 
    use reader = new System.IO.StringReader(text)
    match parser.Parse reader with
    | fragment, parseErrors -> 
      let warnings = this.GetWarnings(fragment :?> TSqlScript)
      { RuleEngineResults.ParseErrors = parseErrors
        Warnings = warnings }
  
  ///Returns true if this text is parsable without errors as TSQL
  member this.IsValidTSQL(text : string) = 
    use reader = new System.IO.StringReader(text)
    match parser.Parse reader with
    | _, parseErrors -> parseErrors.Count = 0
