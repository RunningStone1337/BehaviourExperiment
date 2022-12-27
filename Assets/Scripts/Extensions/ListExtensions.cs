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

        public static FeatureBase FirstOrDefaultSelectedFeature(this List<FeatureBase> list, DropdownButtonPair drop) =>
            list.FirstOrDefault(x => x.FeatureName.Equals(drop.DropdownValue));
    }
}