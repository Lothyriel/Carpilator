using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Semantic
{
    internal class SemanticAnalyzer
    {
        private object SyntaxTree;
        private Dictionary<string, Token> SymbolTable { get; }

        public SemanticAnalyzer(object syntaxTree, Dictionary<string, Token> symbolTable)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        internal object Analyze()
        {
            throw new NotImplementedException();
        }
    }
}