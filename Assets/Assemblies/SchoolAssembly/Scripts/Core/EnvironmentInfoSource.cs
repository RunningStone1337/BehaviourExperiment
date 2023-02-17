using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class EnvironmentInfoSource : MonoBehaviour
    {
        #region events

        [SerializeField] protected BreakEvent breakEvent;
        [SerializeField] protected GlobalEvent currentEvent;
        [SerializeField] protected LessonEvent lessonEvent;

        #endregion events

        
        [SerializeField] protected List<TemporaryEffect> temporaryEffects;

        public abstract GlobalEvent CurrentGlobalEvent { get; }

        public abstract List<TemporaryEffect> TemporaryEffects { get; }
    }
}