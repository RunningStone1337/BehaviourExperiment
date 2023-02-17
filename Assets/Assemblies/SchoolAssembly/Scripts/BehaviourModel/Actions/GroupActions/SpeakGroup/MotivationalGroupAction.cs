using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class MotivationalGroupAction : GroupAction
    {
        public MotivationalGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}