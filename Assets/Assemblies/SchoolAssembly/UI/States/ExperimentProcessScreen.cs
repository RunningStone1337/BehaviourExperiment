using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExperimentProcessScreen : UIScreenBase
    {
        [SerializeField] private Text currentDayText;
        [SerializeField] private CurrentEventRect eventRect;

        public void OnDayChangedCallback(CurrentDayChangedEventArgs args)
        {
            currentDayText.text = $"Δενό {(args.newDay.DayIndex)}, {args.newDay.DayName}";
        }

        public void OnEventChangedCallback(CurrentEventChangedEventArgs args)
        {
            eventRect.UpdateData(args);
        }
    }
}