using Domain.Carpiler.Lexical;

namespace Domain.Carpiler
{
    public class Carpiler
    {
        public Carpiler(string sourceCode)
        {
            SourceCode = sourceCode;
        }

        private string SourceCode { get; }

        public ObjectCode Compile()
        {
            var tokens = new LexicalAnalyzer(SourceCode).Analyze();

            var syntaxTree = new SyntaticAnalyzer(tokens).Analyze();

            var parseTree = new SemanticAnalyzer(syntaxTree).Analyze();

            throw new NotImplementedException();
        }
    }
}