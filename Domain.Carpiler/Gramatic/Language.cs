using Domain.Carpiler.Lexical;

namespace Domain.Carpiler.Gramatic
{
    public abstract class Language
    {
        public Language()
        {
            ReservedWords = InitReservedWords();
            IgnoredCharacters = InitIgnoredCharacters();
            Symbols = InitSymbols();
            Mmatrix = InitMmatrix();
            MaxSymbolLenght = Symbols.Keys.Select(s => s.Length).Max();
        }

        public Dictionary<string, Token> ReservedWords { get; }
        public Dictionary<string, Token> Symbols { get; }
        public int MaxSymbolLenght { get; }
        public HashSet<char> IgnoredCharacters { get; }
        public object[,] Mmatrix { get; }
        public abstract char LiteralDelimiter { get; }
        protected abstract HashSet<char> InitIgnoredCharacters();
        protected abstract Dictionary<string, Token> InitReservedWords();
        protected abstract Dictionary<string, Token> InitSymbols();
        protected abstract object[,] InitMmatrix();
    }
}