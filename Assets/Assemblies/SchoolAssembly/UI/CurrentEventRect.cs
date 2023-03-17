using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CurrentEventRect : UIScreenBase
    {
        [SerializeField] Text currentEventText;
        [SerializeField] ProgressBar eventBar;
        public void UpdateData(CurrentEventChangedEventArgs args)
        {
            currentEventText.text = args.newEvent.Name;
            eventBar.Reset(args.newEvent.EventDuration);
        }
        public void OnEventTimerUpdatedCallback(CurrentEventChangedEventArgs args)
        {
            eventBar.SetProgress(args.eventTimer);
        }
    }
}
