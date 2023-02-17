using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Испортить вещь
    /// </summary>
    public class MessUpThingPhysicAction : NegativePhysicAction
    {
        public MessUpThingPhysicAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public MessUpThingPhysicAction():base()
        {

        }
    }
}