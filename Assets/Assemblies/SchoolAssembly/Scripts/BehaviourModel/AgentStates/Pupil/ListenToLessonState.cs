using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ListenToLessonState : SchoolAgentStateBase<PupilAgent>, IOptionalToCompleteState
    {
        bool isContinue = true;
        public bool IsContinue { get => isContinue; set => isContinue = value; }

        public override IEnumerator StartState()
        {
            while (IsContinue)
            {
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
