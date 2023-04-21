using UnityEngine;

namespace UI
{
    public class PrefferedBehaviourRect : MonoBehaviour
    {
        [SerializeField] private DropdownButtonPair modelDropdownPair;

        public DropdownButtonPair ModelDropdownPair => modelDropdownPair;


        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }       

        public void RandomizeControlsValues()
        {
            modelDropdownPair.PushButton();
        }
    }
}