using Domain.Carpiler.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Carpiler.Lexical
{
    public class LexicalAnalyzer
    {
        public LexicalAnalyzer(string sourceCode, Lexer language, Dictionary<string, Identifier> symbolTable)
        {
            SourceCode = sourceCode;
            Language = language;
            SymbolTable = symbolTable;
            Tokens = new List<Token>();
            Characters = new Queue<char>(sourceCode);
        }

        private string SourceCode { get; }
        private Lexer Language { get; }
        private List<Token> Tokens { get; }
        private Dictionary<string, Identifier> SymbolTable { get; }
        private Queue<char> Characters { get; }
        public int Counter { get; private set; }

        public List<Token> Tokenize()
        {
            try
            {
                return GetTokens();
            }
            catch (InvalidOperationException)
            {
                throw new Exception($"Expected ; at position {Counter + 1}");
            }
            catch (Exception)
            {
                var current = Characters.Peek();
                throw new UnidentifiedToken(current, SourceCode, Characters.Count);
            }
        }

        private List<Token> GetTokens()
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
                Consume();
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

            if (ValidSymbol())
            {
                return;
            }

            throw new UnidentifiedToken(current, SourceCode, Characters.Count);
        }

        private char Consume()
        {
            Counter++;
            return Characters.Dequeue();
        }

        private bool ValidSymbol()
        {
            var sb = new StringBuilder();
            Token symbol = null;

            do
            {
                sb.Append(Characters.Peek());
            } while (ValidSymbol(sb, ref symbol) && Characters.Any());

            if (symbol is null)
                return false;

            Tokens.Add(symbol);
            return true;
        }

        private bool ValidSymbol(StringBuilder sb, ref Token output)   //cannot return symbol directly because a initially valid symbol
        {                                                               //would be overriden by null on encountering a invalid symbol
            var symbol = GetSymbol(sb);
            output = symbol ?? output;
            return symbol != null;
        }

        private Token GetSymbol(StringBuilder sb)
        {
            if (Language.MaxSymbolLenght < sb.Length)
                return null;

            if (Language.Symbols.TryGetValue(sb.ToString(), out var symbol))
                Consume();

            return symbol;
        }

        private bool IgnoreCharacter(char current)
        {
            return Language.IgnoredCharacters.Contains(current);
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
            Consume();

            GetDigits();
            Tokens.Add(new ValueToken(number.ToString(), TokenType.FloatValue));

            void GetDigits()
            {
                while (char.IsDigit(Characters.Peek()))
                {
                    number.Append(Consume());
                }
            }
        }

        private void GetReservedWordIdentifier()
        {
            string identifier = GetIdentifierName();

            (var isReserved, var token) = IsReservedWord(identifier);

            if (isReserved)
            {
                Tokens.Add(token);
                return;
            }

            AddIdentifier(identifier);
        }

        private void AddIdentifier(string identifier)
        {
            var token = new Identifier(identifier);

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

            while (char.IsLetterOrDigit(Characters.Peek()))
            {
                sb.Append(Consume());
            }

            return sb.ToString();
        }

        private (bool IsReserved, Token Token) IsReservedWord(string id)
        {
            return (Language.ReservedWords.TryGetValue(id, out var reserved), reserved);
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
            Consume();
            var word = new StringBuilder();

            while (Characters.Peek() != Language.LiteralDelimiter)
            {
                word.Append(Consume());
            }

            Consume();

            Tokens.Add(new ValueToken(word.ToString(), TokenType.StringValue));
        }
    }
}