using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Lexical
{
    public class Operator : Token
    {
        public Operator(string value, Type type) : base(value, type)
        {
        }
    }
    public class ValueToken : Token, IValuable
    {
        public ValueToken(string value, Type type) : base($"{value}", type)
        {
            Name = GetType().Name;
        }

        public string Name { get; }
    }

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
        ReservedWord
    }
}