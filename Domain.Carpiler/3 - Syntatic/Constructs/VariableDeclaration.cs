using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class VariableDeclaration : Statement
    {
        public VariableDeclaration(Identifier type, Identifier identifier, IValuable? initialValue)
        {
            Identifier = identifier;
            InitialValue = initialValue;
            VarType = type;
        }

        public Identifier Identifier { get; }
        public IValuable? InitialValue { get; }
        public Identifier VarType { get; }
    }
}