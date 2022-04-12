using Domain.Carpiler;
using Domain.Carpiler.Lexical;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class SyntaticAnalyzerTests
    {
        [Fact]
        public void ShouldThrowNotClosedQuotesError()
        {
            var tokens = new List<Token>();

            var symbolTable = new HashSet<Token>();

            var compiler = new SyntaticAnalyzer(tokens, new());

            var analyze = () => compiler.Analyze();

            analyze.Should().ThrowExactly<NotClosed>();

            throw new NotImplementedException();
        }
    }
}
