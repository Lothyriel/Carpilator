using Domain.Carpiler.Lexical;
using System.Collections.Generic;
using System.Linq;
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

        public static ValueToken True { get; } = new ValueToken("true", TokenType.BoolValue);
        public static ValueToken False { get; } = new ValueToken("false", TokenType.BoolValue);
        public static Operator EqualsOp { get; } = new Operator("==", TokenType.Equals);
        public static Operator Attribution { get; } = new Operator("=", TokenType.Attribution);
        public static Operator And { get; } = new Operator("&", TokenType.And);
        public static Operator Or { get; } = new Operator("|", TokenType.Or);
        public static Operator Lesser { get; } = new Operator("<", TokenType.Lesser);
        public static Operator LesserEquals { get; } = new Operator("<=", TokenType.LesserEquals);
        public static Operator Greater { get; } = new Operator(">", TokenType.Greater);
        public static Operator GreaterEquals { get; } = new Operator(">=", TokenType.GreaterEquals);
        public static Operator Plus { get; } = new Operator("+", TokenType.Plus);
        public static Operator Minus { get; } = new Operator("-", TokenType.Minus);
        public static Operator Slash { get; } = new Operator("/", TokenType.Slash);
        public static Operator Asterisk { get; } = new Operator("*", TokenType.Asterisk);
        public static ReservedWord New { get; } = new ReservedWord("new");
        public static ReservedWord While { get; } = new ReservedWord("while");
        public static ReservedWord If { get; } = new ReservedWord("if");
        public static ReservedWord Else { get; } = new ReservedWord("else");
        public static ReservedWord Return { get; } = new ReservedWord("return");
        public static ReservedWord None { get; } = new ReservedWord("None");
        public static Identifier Bool { get; } = new Identifier("bool");
        public static Identifier Float { get; } = new Identifier("float");
        public static Identifier String { get; } = new Identifier("string");
        public static Identifier Int { get; } = new Identifier("int");
        public static Identifier Print { get; } = new Identifier("print");
        public static Identifier Read { get; } = new Identifier("read");
        public static Symbol CurlyBraceOpen { get; } = new Symbol("{", TokenType.CurlyBraceOpen);
        public static Symbol CurlyBraceClose { get; } = new Symbol("}", TokenType.CurlyBraceClose);
        public static Symbol BracketOpen { get; } = new Symbol("[", TokenType.BracketOpen);
        public static Symbol BracketClose { get; } = new Symbol("]", TokenType.BracketClose);
        public static Symbol ParenthesisOpen { get; } = new Symbol("(", TokenType.ParenthesisOpen);
        public static Symbol ParenthesisClose { get; } = new Symbol(")", TokenType.ParenthesisClose);
        public static Symbol Semicolon { get; } = new Symbol(";", TokenType.Semicolon);
        public static Symbol Comma { get; } = new Symbol(",", TokenType.Comma);

        #endregion
    }
}