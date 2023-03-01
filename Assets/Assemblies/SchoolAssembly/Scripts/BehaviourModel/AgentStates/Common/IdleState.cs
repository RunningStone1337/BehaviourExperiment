using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class IdleState<TAgent> : SchoolAgentStateBase<TAgent>
        where TAgent : SchoolAgentBase<TAgent>
    {
        public override IEnumerator StartState()
        {
            yield return null;
        }
    }
}
