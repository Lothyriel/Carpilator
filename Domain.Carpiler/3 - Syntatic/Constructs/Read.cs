namespace Domain.Carpiler.Syntatic.Constructs
{
    public class ReadFunction : IValuable
    {
        public string Name { get; }
        public static ReadFunction Instance { get; } = new ReadFunction();
        private ReadFunction()
        {
            Name = GetType().Name;
        }
    }
}