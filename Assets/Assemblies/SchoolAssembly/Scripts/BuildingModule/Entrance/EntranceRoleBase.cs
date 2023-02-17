using UI;
using UnityEngine;

namespace BuildingModule
{
    public abstract class EntranceRoleBase : ScriptableObject, IUIViewedObject
    {
        [SerializeField] private string Description;
        [SerializeField] private string objName;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] protected Color roleColor;
        public string Name => objName;
        public string ObjDescription => Description;
        public Sprite PreviewSprite => previewSprite;
        public Color RoleColor { get => roleColor; }
    }
}