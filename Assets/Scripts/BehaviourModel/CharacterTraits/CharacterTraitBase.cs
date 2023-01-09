using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterTraitBase : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private int characterValue;
        protected int CharacterValue { get => characterValue; set => characterValue = Mathf.Clamp(value, 1, 10); }
    }
}