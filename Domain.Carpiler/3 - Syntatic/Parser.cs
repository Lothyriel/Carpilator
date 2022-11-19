using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;
using System.Collections.Generic;

namespace Domain.Carpiler.Syntatic
{
    public abstract class Parser
    {
        protected Token Current => Tokens!.Peek();

        protected Queue<Token>? Tokens;
        public abstract Statement Parse(Queue<Token> tokens);
    }
}