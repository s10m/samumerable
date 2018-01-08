using System;
using System.Collections.Generic;

namespace Samumerable
{
    public static partial class Samumerable
    {
        public static T SamFirstOrDefault<T>(this IEnumerable<T> p_Items)
        {
            IEnumerator<T> enumerator = p_Items.GetEnumerator();

            if (enumerator.MoveNext())
            {
                return enumerator.Current;
            }

            return default(T);
        }
    }
}
