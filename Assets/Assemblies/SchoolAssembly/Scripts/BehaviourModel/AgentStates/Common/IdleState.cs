using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public class IdleState<TAgent> : SchoolAgentStateBase<TAgent>, IOptionalToCompleteState
        where TAgent : SchoolAgentBase<TAgent>
    {
        public bool IsContinue { get; set; }

        public override IEnumerator StartState()
        {
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }
}