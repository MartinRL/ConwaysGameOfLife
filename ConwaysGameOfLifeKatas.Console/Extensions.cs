using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConwaysGameOfLifeKatas.Console
{
    public static class Extensions
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> @this, T element)
        {
            return @this.Except(new[] {element});
        }

        public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var element in @this)
            {
                action(element);
            }
        }

        public static string JoinAsString(this IEnumerable<string> @this, string delimiter)
        {
            return string.Join(delimiter, @this.ToArray());
        }

        public static void Times( this int @this, Action action )
        {
            for (var i = 0; i <= @this; i++)
            {
                action();
            }
        }

        public static IEnumerable<string> ToStringRows( this Generation @this, int gridSize )
        {
            return Enumerable.Range( 0, gridSize )
                   .Select( y => Enumerable.Range( 0, gridSize )
                                .Select( x => @this.Contains( new Point( x, y ) ) ? "X" : "O" ).JoinAsString( " " ) );
        }

        public static IEnumerable<int> To(this int @this, int to)
        {
            return Enumerable.Range(@this, to - @this + 1);
        }
    }
}
