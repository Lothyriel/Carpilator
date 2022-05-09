using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic
{
    public abstract class Parser
    {
        public abstract Construct? Parse(Queue<Token> tokens);

    }
}
