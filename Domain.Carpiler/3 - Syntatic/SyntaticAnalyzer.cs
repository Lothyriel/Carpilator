using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic.Constructs;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Carpiler.Syntatic
{
    public class SyntaticAnalyzer
    {
        private Queue<Token> Tokens { get; }
        private Parser Parser { get; }

        public SyntaticAnalyzer(List<Token> tokens, Parser parser)
        {
            Tokens = new Queue<Token>(tokens);
            Parser = parser;
        }

        public List<Statement> Parse()
        {
            var statements = new List<Statement>();

            while (Tokens.Any())
            {
                statements.Add(Parser.Parse(Tokens));
            }

            return statements;
        }
    }
}