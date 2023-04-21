using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierDecoratorBase : InterierBase
    {
        [SerializeField] protected PlacedInterier interier;
    }
}