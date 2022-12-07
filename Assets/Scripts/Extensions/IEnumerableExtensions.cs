using Common;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
    public static class IEnumerableExtensions 
    {
        public static IEnumerable<TStateHanlder> GetCurrentStateHandlers<TStateType, TStateHanlder>(this IEnumerable<TStateHanlder> handlers)
          where TStateType : IState where TStateHanlder: ICurrentStateHandler 
        {
            return handlers.Where(x => x.CurrentState is TStateType);
        }
     
        public static IEnumerable<TStateType> GetCurrentStatesOfType<TStateType, TStateHanlder>(this IEnumerable<TStateHanlder> handlers) 
            where TStateHanlder : ICurrentStateHandler where TStateType: IState
        {
            return (IEnumerable<TStateType>)handlers.Select(x=>x.CurrentState).Where(x => x is TStateType);
        }
        public static int Count<T1, T2>(this IEnumerable<T1> enumer) where T2: T1
        {
            return enumer.Where(x => x is T2).Count();
        }
    }
}