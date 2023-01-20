using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Досада, разочарование
    /// </summary>
    public class AnnoyanceAngerEmotion : AngerEmotionBase
    {
        public AnnoyanceAngerEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }

        
    }
}