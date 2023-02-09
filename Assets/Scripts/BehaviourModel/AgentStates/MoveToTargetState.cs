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
    public class MoveToTargetState : SchoolAgentStateBase
    {
        [SerializeField] MovementComponent movementComponent;

        public override bool StateBreaked
        {
            get => movementComponent.StopMovement;
            set
            {
                movementComponent.StopMovement = value;
                stateBreaked = value;
            }
        }

        public override IEnumerator StartState()
        {
            StateBreaked = false;
            
            if (thisAgent.MovementTarget != null)//���� ����
            {
                if (thisAgent.Chair != null)//�� �����
                {
                    if ((MonoBehaviour)thisAgent.MovementTarget == thisAgent.Chair)//����� ���� - ��� �� ����
                        thisAgent.SetState<IdleAgentState>();
                    else//���� �����
                        yield return thisAgent.Chair.OnLeaveChair();
                }
                yield return AwaitMovementRoutine(); 
            }
            thisAgent.SetState<IdleAgentState>();
        }

        private IEnumerator AwaitMovementRoutine()
        {
            yield return movementComponent.StartMoveToTarget(((MonoBehaviour)thisAgent.MovementTarget).transform.position);
        }
    }
}