namespace SqlWhiteboard.Logic

open Microsoft.SqlServer.TransactSql.ScriptDom

type TSqlStatement_ = 
  | SelectStatement_ of SelectStatement
  | UpdateStatement_ of UpdateStatement
  | UnknownStatement_ of TSqlStatement

type QueryExpression_ = 
  | BinaryQueryExpression_ of BinaryQueryExpression
  | QueryParenthesisExpression_ of QueryParenthesisExpression
  | QuerySpecification_ of QuerySpecification

type TableReferenceWithAliasAndColumns_ = 
  | BulkOpenRowset_ of BulkOpenRowset
  | ChangeTableChangesTableReference_ of ChangeTableChangesTableReference
  | ChangeTableVersionTableReference_ of ChangeTableVersionTableReference
  | DataModificationTableReference_ of DataModificationTableReference
  | InlineDerivedTable_ of InlineDerivedTable
  | QueryDerivedTable_ of QueryDerivedTable
  | SchemaObjectFunctionTableReference_ of SchemaObjectFunctionTableReference
  | VariableMethodCallTableReference_ of VariableMethodCallTableReference

type TableReferenceWithAlias_ = 
  | AdHocTableReference_ of AdHocTableReference
  | BuiltInFunctionTableReference_ of BuiltInFunctionTableReference
  | FullTextTableReference_ of FullTextTableReference
  | InternalOpenRowset_ of InternalOpenRowset
  | NamedTableReference_ of NamedTableReference
  | OpenQueryTableReference_ of OpenQueryTableReference
  | OpenRowsetTableReference_ of OpenRowsetTableReference
  | OpenXmlTableReference_ of OpenXmlTableReference
  | PivotedTableReference_ of PivotedTableReference
  | SemanticTableReference_ of SemanticTableReference
  | TableReferenceWithAliasAndColumns_ of TableReferenceWithAliasAndColumns
  | UnpivotedTableReference_ of UnpivotedTableReference
  | VariableTableReference_ of VariableTableReference

type JoinTableReference_ = 
  | QualifiedJoin_ of QualifiedJoin
  | UnqualifiedJoin_ of UnqualifiedJoin

type TableReference_ = 
  | JoinParenthesisTableReference_ of JoinParenthesisTableReference
  | JoinTableReference_ of JoinTableReference
  | OdbcQualifiedJoinTableReference_ of OdbcQualifiedJoinTableReference
  | TableReferenceWithAlias_ of TableReferenceWithAlias
