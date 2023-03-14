using BehaviourModel;
using Common;
using System;
using static UnityEngine.Random;
using System.Collections.Generic;
using IState = Common.IState;

public static partial class ListExtensions
{
    public static void AddObjectIfMatch<T>(this List<T> list, T obj, Func<bool> func)
    {
        if (func.Invoke())
            list.Add(obj);
    }



    public static void SetStatesFromS1ToS2<T, S1, S2, StateTypeBase>(this List<T> places)
        where T : Common.ICurrentStateHandler<StateTypeBase>
        where S1 : StateTypeBase
        where S2 : StateTypeBase
        where StateTypeBase : IState
    {
        foreach (var p in places)
        {
            if (p.CurrentState is S1)
                p.SetState<S2>();
        }
    }
    public static void AddIfNotContains<T>(this List<T> lst, T obj)
    {
        if (!lst.Contains(obj))
            lst.Add(obj);
    }
}
