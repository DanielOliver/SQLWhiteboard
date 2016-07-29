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

let MatchTableReferenceWithAliasAndColumns(table : TableReferenceWithAliasAndColumns) = 
  match table with
  | :? BulkOpenRowset as x -> BulkOpenRowset_ x
  | :? ChangeTableChangesTableReference as x -> TableReferenceWithAliasAndColumns_.ChangeTableChangesTableReference_ x
  | :? ChangeTableVersionTableReference as x -> TableReferenceWithAliasAndColumns_.ChangeTableVersionTableReference_ x
  | :? DataModificationTableReference as x -> TableReferenceWithAliasAndColumns_.DataModificationTableReference_ x
  | :? InlineDerivedTable as x -> TableReferenceWithAliasAndColumns_.InlineDerivedTable_ x
  | :? QueryDerivedTable as x -> TableReferenceWithAliasAndColumns_.QueryDerivedTable_ x
  | :? SchemaObjectFunctionTableReference as x -> 
    TableReferenceWithAliasAndColumns_.SchemaObjectFunctionTableReference_ x
  | :? VariableMethodCallTableReference as x -> TableReferenceWithAliasAndColumns_.VariableMethodCallTableReference_ x

let MatchTableReferenceWithAlias(table : TableReferenceWithAlias) = 
  match table with
  | :? AdHocTableReference as x -> TableReferenceWithAlias_.AdHocTableReference_ x
  | :? BuiltInFunctionTableReference as x -> TableReferenceWithAlias_.BuiltInFunctionTableReference_ x
  | :? FullTextTableReference as x -> TableReferenceWithAlias_.FullTextTableReference_ x
  | :? InternalOpenRowset as x -> TableReferenceWithAlias_.InternalOpenRowset_ x
  | :? NamedTableReference as x -> TableReferenceWithAlias_.NamedTableReference_ x
  | :? OpenQueryTableReference as x -> TableReferenceWithAlias_.OpenQueryTableReference_ x
  | :? OpenRowsetTableReference as x -> TableReferenceWithAlias_.OpenRowsetTableReference_ x
  | :? OpenXmlTableReference as x -> TableReferenceWithAlias_.OpenXmlTableReference_ x
  | :? PivotedTableReference as x -> TableReferenceWithAlias_.PivotedTableReference_ x
  | :? SemanticTableReference as x -> TableReferenceWithAlias_.SemanticTableReference_ x
  | :? TableReferenceWithAliasAndColumns as x -> TableReferenceWithAlias_.TableReferenceWithAliasAndColumns_ x
  | :? UnpivotedTableReference as x -> TableReferenceWithAlias_.UnpivotedTableReference_ x
  | :? VariableTableReference as x -> TableReferenceWithAlias_.VariableTableReference_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)

let MatchJoinTableReference(table : JoinTableReference) = 
  match table with
  | :? QualifiedJoin as x -> JoinTableReference_.QualifiedJoin_ x
  | :? UnqualifiedJoin as x -> JoinTableReference_.UnqualifiedJoin_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)

let MatchTableReference(table : TableReference) = 
  match table with
  | :? JoinParenthesisTableReference as x -> TableReference_.JoinParenthesisTableReference_ x
  | :? JoinTableReference as x -> TableReference_.JoinTableReference_ x
  | :? OdbcQualifiedJoinTableReference as x -> TableReference_.OdbcQualifiedJoinTableReference_ x
  | :? TableReferenceWithAlias as x -> TableReference_.TableReferenceWithAlias_ x
  | _ -> failwithf "Unknown type %s" (table.GetType().Name)
