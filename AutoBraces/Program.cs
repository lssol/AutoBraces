using System;
using System.IO;

namespace AutoBraces
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql;
            try
            {
                sql = File.ReadAllText(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open file: " + e);
                Console.ReadKey();
                throw;
            }
            var autoBraces = new AutoBraces();
            var newSql = autoBraces.AddBracesToAllNecessaryTokens(sql);
            
            Console.WriteLine("Old String: {0}", sql);
            Console.WriteLine("New String: {0}", newSql);

            Console.ReadKey();
        }
    }
}
