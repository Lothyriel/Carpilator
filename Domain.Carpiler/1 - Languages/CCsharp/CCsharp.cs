using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public sealed class CCsharp : Language
    {
        public override Lexer Lexer { get; } = new CCsharpTokenizer();

        public override Parser Parser { get; } = new CCsharpParser();

        public override Analyzer Analyzer { get; } = new CCsharpAnalyzer();
    }
}