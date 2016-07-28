﻿namespace SqlWhiteboard.Lexical

type TSQLKeyword = 
  | ADD
  | ALL
  | ALTER
  | AND
  | ANY
  | AS
  | ASC
  | AUTHORIZATION
  | BACKUP
  | BEGIN
  | BETWEEN
  | BREAK
  | BROWSE
  | BULK
  | BY
  | CASCADE
  | CASE
  | CHECK
  | CHECKPOINT
  | CLOSE
  | CLUSTERED
  | COALESCE
  | COLLATE
  | COLUMN
  | COMMIT
  | COMPUTE
  | CONSTRAINT
  | CONTAINS
  | CONTAINSTABLE
  | CONTINUE
  | CONVERT
  | CREATE
  | CROSS
  | CURRENT
  | CURRENT_DATE
  | CURRENT_TIME
  | CURRENT_TIMESTAMP
  | CURRENT_USER
  | CURSOR
  | DATABASE
  | DBCC
  | DEALLOCATE
  | DECLARE
  | DEFAULT
  | DELETE
  | DENY
  | DESC
  | DISK
  | DISTINCT
  | DISTRIBUTED
  | DOUBLE
  | DROP
  | DUMP
  | ELSE
  | END
  | ERRLVL
  | ESCAPE
  | EXCEPT
  | EXEC
  | EXECUTE
  | EXISTS
  | EXIT
  | EXTERNAL
  | FETCH
  | FILE
  | FILLFACTOR
  | FOR
  | FOREIGN
  | FREETEXT
  | FREETEXTTABLE
  | FROM
  | FULL
  | FUNCTION
  | GOTO
  | GRANT
  | GROUP
  | HAVING
  | HOLDLOCK
  | IDENTITY
  | IDENTITYCOL
  | IDENTITY_INSERT
  | IF
  | IN
  | INDEX
  | INNER
  | INSERT
  | INTERSECT
  | INTO
  | IS
  | JOIN
  | KEY
  | KILL
  | LEFT
  | LIKE
  | LINENO
  | LOAD
  | MERGE
  | NATIONAL
  | NOCHECK
  | NONCLUSTERED
  | NOT
  | NULL
  | NULLIF
  | OF
  | OFF
  | OFFSETS
  | ON
  | OPEN
  | OPENDATASOURCE
  | OPENQUERY
  | OPENROWSET
  | OPENXML
  | OPTION
  | OR
  | ORDER
  | OUTER
  | OVER
  | PERCENT
  | PIVOT
  | PLAN
  | PRECISION
  | PRIMARY
  | PRINT
  | PROC
  | PROCEDURE
  | PUBLIC
  | RAISERROR
  | READ
  | READTEXT
  | RECONFIGURE
  | REFERENCES
  | REPLICATION
  | RESTORE
  | RESTRICT
  | RETURN
  | REVERT
  | REVOKE
  | RIGHT
  | ROLLBACK
  | ROWCOUNT
  | ROWGUIDCOL
  | RULE
  | SAVE
  | SCHEMA
  | SECURITYAUDIT
  | SELECT
  | SEMANTICKEYPHRASETABLE
  | SEMANTICSIMILARITYDETAILSTABLE
  | SEMANTICSIMILARITYTABLE
  | SESSION_USER
  | SET
  | SETUSER
  | SHUTDOWN
  | SOME
  | STATISTICS
  | SYSTEM_USER
  | TABLE
  | TABLESAMPLE
  | TEXTSIZE
  | THEN
  | TO
  | TOP
  | TRAN
  | TRANSACTION
  | TRIGGER
  | TRUNCATE
  | TRY_CONVERT
  | TSEQUAL
  | UNION
  | UNIQUE
  | UNPIVOT
  | UPDATE
  | UPDATETEXT
  | USE
  | USER
  | VALUES
  | VARYING
  | VIEW
  | WAITFOR
  | WHEN
  | WHERE
  | WHILE
  | WITH
  | WITHIN_GROUP
  | WRITETEXT

module TSQLKeywordModule = 
  ///Use for unit tests ONLY
  let GetTSQLKeywordCases() = SqlWhiteboard.Core.Reflection.GetUnionCases<TSQLKeyword>()
  
  let TSQLKeywordLookup = 
    [| "ADD", TSQLKeyword.ADD
       "ALL", TSQLKeyword.ALL
       "ALTER", TSQLKeyword.ALTER
       "AND", TSQLKeyword.AND
       "ANY", TSQLKeyword.ANY
       "AS", TSQLKeyword.AS
       "ASC", TSQLKeyword.ASC
       "AUTHORIZATION", TSQLKeyword.AUTHORIZATION
       "BACKUP", TSQLKeyword.BACKUP
       "BEGIN", TSQLKeyword.BEGIN
       "BETWEEN", TSQLKeyword.BETWEEN
       "BREAK", TSQLKeyword.BREAK
       "BROWSE", TSQLKeyword.BROWSE
       "BULK", TSQLKeyword.BULK
       "BY", TSQLKeyword.BY
       "CASCADE", TSQLKeyword.CASCADE
       "CASE", TSQLKeyword.CASE
       "CHECK", TSQLKeyword.CHECK
       "CHECKPOINT", TSQLKeyword.CHECKPOINT
       "CLOSE", TSQLKeyword.CLOSE
       "CLUSTERED", TSQLKeyword.CLUSTERED
       "COALESCE", TSQLKeyword.COALESCE
       "COLLATE", TSQLKeyword.COLLATE
       "COLUMN", TSQLKeyword.COLUMN
       "COMMIT", TSQLKeyword.COMMIT
       "COMPUTE", TSQLKeyword.COMPUTE
       "CONSTRAINT", TSQLKeyword.CONSTRAINT
       "CONTAINS", TSQLKeyword.CONTAINS
       "CONTAINSTABLE", TSQLKeyword.CONTAINSTABLE
       "CONTINUE", TSQLKeyword.CONTINUE
       "CONVERT", TSQLKeyword.CONVERT
       "CREATE", TSQLKeyword.CREATE
       "CROSS", TSQLKeyword.CROSS
       "CURRENT", TSQLKeyword.CURRENT
       "CURRENT_DATE", TSQLKeyword.CURRENT_DATE
       "CURRENT_TIME", TSQLKeyword.CURRENT_TIME
       "CURRENT_TIMESTAMP", TSQLKeyword.CURRENT_TIMESTAMP
       "CURRENT_USER", TSQLKeyword.CURRENT_USER
       "CURSOR", TSQLKeyword.CURSOR
       "DATABASE", TSQLKeyword.DATABASE
       "DBCC", TSQLKeyword.DBCC
       "DEALLOCATE", TSQLKeyword.DEALLOCATE
       "DECLARE", TSQLKeyword.DECLARE
       "DEFAULT", TSQLKeyword.DEFAULT
       "DELETE", TSQLKeyword.DELETE
       "DENY", TSQLKeyword.DENY
       "DESC", TSQLKeyword.DESC
       "DISK", TSQLKeyword.DISK
       "DISTINCT", TSQLKeyword.DISTINCT
       "DISTRIBUTED", TSQLKeyword.DISTRIBUTED
       "DOUBLE", TSQLKeyword.DOUBLE
       "DROP", TSQLKeyword.DROP
       "DUMP", TSQLKeyword.DUMP
       "ELSE", TSQLKeyword.ELSE
       "END", TSQLKeyword.END
       "ERRLVL", TSQLKeyword.ERRLVL
       "ESCAPE", TSQLKeyword.ESCAPE
       "EXCEPT", TSQLKeyword.EXCEPT
       "EXEC", TSQLKeyword.EXEC
       "EXECUTE", TSQLKeyword.EXECUTE
       "EXISTS", TSQLKeyword.EXISTS
       "EXIT", TSQLKeyword.EXIT
       "EXTERNAL", TSQLKeyword.EXTERNAL
       "FETCH", TSQLKeyword.FETCH
       "FILE", TSQLKeyword.FILE
       "FILLFACTOR", TSQLKeyword.FILLFACTOR
       "FOR", TSQLKeyword.FOR
       "FOREIGN", TSQLKeyword.FOREIGN
       "FREETEXT", TSQLKeyword.FREETEXT
       "FREETEXTTABLE", TSQLKeyword.FREETEXTTABLE
       "FROM", TSQLKeyword.FROM
       "FULL", TSQLKeyword.FULL
       "FUNCTION", TSQLKeyword.FUNCTION
       "GOTO", TSQLKeyword.GOTO
       "GRANT", TSQLKeyword.GRANT
       "GROUP", TSQLKeyword.GROUP
       "HAVING", TSQLKeyword.HAVING
       "HOLDLOCK", TSQLKeyword.HOLDLOCK
       "IDENTITY", TSQLKeyword.IDENTITY
       "IDENTITYCOL", TSQLKeyword.IDENTITYCOL
       "IDENTITY_INSERT", TSQLKeyword.IDENTITY_INSERT
       "IF", TSQLKeyword.IF
       "IN", TSQLKeyword.IN
       "INDEX", TSQLKeyword.INDEX
       "INNER", TSQLKeyword.INNER
       "INSERT", TSQLKeyword.INSERT
       "INTERSECT", TSQLKeyword.INTERSECT
       "INTO", TSQLKeyword.INTO
       "IS", TSQLKeyword.IS
       "JOIN", TSQLKeyword.JOIN
       "KEY", TSQLKeyword.KEY
       "KILL", TSQLKeyword.KILL
       "LEFT", TSQLKeyword.LEFT
       "LIKE", TSQLKeyword.LIKE
       "LINENO", TSQLKeyword.LINENO
       "LOAD", TSQLKeyword.LOAD
       "MERGE", TSQLKeyword.MERGE
       "NATIONAL", TSQLKeyword.NATIONAL
       "NOCHECK", TSQLKeyword.NOCHECK
       "NONCLUSTERED", TSQLKeyword.NONCLUSTERED
       "NOT", TSQLKeyword.NOT
       "NULL", TSQLKeyword.NULL
       "NULLIF", TSQLKeyword.NULLIF
       "OF", TSQLKeyword.OF
       "OFF", TSQLKeyword.OFF
       "OFFSETS", TSQLKeyword.OFFSETS
       "ON", TSQLKeyword.ON
       "OPEN", TSQLKeyword.OPEN
       "OPENDATASOURCE", TSQLKeyword.OPENDATASOURCE
       "OPENQUERY", TSQLKeyword.OPENQUERY
       "OPENROWSET", TSQLKeyword.OPENROWSET
       "OPENXML", TSQLKeyword.OPENXML
       "OPTION", TSQLKeyword.OPTION
       "OR", TSQLKeyword.OR
       "ORDER", TSQLKeyword.ORDER
       "OUTER", TSQLKeyword.OUTER
       "OVER", TSQLKeyword.OVER
       "PERCENT", TSQLKeyword.PERCENT
       "PIVOT", TSQLKeyword.PIVOT
       "PLAN", TSQLKeyword.PLAN
       "PRECISION", TSQLKeyword.PRECISION
       "PRIMARY", TSQLKeyword.PRIMARY
       "PRINT", TSQLKeyword.PRINT
       "PROC", TSQLKeyword.PROC
       "PROCEDURE", TSQLKeyword.PROCEDURE
       "PUBLIC", TSQLKeyword.PUBLIC
       "RAISERROR", TSQLKeyword.RAISERROR
       "READ", TSQLKeyword.READ
       "READTEXT", TSQLKeyword.READTEXT
       "RECONFIGURE", TSQLKeyword.RECONFIGURE
       "REFERENCES", TSQLKeyword.REFERENCES
       "REPLICATION", TSQLKeyword.REPLICATION
       "RESTORE", TSQLKeyword.RESTORE
       "RESTRICT", TSQLKeyword.RESTRICT
       "RETURN", TSQLKeyword.RETURN
       "REVERT", TSQLKeyword.REVERT
       "REVOKE", TSQLKeyword.REVOKE
       "RIGHT", TSQLKeyword.RIGHT
       "ROLLBACK", TSQLKeyword.ROLLBACK
       "ROWCOUNT", TSQLKeyword.ROWCOUNT
       "ROWGUIDCOL", TSQLKeyword.ROWGUIDCOL
       "RULE", TSQLKeyword.RULE
       "SAVE", TSQLKeyword.SAVE
       "SCHEMA", TSQLKeyword.SCHEMA
       "SECURITYAUDIT", TSQLKeyword.SECURITYAUDIT
       "SELECT", TSQLKeyword.SELECT
       "SEMANTICKEYPHRASETABLE", TSQLKeyword.SEMANTICKEYPHRASETABLE
       "SEMANTICSIMILARITYDETAILSTABLE", TSQLKeyword.SEMANTICSIMILARITYDETAILSTABLE
       "SEMANTICSIMILARITYTABLE", TSQLKeyword.SEMANTICSIMILARITYTABLE
       "SESSION_USER", TSQLKeyword.SESSION_USER
       "SET", TSQLKeyword.SET
       "SETUSER", TSQLKeyword.SETUSER
       "SHUTDOWN", TSQLKeyword.SHUTDOWN
       "SOME", TSQLKeyword.SOME
       "STATISTICS", TSQLKeyword.STATISTICS
       "SYSTEM_USER", TSQLKeyword.SYSTEM_USER
       "TABLE", TSQLKeyword.TABLE
       "TABLESAMPLE", TSQLKeyword.TABLESAMPLE
       "TEXTSIZE", TSQLKeyword.TEXTSIZE
       "THEN", TSQLKeyword.THEN
       "TO", TSQLKeyword.TO
       "TOP", TSQLKeyword.TOP
       "TRAN", TSQLKeyword.TRAN
       "TRANSACTION", TSQLKeyword.TRANSACTION
       "TRIGGER", TSQLKeyword.TRIGGER
       "TRUNCATE", TSQLKeyword.TRUNCATE
       "TRY_CONVERT", TSQLKeyword.TRY_CONVERT
       "TSEQUAL", TSQLKeyword.TSEQUAL
       "UNION", TSQLKeyword.UNION
       "UNIQUE", TSQLKeyword.UNIQUE
       "UNPIVOT", TSQLKeyword.UNPIVOT
       "UPDATE", TSQLKeyword.UPDATE
       "UPDATETEXT", TSQLKeyword.UPDATETEXT
       "USE", TSQLKeyword.USE
       "USER", TSQLKeyword.USER
       "VALUES", TSQLKeyword.VALUES
       "VARYING", TSQLKeyword.VARYING
       "VIEW", TSQLKeyword.VIEW
       "WAITFOR", TSQLKeyword.WAITFOR
       "WHEN", TSQLKeyword.WHEN
       "WHERE", TSQLKeyword.WHERE
       "WHILE", TSQLKeyword.WHILE
       "WITH", TSQLKeyword.WITH
       "WITHIN GROUP", TSQLKeyword.WITHIN_GROUP
       "WRITETEXT", TSQLKeyword.WRITETEXT |]
    |> dict
  
  ///Gets the possible values from a string fragment
  let GetPossibilities(fragment : string) = 
    let upperFragment = fragment.ToUpper()
    TSQLKeywordLookup
    |> Seq.where (fun keyV -> keyV.Key.StartsWith(upperFragment))
    |> Seq.map (fun keyV -> keyV.Value)
    |> Seq.toArray
  
  ///Gets the appropriate Union Case from mapping, if any.
  let ParseTSQLKeyword(words : string) = 
    match TSQLKeywordLookup.TryGetValue(words.ToUpper()) with
    | true, result -> Some(result)
    | _ -> None
