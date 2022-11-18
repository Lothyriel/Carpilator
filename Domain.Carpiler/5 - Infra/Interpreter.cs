using Domain.Carpiler.Semantic;

namespace Domain.Carpiler.Infra
{
    public class Interpreter
    {
        public Action<string>? PrintHandler { get; }
        public Func<string>? ReadHandler { get; }
        public ObjectCode ObjectCode { get; }

        public Interpreter(Action<string>? printHandler, Func<string>? readHandler, ObjectCode objectCode)
        {
            PrintHandler = printHandler;
            ReadHandler = readHandler;
            ObjectCode = objectCode;
        }

        public T Run<T>()
        {
            foreach (var statement in ObjectCode.SyntaxTree.SkipLast(1))
            {
                statement.Run(this);
            }

            return (T)Convert.ChangeType(ObjectCode.SyntaxTree.Last().Run(this), typeof(T));
        }
    }
}
