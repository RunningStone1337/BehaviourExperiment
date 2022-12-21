using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class KeyValueHandler : MonoBehaviour
    {
        [SerializeField] List<Vector2Int> values;

        public int GetValue(int dropdownValue)
        {
            return values.First(x => x.x == dropdownValue).y;
        }
    }
}