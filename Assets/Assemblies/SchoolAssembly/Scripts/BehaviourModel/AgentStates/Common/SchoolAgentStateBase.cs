using Common;
using Events;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentStateBase<TAgent> : IState
        where TAgent : SchoolAgentBase<TAgent>
    {
        [SerializeField] [HideInInspector] protected TAgent thisAgent;
        //[SerializeField] protected bool stateBreaked;
        //public abstract bool StateBreaked { get ; set; }
        public SchoolAgentStateBase()
        {

        }
        public abstract IEnumerator StartState();

        public virtual void Initiate(TAgent _thisAgent)
        {
            thisAgent = _thisAgent;
        }

        //private void Awake()
        //{
        //    thisAgent = GetComponent<T>();
        //}
    }
}