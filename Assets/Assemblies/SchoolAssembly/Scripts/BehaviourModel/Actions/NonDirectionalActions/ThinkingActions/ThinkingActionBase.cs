using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ThinkingActionBase : NonDirectedAction
    {
        public ThinkingActionBase(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public ThinkingActionBase() : base()
        {

        }
    }
}