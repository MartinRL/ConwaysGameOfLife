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
