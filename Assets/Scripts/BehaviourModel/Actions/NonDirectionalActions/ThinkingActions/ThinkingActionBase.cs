using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ThinkingActionBase : NonDirectedAction
    {
        protected ThinkingActionBase(IPhenomenon context) : base(context)
        {
        }
    }
}