using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class Assignment : Statement
    {
        public Assignment(Token identifier, IValuable value)
        {
            Identifier = identifier;
            Value = value;
        }

        public Token Identifier { get; }
        public IValuable Value { get; }
    }
}