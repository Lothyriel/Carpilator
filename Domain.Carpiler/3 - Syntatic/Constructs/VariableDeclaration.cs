using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class VariableDeclaration : Statement
    {
        public VariableDeclaration(Token identifier, IValuable? initialValue, VariableType type)
        {
            Identifier = identifier;
            InitialValue = initialValue;
            VarType = type;
        }

        public Token Identifier { get; }
        public IValuable? InitialValue { get; }
        public VariableType VarType { get; }
    }
}