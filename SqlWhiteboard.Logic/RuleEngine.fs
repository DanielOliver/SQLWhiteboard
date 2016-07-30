namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom
open TsqlMatchSubClass


type RuleEngineResults =
  { ParseErrors: System.Collections.Generic.IList<ParseError>
    Warnings: RuleWarning array
  }

type RuleEngine(rules: Rule array) = 
  member this.GetWarnings (script: TSqlScript) =
    rules 
    |> Array.collect(fun rule -> rule.GetWarnings script)
        
  member this.GetWarnings (text: string, parser: #TSqlParser) =
    use reader = new System.IO.StringReader(text)
    match parser.Parse reader with
    | fragment, parseErrors ->
      let warnings = this.GetWarnings(fragment :?> TSqlScript)
      { RuleEngineResults.ParseErrors = parseErrors
        Warnings = warnings        
      }
