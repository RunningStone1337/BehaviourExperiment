using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterTraitBase : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] int characterValue;
        protected int CharacterValue { get => characterValue; set => characterValue = Mathf.Clamp(value, 1, 10); }
    }
}