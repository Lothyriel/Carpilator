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

    public class PrintFunction : IConstruct
    {
        public string Name { get; }
        public IValuable Expression { get; }

        public PrintFunction(IValuable expression)
        {
            Name = GetType().Name;
            Expression = expression;
        }
    }
}