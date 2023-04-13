using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TextButtonPair : UIButtonPairElement
    {
        [SerializeField] private InputField inputField;
        public InputField InputField { get => inputField; }
        public string Text { get => InputField.text; internal set => InputField.text = value; }
    }
}