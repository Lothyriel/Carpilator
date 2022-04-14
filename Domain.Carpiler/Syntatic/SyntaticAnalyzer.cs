using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Infra;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private List<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        private Language Language { get; }
        private Tree<Token> TokensTree { get; }

        public SyntaticAnalyzer(List<Token> tokens, Dictionary<string, Token> symbolTable, Language language)
        {
            Tokens = tokens;
            SymbolTable = symbolTable;
            Language = language;
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