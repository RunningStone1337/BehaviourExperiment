using Common;
using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierDecoratorBase : InterierBase, IInfluenceSource
    {
        [SerializeField] protected PlacedInterier interier;
        [SerializeField] protected int influenceValue;

        public int InfluenceValue { get => influenceValue; set => influenceValue = value; }
    }
}