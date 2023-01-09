using UnityEngine;

namespace BuildingModule
{
    public class NewDecorator : InterierDecoratorBase
    {
        [SerializeField] private Color color;

        private void Awake()
        {
            interier.Renderer.color = color;
        }
    }
}