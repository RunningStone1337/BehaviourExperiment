using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ExperimentProcessScreen : UIScreenBase
    {
        [SerializeField] CurrentEventRect eventRect;
        [SerializeField] Text currentDayText;
        public void OnEventChangedCallback(CurrentEventChangedEventArgs args)
        {
            eventRect.UpdateData(args);
        }
        public void OnDayChangedCallback(CurrentDayChangedEventArgs args)
        {
            currentDayText.text = $"Δενό {(args.newDay.DayIndex + 1)}, {args.newDay.DayName}";
        }
    }
}
