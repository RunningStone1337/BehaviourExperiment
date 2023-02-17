using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class ContactSpeech : SpeakAction
    {
        public ContactSpeech(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public ContactSpeech():base()
        {

        }
    }
}