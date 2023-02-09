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
        public MessUpThingPhysicAction(IPhenomenon context) : base(context)
        {
        }
    }
}