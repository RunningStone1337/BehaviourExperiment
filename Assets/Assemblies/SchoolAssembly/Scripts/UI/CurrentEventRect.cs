using Core;
using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
            if (args.newEvent is LessonEvent les)
                currentEventText.text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(les.CurrentDiscipline.DisciplineName);
            else if (args.newEvent is BreakEvent)
                currentEventText.text = "Перемена";
            else if (args.newEvent is DayOverEvent)
                currentEventText.text = "Конец дня";
            eventBar.Reset(args.newEvent.EventDuration);
        }
        public void OnEventTimerUpdatedCallback(CurrentEventChangedEventArgs args)
        {
            eventBar.SetProgress(args.eventTimer);
        }
    }
}
