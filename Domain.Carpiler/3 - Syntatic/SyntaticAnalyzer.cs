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

        public JObject Analyze()
        {
            var ast = new JObject();

            while (Tokens.Any())
            {
                ast.Add(Parser.Parse(Tokens));
            }

            return ast;
        }
    }
}