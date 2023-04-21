#if UNITY_EDITOR
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterBuildTester<TAgent> : MonoBehaviour
        where TAgent: SchoolAgentBase<TAgent>
    {
        [SerializeField] protected RawCharacterValuesHandler characterBuilder;
        [SerializeField] protected TAgent agentToBuild;

        [ContextMenu("ApplyCharacter")]
        public abstract void ApplyNewCharacter();

        private void Start()
        {
            ApplyNewCharacter();
        }

        [ContextMenu("Randomize")]
        public void Randomize()
        {
            characterBuilder.Randomize();
        }
    }
}
#endif
