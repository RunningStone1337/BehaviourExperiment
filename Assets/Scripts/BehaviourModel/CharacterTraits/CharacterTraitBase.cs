using System;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterTraitBase : MonoBehaviour
    {
        [SerializeField] [Range(1, 10)] private int characterValue;
        public int CharacterValue { get => characterValue; protected set => characterValue = Mathf.Clamp(value, 1, 10); }

        public void Initiate(int characterValue)
        {
            CharacterValue = characterValue;
        }
    }
}