using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Domain.Carpiler.Languages
{
    public class CCsharpParser : Parser
    {
        public override Statement Parse(Queue<Token> tokens)
        {
            Tokens = tokens;

            return Statement();
        }

        #region Constructs

        private Statement Statement()
        {
            return Current.TokenType switch
            {
                TokenType.Float or TokenType.Int or TokenType.String or TokenType.Bool => VariableDeclaration(),
                TokenType.Identifier => Identifier(),
                TokenType.ReservedWord => ReserverdWord(),
                _ => throw new Exception($"{Current} not expected"),
            };
        }

        private Statement Identifier()
        {
            var identifier = Assert(TokenType.Identifier);

            if (Current.TokenType == TokenType.ParenthesisOpen)
            {
                return FunctionCall(identifier);
            }

            return AssignmentExpression(identifier);
        }

        private FunctionCall FunctionCall(Token identifier)
        {
            Assert(TokenType.ParenthesisOpen);

            var parameters = new List<IValuable>();

            while (Current.TokenType != TokenType.ParenthesisClose)
            {
                parameters.Add(GetExpression());
                AssertOptional(TokenType.Comma);
            }

            var functionCall = new FunctionCall((Identifier)identifier, parameters);

            Assert(TokenType.ParenthesisClose);
            AssertOptional(TokenType.Semicolon);

            return functionCall;
        }

        private Statement ReserverdWord()
        {
            var word = Assert(TokenType.ReservedWord);

            return word.Value switch
            {
                "if" => If(),
                "while" => While(),
                _ => throw new Exception($"Em teoria impossivel exception {word}"),
            };
        }

        private Statement While()
        {
            (var condition, var statements) = GetConditionAndStatements();

            return new While(condition, statements);
        }

        private Statement If()
        {
            (var condition, var statements) = GetConditionAndStatements();

            return new If(condition, statements);
        }

        private Assignment AssignmentExpression(Token identifier)
        {
            Assert(TokenType.Attribution);
            var assignment = new Assignment((Identifier)identifier, GetExpression());
            Assert(TokenType.Semicolon);

            return assignment;
        }

        private VariableDeclaration VariableDeclaration()
        {
            var varType = GetVarType(Assert(TokenType.Float, TokenType.Int, TokenType.String, TokenType.Bool));

            var identifier = Assert(TokenType.Identifier);

            var vd = new VariableDeclaration(identifier, GetAssignmentExpression(), varType!.Value);

            AssertOptional(TokenType.Semicolon);

            return vd;
        }

        private IValuable? GetAssignmentExpression()
        {
            if (Current.TokenType == TokenType.Semicolon)
            {
                return null;
            }

            Assert(TokenType.Attribution);
            return GetExpression();
        }

        private IValuable GetExpression()
        {
            var leftValue = Assert
                (
                    TokenType.StringValue,
                    TokenType.IntValue,
                    TokenType.FloatValue,
                    TokenType.BoolValue,
                    TokenType.Identifier
                );

            if (leftValue.TokenType == TokenType.Identifier && Current.TokenType == TokenType.ParenthesisOpen)
            {
                return FunctionCall(leftValue);
            }

            if (IsEOL())
            {
                return (IValuable)leftValue;
            }

            return new BinaryExpression((IValuable)leftValue, GetOperator(), GetExpression());
        }

        #endregion

        private Operator GetOperator()
        {
            var next = Assert
                (
                    TokenType.Plus,
                    TokenType.Minus,
                    TokenType.Slash,
                    TokenType.Asterisk,
                    TokenType.And,
                    TokenType.Or,
                    TokenType.Attribution,
                    TokenType.Equals,
                    TokenType.Greater,
                    TokenType.GreaterEquals,
                    TokenType.Lesser,
                    TokenType.LesserEquals
                );

            return next as Operator ?? throw new Exception($"Em teoria impossivel exception {next}");
        }

        private (IValuable Condition, List<Statement> Statements) GetConditionAndStatements()
        {
            Assert(TokenType.ParenthesisOpen);
            var condition = GetExpression();
            Assert(TokenType.ParenthesisClose);
            Assert(TokenType.CurlyBraceOpen);

            var statements = new List<Statement>();

            while (Tokens!.Peek().TokenType != TokenType.CurlyBraceClose)
            {
                statements.Add(Statement());
            }

            Assert(TokenType.CurlyBraceClose);

            return (condition, statements);
        }
       
        private bool IsEOL()
        {
            return Current.TokenType is TokenType.Semicolon or TokenType.ParenthesisClose or TokenType.Comma;
        }

        private void AssertOptional(TokenType expected)
        {
            if (Tokens!.Any() && Tokens!.Peek().TokenType == expected)
            {
                Tokens.Dequeue();
            }
        }

        private Token Assert(params TokenType[] expectedTypes)
        {
            var token = Tokens!.Dequeue();

            if (expectedTypes.Any(t => t == token.TokenType) == false)
            {
                throw new Exception($"Expected one of: {string.Join(' ', expectedTypes)}, but found: {token}");
            }

            return token;
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