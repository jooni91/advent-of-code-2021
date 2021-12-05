using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day05
{
    public class Day4Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day05.Day5();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("6856", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day05.Day5();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("20666", result);
        }
    }
}
