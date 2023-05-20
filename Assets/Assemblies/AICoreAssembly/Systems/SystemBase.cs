using UnityEngine;

namespace BehaviourModel
{
    [RequireComponent(typeof(IAgent))]
    public abstract class SystemBase<TAgent> : MonoBehaviour
        where TAgent : IAgent
    {
        [SerializeField, HideInInspector] private TAgent thisAgent;
        public TAgent ThisAgent => thisAgent;

        protected virtual void Awake()
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