using UnityEngine;

namespace BuildingModule
{
    public class NewDecorator : InterierDecoratorBase
    {
        [SerializeField] private Sprite sprite;

        private void Awake()
        {
            interier.Renderer.sprite = sprite;
            interier.PhenomenonPower += influenceValue;
        }
    }
}