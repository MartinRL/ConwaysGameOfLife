using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConwaysGameOfLifeKatasConsole
{
    internal class Program
    {
        private static void Main(string[] args /*2do: should take seed as arg*/)
        {
            new Generations(new Point(0, 1), new Point(1, 1), new Point(2, 1))
            .Each(g => {
                            Thread.Sleep(500);
                            
                            Console.Clear();
                            
                            g.ToStringRows(3).Each(Console.WriteLine);
                        });
        }
    }
}
