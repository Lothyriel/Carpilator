using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Semantic
{
    internal class SemanticAnalyzer
    {
        private object SyntaxTree { get; }
        private Dictionary<string, Token> SymbolTable { get; }

        public SemanticAnalyzer(object syntaxTree, Dictionary<string, Token> symbolTable)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        public object Analyze()
        {
            throw new NotImplementedException();
        }
    }
}