namespace SqlWhiteboard.Rules 

open SqlWhiteboard.Logic
open Microsoft.SqlServer.TransactSql.ScriptDom

type UpdateStatementWhere() = 
  inherit VisitorRule("Update Statement Safety", "Update statement has a where clause")
  override this.Visit(statement : UpdateStatement) = 
    let spec = statement.UpdateSpecification
    if isNull spec.FromClause && isNull spec.WhereClause then
      let firstToken = statement.ScriptTokenStream.[0] 
      this.AddWarning(firstToken.Line, firstToken.Column, statement.FragmentLength, "Update statement is missing a where clause")
    ()
