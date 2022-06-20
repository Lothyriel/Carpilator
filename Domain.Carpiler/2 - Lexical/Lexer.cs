namespace Domain.Carpiler.Lexical
{
    public abstract class Lexer
    {
        public Lexer()
        {
            ReservedWords = InitReservedWords();
            IgnoredCharacters = InitIgnoredCharacters();
            Symbols = InitSymbols();
            MaxSymbolLenght = Symbols.Keys.Max(s => s.Length);
        }

        public Dictionary<string, Token> ReservedWords { get; }
        public Dictionary<string, Symbol> Symbols { get; }
        public int MaxSymbolLenght { get; }
        public HashSet<char> IgnoredCharacters { get; }

        public abstract char LiteralDelimiter { get; }
        protected abstract HashSet<char> InitIgnoredCharacters();
        protected abstract Dictionary<string, Token> InitReservedWords();
        protected abstract Dictionary<string, Symbol> InitSymbols();
    }
}