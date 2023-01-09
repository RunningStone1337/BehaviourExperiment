using UnityEngine.UI;

namespace UI
{
    public interface IButtonHandler
    {
        public Button Button { get; }

        public void PushButton();
    }
}