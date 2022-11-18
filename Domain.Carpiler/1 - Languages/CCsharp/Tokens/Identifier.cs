using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Lexical
{
    public class Identifier : Token, IValuable
    {
        public Identifier(string value) : base(value, TokenType.Identifier)
        {
            Name = GetType().Name;
        }

        public string Name { get; }

        public IValuable? CurrentValue { get; set; }

        public object ToValue()
        {
            return CurrentValue.ToValue();
        }
    }
}