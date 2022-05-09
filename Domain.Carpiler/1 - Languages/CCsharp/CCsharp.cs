using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler.Languages
{
    public class CCsharp : Language
    {
        public override Tokenizer Tokenizer { get; } = new CCsharpTokenizer();

        public override Parser Parser { get; } = new CCsharpParser();
    }
}