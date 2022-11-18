using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class FunctionCall : Statement, IValuable
    {
        public FunctionCall(Identifier identifier, List<IValuable> parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public Identifier Identifier { get; }
        public List<IValuable> Parameters { get; }

        public override object Run(Interpreter interpreter)
        {
            throw new NotImplementedException();
        }
    }
}