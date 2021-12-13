using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day12
{
    public class Day12Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day12.Day12();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day12.Day12();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
