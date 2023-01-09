using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContentOrderHandler : MonoBehaviour
    {
        [SerializeField] private RectTransform lastTransform;

        public void ReorderContent()
        {
            lastTransform.SetSiblingIndex(transform.childCount);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        }
    }
}