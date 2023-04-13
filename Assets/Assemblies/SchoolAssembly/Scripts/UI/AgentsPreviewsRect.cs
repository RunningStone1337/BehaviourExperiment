using UnityEngine;

namespace UI
{
    public class AgentsPreviewsRect : MonoBehaviour
    {
        [SerializeField] private CreateAgentButtonRect pupilButton;
        [SerializeField] private CreateAgentButtonRect teacherButton;

        public void SetTeacherButtonOff()
        {
            teacherButton.gameObject.SetActive(false);
        }

        public void SetTeacherButtonOn()
        {
            teacherButton.gameObject.SetActive(true);
        }
    }
}