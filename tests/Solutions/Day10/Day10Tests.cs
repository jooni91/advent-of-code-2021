using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day10
{
    public class Day10Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day10.Day10();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("413733", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day10.Day10();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("3354640192", result);
        }
    }
}
