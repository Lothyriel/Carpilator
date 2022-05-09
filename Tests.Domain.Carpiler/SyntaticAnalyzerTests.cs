using Domain.Carpiler.Infra;
using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Type = Domain.Carpiler.Lexical.Type;

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
        public void ShouldParseValidASTForSimpleDeclarationAndAssignment()
        {
            var numero = new Token("numero", Type.Identifier);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Attribution,
                new ValueToken("10", Type.IntValue),
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var expectedConstruct = new VariableDeclaration("numero", new ValueToken("10", Type.IntValue), VariableType.Integer);

            var construct = parser.Analyze();

            var jsonExpected = JsonConvert.SerializeObject(expectedConstruct, Formatting.Indented);

            var jsonConstructed = JsonConvert.SerializeObject(construct, Formatting.Indented);

            jsonExpected.Should().Be(jsonConstructed);
        }
    }
}