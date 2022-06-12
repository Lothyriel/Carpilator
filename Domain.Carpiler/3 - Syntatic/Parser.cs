using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Syntatic
{
    public abstract class Parser
    {
        protected Queue<Token>? Tokens;
        public abstract IConstruct Parse(Queue<Token> tokens);
    }
}