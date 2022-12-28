using BehaviourModel;
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