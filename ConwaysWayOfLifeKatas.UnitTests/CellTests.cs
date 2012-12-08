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

        [Fact]
        public void cell_should_have_neighbours()
        {
            var cell_1_1 = new Cell(1, 1);

            cell_1_1.Neighbours.Should().BeEquivalentTo(new []
            {
                new Cell(0, 2), new Cell(1, 2), new Cell(2, 2),
                new Cell(0, 1),                 new Cell(2, 1),
                new Cell(0, 0), new Cell(1, 0), new Cell(2, 0)
            });
        }
    }
}
