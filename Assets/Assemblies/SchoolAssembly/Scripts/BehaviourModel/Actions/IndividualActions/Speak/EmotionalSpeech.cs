using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class EmotionalSpeech : SpeakAction
    {
        public EmotionalSpeech(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public EmotionalSpeech():base()
        {

        }
    }
}