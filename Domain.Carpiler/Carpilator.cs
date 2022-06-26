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
        private Dictionary<string, Identifier> SymbolTable { get; }
        private string SourceCode { get; }
        private Language Language { get; }

        public List<Statement> Compile()
        {
            var tokens = Tokenize();

            var ast = Parse(tokens);

            var aast = Analyze(ast);

            return aast;
        }

        private List<Statement> Analyze(List<Statement> ast)
        {
            return new SemanticAnalyzer(ast, SymbolTable).Analyze();
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