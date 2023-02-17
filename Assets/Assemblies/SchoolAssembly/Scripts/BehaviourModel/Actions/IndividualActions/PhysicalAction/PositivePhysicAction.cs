using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PositivePhysicAction : PhysicalAction
    {
        public PositivePhysicAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }

        protected PositivePhysicAction():base()
        {
        }
    }
}