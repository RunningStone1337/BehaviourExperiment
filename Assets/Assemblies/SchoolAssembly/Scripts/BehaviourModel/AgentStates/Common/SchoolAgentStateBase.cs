using Common;
using Events;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentStateBase<T> : IState
        where T : SchoolAgentBase<T>
    {
        [SerializeField] [HideInInspector] protected T thisAgent;
        //[SerializeField] protected bool stateBreaked;
        //public abstract bool StateBreaked { get ; set; }
        public SchoolAgentStateBase()
        {

        }
        public abstract IEnumerator StartState();

        public virtual void Initiate(T _thisAgent)
        {
            thisAgent = _thisAgent;
        }

        //private void Awake()
        //{
        //    thisAgent = GetComponent<T>();
        //}
    }
}