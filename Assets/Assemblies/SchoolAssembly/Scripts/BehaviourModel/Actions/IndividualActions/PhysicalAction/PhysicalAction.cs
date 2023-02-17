using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PhysicalAction : IndividualAction
    {
        public PhysicalAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }

        protected PhysicalAction():base()
        {
        }
    }
}