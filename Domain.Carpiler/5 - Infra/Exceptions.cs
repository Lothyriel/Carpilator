namespace Domain.Carpiler.Infra
{
    [Serializable]
    public class UnidentifiedToken : Exception
    {
        public UnidentifiedToken(char token, string sourceCode, int characterdsLeft) : base
            (FormatException(token, sourceCode, characterdsLeft))
        {
        }

        private static string FormatException(char token, string sourceCode, int characterdsLeft)
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
    }
}