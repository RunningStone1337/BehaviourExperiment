using UnityEngine;

namespace BuildingModule
{
    public class OldDecorator : InterierDecoratorBase
    {
        private void Awake()
        {
            interier.Renderer.color = interierColor;
        }

        [SerializeField] protected Color interierColor;
    }
}