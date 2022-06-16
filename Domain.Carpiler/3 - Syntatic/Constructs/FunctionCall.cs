using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class FunctionCall : Statement, IValuable
    {
        public FunctionCall(Token identifier, List<IValuable> parameters)
        {
            Identifier = identifier;
            Parameters = parameters;
        }

        public Token Identifier { get; }
        public List<IValuable> Parameters { get; }
    }
}