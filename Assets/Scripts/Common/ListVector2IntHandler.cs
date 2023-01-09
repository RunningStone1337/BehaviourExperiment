using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class ListVector2IntHandler : MonoBehaviour
    {
        [SerializeField] private List<Vector2Int> values;
        public List<Vector2Int> Values => values;
    }
}