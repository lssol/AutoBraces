using System.Data.SqlTypes;
using Microsoft.SqlServer.Management.SqlParser.Parser;

namespace AutoBraces
{
    public class AutoBraces
    {
        public string AddBracesToAllNecessaryTokens(string sqlScript)
        {
            var po = new ParseOptions();
            var scanner = new Scanner(po);
            scanner.SetSource(sqlScript, 0);
            
            Tokens token;
            var state = 0;
            var result = sqlScript;

            var numberOfCharactersAdded = 0;
            
            while ((token = (Tokens)scanner.GetNext(ref state, out var start, out var end, out _, out _)) != Tokens.EOF)
            {
                string str = sqlScript.Substring(start, end - start + 1);
                var quotedStr = AddBracesToTokenIfNecessary(str, token);
                if (quotedStr == str)
                    continue;

                var substringBefore = result.Substring(0, start + numberOfCharactersAdded);
                var substringAfter = result.Substring(end + 1 + numberOfCharactersAdded);
                result = substringBefore + quotedStr + substringAfter;
                numberOfCharactersAdded += 2;
            }

            return result;
        }
        
        private string AddBracesToTokenIfNecessary(string token, Tokens tokenType)
        {
            if (tokenType != Tokens.TOKEN_ID)
                return token;
            if (token.Substring(0, 1) == "[")
                return token;
            
            return "[" + token + "]";
        }
    }
}