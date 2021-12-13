using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day11
{
    public class Day11Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day11.Day11();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("1585", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day11.Day11();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("382", result);
        }
    }
}
