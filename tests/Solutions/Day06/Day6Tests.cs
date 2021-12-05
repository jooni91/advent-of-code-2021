using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day06
{
    public class Day6Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day06.Day6();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("6856", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day06.Day6();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("20666", result);
        }
    }
}
