using System;
using System.IO;

namespace AutoBraces
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql;
            var path = args[0];
            try
            {
                sql = File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open file: " + e);
                Console.ReadKey();
                throw;
            }
            var autoBraces = new AutoBraces();
            var newSql = autoBraces.AddBracesToAllNecessaryTokens(sql);
            
            Console.WriteLine("Old Script -----------------------------------");
            Console.WriteLine(sql);
            Console.WriteLine("\n\nNew Script -----------------------------------");
            Console.WriteLine(newSql);

            FileHandler.CreateNewFile(path, newSql);
            
            Console.ReadKey();
        }
    }
}
