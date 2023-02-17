using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Радость
    /// </summary>
    public class HappyHappinessEmotion : HappinessEmotionBase
    {
        public HappyHappinessEmotion(IReactionSource source) : base(source, MIDDLE_EMOTION_POWER)
        {
        }
        public HappyHappinessEmotion() : base()
        {

        }

     
    }
}