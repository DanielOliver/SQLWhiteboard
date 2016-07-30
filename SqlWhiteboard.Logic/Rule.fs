namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom
open SqlWhiteboard.Logic
open System


type Rule =
  { Name: string
    Description: string
    GetWarnings: TSqlScript -> RuleWarning array    
  }

type VisitorRule(?name: string, ?description: string) = 
  inherit TSqlFragmentVisitor()
  let mutable _warnings : RuleWarning list = []
  member this.AddWarning(warning) = _warnings <- (warning :: _warnings)
  member this.AddWarning(line, column, length, warning) = 
    let newWarning = 
      { RuleWarning.Line = line
        Column = column
        Length = length
        Warning = warning
      }
    _warnings <- (newWarning :: _warnings)
  member this.GetWarnings(script: TSqlScript) =
    _warnings <- []
    script.Accept this
    _warnings |> List.toArray
  member this.AsRule() =
    { Rule.Name = defaultArg name String.Empty
      Rule.Description = defaultArg description String.Empty
      GetWarnings = this.GetWarnings
    }
    