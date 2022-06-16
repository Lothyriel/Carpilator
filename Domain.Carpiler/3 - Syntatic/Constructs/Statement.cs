namespace Domain.Carpiler.Syntatic.Constructs
{
    public abstract class Statement
    {
        public Statement()
        {
            Name = GetType().Name;
        }
        public string Name { get; }
    }
}