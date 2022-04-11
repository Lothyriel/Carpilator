using Domain.Carpiler.Lexical;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class LexicalAnalyzerTests
    {
        [Fact]
        public void ShouldGetAllTokensString()
        {
            var sourceCode = Resource.StringDeclaration;

            var analyzer = new LexicalAnalyzer(sourceCode);

            var tokens = analyzer.Analyze();

            tokens.Should().ContainInOrder(
                new Token("string", Type.Identifier),
                new Token("letras", Type.Identifier),
                Token.Attribution,
                new Token("string", Type.Literal),
                Token.Semicolon
                );
        }

        [Fact]
        public void ShouldGetAllTokensSimpleWhilePrint()
        {
            var sourceCode = Resource.SimpleWhilePrint;

            var analyzer = new LexicalAnalyzer(sourceCode);

            var tokens = analyzer.Analyze();

            var i = new Token("i", Type.Identifier);

            tokens.Should().ContainInOrder(
                new Token("int", Type.Identifier),
                i,
                Token.Attribution,
                new Token("0", Type.Integer),
                Token.Semicolon,
                new Token("while", Type.Identifier),
                Token.ParenthesisOpen,
                i,
                Token.Lesser,
                new Token("20", Type.Integer),
                Token.ParenthesisClose,
                Token.CurlyBraceOpen,
                new Token("print", Type.Identifier),
                Token.ParenthesisOpen,
                i,
                Token.ParenthesisClose,
                Token.Semicolon,
                Token.CurlyBraceClose
                );
        }

        [Fact]
        public void ShouldGetAllTokensSimpleWhileOverArray()
        {
            var sourceCode = Resource.SimpleWhileOverArray;

            var analyzer = new LexicalAnalyzer(sourceCode);

            var tokens = analyzer.Analyze();

            var array = new Token("array", Type.Identifier);
            var i = new Token("i", Type.Identifier);

            tokens.Should().ContainInOrder(
                new Token("int", Type.Identifier),
                Token.BracketOpen,
                Token.BracketClose,
                array,
                Token.Attribution,
                new Token("new", Type.Identifier),
                new Token("int", Type.Identifier),
                Token.BracketOpen,
                new Token("10", Type.Integer),
                Token.BracketClose,
                Token.Semicolon,
                new Token("int", Type.Identifier),
                i,
                Token.Attribution,
                new Token("0", Type.Integer),
                Token.Semicolon,
                new Token("while", Type.Identifier),
                Token.ParenthesisOpen,
                i,
                Token.Lesser,
                new Token("10", Type.Integer),
                Token.ParenthesisClose,
                Token.CurlyBraceOpen,
                new Token("print", Type.Identifier),
                Token.ParenthesisOpen,
                array,
                Token.BracketOpen,
                i,
                Token.BracketClose,
                Token.ParenthesisClose,
                Token.Semicolon,
                i,
                Token.Attribution,
                i,
                Token.Plus,
                new Token("1", Type.Integer),
                Token.Semicolon,
                Token.CurlyBraceClose
                );
        }
    }
}