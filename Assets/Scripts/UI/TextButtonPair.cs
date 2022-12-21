using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TextButtonPair : MonoBehaviour
    {
        [SerializeField] InputField inputField;
        [SerializeField] Button button;
        public InputField InputField { get => inputField; }
    }
}