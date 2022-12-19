using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentBase : MonoBehaviour
    {
        [SerializeField] NervousSystem nervousSystem;
        [SerializeField] CharacterSystem characterSystem;
        public NervousSystem NervousSystem { get => nervousSystem; set => nervousSystem = value; }
        public CharacterSystem CharacterSystem { get => characterSystem; set => characterSystem = value; }
    }
}