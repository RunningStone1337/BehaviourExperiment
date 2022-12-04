using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierDecoratorBase : InterierBase
    {
        [SerializeField] protected InterierBase interier;
       
    }
}