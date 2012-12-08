using ConwaysGameOfLifeKatas.Console;
using FluentAssertions;
using Xunit;

namespace ConwaysWayOfLifeKatas.UnitTests
{
    public class CellTests
    {
        [Fact]
        public void cells_should_be_value_equal()
        {
            var a23Cell = new Cell(2, 3);
            var another23Cell = new Cell(2, 3);

            a23Cell.Should().Be(another23Cell);
            a23Cell.GetHashCode().Should().Be(another23Cell.GetHashCode());
        }
    }
}
