using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class DiscussThingGroupAction : GroupAction
    {
        public DiscussThingGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}