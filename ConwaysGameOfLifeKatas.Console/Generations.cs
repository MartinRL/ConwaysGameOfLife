using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public class Generations : IEnumerable<Generation>
    {
        private readonly Generation seedGeneration;

        public Generations(params Cell[] seed)
        {
            seedGeneration = new Generation(seed);
        }

        public IEnumerator<Generation> GetEnumerator()
        {
            var nextGeneration = seedGeneration.Tick();

            while (true)
            {
                yield return nextGeneration;

                nextGeneration = nextGeneration.Tick();
            }
        }

        public Generation this[int index]
        {
            get { return this.ElementAt(index); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
