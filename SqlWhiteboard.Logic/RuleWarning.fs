namespace SqlWhiteboard.Logic

type RuleWarning =
  { ///The line the warning begins on
    Line: int
    ///The column the warning begins on
    Column: int
    ///The length of the warning
    Length: int
    ///The warning text to the user
    Warning: string
  }

