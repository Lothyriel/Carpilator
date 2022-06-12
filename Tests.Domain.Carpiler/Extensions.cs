using Domain.Carpiler.Syntatic;
using FluentAssertions;
using Newtonsoft.Json;

namespace Tests.Domain.Carpiler
{
    internal static class Extensions
    {
        public static void JsonEquals<T>(this T resulted, T expected)
        {
            var jsonExpected = JsonConvert.SerializeObject(expected, Formatting.Indented);

            var jsonResulted = JsonConvert.SerializeObject(resulted, Formatting.Indented);

            jsonExpected.Should().Be(jsonResulted);
        }
    }
}