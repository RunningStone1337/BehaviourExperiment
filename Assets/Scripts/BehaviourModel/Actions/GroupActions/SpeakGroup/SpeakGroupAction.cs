using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakGroupAction : GroupAction
    {
        protected SpeakGroupAction(IPhenomenon context) : base(context)
        {
        }
    }
}