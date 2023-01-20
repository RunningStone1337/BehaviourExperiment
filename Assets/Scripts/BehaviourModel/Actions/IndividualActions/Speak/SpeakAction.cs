using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakAction : IndividualAction
    {
        protected SpeakAction(IPhenomenon context):base(context)
        {
        }
    }
}