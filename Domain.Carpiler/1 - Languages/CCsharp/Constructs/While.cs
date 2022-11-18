using Domain.Carpiler.Infra;

namespace Domain.Carpiler.Syntatic.Constructs
{
    public class While : Statement
    {
        public While(IValuable condition, List<Statement> statements)
        {
            Condition = condition;
            Statements = statements;
        }

        public IValuable Condition { get; }
        public List<Statement> Statements { get; }

        public override object Run(Interpreter interpreter)
        {
            throw new NotImplementedException();
        }
    }
}