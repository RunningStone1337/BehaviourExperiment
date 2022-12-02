using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIStateBase : MonoBehaviour
    {
        [SerializeField] protected GameObject rootObject;
        [SerializeField] protected CanvasController canvasController;
        private void Awake()
        {
            canvasController = GetComponentInParent<CanvasController>();
        }

        public abstract void DeactivateUI();
        public abstract void ActivateUI();
    }
}