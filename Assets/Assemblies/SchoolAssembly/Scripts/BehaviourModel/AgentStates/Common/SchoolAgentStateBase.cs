using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentStateBase<TAgent> : IState<TAgent>
        where TAgent : SchoolAgentBase<TAgent>
    {
        [SerializeField] [HideInInspector] protected TAgent thisAgent;

        public SchoolAgentStateBase()
        {
        }

        public virtual void Initiate(TAgent _thisAgent)
        {
            thisAgent = _thisAgent;
        }

        public abstract IEnumerator StartState();
    }
}