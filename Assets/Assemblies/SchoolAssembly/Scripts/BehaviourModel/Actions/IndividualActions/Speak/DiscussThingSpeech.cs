using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class DiscussThingSpeech : SpeakAction
    {
        public DiscussThingSpeech(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public DiscussThingSpeech():base()
        {

        }
    }
}