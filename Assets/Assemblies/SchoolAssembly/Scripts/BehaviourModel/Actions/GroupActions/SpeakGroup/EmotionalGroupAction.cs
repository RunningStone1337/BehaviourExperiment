using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class EmotionalGroupAction : GroupAction
    {
        public EmotionalGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}