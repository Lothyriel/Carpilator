using System.Runtime.Serialization;

namespace Domain.Carpiler.Infra
{
    public static class Extensions
    {
        public static string FormatUnidentified(char token, string sourceCode, int characterdsLeft)
        {
            int indexFound = sourceCode.Length - characterdsLeft - 1;
            int line = 0;
            foreach (var l in sourceCode.Split('\n'))
            {
                line++;

                if (indexFound < l.Length)
                    break;

                indexFound -= l.Length;
            }
            return $"The token {token} at line {line} pos {indexFound} was not identified as part of the language";
        }

        public static string FormatUnclosed(char token, string sourceCode, int characterdsLeft)
        {
            int indexFound = sourceCode.Length - characterdsLeft - 1;
            int line = 0;
            foreach (var l in sourceCode.Split('\n'))
            {
                line++;

                if (indexFound < l.Length)
                    break;

                indexFound -= l.Length;
            }

            return $"The token {token} at line {line} pos {indexFound} was not closed properly";
        }
    }
}