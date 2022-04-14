using Domain.Carpiler.Gramatic;
using Domain.Carpiler.Infra;
using Domain.Carpiler.Syntatic;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

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

            var compiler = new SyntaticAnalyzer(tokens, new(), CCsharp);

            var analyze = () => compiler.Analyze();

            analyze.Should().ThrowExactly<NotClosed>();

            throw new NotImplementedException();
        }
    }
}
