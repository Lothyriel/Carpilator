using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Semantic
{
    public class SemanticAnalyzer
    {
        private List<Statement> SyntaxTree { get; }
        private Dictionary<string, Identifier> SymbolTable { get; }

        public SemanticAnalyzer(List<Statement> syntaxTree, Dictionary<string, Identifier> symbolTable, Analyzer analyzer)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        public ObjectCode Analyze()
        {
            var typedSymbolTable = new Dictionary<string, TypedIdentifier>();

            foreach (var statement in SyntaxTree)
            {
                if (statement is IDeclarative declaration)
                {
                    var type = declaration.Typefy();
                    typedSymbolTable.Add(type.Value, type);
                }

                //validate semantics
            }

            return new ObjectCode(SyntaxTree, typedSymbolTable);
        }
    }
}