using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler
{
    public class Carpilator
    {
        public Carpilator(string sourceCode, Language language)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = new();
        }
        private Dictionary<string, Token> SymbolTable { get; }
        private string SourceCode { get; }
        private Language Language { get; }

        public List<IConstruct> Compile()
        {
            var tokens = new LexicalAnalyzer(SourceCode, Language.Tokenizer, SymbolTable).Analyze();

            var syntaxTree = new SyntaticAnalyzer(tokens, Language.Parser).Analyze();

            //var _ = new SemanticAnalyzer(syntaxTree, SymbolTable).Analyze();

            return syntaxTree;
        }
    }
}