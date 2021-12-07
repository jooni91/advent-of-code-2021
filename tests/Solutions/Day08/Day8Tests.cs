using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day08
{
    public class Day8Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day08.Day8();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("347509", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day08.Day8();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("98257206", result);
        }
    }
}
