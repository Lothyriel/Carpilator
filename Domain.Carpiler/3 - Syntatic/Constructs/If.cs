namespace Domain.Carpiler.Syntatic.Constructs
{
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