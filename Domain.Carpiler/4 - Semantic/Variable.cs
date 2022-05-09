using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Semantic
{
    public class VariableDeclaration : Construct
    {
        public VariableDeclaration(string name, Expression? initialValue, VariableType type)
        {
            Name = name;
            InitialValue = initialValue;
            Type = type;
        }

        public string Name { get; }
        public Expression? InitialValue { get; }
        public VariableType Type { get; }
    }
}