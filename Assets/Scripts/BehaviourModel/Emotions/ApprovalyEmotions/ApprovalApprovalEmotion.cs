using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ���������
    /// </summary>
    public class ApprovalApprovalEmotion : ApprovalEmotion
    {
        public ApprovalApprovalEmotion(IEmotionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }

      
    }
}