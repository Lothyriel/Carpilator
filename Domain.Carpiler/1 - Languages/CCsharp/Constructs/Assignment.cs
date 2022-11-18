using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class Assignment : Statement
    {
        public Assignment(Identifier identifier, IValuable value)
        {
            Identifier = identifier;
            Value = value;
        }

        public Identifier Identifier { get; }
        public IValuable Value { get; }

        public override object Run(Interpreter interpreter)
        {
            throw new NotImplementedException();
        }
    }
}