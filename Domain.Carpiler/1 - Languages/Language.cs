using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public abstract class Language
    {
        public abstract Tokenizer Tokenizer { get; }
        public abstract Parser Parser { get; }
    }
}