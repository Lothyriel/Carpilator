using Domain.Carpiler.Lexical;
using System;

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
            var leftValue = Left.ToValue();

            var rightValue = Right.ToValue();

            switch (Operator.TokenType)
            {
                case TokenType.Plus: return (dynamic)leftValue + (dynamic)rightValue;
                case TokenType.Minus: return (dynamic)leftValue - (dynamic)rightValue;
                case TokenType.Slash: return (dynamic)leftValue / (dynamic)rightValue;
                case TokenType.Asterisk: return (dynamic)leftValue * (dynamic)rightValue;
                case TokenType.And: return (dynamic)leftValue && (dynamic)rightValue;
                case TokenType.Or: return (dynamic)leftValue || (dynamic)rightValue;
                case TokenType.Greater: return (dynamic)leftValue > (dynamic)rightValue;
                case TokenType.GreaterEquals: return (dynamic)leftValue >= (dynamic)rightValue;
                case TokenType.Lesser: return (dynamic)leftValue < (dynamic)rightValue;
                case TokenType.LesserEquals: return (dynamic)leftValue <= (dynamic)rightValue;
                case TokenType.Equals: return (dynamic)leftValue == (dynamic)rightValue;
                default: throw new InvalidOperationException();
            };
        }
    }
}