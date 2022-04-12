using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Lexical;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class LexicalAnalyzerTests
    {
        CCsharp CCsharp = new();

        [Fact]
        public void ShouldGetAllTokensString()
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
                new Token("string", Type.Literal),
                CCsharp.Semicolon
                );

            symbolTable.Values.Should().ContainInOrder(
                letras
                );
        }

        [Fact]
        public void ShouldGetAllTokensSimpleWhilePrint()
        {
            var sourceCode = Resource.SimpleWhilePrint;

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
        public void ShouldGetAllTokensSimpleWhileOverArray()
        {
            var sourceCode = Resource.SimpleWhileOverArray;

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