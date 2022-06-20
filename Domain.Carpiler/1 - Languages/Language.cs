using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public abstract class Language
    {
        public abstract Lexer Tokenizer { get; }
        public abstract Parser Parser { get; }
    }
}