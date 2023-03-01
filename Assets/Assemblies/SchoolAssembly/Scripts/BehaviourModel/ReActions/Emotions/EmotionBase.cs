using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public enum Emotions
    {
        Annoyance,
        Anger,
        Rage,
        Approval,
        Acceptance,
        Adoration,
        Abstractness,
        Surprise,
        Amazement,
        Disapproval,
        Dislike,
        Disgust,
        Caution,
        Fear,
        Horror,
        Serenity,
        Happy,
        Eiphoria,
        Interest,
        Awaiting,
        Anticipation,
        Despondency,
        Sad,
        Misery
    }
    [Serializable]
    public abstract class EmotionBase : ReactionBase
    {
        public static readonly int WEAK_EMOTION_POWER = 1;
        public static readonly int MIDDLE_EMOTION_POWER = 2;
        public static readonly int STRONG_EMOTION_POWER = 3;
        public EmotionBase():base()
        {

        }

    }
}
