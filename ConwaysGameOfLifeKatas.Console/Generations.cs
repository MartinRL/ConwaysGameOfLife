using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public class Generations : IEnumerable<Generation>
    {
        private readonly Generation seedGeneration;

        public Generations(params Point[] seed)
        {
            seedGeneration = new Generation(seed);
        }

        public IEnumerator<Generation> GetEnumerator()
        {
            return new GenerationEnumerator(seedGeneration);
        }

        public Generation this[int index]
        {
            get { return this.ElementAt(index); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class GenerationEnumerator : IEnumerator<Generation>
        {
            public GenerationEnumerator(Generation generation)
            {
                Current = generation;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                Current = Current.Tick();

                return true;
            }

            public void Reset()
            {
            }

            public Generation Current { get; private set; }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
