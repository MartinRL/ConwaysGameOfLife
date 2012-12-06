using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public class Generation
    {
        private readonly ISet<Point> aliveCells;

        public Generation(params Point[] seed)
        {
            aliveCells = new HashSet<Point>(seed);
        }

        private IEnumerable<Point> KeepAlives
        {
            get
            {
                return aliveCells.Where(c => GetNumberOfAliveNeighboursOf(c) == 2
                                             || GetNumberOfAliveNeighboursOf(c) == 3);
            }
        }

        private IEnumerable<Point> Revives
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

        private IEnumerable<Point> GetDeadNeighboursOf(Point cell)
        {
            return GetNeighboursOf(cell).Where(IsDead);
        }

        private static IEnumerable<Point> GetNeighboursOf(Point cell)
        {
            const int START = -1;
            const int END = 1;

            return START.To(END)
                    .SelectMany(x => START.To(END).Select(y => new Point(cell.X + x, cell.Y + y)))
                    .Except(cell);
        }

        private int GetNumberOfAliveNeighboursOf(Point cell)
        {
            return GetNeighboursOf(cell).Count(Contains);
        }

        private bool IsDead(Point cell)
        {
            return !Contains(cell);
        }

        public bool Contains(Point cell)
        {
            return aliveCells.Contains(cell);
        }
    }
}
