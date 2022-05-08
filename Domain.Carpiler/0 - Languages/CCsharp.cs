using Domain.Carpiler.Grammar;
using Type = Domain.Carpiler.Grammar.Type;

namespace Domain.Carpiler.Languages
{
    public sealed class CCsharp : Language
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
                Print,
                Read,
                New,
                While,
                If,
                Else,
                Float,
                String,
                Bool,
                Int,
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

        public static Token Print { get; } = new Token("print", Type.ReservedWord);
        public static Token Read { get; } = new Token("read", Type.ReservedWord);
        public static Token New { get; } = new Token("new", Type.ReservedWord);
        public static Token While { get; } = new Token("while", Type.ReservedWord);
        public static Token If { get; } = new Token("if", Type.ReservedWord);
        public static Token Else { get; } = new Token("else", Type.ReservedWord);
        public static Token Bool { get; } = new Token("bool", Type.ReservedWord);
        public static Token Float { get; } = new Token("float", Type.ReservedWord);
        public static Token String { get; } = new Token("string", Type.ReservedWord);
        public static Token Int { get; } = new Token("int", Type.ReservedWord);
        public static new Token Equals { get; } = new("==", Type.Equals);
        public static Token Attribution { get; } = new("=", Type.Attribution);
        public static Token And { get; } = new("&", Type.And);
        public static Token Or { get; } = new("|", Type.Or);
        public static Token Lesser { get; } = new("<", Type.Lesser);
        public static Token LesserEquals { get; } = new("<=", Type.LesserEquals);
        public static Token Greater { get; } = new(">", Type.Greater);
        public static Token GreaterEquals { get; } = new(">=", Type.GreaterEquals);
        public static Token Plus { get; } = new("+", Type.Plus);
        public static Token Minus { get; } = new("-", Type.Minus);
        public static Token Slash { get; } = new("/", Type.Slash);
        public static Token Asterisk { get; } = new("*", Type.Asterisk);
        public static Token CurlyBraceOpen { get; } = new("{", Type.CurlyBraceOpen);
        public static Token CurlyBraceClose { get; } = new("}", Type.CurlyBraceClose);
        public static Token BracketOpen { get; } = new("[", Type.BracketOpen);
        public static Token BracketClose { get; } = new("]", Type.BracketClose);
        public static Token ParenthesisOpen { get; } = new("(", Type.ParenthesisOpen);
        public static Token ParenthesisClose { get; } = new(")", Type.ParenthesisClose);
        public static Token Semicolon { get; } = new(";", Type.Semicolon);

        #endregion

        protected override List<ProductionRule> InitProductionRules()
        {
            return new List<ProductionRule>()
            {
                VariableDeclaration
            };
        }

        #region ProductionRules

        private static bool VariableDeclaration(Token left, Token right)
        {
            var typeDeclaration = left.Type == Type.Float ||
                                  left.Type == Type.Int ||
                                  left.Type == Type.String;

            var rightIdentifier = right.Type == Type.Identifier;

            return typeDeclaration == true && rightIdentifier;
        }

        #endregion
    }
}