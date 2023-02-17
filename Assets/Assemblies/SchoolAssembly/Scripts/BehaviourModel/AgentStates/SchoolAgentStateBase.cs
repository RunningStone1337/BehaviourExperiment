using Common;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentStateBase<T> : MonoBehaviour, IState
        where T : SchoolAgentBase<T>
    {
        [SerializeField] [HideInInspector] protected T thisAgent;
        //[SerializeField] protected bool stateBreaked;
        //public abstract bool StateBreaked { get ; set; }

        public abstract IEnumerator StartState();
        private void Awake()
        {
            thisAgent = GetComponent<T>();
        }
    }
}