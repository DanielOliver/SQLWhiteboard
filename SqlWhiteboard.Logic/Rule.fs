namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom
open SqlWhiteboard.Logic

type Rule = 
  { Name : string
    Description : string
    GetWarnings : TSqlScript -> RuleWarning array }

