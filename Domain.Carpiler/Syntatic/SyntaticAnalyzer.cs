
using Domain.Carpiler.Infra;
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private List<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        public Tree<Token> TokensTree { get; }

        public SyntaticAnalyzer(List<Token> tokens, Dictionary<string, Token> symbolTable)
        {
            Tokens = tokens;
            SymbolTable = symbolTable;
            throw new NotImplementedException();
            TokensTree = null;
        }

        public object Analyze()
        {
            foreach (var token in Tokens)
            {

            }

            throw new NotImplementedException();
        }
    }
}