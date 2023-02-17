using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakGroupAction : GroupAction
    {
        public SpeakGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}