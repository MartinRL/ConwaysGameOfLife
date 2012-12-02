using System.Drawing;
using System.Threading;

namespace ConwaysGameOfLifeKatas.Console
{
    internal class Program
    {
        private static void Main(string[] args /*2do: should take seed as arg*/)
        {
            new Generations(new Point(0, 1), new Point(1, 1), new Point(2, 1))
            .Each(g => {
                            Thread.Sleep(500);
                            
                            System.Console.Clear();
                            
                            g.ToStringRows(3).Each(System.Console.WriteLine);
                        });
        }
    }
}
