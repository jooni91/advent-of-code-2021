using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day15
{
    public class Day15Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day15.Day15();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day15.Day15();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
