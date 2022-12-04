using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class ObjectPlacingTypesSolver : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] public int index;

        [SerializeField] public string displayedName;
#endif
        [SerializeField] string objectBaseType;
        public string ObjectBaseType { get => objectBaseType; set => objectBaseType = value; }

    }
}