using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler
{
    public class Carpiler
    {
        public Carpiler(string sourceCode)
        {
            SourceCode = sourceCode;
            SymbolTable = new();
        }
        private Dictionary<string, Token> SymbolTable { get; }
        private string SourceCode { get; }

        public ObjectCode Compile()
        {
            var tokens = new LexicalAnalyzer(SourceCode, new CCsharp(), SymbolTable).Analyze();

            var syntaxTree = new SyntaticAnalyzer(tokens, SymbolTable).Analyze();

            var parseTree = new SemanticAnalyzer(syntaxTree, SymbolTable).Analyze();

            throw new NotImplementedException();
        }
    }
}