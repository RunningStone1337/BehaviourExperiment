using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SpeakAction : IndividualAction
    {
        public SpeakAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }

        protected SpeakAction():base()
        {
        }
    }
}