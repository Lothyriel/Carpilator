namespace Domain.Carpiler.Grammar
{
    public abstract class Language
    {
        public delegate bool ProductionRule(Token Left, Token Right);

        public Language()
        {
            ReservedWords = InitReservedWords();
            IgnoredCharacters = InitIgnoredCharacters();
            Symbols = InitSymbols();
            MaxSymbolLenght = Symbols.Keys.Select(s => s.Length).Max();
            ProductionRules = InitProductionRules();
        }

        public Dictionary<string, Token> ReservedWords { get; }
        public Dictionary<string, Token> Symbols { get; }
        public int MaxSymbolLenght { get; }
        public List<ProductionRule> ProductionRules { get; }
        public HashSet<char> IgnoredCharacters { get; }

        public abstract char LiteralDelimiter { get; }
        protected abstract HashSet<char> InitIgnoredCharacters();
        protected abstract Dictionary<string, Token> InitReservedWords();
        protected abstract Dictionary<string, Token> InitSymbols();
        protected abstract List<ProductionRule> InitProductionRules();
    }
}