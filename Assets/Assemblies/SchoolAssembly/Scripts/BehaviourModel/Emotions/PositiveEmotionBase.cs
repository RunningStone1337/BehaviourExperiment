using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class PositiveEmotionBase : EmotionBase
    {
        public PositiveEmotionBase(IReactionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        public PositiveEmotionBase():base()
        {

        }
    }
}