using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase : MonoBehaviour
    {
        [SerializeField] private CharacterSystem characterSystem;
        [SerializeField] private NervousSystem nervousSystem;
        public CharacterSystem CharacterSystem { get => characterSystem; set => characterSystem = value; }
        public NervousSystem NervousSystem { get => nervousSystem; set => nervousSystem = value; }
    }
}