using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingModule
{
    public abstract class EntranceRoleBase : ScriptableObject, IUIViewedObject
    {
        [SerializeField] protected Color roleColor;
        [SerializeField] Sprite previewSprite;
        [SerializeField] string objName;
        [SerializeField] string Description;
        public Color RoleColor { get => roleColor; }

        public Sprite PreviewSprite => previewSprite;

        public string Name => objName;

        public string ObjDescription => Description;
    }
}