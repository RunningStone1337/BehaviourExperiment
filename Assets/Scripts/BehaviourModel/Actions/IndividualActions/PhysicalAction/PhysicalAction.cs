using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PhysicalAction : IndividualAction
    {
        protected PhysicalAction(IPhenomenon context) : base(context)
        {
        }
    }
}