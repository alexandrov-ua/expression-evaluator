using System.Collections.Generic;

namespace Calculator.Core.Tools
{
    public static class IEnumeratorExtensions
    {
        public static T GetAndMoveNext<T>(this IEnumerator<T> enumerator)
        {
            var current = enumerator.Current;
            enumerator.MoveNext();
            return current;
        }
    }
}