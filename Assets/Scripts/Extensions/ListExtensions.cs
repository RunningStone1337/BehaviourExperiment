using BehaviourModel;
using BuildingModule;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Extensions
{
    public static partial class ListExtensions
    {
        public static void SetStatesFromS1ToS2<T,S1, S2>(this List<T> places) 
            where T: ICurrentStateHandler
            where S1: IState
            where S2 : IState
        {
            foreach (var p in places)
            {
                if (p.CurrentState is S1)
                    p.SetState<S2>();
            }
        }
        public static void AddObjectIfMatch<T>(this List<T> list, T obj, Func<bool> func)
        {
            if (func.Invoke())
                list.Add(obj);
        }

        public static Content FirstOrDefaultMatchContent<Content, ContentHandler>(this List<Content> list, ContentHandler drop)
            where Content: IOption
            where ContentHandler: IOptionsHandler
            =>
            list.FirstOrDefault(x => x.OptionName.Equals(drop.SelectedOptionValue));
    }
}