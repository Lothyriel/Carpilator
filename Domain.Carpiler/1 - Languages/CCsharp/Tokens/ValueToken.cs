using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Lexical
{
    public class ValueToken : Token, IValuable
    {
        public ValueToken(string value, TokenType type) : base(value, type)
        {
            Name = GetType().Name;
        }

        public string Name { get; }

        public object ToValue()
        {
            return TokenType switch
            {
                TokenType.StringValue => Value,
                TokenType.IntValue => Convert.ToInt32(Value),
                TokenType.FloatValue => Convert.ToDouble(Value),
                TokenType.BoolValue => Convert.ToBoolean(Value),
                _ => Value,
            };
        }
    }
}