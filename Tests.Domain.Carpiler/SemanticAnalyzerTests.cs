using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Semantic;
using Domain.Carpiler.Syntatic.Constructs;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Tests.Domain.Carpiler
{
    public class SemanticAnalyzerTests
    {
        private CCsharp CCsharp { get; } = new();

        [Fact]
        public void ShouldTypefySymbolTable()
        {
            var numero = new Identifier("numero");

            var symbolTable = new Dictionary<string, Identifier>
            {
                { numero.Value, numero}
            };

            var ast = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, new ValueToken("10", TokenType.IntValue))
            };

            var objectCode = new SemanticAnalyzer(ast, symbolTable, CCsharp.Analyzer).Analyze();

            var expected = new Dictionary<string, TypedIdentifier>
            {
                { numero.Value, new TypedIdentifier(numero, new Type("int")) }
            };

            objectCode.SymbolTable.Should().BeEquivalentTo(expected);
        }
    }
}