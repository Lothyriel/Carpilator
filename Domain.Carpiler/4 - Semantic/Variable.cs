namespace Domain.Carpiler.Semantic
{
    public class Variable<T>
    {
        public Variable(string name, T? value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public T? Value { get; }
    }
}