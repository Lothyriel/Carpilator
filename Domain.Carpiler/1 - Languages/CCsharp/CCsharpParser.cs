using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Type = Domain.Carpiler.Lexical.Type;

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
            var vd = VariableDeclaration();
            //var va = AssigmentExpression();

            //assignment
            //function call
            //while
            //if / else

            return vd;
        }

        private Expression AssigmentExpression()
        {
            throw new NotImplementedException();
        }

        private VariableDeclaration VariableDeclaration()
        {
            var type = Tokens!.Dequeue();
            var identifier = Tokens.Dequeue();

            var leftVarType = IsVarType(type);
            var rightIdentifier = identifier.Type == Type.Identifier;

            if (leftVarType == false || rightIdentifier == false)
            {
                throw new Exception("Invalid variable declaration");
            }

            var expressionValue = GetAssignmentExpression();

            var name = identifier.Value;

            var varType = GetVarType(type);

            return new VariableDeclaration(name, expressionValue, varType);
        }

        private IValuable? GetAssignmentExpression()
        {
            var next = Tokens!.Dequeue();

            if (next.Type == Type.Semicolon)
            {
                return null;
            }

            if (next.Type == Type.Attribution)
            {
                return GetExpression();
            }

            throw new Exception("Expected ; or a expression after variable declaration");
        }

        private IValuable GetExpression()
        {
            var sv = SimpleValue();

            if (sv != null)
            {
                return sv;
            }

            var be = BinaryExpression();

            return be;
        }

        private ValueToken? SimpleValue()
        {
            var token = Tokens!.Dequeue();

            var isValue = IsValue(token);

            if (isValue && Tokens.Dequeue().Type == Type.Semicolon)
            {
                return (ValueToken)token;
            }

            return null;
        }

        private static bool IsValue(Token token)
        {
            return token.Type == Type.FloatValue ||
                   token.Type == Type.IntValue ||
                   token.Type == Type.StringValue ||
                   token.Type == Type.BoolValue;
        }

        private Expression BinaryExpression()
        {
            var left = GetExpression();

            var op = GetOperator();

            var right = GetExpression();

            return new Expression(left, op, right);
        }

        private Operator GetOperator()
        {
            throw new NotImplementedException();
        }

        private static bool IsVarType(Token type)
        {
            return type.Value == "float" ||
                   type.Value == "bool" ||
                   type.Value == "string" ||
                   type.Value == "int";
        }

        private static VariableType GetVarType(Token type)
        {
            return type.Value switch
            {
                "bool" => VariableType.Bool,
                "float" => VariableType.Float,
                "int" => VariableType.Integer,
                "string" => VariableType.String,
                _ => throw new Exception("Invalid type for variable declaration"),
            };
        }
    }
}