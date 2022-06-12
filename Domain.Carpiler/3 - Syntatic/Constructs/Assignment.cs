using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class Assignment : IConstruct
    {
        public Assignment(Token identifier, IValuable value)
        {
            Identifier = identifier;
            Value = value;
            Name = GetType().Name;
        }

        public Token Identifier { get; }
        public IValuable Value { get; }
        public string Name { get; }
    }
}
