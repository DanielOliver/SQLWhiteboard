using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace SqlWhiteboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptText = "SELECT (SELECT a.ID FROM LastLogin a) [T], * FROM dbo.People p FULL OUTER JOIN ThirdTable ON ThirdTable.ID = p.ID LEFT OUTER JOIN Employees e ON e.PeopleID = p.ID WHERE p.Name IN (SELECT c.Name FROM Contacts c) AND p.ID = @A;";

            IList<ParseError> parseErrors;
            var Parser = new TSql100Parser(true);
            TSqlFragment fragment;
            using (System.IO.StringReader stringReader = new System.IO.StringReader(scriptText))
            {
                fragment = Parser.Parse(stringReader, out parseErrors);
            }
            var tScript = (TSqlScript)fragment;

            Logic.Analysis.ParseScript(tScript);

            System.Console.ReadLine();
        }
    }
}
