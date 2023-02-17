using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Одобрение
    /// </summary>
    public class ApprovalApprovalEmotion : ApprovalEmotion
    {
        public ApprovalApprovalEmotion(IReactionSource source) : base(source, WEAK_EMOTION_POWER)
        {
        }
        public ApprovalApprovalEmotion() : base()
        {

        }
      
    }
}