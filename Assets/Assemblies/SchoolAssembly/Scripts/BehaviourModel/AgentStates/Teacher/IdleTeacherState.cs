using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class IdleTeacherState : IdleState<TeacherAgent>
    {
        public override IEnumerator StartState()
        {
            yield return null;
        }
    }
}
