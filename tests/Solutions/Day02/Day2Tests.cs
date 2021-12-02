using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day02
{
    public class Day2Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day02.Day2();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("1480518", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day02.Day2();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("1282809906", result);
        }
    }
}
