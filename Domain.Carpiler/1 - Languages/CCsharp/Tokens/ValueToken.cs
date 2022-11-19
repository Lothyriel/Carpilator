using Domain.Carpiler.Syntatic.Constructs;
using System;

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
            switch (TokenType)
            {
                case TokenType.StringValue: return Value;
                case TokenType.IntValue: return Convert.ToInt32(Value);
                case TokenType.FloatValue: return Convert.ToDouble(Value);
                case TokenType.BoolValue: return Convert.ToBoolean(Value);
                default: return Value;
            };
        }
    }
}