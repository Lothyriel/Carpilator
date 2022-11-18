using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
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

        public override object Run(Interpreter interpreter)
        {
            Identifier.CurrentValue = InitialValue;

            return CCsharpTokenizer.None;
        }

        public TypedIdentifier Typefy()
        {
            return new TypedIdentifier(Identifier, new Type(VarType.Value));
        }
    }
}