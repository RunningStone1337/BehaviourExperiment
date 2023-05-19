using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class PupilLookAroudAction : IndividualPerciptionActionBase, ICompletedAction
    {
        public PupilLookAroudAction():base()
        {

        }
        public PupilLookAroudAction(PupilAgent cast)
        {
            Initiate(null, cast);
        }

        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as PupilAgent;
            if (cast != null)
            {
                var state = cast.SetState<TurnToSidesState<PupilAgent>>();
                yield return state.StartState();
                WasPerformed = true;
                cast.SetDefaultState();
            }
        }
    }
}
