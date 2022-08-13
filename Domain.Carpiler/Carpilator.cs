using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;

namespace Domain.Carpiler
{
    public class Carpilator
    {
        public Carpilator(string sourceCode, Language language)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = new();
        }
        private Dictionary<string, Identifier> SymbolTable { get; }
        private string SourceCode { get; }
        private Language Language { get; }

        public void Run(Action<string> printHandler, Func<string> readHandler)
        {
            var objectCode = Compile();
            new Interpreter(printHandler, readHandler, objectCode).Run();
        }
        public ObjectCode Compile()
        {
            var tokens = Tokenize();

            var ast = Parse(tokens);

            var aast = Analyze(ast);

            return aast;
        }

        public List<Statement> Parse(List<Token> tokens)
        {
            return new SyntaticAnalyzer(tokens, Language.Parser).Parse();
        }

        public List<Token> Tokenize()
        {
            return new LexicalAnalyzer(SourceCode, Language.Lexer, SymbolTable).Tokenize();
        }

        private ObjectCode Analyze(List<Statement> ast)
        {
            return new SemanticAnalyzer(ast, SymbolTable, Language.Analyzer).Analyze();
        }
    }
}