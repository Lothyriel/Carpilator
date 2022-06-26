using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Semantic
{
    internal class SemanticAnalyzer
    {
        private List<Statement> SyntaxTree { get; }
        private Dictionary<string, Identifier> SymbolTable { get; }

        public SemanticAnalyzer(List<Statement> syntaxTree, Dictionary<string, Identifier> symbolTable)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        public List<Statement> Analyze()
        {
            SyntaxTree.Select(s => s.);

            foreach (var statement in SyntaxTree)
            {

            }

            return SyntaxTree;
        }
    }
}