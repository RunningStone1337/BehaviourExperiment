using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class NonDirectedAction : ActionBase
    {
        protected NonDirectedAction(IPhenomenon context) : base(context)
        {
        }
    }
}