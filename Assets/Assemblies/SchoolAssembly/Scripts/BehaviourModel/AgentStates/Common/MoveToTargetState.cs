using Aoiti.Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// ����� �������� � ����
    /// </summary>
    public class MoveToTargetState<T> : SchoolAgentStateBase<T>
        where T : SchoolAgentBase<T>
    {
        [SerializeField] MovementComponent<T> movementComponent;
        public override void Initiate(T _thisAgent)
        {
            base.Initiate(_thisAgent);
            movementComponent = _thisAgent.GetComponent<MovementComponent<T>>();
        }      

        public override IEnumerator StartState()
        {
            //StateBreaked = false;

            if (thisAgent.MovementTarget != null)//���� ����
            {
                if (thisAgent.AgentEnvironment.ChairInfo != null)//�� �����
                {
                    if (IsNewTarget())//����� ����
                        yield return thisAgent.OnLeaveChair();
                }
                var pos = ((MonoBehaviour)thisAgent.MovementTarget).transform.position;
                var moveCondition = thisAgent.MovementTarget.MoveToTargetCondition;
                yield return movementComponent.StartMoveToPoint(pos, moveCondition);
            }
            thisAgent.SetDefaultState();
        }

        private bool IsNewTarget()
        {
            return (MonoBehaviour)thisAgent.MovementTarget != thisAgent.AgentEnvironment.ChairInfo.ThisInterier;
        }

       
    }
}