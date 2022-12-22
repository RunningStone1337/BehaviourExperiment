using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContentOrderHandler : MonoBehaviour
    {
        [SerializeField] RectTransform lastTransform;
        public void ReorderContent()
        {
            lastTransform.SetSiblingIndex(transform.childCount);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform);
        }
    }
}