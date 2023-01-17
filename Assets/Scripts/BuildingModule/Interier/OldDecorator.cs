using UnityEngine;

namespace BuildingModule
{
    public class OldDecorator : InterierDecoratorBase
    {
        private void Awake()
        {
            interier.Renderer.sprite = sprite;
            interier.InfluenceValue -= influenceValue;
        }

        [SerializeField] protected Sprite sprite;
    }
}