using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CoordinationSpeech : SpeakAction
    {
        public CoordinationSpeech(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public CoordinationSpeech():base()
        {

        }
    }
}