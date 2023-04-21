using UnityEngine;

namespace UI {
    public class AddRandomPupilDataButton : MonoBehaviour
    {
        [SerializeField] CreateAgentButtonRect buttonRect;
        [SerializeField] AgentCreationScreen screen;
        public void OnAddRandomPupilDataClick()
        {
            buttonRect.Button.onClick.Invoke();
            screen.SetFullRandomValuesButtonClick();
            screen.OnConfirmCreationButtonClick();
        }
    }
}