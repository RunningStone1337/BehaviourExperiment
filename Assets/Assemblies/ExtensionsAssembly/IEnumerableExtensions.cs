using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
    public static int Count<TBase, TCountable>(this IEnumerable<TBase> enumer) where TCountable : TBase
    {
        return enumer.Where(x => x is TCountable).Count();
    }
}
