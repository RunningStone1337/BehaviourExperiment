using System.Collections;
using UnityEngine;

namespace Common
{
    public interface IVisualEffectRoutineHandler
    {
        Coroutine Routine { get; set; }

        void StartRoutine();

        IEnumerator VisualEffectRoutine();
    }
}