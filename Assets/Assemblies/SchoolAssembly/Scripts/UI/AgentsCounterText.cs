using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AgentsCounterText : MonoBehaviour
    {
        [SerializeField] Text textToUpdate;
        public void OnAgentsCountChanged(AgentsSelectionEventArgs args)
        {
            textToUpdate.text = $"Учеников выбрано: {args.newSelection.Count}";
        }
    }
}
