using UnityEngine;

namespace Common
{
    public class ObjectUniqIdentifier : MonoBehaviour
    {
        [SerializeField] private int id;
        public int ID { get => id; }
    }
}