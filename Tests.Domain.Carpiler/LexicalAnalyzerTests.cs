using Domain.Carpiler.Grammar;
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

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp, symbolTable);

            var tokens = analyzer.Analyze();

            var expressao = new Token("expressao", Type.Identifier);

            tokens.Should().ContainInOrder(
                CCsharp.Bool,
                expressao,
                CCsharp.Attribution,
                new Token("10", Type.IntValue),
                CCsharp.LesserEquals,
                new Token("5", Type.IntValue),
                CCsharp.Semicolon
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

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp, symbolTable);

            var tokens = analyzer.Analyze();

            var letras = new Token("letras", Type.Identifier);
            tokens.Should().ContainInOrder(
                CCsharp.String,
                letras,
                CCsharp.Attribution,
                new Token("string", Type.StringValue),
                CCsharp.Semicolon
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

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp, symbolTable);

            var tokens = analyzer.Analyze();

            var i = new Token("i", Type.Identifier);

            tokens.Should().ContainInOrder(
                CCsharp.Int,
                i,
                CCsharp.Attribution,
                new Token("0", Type.IntValue),
                CCsharp.Semicolon,
                CCsharp.While,
                CCsharp.ParenthesisOpen,
                i,
                CCsharp.Lesser,
                new Token("20", Type.IntValue),
                CCsharp.ParenthesisClose,
                CCsharp.CurlyBraceOpen,
                CCsharp.Print,
                CCsharp.ParenthesisOpen,
                i,
                CCsharp.ParenthesisClose,
                CCsharp.Semicolon,
                CCsharp.CurlyBraceClose
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

            var analyzer = new LexicalAnalyzer(sourceCode, CCsharp, symbolTable);

            var tokens = analyzer.Analyze();

            var array = new Token("array", Type.Identifier);
            var i = new Token("i", Type.Identifier);

            tokens.Should().ContainInOrder(
                CCsharp.Int,
                CCsharp.BracketOpen,
                CCsharp.BracketClose,
                array,
                CCsharp.Attribution,
                CCsharp.New,
                CCsharp.Int,
                CCsharp.BracketOpen,
                new Token("10", Type.IntValue),
                CCsharp.BracketClose,
                CCsharp.Semicolon,
                CCsharp.Int,
                i,
                CCsharp.Attribution,
                new Token("0", Type.IntValue),
                CCsharp.Semicolon,
                CCsharp.While,
                CCsharp.ParenthesisOpen,
                i,
                CCsharp.Lesser,
                new Token("10", Type.IntValue),
                CCsharp.ParenthesisClose,
                CCsharp.CurlyBraceOpen,
                CCsharp.Print,
                CCsharp.ParenthesisOpen,
                array,
                CCsharp.BracketOpen,
                i,
                CCsharp.BracketClose,
                CCsharp.ParenthesisClose,
                CCsharp.Semicolon,
                i,
                CCsharp.Attribution,
                i,
                CCsharp.Plus,
                new Token("1", Type.IntValue),
                CCsharp.Semicolon,
                CCsharp.CurlyBraceClose
                );

            symbolTable.Values.Should().ContainInOrder(
                array,
                i
                );
        }
    }
}