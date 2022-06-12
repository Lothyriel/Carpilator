namespace Domain.Carpiler.Syntatic.Constructs
{
    public interface IConstruct
    {
        public string Name { get; }
    }

    public enum VariableType
    {
        Bool,
        Float,
        Integer,
        String
    }
}