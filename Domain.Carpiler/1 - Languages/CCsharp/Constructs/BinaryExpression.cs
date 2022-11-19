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

            return Operator.TokenType switch
            {
                TokenType.Plus => (dynamic)leftValue + (dynamic)rightValue,
                TokenType.Minus => (dynamic)leftValue - (dynamic)rightValue,
                TokenType.Slash => (dynamic)leftValue / (dynamic)rightValue,
                TokenType.Asterisk => (dynamic)leftValue * (dynamic)rightValue,
                TokenType.And => (dynamic)leftValue && (dynamic)rightValue,
                TokenType.Or => (dynamic)leftValue || (dynamic)rightValue,
                TokenType.Greater => (dynamic)leftValue > (dynamic)rightValue,
                TokenType.GreaterEquals => (dynamic)leftValue >= (dynamic)rightValue,
                TokenType.Lesser => (dynamic)leftValue < (dynamic)rightValue,
                TokenType.LesserEquals => (dynamic)leftValue <= (dynamic)rightValue,
                TokenType.Equals => (dynamic)leftValue == (dynamic)rightValue,
                _ => throw new InvalidOperationException(),
            };
        }
    }
}