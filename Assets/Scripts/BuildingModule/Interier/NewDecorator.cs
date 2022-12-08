using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class NewDecorator : InterierDecoratorBase
    {
        [SerializeField] Color color;

        private void Awake()
        {
            interier.Renderer.color = color;
        }
    }
}