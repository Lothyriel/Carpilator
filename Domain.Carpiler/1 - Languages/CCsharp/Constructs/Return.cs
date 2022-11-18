using Domain.Carpiler.Infra;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class Return : Statement
    {
        public Return(IValuable returnValue)
        {
            ReturnValue = returnValue;
        }

        public IValuable ReturnValue { get; }

        public override object Run(Interpreter interpreter)
        {
            return ReturnValue.ToValue();
        }
    }
}
