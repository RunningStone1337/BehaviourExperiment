using UnityEngine;

namespace BuildingModule
{
    public class OldDecorator : InterierDecoratorBase
    {
        private void Awake()
        {
            interier.Renderer.sprite = sprite;
        }

        [SerializeField] protected Sprite sprite;
    }
}