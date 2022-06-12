using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;
using System.Collections.Generic;
using Xunit;
using TokenType = Domain.Carpiler.Lexical.TokenType;
using BinaryExpression = Domain.Carpiler.Syntatic.Constructs.BinaryExpression;

namespace Tests.Domain.Carpiler
{
    public class SyntaticAnalyzerTests
    {
        private CCsharp CCsharp { get; } = new();

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentInline()
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
                new VariableDeclaration("numero", new BinaryExpression(ten, CCsharpTokenizer.Plus, ten), VariableType.Integer)
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentValue()
        {
            var numero = new Token("numero", TokenType.Identifier);
            var ten = new ValueToken("10", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Semicolon,
                numero,
                CCsharpTokenizer.Attribution,
                ten,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("numero", null, VariableType.Integer),
                new Assignment(numero, ten)
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentExpression()
        {
            var numero = new Token("numero", TokenType.Identifier);
            var ten = new ValueToken("10", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Semicolon,
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
                new VariableDeclaration("numero", null, VariableType.Integer),
                new Assignment(numero, new BinaryExpression(ten, CCsharpTokenizer.Plus, ten)),
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssigmentRead()
        {
            var input = new Token("input", TokenType.Identifier);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.String,
                input,
                CCsharpTokenizer.Attribution,
                CCsharpTokenizer.Read,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, new(), CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("input", ReadFunction.Instance, VariableType.String),
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }
    }
}