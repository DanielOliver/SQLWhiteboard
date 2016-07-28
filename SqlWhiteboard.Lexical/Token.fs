namespace SqlWhiteboard.Lexical

type TokenType =
  | TSQLKeyword of TSQLKeyword
  | ODBCKeyword of ODBCKeyword
  | Integer of int
  ///A bracketed identifier for a name
  | Identifier 
  ///An '@' + name 
  | Variable
  ///One or more Punctuation marks that create a symbol
  | Symbol

type Token =
  { ///0-index based
    LineNumber: int
    ///0-index based
    StartColumn: int
    ///The actual string
    Token: string
    ///The type of this token
    Type: TokenType
  }

