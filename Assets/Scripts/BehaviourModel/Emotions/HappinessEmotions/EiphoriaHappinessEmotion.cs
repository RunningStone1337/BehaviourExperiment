using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Эйфория
    /// </summary>
    public class EiphoriaHappinessEmotion : HappinessEmotionBase
    {
        public EiphoriaHappinessEmotion(IEmotionSource source) : base(source, STRONG_EMOTION_POWER)
        {
        }

    }
}