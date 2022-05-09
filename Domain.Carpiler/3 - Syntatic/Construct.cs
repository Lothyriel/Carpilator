namespace Domain.Carpiler.Syntatic
{
    public class Construct
    {
    }

    public class Statement : Construct
    {

    }

    public class Expression : Construct
    {
        public string? Value { get; }
        public Expression? Left { get; }
        public Expression? Right { get; }

        public Expression(string? value)
        {
            Value = value;
        }

        public Expression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }

    public enum VariableType
    {
        Bool,
        Float,
        Integer,
        String
    }
}