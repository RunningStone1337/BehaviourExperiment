using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ListenToTeacherAction : ListenToAgentActionBase<PupilAgent, TeacherAgent>, ICompletedAction
    {
        public ListenToTeacherAction():base() { }
      
    }
}