using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public class Generation : IEnumerable<Cell>
    {
        private readonly ISet<Cell> aliveCells;

        public Generation(params Cell[] seed)
        {
            aliveCells = new HashSet<Cell>(seed);
        }

        private IEnumerable<Cell> KeepAlives
        {
            get
            {
                return aliveCells.Where(c => GetNumberOfAliveNeighboursOf(c) == 2
                                             || GetNumberOfAliveNeighboursOf(c) == 3);
            }
        }

        private IEnumerable<Cell> Revives
        {
            get
            {
                return aliveCells
                    .SelectMany(GetDeadNeighboursOf)
                    .Where(c => GetNumberOfAliveNeighboursOf(c) == 3);
            }
        }

        public Generation Tick()
        {
            return new Generation(KeepAlives.Union(Revives).ToArray());
        }

        private IEnumerable<Cell> GetDeadNeighboursOf(Cell cell)
        {
            return cell.Neighbours.Where(IsDead);
        }

        private int GetNumberOfAliveNeighboursOf(Cell cell)
        {
            return cell.Neighbours.Count(this.Contains);
        }

        private bool IsDead(Cell cell)
        {
            return !this.Contains(cell);
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return aliveCells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
