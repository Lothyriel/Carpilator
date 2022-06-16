using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Domain.Carpiler.Languages
{
    public class CCsharpParser : Parser
    {
        private Token Current => Tokens!.Peek();

        public override IConstruct Parse(Queue<Token> tokens)
        {
            Tokens = tokens;

            return Statement();
        }

        private Statement Statement()
        {
            return Current.TokenType switch
            {
                TokenType.Float or TokenType.Int or TokenType.String or TokenType.Bool => VariableDeclaration(),
                TokenType.Identifier => AssignmentExpression(),
                TokenType.ReservedWord => ReserverdWord(),
                _ => throw new Exception($"{Current} not expected"),
            };
        }

        private Statement ReserverdWord()
        {
            var word = Assert(TokenType.ReservedWord);

            return word.Value switch
            {
                "print" => Print(),
                "read" => Read(),
                "if" => If(),
                "while" => While(),
                _ => throw new Exception($"Em teoria impossivel exception {word}"),
            };
        }

        private Statement While()
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

            return new While(condition, statements);
        }

        private Statement If()
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

            return new If(condition, statements);
        }

        private ReadFunction Read()
        {
            Assert(TokenType.ParenthesisOpen);
            Assert(TokenType.ParenthesisClose);
            Assert(TokenType.Semicolon);

            return new ReadFunction();
        }

        private Statement Print()
        {
            Assert(TokenType.ParenthesisOpen);

            var print = new PrintFunction(GetExpression());

            Assert(TokenType.ParenthesisClose);
            Assert(TokenType.Semicolon);

            return print;
        }

        private Assignment AssignmentExpression()
        {
            var identifier = Assert(TokenType.Identifier);
            Assert(TokenType.Attribution);
            var assignment = new Assignment(identifier, GetExpression());
            Assert(TokenType.Semicolon);

            return assignment;
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

        private VariableDeclaration VariableDeclaration()
        {
            var varType = GetVarType(Assert(TokenType.Float, TokenType.Int, TokenType.String, TokenType.Bool));

            var identifier = Assert(TokenType.Identifier);

            var vd = new VariableDeclaration(identifier.Value, GetAssignmentExpression(), varType!.Value);

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

            if ((leftValue.TokenType == TokenType.Identifier || IsValue(leftValue)) && IsEOL())
            {
                return (IValuable)leftValue;
            }

            if (leftValue.Value == "read") //generalizar para toda funcao, e na hora de executar eu dou o erro de tipo
            {
                return Read();
            }

            return new BinaryExpression((IValuable)leftValue, GetOperator(), GetExpression());
        }

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

        private bool IsEOL()
        {
            var tokenType = Current.TokenType;

            return tokenType is TokenType.Semicolon or TokenType.ParenthesisClose;
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