using Domain.Carpiler;
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

            var compiler = new LexicalAnalyzer(sourceCode);

            var tokens = compiler.Analyze();

            tokens.Should().ContainInOrder(
                new Token("string", Type.Identifier),
                new Token("letras", Type.Identifier),
                Token.Attribution,
                new Token("string", Type.Literal),
                Token.Semicolon
                );
        }

        [Fact]
        public void ShouldGetAllTokensSimpleWhile()
        {
            var sourceCode = Resource.SimpleWhilePrint;

            var compiler = new LexicalAnalyzer(sourceCode);

            var tokens = compiler.Analyze();

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
                Token.BracketOpen,
                new Token("print", Type.Identifier),
                Token.ParenthesisOpen,
                i,
                Token.ParenthesisClose,
                Token.Semicolon,
                Token.BracketClose
                );
        }


        [Fact]
        public void ShouldThrowNotClosedQuotesError()
        {
            var sourceCode = Resource.StringDeclarationNoCloseQuotes;

            var compiler = new LexicalAnalyzer(sourceCode);

            var analyze = () => compiler.Analyze();

            analyze.Should().ThrowExactly<NotClosed>();
        }
    }
}