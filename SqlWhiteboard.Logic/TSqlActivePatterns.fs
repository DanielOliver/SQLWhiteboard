module SqlWhiteboard.Logic.TSqlActivePatterns

open Microsoft.SqlServer.TransactSql.ScriptDom

let MatchTSqlStatement(statement : TSqlStatement) = 
  match statement with
  | :? SelectStatement as x -> TSqlStatement_.SelectStatement_ x
  | :? UpdateStatement as x -> TSqlStatement_.UpdateStatement_ x
  | _ -> TSqlStatement_.UnknownStatement_ statement

let MatchQueryExpression(queryExpression : QueryExpression) = 
  match queryExpression with
  | :? BinaryQueryExpression as x -> QueryExpression_.BinaryQueryExpression_ x
  | :? QueryParenthesisExpression as x -> QueryExpression_.QueryParenthesisExpression_ x
  | :? QuerySpecification as x -> QueryExpression_.QuerySpecification_ x
  | _ -> failwithf "Unknown type %s" (queryExpression.GetType().Name)

let MatchTableReference(table : TableReference) = 
  match table with
  | :? JoinParenthesisTableReference as x -> TableReference_.JoinParenthesisTableReference_ x
  | :? JoinTableReference as x -> TableReference_.JoinTableReference_ x
  | :? OdbcQualifiedJoinTableReference as x -> TableReference_.OdbcQualifiedJoinTableReference_ x
  | :? TableReferenceWithAlias as x -> TableReference_.TableReferenceWithAlias_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)

let MatchJoinTableReference(table : JoinTableReference) = 
  match table with
  | :? QualifiedJoin as x -> JoinTableReference_.QualifiedJoin_ x
  | :? UnqualifiedJoin as x -> JoinTableReference_.UnqualifiedJoin_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)

let MatchTableReferenceWithAlias(table : TableReferenceWithAlias) = 
  match table with
  | :? AdHocTableReference as x -> AdHocTableReference_ x
  | :? BuiltInFunctionTableReference as x -> BuiltInFunctionTableReference_ x
  | :? FullTextTableReference as x -> FullTextTableReference_ x
  | :? InternalOpenRowset as x -> InternalOpenRowset_ x
  | :? NamedTableReference as x -> NamedTableReference_ x
  | :? OpenQueryTableReference as x -> OpenQueryTableReference_ x
  | :? OpenRowsetTableReference as x -> OpenRowsetTableReference_ x
  | :? OpenXmlTableReference as x -> OpenXmlTableReference_ x
  | :? PivotedTableReference as x -> PivotedTableReference_ x
  | :? SemanticTableReference as x -> SemanticTableReference_ x
  | :? TableReferenceWithAliasAndColumns as x -> TableReferenceWithAliasAndColumns_ x
  | :? UnpivotedTableReference as x -> UnpivotedTableReference_ x
  | :? VariableTableReference as x -> VariableTableReference_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)
