using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class KeyValuesHandler : MonoBehaviour
    {
        [SerializeField] List<Vector3Int> values;

        public List<int> CreateDiapazonForKey(int key)
        {
            var res = new List<int>();
            var value = values.First(x => x.x == key);
            for (int min = value.y; min <= value.z; min++)
                res.Add(min);
            return res;
        }

        public Vector2Int GetYZForValue(int key)
        {
            var t = values.First(x => x.x == key);
            return new Vector2Int(t.y, t.z);
        }
    }
}