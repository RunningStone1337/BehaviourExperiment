using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public abstract class InterierPlaceBase : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] Collider2D collider2d;
    }
}