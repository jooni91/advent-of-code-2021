using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day09
{
    public class Day9Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day09.Day9();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("545", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day09.Day9();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
