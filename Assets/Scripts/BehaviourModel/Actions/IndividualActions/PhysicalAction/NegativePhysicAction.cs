using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class NegativePhysicAction : PhysicalAction
    {
        protected NegativePhysicAction(IPhenomenon context) : base(context)
        {
        }
    }
}