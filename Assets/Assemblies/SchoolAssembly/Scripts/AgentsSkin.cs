using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class AgentsSkin : MonoBehaviour
    {
        [SerializeField, Range(0.001f, 1f)] protected float opacityChangeStep;
        [SerializeField] bool isHided;
        [SerializeField] bool isFullyShowed;
        public bool IsHided { get => isHided; protected set => isHided = value; }
        public bool IsFullShowed { get=> isFullyShowed; internal set=> isFullyShowed = value; }

        public abstract void DecreaseVisibility();
        public abstract void IncreaseVisibility();
    }
}
