using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class GlobalEventsHandler : MonoBehaviour
    {
        static GlobalEventsHandler instance;
        public static GlobalEventsHandler Instance => instance;
        private void Awake()
        {
            if (Instance == null)
            {
                instance = this;
                return;
            }
            Destroy(this);
        }

        [SerializeField] protected DayOverEvent dayOverEvent;
        public DayOverEvent DayOverEvent => dayOverEvent;
        [SerializeField] protected BreakEvent breakEvent;
        public BreakEvent BreakEvent => breakEvent;
        [SerializeField] protected LessonEvent lessonEvent;
        public LessonEvent LessonEvent => lessonEvent;
        [SerializeField] protected GlobalEvent currentEvent;
        [SerializeField] UnityEvent<CurrentEventChangedEventArgs> onGlobalEventChanged;
        public UnityEvent<CurrentEventChangedEventArgs> OnGlobalEventChanged => onGlobalEventChanged;
        public GlobalEvent CurrentGlobalEvent
        {
            get => currentEvent;
            set
            {
                currentEvent = value;
                OnGlobalEventChanged?.Invoke(new CurrentEventChangedEventArgs() { newEvent = currentEvent });
            }
        }
        public void OnDayChangedCallback(CurrentDayChangedEventArgs args)
        {
            CurrentGlobalEvent = LessonEvent;
        }
    }
}
