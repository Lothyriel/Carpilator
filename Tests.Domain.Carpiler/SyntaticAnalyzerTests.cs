using Domain.Carpiler;
using Domain.Carpiler.Lexical;
using FluentAssertions;
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

            var compiler = new SyntaticAnalyzer(tokens);

            var analyze = () => compiler.Analyze();

            analyze.Should().ThrowExactly<NotClosed>();
        }
    }
}
