namespace SqlWhiteboard.Rules

open Microsoft.SqlServer.TransactSql.ScriptDom
open SqlWhiteboard.Logic
open SqlWhiteboard.Logic.TsqlMatchSubClass

type SelectStatementTop() = 
  inherit VisitorRule("Select Statement Top Clause", "SELECT TOP is useless without ORDER BY")
  override this.Visit(expression : QueryExpression) = 
    match MatchQueryExpression expression with
    | QuerySpecification_ x -> 
      if isNull x.OrderByClause && not (isNull x.TopRowFilter) then 
        let firstToken = x.TopRowFilter.ScriptTokenStream.[x.TopRowFilter.FirstTokenIndex]
        this.AddWarning
          (firstToken.Line, firstToken.Column, x.TopRowFilter.FragmentLength, 
           "ORDER BY should have matching TOP clause.")
    | BinaryQueryExpression_ x -> ()
    | QueryParenthesisExpression_ x -> ()
