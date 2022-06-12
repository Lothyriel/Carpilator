using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class LexicalAnalyzerTests
    {
        private CCsharp CCsharp { get; } = new();

        [Fact]
        public void ShouldGetAllTokensBoolDeclaration()
        {
            var sourceCode = Resource.BoolDeclaration;

            var symbolTable = new Dictionary<string, Token>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Tokenizer, symbolTable);

            var tokens = analyzer.Analyze();

            var expressao = new Token("expressao", TokenType.Identifier);

            tokens.Should().ContainInOrder(
                CCsharpTokenizer.Bool,
                expressao,
                CCsharpTokenizer.Attribution,
                new Token("10", TokenType.IntValue),
                CCsharpTokenizer.LesserEquals,
                new Token("5", TokenType.IntValue),
                CCsharpTokenizer.Semicolon
                );

            symbolTable.Values.Should().ContainInOrder(
                expressao
                );
        }

        [Fact]
        public void ShouldGetAllTokensStringDeclaration()
        {
            var sourceCode = Resource.StringDeclaration;

            var symbolTable = new Dictionary<string, Token>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Tokenizer, symbolTable);

            var tokens = analyzer.Analyze();

            var letras = new Token("letras", TokenType.Identifier);
            tokens.Should().ContainInOrder(
                CCsharpTokenizer.String,
                letras,
                CCsharpTokenizer.Attribution,
                new Token("string", TokenType.StringValue),
                CCsharpTokenizer.Semicolon
                );

            symbolTable.Values.Should().ContainInOrder(
                letras
                );
        }

        [Fact]
        public void ShouldGetAllTokensWhilePrint()
        {
            var sourceCode = Resource.WhilePrint;

            var symbolTable = new Dictionary<string, Token>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Tokenizer, symbolTable);

            var tokens = analyzer.Analyze();

            var i = new Token("i", TokenType.Identifier);

            tokens.Should().ContainInOrder(
                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                new Token("0", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                new Token("20", TokenType.IntValue),
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,
                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.CurlyBraceClose
                );

            symbolTable.Values.Should().ContainInOrder(
                i
                );
        }

        [Fact]
        public void ShouldGetAllTokensWhilePrintOverArray()
        {
            var sourceCode = Resource.WhileOverArray;

            var symbolTable = new Dictionary<string, Token>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Tokenizer, symbolTable);

            var tokens = analyzer.Analyze();

            var array = new Token("array", TokenType.Identifier);
            var i = new Token("i", TokenType.Identifier);

            tokens.Should().ContainInOrder(
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                CCsharpTokenizer.BracketClose,
                array,
                CCsharpTokenizer.Attribution,
                CCsharpTokenizer.New,
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                new Token("10", TokenType.IntValue),
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                new Token("0", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                new Token("10", TokenType.IntValue),
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,
                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                array,
                CCsharpTokenizer.BracketOpen,
                i,
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
                i,
                CCsharpTokenizer.Attribution,
                i,
                CCsharpTokenizer.Plus,
                new Token("1", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.CurlyBraceClose
                );

            symbolTable.Values.Should().ContainInOrder(
                array,
                i
                );
        }
    }
}