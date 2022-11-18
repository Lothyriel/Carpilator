using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class BinaryExpression : IValuable
    {
        public IValuable Left { get; }
        public Operator Operator { get; }
        public IValuable Right { get; }
        public string Name { get; }

        public BinaryExpression(IValuable left, Operator op, IValuable right)
        {
            Name = GetType().Name;
            Left = left;
            Operator = op;
            Right = right;
        }

        public object ToValue()
        {
            throw new NotImplementedException();
        }
    }
}