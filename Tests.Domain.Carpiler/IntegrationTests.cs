using Domain.Carpiler;
using Domain.Carpiler.Languages;
using FluentAssertions;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class IntegrationTests
    {
        [Fact]
        public void ShouldReturnTrueSimple() 
        {
            var code = Resource.ReturnTrueSimple;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<bool>();

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnTrueForBinaryExpression()
        {
            var code = Resource.ReturnTrueSimple;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<bool>();

            result.Should().BeTrue();
        }
    }
}
