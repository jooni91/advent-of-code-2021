using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day07
{
    public class Day7Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day07.Day7();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("347509", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day07.Day7();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("98257206", result);
        }
    }
}
