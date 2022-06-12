using Domain.Carpiler.Lexical;
using Newtonsoft.Json.Linq;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private Queue<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        private Parser Parser { get; }

        public SyntaticAnalyzer(List<Token> tokens, Dictionary<string, Token> symbolTable, Parser parser)
        {
            Tokens = new(tokens);
            SymbolTable = symbolTable;
            Parser = parser;
        }

        public List<IConstruct> Analyze()
        {
            var statements = new List<IConstruct>();

            while (Tokens.Any())
            {
                var construct = Parser.Parse(Tokens);
                statements.Add(construct);
            }

            return statements;
        }
    }
}