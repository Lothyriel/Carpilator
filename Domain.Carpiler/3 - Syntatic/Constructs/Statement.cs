namespace Domain.Carpiler.Syntatic.Constructs
{
    public class Statement : IConstruct
    {
        public Statement()
        {
            Name = GetType().Name;
        }
        public string Name { get; }
    }
}