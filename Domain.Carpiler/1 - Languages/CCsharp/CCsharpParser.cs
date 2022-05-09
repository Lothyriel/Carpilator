using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;
using Type = Domain.Carpiler.Lexical.Type;

namespace Domain.Carpiler.Languages
{
    public class CCsharpParser : Parser
    {
        public override Construct? Parse(Queue<Token> tokens)
        {
            throw new NotImplementedException();
        }

        private static Construct? InitialProduction(Queue<Token> tokens)
        {
            var vd = VariableDeclaration(tokens);
            var va = VariableAssignment(tokens);

            return vd;
        }

        private static object VariableAssignment(Queue<Token> tokens)
        {
            throw new NotImplementedException();
        }

        private static Construct? VariableDeclaration(Queue<Token> tokens)
        {
            var type = tokens.Dequeue();
            var identifier = tokens.Dequeue();

            var leftVarType = IsVarType(type);
            var rightIdentifier = identifier.Type == Type.Identifier;

            if (leftVarType == false || rightIdentifier == false)
            {
                throw new Exception("Invalid variable declaration");
            }

            var expressionValue = GetAssignmentExpression(tokens);

            var name = identifier.Value;

            var varType = GetVarType(type);

            return new VariableDeclaration(name, expressionValue, varType);
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

        private static Expression GetAssignmentExpression(Queue<Token> tokens)
        {
            var next = tokens.Dequeue();

            if (next.Type == Type.Semicolon)
            {
                return new Expression(null);
            }

            if (next.Type == Type.Attribution)
            {
                return GetExpression(tokens);
            }

            throw new Exception("Expected ; or a expression after variable declaration");
        }

        private static Expression GetExpression(Queue<Token> tokens)
        {
            var sv = SimpleValue(tokens);

            if (sv != null)
            {
                return sv;
            }

            var be = BinaryExpression(tokens);

            return sv ?? be;
        }

        private static Expression? SimpleValue(Queue<Token> tokens)
        {
            var token = tokens.Dequeue();

            var isValue = token.Type == Type.FloatValue ||
                          token.Type == Type.IntValue ||
                          token.Type == Type.StringValue ||
                          token.Type == Type.BoolValue;

            if (isValue && tokens.Dequeue().Type == Type.Semicolon)
            {
                return new Expression(token.Value);
            }

            return null;
        }

        private static Expression BinaryExpression(Queue<Token> tokens)
        {
            var right = tokens.Dequeue();
            var oper = tokens.Dequeue();
            var left = tokens.Dequeue();

            return null;
        }
    }
}
