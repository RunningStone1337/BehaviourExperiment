using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class OldDecorator : InterierDecoratorBase
    {
        [SerializeField] protected Color interierColor;
        private void Awake()
        {
            interier.Renderer.color = interierColor;
        }
    }
}