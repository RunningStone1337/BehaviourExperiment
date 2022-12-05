using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class ObjectUniqIdentifier : MonoBehaviour
    {
        [SerializeField] int id;
        public int ID { get => id; }
    }
}