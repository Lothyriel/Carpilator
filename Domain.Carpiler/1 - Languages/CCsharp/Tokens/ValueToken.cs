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
    }
}