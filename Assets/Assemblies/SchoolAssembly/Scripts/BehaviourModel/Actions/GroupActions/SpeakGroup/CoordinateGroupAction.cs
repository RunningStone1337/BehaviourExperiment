using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CoordinateGroupAction : GroupAction
    {
        public CoordinateGroupAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
    }
}