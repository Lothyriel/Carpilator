using Domain.Carpiler.Gramatic;
using System.Text;

namespace Domain.Carpiler.Lexical
{
    public class LexicalAnalyzer
    {
        public LexicalAnalyzer(string sourceCode, Language language, Dictionary<string, Token> symbolTable)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = symbolTable;
            Tokens = new List<Token>();
            Characters = new Queue<char>(sourceCode);
        }

        public string SourceCode { get; }
        public Language Language { get; }
        private List<Token> Tokens { get; }
        private Dictionary<string, Token> SymbolTable { get; }
        private Queue<char> Characters { get; }

        public List<Token> Analyze()
        {
            while (Characters.Any())
            {
                GetToken();
            }

            return Tokens;
        }

        private void GetToken()
        {
            var current = Characters.Peek();

            if (IgnoreCharacter(current))
            {
                Characters.Dequeue();
                return;
            }

            if (current == Language.LiteralDelimiter)
            {
                GetLiteral();
                return;
            }

            if (char.IsDigit(current))
            {
                GetNumber();
                return;
            }

            if (char.IsLetter(current))
            {
                GetReservedWordIdentifier();
                return;
            }

            var sb = new StringBuilder(current);
            for (int count = 0; count < Language.MaxSymbolLenght; count++)
            {
                if (Language.Symbols.TryGetValue(sb.ToString(), out var symbol))
                {
                    Tokens.Add(symbol);
                    return;
                }
                sb.Append(Characters.Dequeue());
            }

            throw new UnidentifiedToken(current);
        }

        private bool IgnoreCharacter(char current)
        {
            return Language.IgnoredCharacters.TryGetValue(current, out _);
        }

        private void GetNumber()
        {
            var number = new StringBuilder();
            GetDigits();

            if (Characters.Peek() != '.')
            {
                Tokens.Add(new Token(number.ToString(), Type.IntValue));
                return;
            }

            number.Append('.');
            Characters.Dequeue();

            GetDigits();
            Tokens.Add(new Token(number.ToString(), Type.FloatValue));

            void GetDigits()
            {
                char c;
                while (char.IsDigit(c = Characters.Peek()))
                {
                    number.Append(c);
                    Characters.Dequeue();
                }
            }
        }

        private void GetReservedWordIdentifier()
        {
            string identifier = GetIdentifier();

            if (IsReservedWord(identifier, out var reservedWord))
            {
                Tokens.Add(reservedWord);
                return;
            }

            var token = new Token(identifier, Type.Identifier);

            var newIdentifier = SymbolTable.TryAdd(identifier, token);

            if (newIdentifier == false)
            {
                token = SymbolTable[identifier];
            }
            Tokens.Add(token);
        }

        private string GetIdentifier()
        {
            var sb = new StringBuilder();
            char c;

            while (char.IsLetterOrDigit(c = Characters.Peek()))
            {
                sb.Append(c);
                Characters.Dequeue();
            }

            return sb.ToString();
        }

        private bool IsReservedWord(string id, out Token reserved)
        {
            return Language.ReservedWords.TryGetValue(id, out reserved!);
        }

        private void GetLiteral()
        {
            Characters.Dequeue();
            var word = new StringBuilder();
            char c;
            while ((c = Characters.Peek()) != Language.LiteralDelimiter)
            {
                word.Append(c);
                Characters.Dequeue();
            }

            Characters.Dequeue();

            Tokens.Add(new Token(word.ToString(), Type.Literal));
        }
    }
}