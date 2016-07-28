namespace SqlWhiteboard.Lexical

type TokenType = 
  | TSQLKeyword of TSQLKeyword
  | ODBCKeyword of ODBCKeyword
  ///A bracketed identifier for a name
  | Identifier
  ///An '@' + name 
  | Variable
  ///One or more Punctuation marks that create a symbol
  | Symbol of Symbol
  ///A single-quote contained string.
  | String
  ///Unknown doesn't fit into any other category. Possibly parsing error?  
  | Unknown

type Token = 
  { ///0-index based
    LineNumber : int
    ///0-index based
    StartColumn : int
    ///The actual string
    Token : string
    ///The type of this token
    Type : TokenType }
