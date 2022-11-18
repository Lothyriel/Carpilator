using Domain.Carpiler;
using Domain.Carpiler.Languages;
using FluentAssertions;
using System;
using Xunit;

namespace Tests.Domain.Carpiler
{
    public class IntegrationTests
    {
        [Fact]
        public void ShouldAssertTrueSimple() 
        {
            var code = Resource.ReturnTrueSimple;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<bool>();

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldAssertTrueForBinaryExpression()
        {
            var code = Resource.ReturnTrueBinaryExpression;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<bool>();

            result.Should().BeTrue();
        }

        [Fact]
        public void ShouldAssertSumForComplexBinaryExpression()
        {
            var code = Resource.ReturnSumComplexBinaryExpression;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<int>();

            result.Should().Be(19);
        }


        [Fact]
        public void ShouldAssertFalseBinaryExpressionWithVariables()
        {
            var code = Resource.ReturnBinaryExpressionWithVariables;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<bool>();

            result.Should().BeFalse();
        }

        [Fact]
        public void ShouldAssertCorrectlyAllAtOnce()
        {
            var code = Resource.AllAtOnce;

            var carpiler = new Carpilator(code, new CCsharp());

            var result = carpiler.Run<int>();

            result.Should().Be(10);
        }
    }
}
