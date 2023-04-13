using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class CharInfoRect : MonoBehaviour
    {
        [SerializeField] RectTransform thisRect;
        [SerializeField] bool isExpanded = false;
        [SerializeField] float expandHeightSize;
        [SerializeField, HideInInspector] float rolledHeightSize;
        private void Awake()
        {
            rolledHeightSize = thisRect.sizeDelta.y;
        }
        public void OnInfoRectClickCallback(BaseEventData args)
        {
            if (!isExpanded)
            {
                thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, expandHeightSize);
            }
            else
            {
                thisRect.sizeDelta = new Vector2(thisRect.sizeDelta.x, rolledHeightSize);
            }
            isExpanded = !isExpanded;
        }
    }
}
