using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Semantic
{
    public class ObjectCode
    {
        public ObjectCode(List<Statement> syntaxTree, Dictionary<string, TypedIdentifier> symbolTable)
        {
            SyntaxTree = syntaxTree;
            SymbolTable = symbolTable;
        }

        public List<Statement> SyntaxTree { get; }
        public Dictionary<string, TypedIdentifier> SymbolTable { get; }
    }
}