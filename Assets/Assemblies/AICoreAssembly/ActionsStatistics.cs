using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace BehaviourModel
{
    public static class ActionsStatistics
    {
        static Dictionary<Type, int> reactionsCountsDict = new Dictionary<Type, int>();
        internal static void AddPerformed<TReaction>(TReaction selectedReaction)
            where TReaction : IReaction
        {
            var type = selectedReaction.GetType();
            if (!reactionsCountsDict.ContainsKey(type))
            {
                reactionsCountsDict.Add(type, 1);
            }
            else
            {
                reactionsCountsDict[type] += 1;
            }
        }

        internal static void Log()
        {
            StringBuilder res = new StringBuilder();
            foreach (var pair in reactionsCountsDict)
            {
                res.Append($"{pair.Key} action: {pair.Value} count\n");
            }
            Debug.Log(res.ToString());
        }
    }
}
