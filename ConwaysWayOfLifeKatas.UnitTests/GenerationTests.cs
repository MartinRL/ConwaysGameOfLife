using System;
using System.Drawing;
using System.Linq;
using ConwaysGameOfLifeKatasConsole;
using NUnit.Framework;
using SharpTestsEx;

/*
 * The unit tests corresponds to the following four rules:
 * 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
 * 2. Any live cell with more than three live neighbours dies, as if by overcrowding.
 * 3. Any live cell with two or three live neighbours lives on to the next generation.
 * 4. Any dead cell with exactly three live neighbours becomes a live cell.
 * http://coderetreat.com/gol.html
 */
namespace ConwaysGameOfLifeKatas.GenerationsUnitTests
{
    public class GenerationTests
    {
        [Test]
        public void new_generation_should_kill_alive_cell_with_one_live_neighbour()
        {
            var generation = new Generation(new Point(1, 1), new Point(0, 1));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.False();
        }

        [Test]
        public void new_generation_should_kill_alive_cell_with_no_live_neighbours()
        {
            var generation = new Generation(new Point(1, 1));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.False();
        }

        [Test]
        public void new_generation_should_kill_alive_cell_with_four_alive_neighbours()
        {
            var generation = new Generation(new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(0, 1),  new Point(1, 1));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.False();
        }

        [Test]
        public void new_generation_should_kill_alive_cell_with_eight_alive_neighbours()
        {
            var generation = new Generation(new Point(0, 0), new Point(1, 0), new Point(2, 0), 
                                            new Point(0, 1), new Point(1, 1), new Point(2, 1),
                                            new Point(0, 2), new Point(1, 2), new Point(2, 2));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.False();
        }

        [Test]
        public void new_generation_should_keep_alive_cell_with_three_alive_neighbours()
        {
            var generation = new Generation(new Point(1, 1), new Point(0, 1), new Point(2, 1), new Point(0, 0));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.True();
        }

        [Test]
        public void new_generation_should_keep_alive_cell_with_two_live_neighbours()
        {
            var generation = new Generation(new Point(1, 1), new Point(0, 1), new Point(2, 1));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.True();
        }

        [Test]
        public void new_generation_should_revive_dead_cell_with_three_alive_neighbours()
        {
            var generation = new Generation(new Point(0, 0), new Point(1, 0), new Point(2, 0));

            generation.Tick().Contains(new Point(1, 1)).Should().Be.True();
        }

        [TestCase(0, 0, 0, false)]
        [TestCase(1, 0, 0, true)]
        [TestCase(2, 0, 0, false)]
        [TestCase(0, 1, 0, false)]
        [TestCase(1, 1, 0, true)]
        [TestCase(2, 1, 0, false)]
        [TestCase(0, 2, 0, false)]
        [TestCase(1, 2, 0, true)]
        [TestCase(2, 2, 0, false)]
        [TestCase(0, 0, 1, false)]
        [TestCase(1, 0, 1, false)]
        [TestCase(2, 0, 1, false)]
        [TestCase(0, 1, 1, true)]
        [TestCase(1, 1, 1, true)]
        [TestCase(2, 1, 1, true)]
        [TestCase(0, 2, 1, false)]
        [TestCase(1, 2, 1, false)]
        [TestCase(2, 2, 1, false)]
        public void blinker_oscillator_should_oscillate_according_to_wikipedia(
            int x, int y, int generationIndex, bool isAlive)
        {
            var generation = new Generation(new Point(0, 1), new Point(1, 1), new Point(2, 1));

            generation.Tick(generationIndex).Contains(new Point(x, y)).Should().Be.EqualTo(isAlive); 
        }
    }
}