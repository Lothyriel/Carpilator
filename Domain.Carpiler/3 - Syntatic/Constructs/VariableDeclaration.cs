namespace Domain.Carpiler.Syntatic.Constructs
{
    public class VariableDeclaration : Statement
    {
        public VariableDeclaration(string varName, IValuable? initialValue, VariableType type)
        {
            VarName = varName;
            InitialValue = initialValue;
            VarType = type;
        }

        public string VarName { get; }
        public IValuable? InitialValue { get; }
        public VariableType VarType { get; }
    }
}