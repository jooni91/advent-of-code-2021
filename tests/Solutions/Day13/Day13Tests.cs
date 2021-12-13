using Xunit;

namespace AdventOfCode2021.Tests.Solutions.Day13
{
    public class Day13Tests
    {
        //[Fact]
        public void PartOne_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day13.Day13();

            // Act
            var result = daySolution.GetResult(Part.One);

            // Assert
            Assert.Equal("", result);
        }

        //[Fact]
        public void PartTwo_ShouldReturn_ExpectedValue()
        {
            // Arrange
            var daySolution = new AdventOfCode2021.Solutions.Day13.Day13();

            // Act
            var result = daySolution.GetResult(Part.Two);

            // Assert
            Assert.Equal("", result);
        }
    }
}
