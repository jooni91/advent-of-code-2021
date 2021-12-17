using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day16
{
    public class Day16Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day16.Day16();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day16.Day16();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
