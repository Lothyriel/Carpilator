namespace Domain.Carpiler.Gramatic
{
    public class Token
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

        public override bool Equals(object? obj)
        {
            return obj is Token token && token.Type == Type && token.Value == Value;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public enum Type
    {
        Literal,
        IntValue,
        FloatValue,
        Float,
        Int,
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
        ReservedWord
    }
}