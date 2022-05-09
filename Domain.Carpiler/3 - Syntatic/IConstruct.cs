using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic
{
    public interface IConstruct
    {
        public string Name { get; }
    }

    public interface IValuable : IConstruct
    {

    }

    public class Statement : IConstruct
    {
        public Statement()
        {
            Name = GetType().Name;
        }
        public string Name { get; }
    }

    public class Expression : IValuable
    {
        public IValuable Left { get; }
        public Operator Operator { get; }
        public IValuable Right { get; }
        public string Name { get; }

        public Expression(IValuable left, Operator op, IValuable right)
        {
            Name = GetType().Name;
            Left = left;
            Operator = op;
            Right = right;
        }
    }
    public class VariableDeclaration : IConstruct
    {
        public VariableDeclaration(string name, IValuable? initialValue, VariableType type)
        {
            Name = GetType().Name;
            VarName = name;
            InitialValue = initialValue;
            Type = type;
        }

        public string VarName { get; }
        public IValuable? InitialValue { get; }
        public VariableType Type { get; }

        public string Name { get; }
    }

    public enum VariableType
    {
        Bool,
        Float,
        Integer,
        String
    }
}