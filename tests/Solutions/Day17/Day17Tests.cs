using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day17
{
    public class Day17Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day17.Day17();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("4005", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day17.Day17();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
