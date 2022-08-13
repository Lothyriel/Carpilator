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

            var symbolTable = new Dictionary<string, Identifier>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Lexer, symbolTable);

            var tokens = analyzer.Tokenize();

            var expressao = new Identifier("expressao");

            tokens.Should().ContainInOrder
            (
                CCsharpTokenizer.Bool,
                expressao,
                CCsharpTokenizer.Attribution,
                new ValueToken("10", TokenType.IntValue),
                CCsharpTokenizer.LesserEquals,
                new ValueToken("5", TokenType.IntValue),
                CCsharpTokenizer.Semicolon
            );

            symbolTable.Values.Should().ContainInOrder
            (
                CCsharpTokenizer.Bool,
                expressao
            );
        }

        [Fact]
        public void ShouldGetAllTokensStringDeclaration()
        {
            var sourceCode = Resource.StringDeclaration;

            var symbolTable = new Dictionary<string, Identifier>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Lexer, symbolTable);

            var tokens = analyzer.Tokenize();

            var letras = new Identifier("letras");

            tokens.Should().ContainInOrder
            (
                CCsharpTokenizer.String,
                letras,
                CCsharpTokenizer.Attribution,
                new ValueToken("string", TokenType.StringValue),
                CCsharpTokenizer.Semicolon
            );

            symbolTable.Values.Should().ContainInOrder
            (
                CCsharpTokenizer.String,
                letras
            );
        }

        [Fact]
        public void ShouldGetAllTokensWhilePrint()
        {
            var sourceCode = Resource.WhilePrint;

            var symbolTable = new Dictionary<string, Identifier>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Lexer, symbolTable);

            var tokens = analyzer.Tokenize();

            var i = new Identifier("i");

            tokens.Should().ContainInOrder
            (
                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                new ValueToken("0", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                new ValueToken("20", TokenType.IntValue),
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,
                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.CurlyBraceClose
            );

            symbolTable.Values.Should().ContainInOrder
            (
                CCsharpTokenizer.Int,
                i
            );
        }

        [Fact]
        public void ShouldGetAllTokensWhilePrintOverArray()
        {
            var sourceCode = Resource.WhileOverArray;

            var symbolTable = new Dictionary<string, Identifier>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Lexer, symbolTable);

            var tokens = analyzer.Tokenize();

            var array = new Identifier("array");
            var i = new Identifier("i");

            tokens.Should().ContainInOrder
            (
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                CCsharpTokenizer.BracketClose,
                array,
                CCsharpTokenizer.Attribution,
                CCsharpTokenizer.New,
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                new ValueToken("10", TokenType.IntValue),
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                new ValueToken("0", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                new ValueToken("10", TokenType.IntValue),
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
                new ValueToken("1", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,
                CCsharpTokenizer.CurlyBraceClose
            );

            symbolTable.Values.Should().ContainInOrder
            (
                CCsharpTokenizer.Int,
                array,
                i
            );
        }

        [Fact]
        public void ShouldGetAllTokensWhileTrue()
        {
            var sourceCode = Resource.WhileTrue;

            var symbolTable = new Dictionary<string, Identifier>();

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp.Lexer, symbolTable);

            var tokens = analyzer.Tokenize();

            tokens.Should().ContainInOrder
            (
                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                CCsharpTokenizer.True,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,
                CCsharpTokenizer.CurlyBraceClose
            );

            symbolTable.Values.Should().ContainInOrder();
        }
    }
}