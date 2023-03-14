using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierInfoBase<TInterier> : MonoBehaviour
        where TInterier : PlacedInterier
    {
        [SerializeField] protected TInterier thisInterier;
        public TInterier ThisInterier => thisInterier;
    }
}