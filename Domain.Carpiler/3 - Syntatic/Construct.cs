using Domain.Carpiler.Semantic;

namespace Domain.Carpiler.Syntatic
{
    public abstract class Construct
    {

    }

    public class VariableDeclaration<T> : Construct
    {
        public VariableDeclaration(string name, T? value, VariableType type)
        {
            Identifier = new(name, value);
            Type = type;
        }

        public Variable<T?> Identifier { get; }
        public VariableType Type { get; }
    }

    public class Statement : Construct
    {
        
    }

    public enum VariableType
    {
        Bool,
        Float,
        Integer,
        String
    }
}