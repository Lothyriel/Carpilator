using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Semantic
{
    internal class SemanticAnalyzer
    {
        private List<Statement> SyntaxTree { get; }
        private Dictionary<string, Token> SymbolTable { get; }

        public SemanticAnalyzer(List<Statement> syntaxTree, Dictionary<string, Token> symbolTable)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        public List<Statement> Analyze()
        {
            throw new NotImplementedException();
        }
    }
}