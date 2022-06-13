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

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

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

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

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

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

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

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

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
                CCsharpTokenizer.ParenthesisOpen,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("input", ReadFunction.Instance, VariableType.String),
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForPrintBinaryExpression()
        {
            var ten = new ValueToken("10", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                ten,
                CCsharpTokenizer.Plus,
                ten,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new PrintFunction(new BinaryExpression(ten, CCsharpTokenizer.Plus, ten))
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForWhilePrintVariable()
        {
            var zero = new ValueToken("0", TokenType.IntValue);
            var i = new ValueToken("i", TokenType.Identifier);
            var ten = new ValueToken("10", TokenType.IntValue);
            var one = new ValueToken("1", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                zero,
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                ten,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,

                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,

                i,
                CCsharpTokenizer.Attribution,
                i,
                CCsharpTokenizer.Plus,
                one,
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.CurlyBraceClose,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("i", new ValueToken("0", TokenType.IntValue), VariableType.Integer),
                new While(new BinaryExpression(i, CCsharpTokenizer.Lesser, ten), 
                    new List<Statement>
                    {
                        new PrintFunction(i),
                        new Assignment(i, new BinaryExpression(i, CCsharpTokenizer.Plus, one))
                    }),
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForArrayDeclaration()
        {
            var ten = new ValueToken("10", TokenType.IntValue);
            var array = new Token("array", TokenType.Identifier);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                CCsharpTokenizer.BracketClose,
                array,
                CCsharpTokenizer.Attribution,
                CCsharpTokenizer.New,
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                ten,
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.Semicolon,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("array", new ValueToken("10", TokenType.IntValue), VariableType.Integer),
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForWhileReadArray()
        {
            var ten = new ValueToken("10", TokenType.IntValue);
            var array = new Token("array", TokenType.Identifier);
            var i = new Token("i", TokenType.Identifier);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                CCsharpTokenizer.BracketClose,
                array,
                CCsharpTokenizer.Attribution,
                CCsharpTokenizer.New,
                CCsharpTokenizer.Int,
                CCsharpTokenizer.BracketOpen,
                ten,
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.Int,
                i,
                CCsharpTokenizer.Attribution,
                ten,
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.While,
                CCsharpTokenizer.ParenthesisOpen,
                i,
                CCsharpTokenizer.Lesser,
                ten,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,

                array,
                CCsharpTokenizer.BracketOpen,
                i,
                CCsharpTokenizer.BracketClose,
                CCsharpTokenizer.Attribution,

                CCsharpTokenizer.Read,
                CCsharpTokenizer.ParenthesisOpen,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,

                i,
                CCsharpTokenizer.Attribution,
                i,
                CCsharpTokenizer.Plus,
                new ValueToken("1", TokenType.IntValue),
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.CurlyBraceClose,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<IConstruct>()
            {
                new VariableDeclaration("numero", new ValueToken("10", TokenType.IntValue), VariableType.Integer),
                new VariableDeclaration("array", new ValueToken("10", TokenType.IntValue), VariableType.Integer),
                new PrintFunction(new BinaryExpression(ten, CCsharpTokenizer.Plus, ten))
            };

            var resulted = parser.Analyze();

            resulted.JsonEquals(expectedConstruct);
        }
    }
}