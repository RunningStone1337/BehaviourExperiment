using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;

namespace Extensions
{
    public static partial class ListExtensions
    {
        public static void AddObjectIfMatch<T>(this List<T> list, T obj, Func<bool> func)
        {
            if (func.Invoke())
                list.Add(obj);
        }

        public static Content FirstOrDefaultMatchContent<Content, ContentHandler>(this List<Content> list, ContentHandler ch)
            where Content : INameHandler
            where ContentHandler : IKeysValuesHandler
            =>
            list.FirstOrDefault(x => x.Name.Equals(ch.SelectedOptionKey));

        public static void SetStatesFromS1ToS2<T, S1, S2>(this List<T> places)
                            where T : ICurrentStateHandler
            where S1 : IState
            where S2 : IState
        {
            foreach (var p in places)
            {
                if (p.CurrentState is S1)
                    p.SetState<S2>();
            }
        }
    }
}