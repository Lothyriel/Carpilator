using Domain.Carpiler.Lexical;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Domain.Carpiler.Languages
{
    public sealed class CCsharpTokenizer : Tokenizer
    {
        public override char LiteralDelimiter { get; } = '"';
        protected override HashSet<char> InitIgnoredCharacters()
        {
            return new HashSet<char>()
            {
                '\n',
                ' ',
                '\r',
                '\t'
            };
        }
        protected override Dictionary<string, Token> InitReservedWords()
        {
            var words = new List<Token>()
            {
                New,
                While,
                If,
                Else,
                Float,
                String,
                Bool,
                Int,
                True,
                False
            };

            return words.ToDictionary(token => token.Value);
        }
        protected override Dictionary<string, Token> InitSymbols()
        {
            var words = new List<Token>()
            {
                Equals,
                GreaterEquals,
                LesserEquals,
                Attribution,
                And,
                Or,
                Lesser,
                Greater,
                Plus,
                Minus,
                Slash,
                Asterisk,
                CurlyBraceOpen,
                CurlyBraceClose,
                BracketOpen,
                BracketClose,
                ParenthesisOpen,
                ParenthesisClose,
                Semicolon
            };

            return words.ToDictionary(token => token.Value);
        }

        #region Tokens

        public static ValueToken True { get; } = new("true", TokenType.BoolValue);
        public static ValueToken False { get; } = new("false", TokenType.BoolValue);
        public static Identifier Print { get; } = new("print", TokenType.Identifier);
        public static Identifier Read { get; } = new("read", TokenType.Identifier);
        public static new Operator Equals { get; } = new("==", TokenType.Equals);
        public static Operator Attribution { get; } = new("=", TokenType.Attribution);
        public static Operator And { get; } = new("&", TokenType.And);
        public static Operator Or { get; } = new("|", TokenType.Or);
        public static Operator Lesser { get; } = new("<", TokenType.Lesser);
        public static Operator LesserEquals { get; } = new("<=", TokenType.LesserEquals);
        public static Operator Greater { get; } = new(">", TokenType.Greater);
        public static Operator GreaterEquals { get; } = new(">=", TokenType.GreaterEquals);
        public static Operator Plus { get; } = new("+", TokenType.Plus);
        public static Operator Minus { get; } = new("-", TokenType.Minus);
        public static Operator Slash { get; } = new("/", TokenType.Slash);
        public static Operator Asterisk { get; } = new("*", TokenType.Asterisk);
        public static Token New { get; } = new("new", TokenType.ReservedWord);
        public static Token While { get; } = new("while", TokenType.ReservedWord);
        public static Token If { get; } = new("if", TokenType.ReservedWord);
        public static Token Else { get; } = new("else", TokenType.ReservedWord);
        public static Token Bool { get; } = new("bool", TokenType.Bool);
        public static Token Float { get; } = new("float", TokenType.Float);
        public static Token String { get; } = new("string", TokenType.String);
        public static Token Int { get; } = new Token("int", TokenType.Int);
        public static Token CurlyBraceOpen { get; } = new("{", TokenType.CurlyBraceOpen);
        public static Token CurlyBraceClose { get; } = new("}", TokenType.CurlyBraceClose);
        public static Token BracketOpen { get; } = new("[", TokenType.BracketOpen);
        public static Token BracketClose { get; } = new("]", TokenType.BracketClose);
        public static Token ParenthesisOpen { get; } = new("(", TokenType.ParenthesisOpen);
        public static Token ParenthesisClose { get; } = new(")", TokenType.ParenthesisClose);
        public static Token Semicolon { get; } = new(";", TokenType.Semicolon);

        #endregion
    }
}