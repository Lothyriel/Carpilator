namespace Domain.Carpiler.Lexical
{
    public abstract class Token
    {
        public Token(string value, TokenType type)
        {
            Value = value;
            TokenType = type;
        }

        public string Value { get; set; }

        public TokenType TokenType { get; }

        public override string ToString()
        {
            return $"{{{TokenType} {(string.IsNullOrWhiteSpace(Value) ? "null" : Value)}}}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Token token && token.TokenType == TokenType && token.Value == Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum TokenType
    {
        StringValue,
        IntValue,
        FloatValue,
        BoolValue,
        Float,
        Int,
        String,
        Bool,
        Identifier,
        CurlyBraceOpen,
        CurlyBraceClose,
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
        Equals,
        Attribution,
        Semicolon,
        ReservedWord,
        Comma
    }
}