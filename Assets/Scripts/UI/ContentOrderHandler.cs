using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContentOrderHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform lastTransform;
        [SerializeField] private RectTransform firstTransform;
        public RectTransform FirstTransform { get => firstTransform; set => firstTransform = value; }
        public void ReorderContent()
        {
            if (lastTransform != null)
                lastTransform.SetSiblingIndex(transform.childCount);
            if (firstTransform != null)
                firstTransform.SetSiblingIndex(0);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        }
    }
}