using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public sealed class CCsharp : Language
    {
        public override Lexer Tokenizer { get; } = new CCsharpTokenizer();

        public override Parser Parser { get; } = new CCsharpParser();
    }
}