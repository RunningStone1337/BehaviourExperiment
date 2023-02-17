using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class SexBase : ScriptableObject, INameHandler
    {
        [SerializeField] string sexName;
        public string Name => sexName;
    }
}