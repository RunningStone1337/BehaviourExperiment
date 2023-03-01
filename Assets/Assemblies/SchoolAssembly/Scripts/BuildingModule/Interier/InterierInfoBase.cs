using BehaviourModel;
using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierInfoBase<TInterier> : MonoBehaviour
        where TInterier: PlacedInterier
    {
        
        protected TInterier thisInterier;
        public TInterier ThisInterier => thisInterier;
    }
}
