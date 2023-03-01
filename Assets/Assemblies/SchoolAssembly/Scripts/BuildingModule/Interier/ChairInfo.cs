using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class ChairInfo : InterierInfoBase<ChairInterier>
    {
        protected IAgent thisAgent;
        public IAgent ThisAgent { get => thisAgent; set => thisAgent = value; }
        private void FixedUpdate()
        {
            if (thisAgent != null)
            {
                if (thisAgent is PupilAgent p)
                    p.AgentRigidbody.MovePosition(transform.position);
                else if (thisAgent is TeacherAgent t)
                    t.AgentRigidbody.MovePosition(transform.position);
            }
        }
    }
}
