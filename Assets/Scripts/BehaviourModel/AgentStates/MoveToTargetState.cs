using Aoiti.Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Стейт движения к цели
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
            
            if (thisAgent.MovementTarget != null)//цель есть
            {
                if (thisAgent.Chair != null)//на стуле
                {
                    if ((MonoBehaviour)thisAgent.MovementTarget == thisAgent.Chair)//новая цель - тот же стул
                        thisAgent.SetState<IdleAgentState>();
                    else//цель новая
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