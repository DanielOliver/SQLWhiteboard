using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;

namespace SqlWhiteboard
{
    class Program
    {
        static void Main(string[] args)
        {
            //var scriptText = "SELECT (SELECT a.ID FROM LastLogin a) [T], * FROM dbo.People p FULL OUTER JOIN ThirdTable ON ThirdTable.ID = p.ID LEFT OUTER JOIN Employees e ON e.PeopleID = p.ID WHERE p.Name IN (SELECT c.Name FROM Contacts c) AND p.ID = @A;";
            var scriptText = "UPDATE People SET FirstName = 'Daniel'";

            var parser = new TSql120Parser(true);

            var rules = Rules.RuleFactory.GetAllRules();
            var engine = new Logic.RuleEngine(rules);
            var warnings = engine.GetWarnings(scriptText, parser);


            if (warnings.ParseErrors.Count > 0)
            {
                Console.WriteLine("***  Parse Errors:  ***");
                foreach (var parseError in warnings.ParseErrors)
                {
                    var output =
                        string.Format("Line: {0}; Column: {1}; Warning: {2}",
                            parseError.Line,
                            parseError.Column,
                            parseError.Message);
                    Console.WriteLine(output);
                }
            }

            if (warnings.Warnings.Length > 0)
            {
                Console.WriteLine("***  Warnings:  ***");
                foreach (var warning in warnings.Warnings)
                {
                    var output =
                        string.Format("Line: {0}; Column: {1}; Length: {2}; Warning: {3}",
                            warning.Line,
                            warning.Column,
                            warning.Length,
                            warning.Warning);
                    Console.WriteLine(output);
                }
            }

            Console.ReadLine();
        }
    }
}
