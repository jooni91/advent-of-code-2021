using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day14
{
    public class Day14Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day14.Day14();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day14.Day14();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
