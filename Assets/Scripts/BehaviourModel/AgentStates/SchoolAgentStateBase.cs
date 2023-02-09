using Common;
using System;
using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SchoolAgentStateBase : MonoBehaviour, IState
    {
        [SerializeField] [HideInInspector] protected SchoolAgentBase thisAgent;
        [SerializeField] protected bool stateBreaked;
        public abstract bool StateBreaked { get ; set; }

        public abstract IEnumerator StartState();
        private void Awake()
        {
            thisAgent = GetComponent<SchoolAgentBase>();
        }
    }
}