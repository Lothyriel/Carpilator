using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
using System.Collections.Generic;

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
            while ((bool)Condition.ToValue() == true)
            {
                foreach (var statement in Statements)
                {
                    if (statement is Return)
                    {
                        return statement.Run(interpreter);
                    }

                    statement.Run(interpreter);
                }
            }

            return CCsharpTokenizer.None;
        }
    }
}