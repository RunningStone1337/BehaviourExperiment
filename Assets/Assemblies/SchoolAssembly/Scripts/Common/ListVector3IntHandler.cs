using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Common
{
    public class ListVector3IntHandler : MonoBehaviour
    {
        [SerializeField] private List<Vector3Int> values;

        public List<int> GetDiapazoneYZForXValue(int newValue)
        {
            return GetYZForXValue(newValue).GetDiapazoneBetweenXY();
        }

        public Vector2Int GetYZForXValue(int xVal)
        {
            var t = values.First(x => x.x == xVal);
            return new Vector2Int(t.y, t.z);
        }
    }
}