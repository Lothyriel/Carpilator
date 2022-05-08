using Domain.Carpiler.Grammar;
using Domain.Carpiler.Infra;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private Queue<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        private Language Language { get; }
        private Tree<Token> TokensTree { get; }

        public SyntaticAnalyzer(List<Token> tokens, Dictionary<string, Token> symbolTable, Language language)
        {
            Tokens = new(tokens);
            SymbolTable = symbolTable;
            Language = language;
            TokensTree = new();
        }

        public object Analyze()
        {
            while (Tokens.Any())
            {
                IdentifyProduction();
            }

            throw new NotImplementedException();
        }

        private void IdentifyProduction()
        {
            (Token left, Token right) = GetTokens();

            foreach (var rule in Language.ProductionRules)
            {
                if (rule(left, right))
                {
                    //nao sei
                    return;
                }
            }

            throw new Exception($"The token {right} is not valid after {left}");
        }

        private (Token Left, Token Right) GetTokens()
        {
            return (Tokens.Dequeue(), Tokens.Dequeue());
        }
    }
}