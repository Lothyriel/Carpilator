namespace Domain.Carpiler.Syntatic.Constructs
{
    public class ReadFunction : Statement, IValuable
    {
    }

    public class PrintFunction : Statement
    {
        public IValuable Expression { get; }

        public PrintFunction(IValuable expression)
        {
            Expression = expression;
        }
    }
    public class While : Statement
    {
        public While(IValuable condition, List<Statement> statements)
        {
            Condition = condition;
            Statements = statements;
        }

        public IValuable Condition { get; }
        public List<Statement> Statements { get; }
    }

    public class If : Statement
    {
        public If(IValuable condition, List<Statement> statements)
        {
            Condition = condition;
            Statements = statements;
        }

        public IValuable Condition { get; }
        public List<Statement> Statements { get; }
    }
}