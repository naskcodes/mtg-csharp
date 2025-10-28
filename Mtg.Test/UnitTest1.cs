using FluentAssertions;

namespace Mtg.Test
{
    public class UnitTest1
    {
        [Fact]
        public void DeveRetornarHelloWorld()
        {
            var helloWorld = "hello world";

            helloWorld.Should().Be("hello world");
        }
    }
}
