using System.Runtime.Serialization;

namespace Domain.Carpiler
{
    [Serializable]
    public class UnidentifiedToken : Exception
    {
        public UnidentifiedToken(char token) : base
            ($"The token {token} was not identified as part of the language")
        {
        }
    }

    [Serializable]
    public class NotClosed : Exception
    {
        public NotClosed(char token) : base
            ($"The token {token} was not properly closed")
        {
        }
    }
}