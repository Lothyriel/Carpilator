﻿using Domain.Carpiler.Languages;
using Domain.Carpiler.Lexical;
using Domain.Carpiler.Syntatic;
using Domain.Carpiler.Syntatic.Constructs;
using System;
using System.Collections.Generic;
using Xunit;
using BinaryExpression = Domain.Carpiler.Syntatic.Constructs.BinaryExpression;
using TokenType = Domain.Carpiler.Lexical.TokenType;

namespace Tests.Domain.Carpiler
{
    public class SyntaticAnalyzerTests
    {
        private CCsharp CCsharp { get; } = new();

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentInline()
        {
            var numero = new Identifier("numero");

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Attribution,
                new ValueToken("10", TokenType.IntValue),
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, new ValueToken("10", TokenType.IntValue))
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndBinaryExpressionAssignment()
        {
            var numero = new Identifier("numero");

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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, new BinaryExpression(ten, CCsharpTokenizer.Plus, ten))
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationWithAssigmentAndAssignmentValue()
        {
            var numero = new Identifier("numero");
            var zero = new ValueToken("0", TokenType.IntValue);
            var one = new ValueToken("1", TokenType.IntValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Int,
                numero,
                CCsharpTokenizer.Attribution,
                zero,
                CCsharpTokenizer.Semicolon,

                numero,
                CCsharpTokenizer.Attribution,
                numero,
                CCsharpTokenizer.Plus,
                one,
                CCsharpTokenizer.Semicolon
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, zero),
                new Assignment(numero, new BinaryExpression(numero, CCsharpTokenizer.Plus, one))
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentValue()
        {
            var numero = new Identifier("numero");
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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, null),
                new Assignment(numero, ten)
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssignmentExpression()
        {
            var numero = new Identifier("numero");
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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, numero, null),
                new Assignment(numero, new BinaryExpression(ten, CCsharpTokenizer.Plus, ten)),
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForVariableDeclarationAndAssigmentRead()
        {
            var input = new Identifier("input");

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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.String, input, new FunctionCall(CCsharpTokenizer.Read, new ())),
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForIfPrint()
        {
            var ten = new ValueToken("10", TokenType.IntValue);
            var five = new ValueToken("5", TokenType.IntValue);
            var maior = new ValueToken("MAIOR", TokenType.StringValue);

            var tokens = new List<Token>()
            {
                CCsharpTokenizer.If,
                CCsharpTokenizer.ParenthesisOpen,

                ten,
                CCsharpTokenizer.Greater,
                five,

                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.CurlyBraceOpen,

                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                maior,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,

                CCsharpTokenizer.CurlyBraceClose
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new If(new BinaryExpression(ten, CCsharpTokenizer.Greater, five),
                    new List<Statement>
                    {
                        new FunctionCall(CCsharpTokenizer.Print, new List<IValuable>(){ maior })
                    }),
            };

            var resulted = parser.Parse();

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

            var expectedConstruct = new List<Statement>()
            {
                new FunctionCall(CCsharpTokenizer.Print, new List<IValuable>
                    {
                        new BinaryExpression(ten, CCsharpTokenizer.Plus, ten)
                    })
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForWhilePrintVariable()
        {
            var zero = new ValueToken("0", TokenType.IntValue);
            var i = new Identifier("i");
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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, i, new ValueToken("0", TokenType.IntValue)),
                new While(new BinaryExpression(i, CCsharpTokenizer.Lesser, ten),
                    new List<Statement>
                    {
                        new FunctionCall(CCsharpTokenizer.Print, new List<IValuable>{ i }),
                        new Assignment(i, new BinaryExpression(i, CCsharpTokenizer.Plus, one))
                    }),
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForPrintRead()
        {
            var tokens = new List<Token>()
            {
                CCsharpTokenizer.Print,
                CCsharpTokenizer.ParenthesisOpen,
                CCsharpTokenizer.Read,
                CCsharpTokenizer.ParenthesisOpen,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new FunctionCall(CCsharpTokenizer.Print, new List<IValuable>
                {
                    new FunctionCall(CCsharpTokenizer.Read, new ()),
                })
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForFunctionTwoArguments()
        {
            var ten = new ValueToken("10", TokenType.IntValue);
            var twenty = new ValueToken("20", TokenType.IntValue);
            var funtion = new Identifier("function");

            var tokens = new List<Token>()
            {
                funtion,
                CCsharpTokenizer.ParenthesisOpen,
                ten,
                CCsharpTokenizer.Comma,
                twenty,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new FunctionCall(funtion, new List<IValuable>
                {
                    ten,
                    twenty
                })
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        [Fact]
        public void ShouldParseValidASTForFunctionTwoArgumentBinaryExpression()
        {
            var ten = new ValueToken("10", TokenType.IntValue);
            var twenty = new ValueToken("20", TokenType.IntValue);
            var function = new Identifier("function");

            var tokens = new List<Token>()
            {
                function,
                CCsharpTokenizer.ParenthesisOpen,
                ten,
                CCsharpTokenizer.Comma,
                twenty,
                CCsharpTokenizer.Plus,
                ten,
                CCsharpTokenizer.ParenthesisClose,
                CCsharpTokenizer.Semicolon,
            };

            var parser = new SyntaticAnalyzer(tokens, CCsharp.Parser);

            var expectedConstruct = new List<Statement>()
            {
                new FunctionCall(function, new List<IValuable>
                {
                    ten,
                    new BinaryExpression(twenty, CCsharpTokenizer.Plus, ten)
                })
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        /* [Fact] */
        public void ShouldParseValidASTForArrayDeclaration()
        {
            throw new NotImplementedException();

            var ten = new ValueToken("10", TokenType.IntValue);
            var array = new Identifier("array");

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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(null!, array, new ValueToken("10", TokenType.IntValue)),
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }

        /* [Fact] */
        public void ShouldParseValidASTForWhileReadArray()
        {
            throw new NotImplementedException();

            var ten = new ValueToken("10", TokenType.IntValue);
            var array = new Identifier("array");
            var i = new Identifier("i");
            var one = new ValueToken("1", TokenType.IntValue);

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
                new ValueToken("0", TokenType.IntValue),
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

            var expectedConstruct = new List<Statement>()
            {
                new VariableDeclaration(CCsharpTokenizer.Int, i, new ValueToken("0", TokenType.IntValue)),
                new VariableDeclaration(null!, array, null/*PRECISO CRIAR CONSTRUTOR PARA ARRAY*/),
                new While(new BinaryExpression(i, CCsharpTokenizer.Lesser, ten),
                    new List<Statement>
                    {
                        new Assignment(array, new FunctionCall(CCsharpTokenizer.Print, new())), /*PRECISO CRIAR FORMADE ACESSAR ARRAY*/
                        new Assignment(i, new BinaryExpression(i, CCsharpTokenizer.Plus, one))
                    }),
            };

            var resulted = parser.Parse();

            resulted.JsonEquals(expectedConstruct);
        }
    }
}
