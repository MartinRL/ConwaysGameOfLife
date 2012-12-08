using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public class Cell
    {
        private readonly int x;
        private readonly int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public ISet<Cell> Neighbours
        {
            get
            {
                const int START = -1;
                const int END = 1;

                return START.To(END)
                            .SelectMany(xOffset => START.To(END).Select(yOffset => new Cell(x + xOffset, y + yOffset)))
                            .Except(this)
                            .ToHashSet();
            }
        }

        protected bool Equals(Cell other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Cell);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (x * 397) ^ y;
            }
        }
    }
}
