using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Type = Domain.Carpiler.Semantic.Type;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class VariableDeclaration : Statement, IDeclarative
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

        public override void Run(Interpreter interpreter)
        {
            
        }

        public TypedIdentifier Typefy()
        {
            return new TypedIdentifier(Identifier, new Type(VarType.Value));
        }
    }
}