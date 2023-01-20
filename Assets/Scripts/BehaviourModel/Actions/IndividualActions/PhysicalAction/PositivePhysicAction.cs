using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PositivePhysicAction : PhysicalAction
    {
        protected PositivePhysicAction(IPhenomenon context) : base(context)
        {
        }
    }
}