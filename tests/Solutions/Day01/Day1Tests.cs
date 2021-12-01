using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day01
{
    public class Day1Tests
    {
        [Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day01.Day1();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("1228", result);
        }

        [Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day01.Day1();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("1257", result);
        }
    }
}
