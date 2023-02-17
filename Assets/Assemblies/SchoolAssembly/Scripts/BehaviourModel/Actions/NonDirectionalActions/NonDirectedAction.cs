using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class NonDirectedAction : ActionBase
    {
        protected NonDirectedAction() : base()
        {
        }

        protected NonDirectedAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}