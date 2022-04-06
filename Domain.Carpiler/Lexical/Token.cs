namespace Domain.Carpiler.Lexical
{
    public struct Token
    {
        public Token(string value, Type type)
        {
            Value = value;
            Type = type;
        }

        public string Value { get; }

        public Type Type { get; }

        public override string ToString()
        {
            return $"{Type} {Value}";
        }

        public static new Token Equals { get; } = new("==", Type.Equals);
        public static Token Attribution { get; } = new("=", Type.Attribution);
        public static Token And { get; } = new("&", Type.And);
        public static Token Or { get; } = new("|", Type.Or);
        public static Token Lesser { get; } = new("<", Type.Lesser);
        public static Token LesserEquals { get; } = new("<=", Type.LesserEquals);
        public static Token Greater { get; } = new(">", Type.Greater);
        public static Token GreaterEquals { get; } = new(">=", Type.GreaterEquals);
        public static Token Plus { get; } = new("+", Type.Plus);
        public static Token Minus { get; } = new("-", Type.Minus);
        public static Token Slash { get; } = new("/", Type.Slash);
        public static Token Asterisk { get; } = new("*", Type.Asterisk);
        public static Token BracketOpen { get; } = new("{", Type.BracketOpen);
        public static Token BracketClose { get; } = new("}", Type.BracketClose);
        public static Token ParenthesisOpen { get; } = new("(", Type.ParenthesisOpen);
        public static Token ParenthesisClose { get; } = new(")", Type.ParenthesisClose);
        public static Token Semicolon { get; } = new(";", Type.Semicolon);
    }

    public enum Type
    {
        Literal,
        Float,
        Integer,
        Identifier,
        Read,
        Print,
        While,
        If,
        Continue,
        Break,
        BracketOpen,
        BracketClose,
        ParenthesisOpen,
        ParenthesisClose,
        Plus,
        Minus,
        Slash,
        Asterisk,
        And,
        Or,
        Greater,
        GreaterEquals,
        Lesser,
        LesserEquals,
        Attribution,
        Equals,
        Semicolon
    }
}