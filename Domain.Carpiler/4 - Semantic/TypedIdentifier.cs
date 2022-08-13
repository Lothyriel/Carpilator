using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Semantic
{
    public class TypedIdentifier : Identifier
    {
        public TypedIdentifier(Identifier identifier, Type type) : base(identifier.Value)
        {
            Type = type;
        }

        public Type Type { get; }
    }
}