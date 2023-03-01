using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class LookAroundIfOnChairAction : LookAroudAction, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (PupilAgent)ActionActor;
            if (cast.AgentEnvironment.ChairInfo != null)
            {
                yield return base.TryPerformAction();
                Debug.Log($"{this} was performed!");
            }
            else
            {
                Debug.Log($"{this} was'nt performed");
            }
        }
    }
}
