using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class NegativePhysicAction : PhysicalAction
    {
        public NegativePhysicAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }

        protected NegativePhysicAction():base()
        {
        }
    }
}