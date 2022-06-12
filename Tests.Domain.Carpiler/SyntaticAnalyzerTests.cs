using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Tests.Domain.Carpiler
{
    public class SyntaticAnalyzerTests
    {
        private CCsharp CCsharp { get; } = new();

        [Fact]
        public void ShouldThrowNotClosedQuotesError()
        {
            var tokens = new List<Token>();

            var symbolTable = new HashSet<Token>();

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var analyze = () => parser.Analyze();

            analyze.Should().ThrowExactly<NotClosed>();
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignment()
        {
            var numero = new Token("numero", TokenType.Identifier);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Attribution,
                new ValueToken("10", TokenType.IntValue),
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("numero", new ValueToken("10", TokenType.IntValue), VariableType.Integer)
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndBinaryExpressionAssignment()
        {
            var numero = new Token("numero", TokenType.Identifier);

            var ten = new ValueToken("10", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Attribution,
                ten,
                CCsharpTokenizer.Plus,
                ten,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("numero", new Expression(ten,CCsharpTokenizer.Plus,ten), VariableType.Integer)
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }
    }
}