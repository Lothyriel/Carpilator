namespace Domain.Carpiler.Syntatic.Constructs
{
    public class VariableDeclaration : IConstruct
    {
        public VariableDeclaration(string name, IValuable? initialValue, VariableType type)
        {
            Name = GetType().Name;
            VarName = name;
            InitialValue = initialValue;
            VarType = type;
        }

        public string VarName { get; }
        public IValuable? InitialValue { get; }
        public VariableType VarType { get; }

        public string Name { get; }
    }
}