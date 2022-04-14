using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;

namespace Domain.Carpiler
{
    public class Carpiler
    {
        public Carpiler(string sourceCode, Language language)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = new();
        }
        private Dictionary<string, Token> SymbolTable { get; }
        private string SourceCode { get; }
        private Language Language { get; }

        public ObjectCode Compile()
        {
            var tokens = new LexicalAnalyzer(SourceCode, Language, SymbolTable).Analyze();

            var syntaxTree = new SyntaticAnalyzer(tokens, SymbolTable, Language).Analyze();

            var parseTree = new SemanticAnalyzer(syntaxTree, SymbolTable).Analyze();

            throw new NotImplementedException();
        }
    }
}