using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Domain.Carpiler.Languages
{
    public class CCsharpParser : Parser
    {
        public override IConstruct Parse(Queue<Token> tokens)
        {
            Tokens = tokens;

            return Statement();
        }

        private IConstruct Statement()
        {
            var current = Tokens!.Peek();

            return current.TokenType switch
            {
                TokenType.Float or TokenType.Int or TokenType.String or TokenType.Bool => VariableDeclaration(),
                TokenType.Identifier => AssignmentExpression(),
                TokenType.ReservedWord => ReserverdWord(current),
                _ => throw new Exception($"{current} not expected"),
            };
        }

        private IConstruct ReserverdWord(Token current)
        {
            //function call //while //if / else
            throw new NotImplementedException();
        }

        private Assignment AssignmentExpression()
        {
            var identifier = Tokens!.Dequeue();

            Assert(TokenType.Attribution);

            return new Assignment(identifier, GetExpression());
        }

        private Token Assert(TokenType expected)
        {
            var token = Tokens!.Dequeue();

            if (token.TokenType != expected)
                throw new Exception($"Expected {expected}");

            return token;
        }

        private VariableDeclaration VariableDeclaration()
        {
            var varType = GetVarType(Tokens!.Dequeue());

            var identifier = Assert(TokenType.Identifier);

            return new VariableDeclaration(identifier.Value, GetAssignmentExpression(), varType!.Value);
        }

        private IValuable? GetAssignmentExpression()
        {
            var next = Tokens!.Dequeue();

            if (next.TokenType == TokenType.Semicolon)
            {
                return null;
            }

            if (next.TokenType == TokenType.Attribution)
            {
                return GetExpression();
            }

            throw new Exception("Expected ; or a expression after variable declaration");
        }

        private IValuable GetExpression()
        {
            var token = Tokens!.Dequeue();

            if (IsValue(token) && IsSemicolon())
            {
                return (ValueToken)token;
            }

            return new BinaryExpression((ValueToken)token, GetOperator(), GetExpression());
        }

        private bool IsSemicolon()
        {
            var isSemicolon = Tokens!.Peek().TokenType == TokenType.Semicolon;

            if (isSemicolon)
                Tokens.Dequeue();

            return isSemicolon;
        }

        private Operator GetOperator()
        {
            var next = Tokens!.Dequeue();
            return next is Operator op ? op : throw new Exception("Expected operator");
        }

        private static bool IsValue(Token token)
        {
            return token.TokenType is
                TokenType.StringValue or
                TokenType.IntValue or
                TokenType.FloatValue or
                TokenType.BoolValue;
        }

        private static VariableType? GetVarType(Token type)
        {
            return type.Value switch
            {
                "bool" => VariableType.Bool,
                "float" => VariableType.Float,
                "int" => VariableType.Integer,
                "string" => VariableType.String,
                _ => null,
            };
        }
    }
}