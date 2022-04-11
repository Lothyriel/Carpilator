using System.Text;

namespace Domain.Carpiler.Lexical
{
    public class LexicalAnalyzer
    {
        private const char Quotes = '"';

        public LexicalAnalyzer(string sourceCode)
        {
            SourceCode = sourceCode;
            Tokens = new List<Token>();
            Characters = new Queue<char>(sourceCode);
        }

        public string SourceCode { get; }

        private List<Token> Tokens { get; }

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

            switch (current)
            {
                case ';': AddSingle(Token.Semicolon); return;
                case '{': AddSingle(Token.CurlyBraceOpen); return;
                case '}': AddSingle(Token.CurlyBraceClose); return;
                case '[': AddSingle(Token.BracketOpen); return;
                case ']': AddSingle(Token.BracketClose); return;
                case '(': AddSingle(Token.ParenthesisOpen); return;
                case ')': AddSingle(Token.ParenthesisClose); return;
                case '+': AddSingle(Token.Plus); return;
                case '-': AddSingle(Token.Minus); return;
                case '/': AddSingle(Token.Slash); return;
                case '*': AddSingle(Token.Asterisk); return;
                case '&': AddSingle(Token.And); return;
                case '|': AddSingle(Token.Or); return;
                case '=': GetAttributionEquals(); return;
                case '<': GetLesser(); return;
                case '>': GetGreater(); return;
            }

            if (current == Quotes)
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
                GetIdentifier();
                return;
            }

            throw new UnidentifiedToken(current);
        }

        private static bool IgnoreCharacter(char current)
        {
            return current == '\n' || current == ' ' || current == '\r' || current == '\t';
        }

        private void AddSingle(Token token)
        {
            Tokens.Add(token);
            Characters.Dequeue();
        }

        private void GetNumber()
        {
            var number = new StringBuilder();
            GetDigits();

            if (Characters.Peek() != '.')
            {
                Tokens.Add(new Token(number.ToString(), Type.Integer));
                return;
            }

            number.Append('.');
            Characters.Dequeue();

            GetDigits();
            Tokens.Add(new Token(number.ToString(), Type.Float));

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

        private void GetIdentifier()
        {
            var identifier = new StringBuilder();
            char c;

            while (char.IsLetterOrDigit(c = Characters.Peek()))
            {
                identifier.Append(c);
                Characters.Dequeue();
            }

            Tokens.Add(new Token(identifier.ToString(), Type.Identifier));
        }

        private void GetAttributionEquals()
        {
            Characters.Dequeue();

            if (Characters.Peek() == '=')
            {
                AddSingle(Token.Equals);
                return;
            }

            Tokens.Add(Token.Attribution);
        }

        private void GetGreater()
        {
            Characters.Dequeue();

            if (Characters.Peek() == '=')
            {
                AddSingle(Token.GreaterEquals);
                return;
            }

            Tokens.Add(Token.Greater);
        }

        private void GetLesser()
        {
            Characters.Dequeue();

            if (Characters.Peek() == '=')
            {
                AddSingle(Token.LesserEquals);
                return;
            }

            Tokens.Add(Token.Lesser);
        }

        private void GetLiteral()
        {
            Characters.Dequeue();
            var word = new StringBuilder();
            char c;
            while ((c = Characters.Peek()) != Quotes)
            {
                word.Append(c);
                Characters.Dequeue();
            }

            Characters.Dequeue();

            Tokens.Add(new Token(word.ToString(), Type.Literal));
        }
    }
}