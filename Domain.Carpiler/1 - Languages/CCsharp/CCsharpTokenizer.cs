using Domain.Carpiler.Lexical;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Domain.Carpiler.Languages
{
    public sealed class CCsharpTokenizer : Lexer
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
                True,
                False,
                Return,
                None
            };

            return words.ToDictionary(token => token.Value);
        }
        protected override Dictionary<string, Symbol> InitSymbols()
        {
            var words = new List<Symbol>()
            {
                EqualsOp,
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
                Semicolon,
                Comma
            };

            return words.ToDictionary(token => token.Value);
        }

        #region Tokens

        public static ValueToken True { get; } = new("true", TokenType.BoolValue);
        public static ValueToken False { get; } = new("false", TokenType.BoolValue);
        public static Operator EqualsOp { get; } = new("==", TokenType.Equals);
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
        public static ReservedWord New { get; } = new("new");
        public static ReservedWord While { get; } = new("while");
        public static ReservedWord If { get; } = new("if");
        public static ReservedWord Else { get; } = new("else");
        public static ReservedWord Return { get; } = new("return");
        public static ReservedWord None { get; } = new("None");
        public static Identifier Bool { get; } = new("bool");
        public static Identifier Float { get; } = new("float");
        public static Identifier String { get; } = new("string");
        public static Identifier Int { get; } = new("int");
        public static Identifier Print { get; } = new("print");
        public static Identifier Read { get; } = new("read");
        public static Symbol CurlyBraceOpen { get; } = new("{", TokenType.CurlyBraceOpen);
        public static Symbol CurlyBraceClose { get; } = new("}", TokenType.CurlyBraceClose);
        public static Symbol BracketOpen { get; } = new("[", TokenType.BracketOpen);
        public static Symbol BracketClose { get; } = new("]", TokenType.BracketClose);
        public static Symbol ParenthesisOpen { get; } = new("(", TokenType.ParenthesisOpen);
        public static Symbol ParenthesisClose { get; } = new(")", TokenType.ParenthesisClose);
        public static Symbol Semicolon { get; } = new(";", TokenType.Semicolon);
        public static Symbol Comma { get; } = new(",", TokenType.Comma);

        #endregion
    }
}