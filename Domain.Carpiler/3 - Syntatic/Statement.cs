using Domain.Carpiler.Infra;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public abstract class Statement
    {
        public Statement()
        {
            Name = GetType().Name;
        }
        public string Name { get; }

        public abstract object Run(Interpreter interpreter);
    }
    public interface IValuable
    {
        public object ToValue();
    }
}