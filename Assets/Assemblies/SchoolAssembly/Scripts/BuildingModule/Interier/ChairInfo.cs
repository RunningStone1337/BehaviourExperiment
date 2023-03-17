using BehaviourModel;
using UnityEngine;

namespace BuildingModule
{
    public class ChairInfo : InterierInfoBase<ChairInterier>
    {
        //private void FixedUpdate()
        //{
        //    if (thisAgent != null)
        //    {
        //        if (thisAgent is PupilAgent p)
        //            p.AgentRigidbody.MovePosition(transform.position);
        //        else if (thisAgent is TeacherAgent t)
        //            t.AgentRigidbody.MovePosition(transform.position);
        //    }
        //}

      
        protected IAgent thisAgent;
        public IAgent ThisAgent { get => thisAgent; set => thisAgent = value; }
    }
}