using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
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
            var value = Identifier.CurrentValue as ValueToken;

            value.Value = Value.ToValue().ToString();

            return CCsharpTokenizer.None;
        }
    }
}