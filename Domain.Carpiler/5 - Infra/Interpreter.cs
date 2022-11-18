using Domain.Carpiler.Semantic;

namespace Domain.Carpiler.Infra
{
    public class Interpreter
    {
        public ObjectCode ObjectCode { get; }

        public Interpreter(ObjectCode objectCode)
        {
            ObjectCode = objectCode;
        }

        public T Run<T>()
        {
            foreach (var statement in ObjectCode.SyntaxTree.SkipLast(1))
            {
                statement.Run(this);
            }

            var lastValue = ObjectCode.SyntaxTree.Last().Run(this);

            return (T)Convert.ChangeType(lastValue, typeof(T));
        }
    }
}
