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
        public InterestEmotionBase() : base()
        {

        }
        
    }
}