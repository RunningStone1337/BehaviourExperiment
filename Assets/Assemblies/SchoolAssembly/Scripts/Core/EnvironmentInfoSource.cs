using Events;
using UnityEngine;

namespace Core
{
    public abstract class EnvironmentInfoSource : MonoBehaviour
    {
        public class CurrentEventChangedEventArgs
        {
            public GlobalEvent newEvent;
        }
        public delegate void CurrentEventChangedDelegate(CurrentEventChangedEventArgs args);
        public event CurrentEventChangedDelegate OnGlobalEventChanged;
        #region events

        [SerializeField] protected BreakEvent breakEvent;
        [SerializeField] protected LessonEvent lessonEvent;
        [SerializeField] protected GlobalEvent currentEvent;

        #endregion events

        public abstract GlobalEvent CurrentGlobalEvent { get; protected set; }
        protected void RaiseOnGlobalEventChanged(GlobalEvent value)
        {
            OnGlobalEventChanged?.Invoke(new CurrentEventChangedEventArgs() { newEvent = value }); ;
        }
    }
}