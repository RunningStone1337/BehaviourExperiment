using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ������ ��������.
    /// </summary>
    public abstract class InterestEmotionBase : PositiveEmotionBase, IAgressiveEmotion
    {
        protected InterestEmotionBase(IEmotionSource source, int emotionPower) : base(source, emotionPower)
        {
        }
        
    }
}