using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public abstract class UIButtonPairElement : MonoBehaviour, IButtonHandler
    {
        [SerializeField] Button button;
        public Button Button => button;

        public virtual void PushButton()
        {
            Button.onClick.Invoke();
        }
    }
}