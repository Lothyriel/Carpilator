using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Infra
{
    [Serializable]
    public class UnidentifiedToken : Exception
    {
        public UnidentifiedToken(char token, string sourceCode, int characterdsLeft) : base
            (Extensions.FormatUnidentified(token, sourceCode, characterdsLeft))
        {
        }

    }

    [Serializable]
    public class UnexpectedToken : Exception
    {
        public UnexpectedToken(Token token, params TokenType[] expectedTypes) : base
            ($"Expected one of: {string.Join(' ', expectedTypes)}, but found: {token}")
        {
        }

    }

    [Serializable]
    public class UnclosedToken : Exception
    {
        public UnclosedToken(char token, string sourceCode, int characterdsLeft) : base
            (Extensions.FormatUnclosed(token, sourceCode, characterdsLeft))
        {
        }

    }
}