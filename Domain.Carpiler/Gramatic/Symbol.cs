namespace Domain.Carpiler.Gramatic
{
    public class Symbol
    {
        public Symbol(Type type)
        {
            Type = type;
        }

        public Type Type { get; }

        public static implicit operator Symbol(Type type)
        {
            return new Symbol(type);
        }
    }
}