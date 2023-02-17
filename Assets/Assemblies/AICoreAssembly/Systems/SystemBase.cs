using UnityEngine;

namespace BehaviourModel
{
    [RequireComponent(typeof(IAgent))]
    public abstract class SystemBase<TAgent, TReaction, TFeature, TState, TSensor> : MonoBehaviour
        where TAgent : ICurrentStateHandler<TState>
        where TReaction : IReaction
        where TFeature : IFeature
        where TState : IState
        where TSensor : ISensor
    {
        [SerializeField] [HideInInspector] private TAgent thisAgent;
        public TAgent ThisAgent => thisAgent;

        private void Awake()
        {
            if (thisAgent == null)
            {
                if (TryGetComponent(out TAgent ag))
                    thisAgent = ag;
#if UNITY_EDITOR
                else
                {
                    Debug.Log($"Required component {nameof(ThisAgent)} was not found." +
                        $" Assign required refrence with inspector.");
                }
#endif
            }
        }
    }
}