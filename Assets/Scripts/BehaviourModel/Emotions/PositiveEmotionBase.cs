using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PositiveEmotionBase : EmotionBase
    {
        public PositiveEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
    }
}