using System.Collections;
using UnityEngine;

namespace BehaviourModel
{
    /// <summary>
    /// Стейт движения к цели
    /// </summary>
    public class MoveToTargetState<T> : SchoolAgentStateBase<T>
        where T : SchoolAgentBase<T>
    {
        [SerializeField] SchoolAIPath movementComponent;
        public override void Initiate(T _thisAgent)
        {
            base.Initiate(_thisAgent);
            movementComponent = _thisAgent.GetComponent<SchoolAIPath>();
        }      

        public override IEnumerator StartState()
        {
            var cached = thisAgent.MovementTarget;
            if (thisAgent.MovementTarget != null)//цель есть
            {
                movementComponent.canMove = true;
                yield return thisAgent.OnBeforeStartMovement();
            }
            else yield break;

            while (movementComponent.canMove && thisAgent.MoveToTargetCondition())
                yield return null;

            yield return thisAgent.OnTargetReachedRoutine(cached);
            //Debug.Log("End movement state");
            thisAgent.SetDefaultState();
        }
    }
}