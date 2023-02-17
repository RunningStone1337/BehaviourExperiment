using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Базовая эмоция интереса.
    /// </summary>
    public abstract class InterestEmotionBase : PositiveEmotionBase, IAgressiveEmotion
    {
        protected InterestEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public InterestEmotionBase() : base()
        {

        }
        
    }
}