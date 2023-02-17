using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class MotivationSpeech : SpeakAction
    {
        public MotivationSpeech(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public MotivationSpeech() : base()
        {

        }
    }
}