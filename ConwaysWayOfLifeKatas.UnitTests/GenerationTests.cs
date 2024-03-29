using System.Linq;
using ConwaysGameOfLifeKatas.Console;
using FluentAssertions;
using Xunit;
using Xunit.Extensions;

/*
 * The unit tests corresponds to the following four rules:
 * 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
 * 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
 * 3. Any live cell with two or three live neighbours lives on to the next generation.
 * 4. Any dead cell with exactly three live neighbours becomes a live cell.
 * http://coderetreat.com/gol.html
 */
namespace ConwaysWayOfLifeKatas.UnitTests
{
    public class GenerationTests
    {
        [Fact]
        public void new_generation_should_kill_alive_cell_with_one_live_neighbour()
        {
            var generation = new Generation(new Cell(1, 1), new Cell(0, 1));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeFalse();
        }

        [Fact]
        public void new_generation_should_kill_alive_cell_with_no_live_neighbours()
        {
            var generation = new Generation(new Cell(1, 1));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeFalse();
        }

        [Fact]
        public void new_generation_should_kill_alive_cell_with_four_alive_neighbours()
        {
            var generation = new Generation(new Cell(0, 0), new Cell(1, 0), new Cell(2, 0), new Cell(0, 1), new Cell(1, 1));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeFalse();
        }

        [Fact]
        public void new_generation_should_kill_alive_cell_with_eight_alive_neighbours()
        {
            var generation = new Generation(new Cell(0, 0), new Cell(1, 0), new Cell(2, 0), 
                                            new Cell(0, 1), new Cell(1, 1), new Cell(2, 1),
                                            new Cell(0, 2), new Cell(1, 2), new Cell(2, 2));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeFalse();
        }

        [Fact]
        public void new_generation_should_keep_alive_cell_with_three_alive_neighbours()
        {
            var generation = new Generation(new Cell(1, 1), new Cell(0, 1), new Cell(2, 1), new Cell(0, 0));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeTrue();
        }

        [Fact]
        public void new_generation_should_keep_alive_cell_with_two_live_neighbours()
        {
            var generation = new Generation(new Cell(1, 1), new Cell(0, 1), new Cell(2, 1));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeTrue();
        }

        [Fact]
        public void new_generation_should_revive_dead_cell_with_three_alive_neighbours()
        {
            var generation = new Generation(new Cell(0, 0), new Cell(1, 0), new Cell(2, 0));

            generation.Tick().Contains(new Cell(1, 1)).Should().BeTrue();
        }

        [Theory] /* http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life */
        [InlineData(0, 0, 0, false)]
        [InlineData(1, 0, 0, true)]
        [InlineData(2, 0, 0, false)]
        [InlineData(0, 1, 0, false)]
        [InlineData(1, 1, 0, true)]
        [InlineData(2, 1, 0, false)]
        [InlineData(0, 2, 0, false)]
        [InlineData(1, 2, 0, true)]
        [InlineData(2, 2, 0, false)]
        [InlineData(0, 0, 1, false)]
        [InlineData(1, 0, 1, false)]
        [InlineData(2, 0, 1, false)]
        [InlineData(0, 1, 1, true)]
        [InlineData(1, 1, 1, true)]
        [InlineData(2, 1, 1, true)]
        [InlineData(0, 2, 1, false)]
        [InlineData(1, 2, 1, false)]
        [InlineData(2, 2, 1, false)]
        public void blinker_oscillator_should_oscillate_according_to_wikipedia(
            int x, int y, int generationIndex, bool isAlive)
        {
            var generations = new Generations(new Cell(0, 1), new Cell(1, 1), new Cell(2, 1));

            generations[generationIndex].Contains(new Cell(x, y)).Should().Be(isAlive);
        }
    }
}
