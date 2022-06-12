using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private Queue<Token> Tokens { get; }
        private Parser Parser { get; }

        public SyntaticAnalyzer(List<Token> tokens, Parser parser)
        {
            Tokens = new(tokens);
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