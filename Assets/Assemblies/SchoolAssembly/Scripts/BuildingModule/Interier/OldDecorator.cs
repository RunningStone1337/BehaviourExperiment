using UnityEngine;

namespace BuildingModule
{
    public class OldDecorator : InterierDecoratorBase
    {
        private void Awake()
        {
            interier.Renderer.sprite = sprite;
            interier.PhenomenonPower -= influenceValue;
        }

        [SerializeField] protected Sprite sprite;
    }
}