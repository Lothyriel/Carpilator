using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
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
        private Dictionary<string, Identifier> SymbolTable { get; }
        private string SourceCode { get; }
        private Language Language { get; }

        public List<Statement> Compile()
        {
            var tokens = Tokenize();

            var syntaxTree = Parse(tokens);

            //var _ = new SemanticAnalyzer(syntaxTree, SymbolTable).Analyze();

            return syntaxTree;
        }

        public List<Statement> Parse(List<Token> tokens)
        {
            return new SyntaticAnalyzer(tokens, Language.Parser).Parse();
        }

        public List<Token> Tokenize()
        {
            return new LexicalAnalyzer(SourceCode, Language.Tokenizer, SymbolTable).Tokenize();
        }
    }
}