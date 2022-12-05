using Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class IEnumerableExtensions 
    {
        public static IEnumerable<ICurrentStateHandler> GetCurrentStateHandlers<TStateType>(this IEnumerable<ICurrentStateHandler> handlers)
        {
            return handlers.Where(x => x.CurrentState is TStateType);
        }
        public static IEnumerable<IState> GetCurrentStatesOfType<TStateType>(this IEnumerable<ICurrentStateHandler> handlers)
        {
            return handlers.Select(x=>x.CurrentState).Where(x => x is TStateType);
        }
    }
}