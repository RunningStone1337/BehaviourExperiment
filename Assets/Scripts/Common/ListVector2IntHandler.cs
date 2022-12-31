using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class ListVector2IntHandler : MonoBehaviour
    {
        [SerializeField] List<Vector2Int> values;
        public List<Vector2Int> Values => values;
        
    }
}