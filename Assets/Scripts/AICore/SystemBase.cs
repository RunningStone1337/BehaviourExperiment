using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SystemBase<TReaction, TFeature, TState> : MonoBehaviour
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
    {
        [SerializeField] AgentBase<TReaction, TFeature, TState> thisAgent;
        public AgentBase<TReaction, TFeature, TState> ThisAgent => thisAgent;
        private void Awake()
        {
            if (thisAgent == null)
            {
                if (TryGetComponent(out AgentBase<TReaction, TFeature, TState> ag))
                    thisAgent = ag;
                else {
#if UNITY_EDITOR
                    Debug.Log($"Required component {nameof(ThisAgent)} was not found." +
                        $" Assign required refrence with inspector.");
#endif
                }
            }
        }
    }
}
