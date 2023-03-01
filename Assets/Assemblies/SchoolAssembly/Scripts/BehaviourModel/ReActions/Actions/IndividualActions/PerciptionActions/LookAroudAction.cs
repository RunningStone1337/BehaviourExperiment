using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class LookAroudAction : IndividualPerciptionActionBase, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            cast.SetState<TurnToSidesState<PupilAgent>>();
            yield return cast.CurrentState.StartState();
            WasPerformed = true;
            cast.SetDefaultState();
        }
    }
}
