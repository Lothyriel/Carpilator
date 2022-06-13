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

        private Statement Statement()
        {
            var current = Tokens!.Peek();

            return current.TokenType switch
            {
                TokenType.Float or TokenType.Int or TokenType.String or TokenType.Bool => VariableDeclaration(),
                TokenType.Identifier => AssignmentExpression(),
                TokenType.ReservedWord => ReserverdWord(),
                _ => throw new Exception($"{current} not expected"),
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
            var identifier = Tokens!.Dequeue();
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

        private Token Assert(TokenType expected)
        {
            var token = Tokens!.Dequeue();

            if (token.TokenType != expected)
            {
                throw new Exception($"Expected {expected}");
            }

            return token;
        }

        private VariableDeclaration VariableDeclaration()
        {
            var varType = GetVarType(Tokens!.Dequeue());

            var identifier = Assert(TokenType.Identifier);

            var vd = new VariableDeclaration(identifier.Value, GetAssignmentExpression(), varType!.Value);

            AssertOptional(TokenType.Semicolon);

            return vd;
        }

        private IValuable? GetAssignmentExpression()
        {
            var next = Tokens!.Peek();

            if (next.TokenType == TokenType.Semicolon)
            {
                return null;
            }

            Assert(TokenType.Attribution);
            return GetExpression();
        }

        private IValuable GetExpression()
        {
            var token = Tokens!.Dequeue();

            if ((token.TokenType == TokenType.Identifier || IsValue(token)) && IsEOL())
            {
                return (ValueToken)token;
            }

            if (token.Value == "read") //generalizar para toda funcao, e na hora de executar eu dou o erro de tipo
            {
                return Read();
            }

            return new BinaryExpression((ValueToken)token, GetOperator(), GetExpression());
        }

        private Operator GetOperator()
        {
            var next = Tokens!.Dequeue();
            return next as Operator ?? throw new Exception("Expected operator");
        }

        private bool IsEOL()
        {
            var tokenType = Tokens!.Peek().TokenType;

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