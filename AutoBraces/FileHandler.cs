using System;
using System.IO;

namespace AutoBraces
{
    public class FileHandler
    {
        public static void CreateNewFile(string originalPath, string content)
        {
            var directory = Path.GetDirectoryName(originalPath);
            var fileName = Path.GetFileNameWithoutExtension(originalPath);
            var newPath = Path.Combine(directory, fileName + "_quoted.sql");

            if (File.Exists(newPath))
            {
                Console.WriteLine("The file already exists");
                return;
            }
            File.WriteAllText(newPath, content);
        }
    }
}