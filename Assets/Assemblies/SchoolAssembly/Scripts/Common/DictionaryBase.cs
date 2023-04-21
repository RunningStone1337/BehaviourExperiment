using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class DictionaryBase<TKey, TValue> : SerializedMonoBehaviour
    {
        [SerializeField] private Dictionary<TKey, TValue> keyValuePairs;
        public Dictionary<TKey, TValue> KeyValuePairs => keyValuePairs;
    }
}