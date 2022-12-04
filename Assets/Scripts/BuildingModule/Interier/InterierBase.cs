using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierBase : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        public SpriteRenderer Renderer { get => spriteRenderer; }
    }
}