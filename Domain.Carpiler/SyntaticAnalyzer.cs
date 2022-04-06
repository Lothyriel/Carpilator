
using Domain.Carpiler.Lexical;

namespace Domain.Carpiler
{
    public class SyntaticAnalyzer
    {
        private List<Token> Tokens { get; }

        public SyntaticAnalyzer(List<Token> tokens)
        {
            Tokens = tokens;
        }

        public object Analyze()
        {
            throw new NotImplementedException();
        }
    }
}