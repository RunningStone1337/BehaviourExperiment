using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common {
    public interface IVisualEffectRoutineHandler
    {
        Coroutine Routine { get; set; }

        IEnumerator VisualEffectRoutine();
        void StartRoutine();
    }
}