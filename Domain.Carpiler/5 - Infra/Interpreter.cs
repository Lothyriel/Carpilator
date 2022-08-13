using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;

namespace Domain.Carpiler.Infra
{
    public class Interpreter
    {
        public Action<string> PrintHandler { get; }
        public Func<string> ReadHandler { get; }
        public ObjectCode ObjectCode { get; }

        public Interpreter(Action<string> printHandler, Func<string> readHandler, ObjectCode objectCode)
        {
            PrintHandler = printHandler;
            ReadHandler = readHandler;
            ObjectCode = objectCode;
        }

        public void Run()
        {
            foreach (var statement in ObjectCode.SyntaxTree)
            {
                statement.Run(this);
            }
        }
    }
}
