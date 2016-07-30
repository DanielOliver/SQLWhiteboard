namespace SqlWhiteboard.Rules

open Microsoft.SqlServer.TransactSql.ScriptDom
open SqlWhiteboard.Logic

type UpdateStatementWhere() = 
  inherit VisitorRule("Update Statement Safety", "Update statement has a where clause")
  override this.Visit(statement : UpdateStatement) = 
    let spec = statement.UpdateSpecification
    if isNull spec.WhereClause then 
      let firstToken = statement.ScriptTokenStream.[statement.FirstTokenIndex]
      this.AddWarning
        (firstToken.Line, firstToken.Column, statement.FragmentLength, "Update statement is missing a where clause")
