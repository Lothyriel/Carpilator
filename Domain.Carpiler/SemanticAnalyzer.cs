namespace Domain.Carpiler
{
    internal class SemanticAnalyzer
    {
        private object syntaxTree;

        public SemanticAnalyzer(object syntaxTree)
        {
            this.syntaxTree = syntaxTree;
        }

        internal object Analyze()
        {
            throw new NotImplementedException();
        }
    }
}