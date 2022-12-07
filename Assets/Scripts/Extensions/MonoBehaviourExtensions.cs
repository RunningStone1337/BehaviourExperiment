using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions {
    public static class MonoBehaviourExtensions
    {
        public static bool Equals<T>(this MonoBehaviour mb)
        {
            return mb.GetType().Equals<T>();
        }
    }
}