using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public abstract class Language
    {
        public abstract Lexer Lexer { get; }
        public abstract Parser Parser { get; }
        public abstract Analyzer Analyzer { get; }
    }
}