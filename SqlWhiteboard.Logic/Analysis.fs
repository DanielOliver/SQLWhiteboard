module SqlWhiteboard.Logic.Analysis

open Microsoft.SqlServer.TransactSql.ScriptDom
open TSqlActivePatterns

let PrintIdentifiers(identifiers : Identifier seq) = System.String.Join(".", identifiers |> Seq.map (fun t -> t.Value))

let rec PrintTables (table : TableReference) (indent : string) = 
  match MatchTableReference table with
  | JoinTableReference_(x) -> 
    PrintTables x.FirstTableReference (indent + "  ")
    match MatchJoinTableReference x with
    | QualifiedJoin_(y) -> printfn "%sJoin Type %s" indent (y.QualifiedJoinType.ToString())
    | UnqualifiedJoin_(y) -> printfn "%sJoin Type %s" indent (y.UnqualifiedJoinType.ToString())
    PrintTables x.SecondTableReference (indent + "  ")
  | JoinParenthesisTableReference_(x) -> failwith "Not implemented yet"
  | OdbcQualifiedJoinTableReference_(x) -> failwith "Not implemented yet"
  | TableReferenceWithAlias_(x) -> 
    match MatchTableReferenceWithAlias x with
    | AdHocTableReference_(_) -> failwith "Not implemented yet"
    | BuiltInFunctionTableReference_(_) -> failwith "Not implemented yet"
    | FullTextTableReference_(_) -> failwith "Not implemented yet"
    | InternalOpenRowset_(_) -> failwith "Not implemented yet"
    | NamedTableReference_(y) -> 
      printfn "%sNamedTableReference: %s" indent (y.SchemaObject.Identifiers |> PrintIdentifiers)
      if not (isNull y.Alias) then printfn "%s   Alias: %s" indent y.Alias.Value
    | OpenQueryTableReference_(_) -> failwith "Not implemented yet"
    | OpenRowsetTableReference_(_) -> failwith "Not implemented yet"
    | OpenXmlTableReference_(_) -> failwith "Not implemented yet"
    | PivotedTableReference_(_) -> failwith "Not implemented yet"
    | SemanticTableReference_(_) -> failwith "Not implemented yet"
    | TableReferenceWithAliasAndColumns_(_) -> failwith "Not implemented yet"
    | UnpivotedTableReference_(_) -> failwith "Not implemented yet"
    | VariableTableReference_(_) -> failwith "Not implemented yet"

let ParseStatement(statement : TSqlStatement) = 
  let text = 
    statement.ScriptTokenStream
    |> Seq.map (fun t -> t.Text)
    |> Seq.fold (+) System.String.Empty
  match MatchTSqlStatement statement with
  | UpdateStatement_(x) -> printfn "UPDATE Statement: %s" text
  | SelectStatement_(x) -> 
    printfn "SELECT Statement: %s" text
    match MatchQueryExpression x.QueryExpression with
    | QuerySpecification_(y) -> 
      printfn "SELECT Query Tables:"
      for table in y.FromClause.TableReferences do
        PrintTables table System.String.Empty
    | QueryParenthesisExpression_(y) -> printfn "PARENTHESES Query"
    | BinaryQueryExpression_(y) -> printfn "UNION Query"
  | _ -> ()

let ParseBatch(batch : TSqlBatch) = 
  for statement in batch.Statements do
    ParseStatement statement

let ParseScript(script : TSqlScript) = 
  for batch in script.Batches do
    ParseBatch batch
