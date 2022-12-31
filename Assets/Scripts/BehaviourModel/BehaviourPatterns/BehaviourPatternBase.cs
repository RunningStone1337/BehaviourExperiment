using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class BehaviourPatternBase : ScriptableObject, IUIViewedObject
    {
        [SerializeField] private Sprite behaviourSprite;
        [SerializeField] private string objDescription;
        [SerializeField] private string objName;
        public string Name => objName;
        public string ObjDescription => objDescription;
        public Sprite PreviewSprite => behaviourSprite;
    }
}