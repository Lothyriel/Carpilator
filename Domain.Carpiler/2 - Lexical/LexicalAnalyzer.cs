using Domain.Carpiler.Infra;
using System.Text;

namespace Domain.Carpiler.Lexical
{
    public class LexicalAnalyzer
    {
        public LexicalAnalyzer(string sourceCode, Tokenizer language, Dictionary<string, Identifier> symbolTable)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = symbolTable;
            Tokens = new List<Token>();
            Characters = new Queue<char>(sourceCode);
        }

        private string SourceCode { get; }
        private Tokenizer Language { get; }
        private List<Token> Tokens { get; }
        private Dictionary<string, Identifier> SymbolTable { get; }
        private Queue<char> Characters { get; }

        public List<Token> Analyze()
        {
            try
            {
                while (Characters.Any())
                {
                    GetToken();
                }
                return Tokens;
            }
            catch (UnclosedToken)
            {
                throw;
            }
            catch (Exception)
            {
                var current = Characters.Peek();
                throw new UnidentifiedToken(current, SourceCode, Characters.Count);
            }
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

            if (ValidSymbol() == false)
            {
                throw new UnidentifiedToken(current, SourceCode, Characters.Count);
            }
        }

        private bool ValidSymbol()
        {
            var sb = new StringBuilder();
            Token? symbol = null;

            do
            {
                sb.Append(Characters.Peek());
            } while (ValidSymbol(sb, ref symbol) && Characters.Any());

            if (symbol is null)
                return false;

            Tokens.Add(symbol);
            return true;
        }

        private bool ValidSymbol(StringBuilder sb, ref Token? output)   //cannot return symbol directly because a initially valid symbol
        {                                                               //would be overriden by null on encountering a invalid symbol
            var symbol = GetSymbol(sb);
            output = symbol ?? output;
            return symbol is not null;
        }

        private Token? GetSymbol(StringBuilder sb)
        {
            if (Language.MaxSymbolLenght < sb.Length)
                return null;

            if (Language.Symbols.TryGetValue(sb.ToString(), out var symbol))
                Characters.Dequeue();

            return symbol;
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
                Tokens.Add(new ValueToken(number.ToString(), TokenType.IntValue));
                return;
            }

            number.Append('.');
            Characters.Dequeue();

            GetDigits();
            Tokens.Add(new ValueToken(number.ToString(), TokenType.FloatValue));

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
            string identifier = GetIdentifierName();

            if (IsReservedWord(identifier, out var reservedWord))
            {
                Tokens.Add(reservedWord!);
                return;
            }

            AddIdentifier(identifier);
        }

        private void AddIdentifier(string identifier)
        {
            var token = new Identifier(identifier, TokenType.Identifier);

            var newIdentifier = SymbolTable.TryAdd(identifier, token);

            if (newIdentifier == false)
            {
                token = SymbolTable[identifier];
            }
            Tokens.Add(token);
        }

        private string GetIdentifierName()
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

        private bool IsReservedWord(string id, out Token? reserved)
        {
            return Language.ReservedWords.TryGetValue(id, out reserved);
        }

        private void GetLiteral()
        {
            try
            {
                GetStringLiteral();
            }
            catch (InvalidOperationException)
            {
                throw new UnclosedToken('"', SourceCode, Characters.Count);
            }
        }

        private void GetStringLiteral()
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

            Tokens.Add(new ValueToken(word.ToString(), TokenType.StringValue));
        }
    }
}