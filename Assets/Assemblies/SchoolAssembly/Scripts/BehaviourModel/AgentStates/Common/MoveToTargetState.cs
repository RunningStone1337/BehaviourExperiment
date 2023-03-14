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
        [SerializeField] MovementComponent<T> movementComponent;
        public override void Initiate(T _thisAgent)
        {
            base.Initiate(_thisAgent);
            movementComponent = _thisAgent.GetComponent<MovementComponent<T>>();
        }      

        public override IEnumerator StartState()
        {
            //StateBreaked = false;
            var cached = thisAgent.MovementTarget;
            if (thisAgent.MovementTarget != null)//цель есть
                yield return thisAgent.OnBeforeStartMovement();
            else yield break;
            while (!thisAgent.TargetReached)
            {
                yield return null;
                //var target = ((MonoBehaviour)thisAgent.MovementTarget).transform;
                //Func<bool> moveCondition = thisAgent.MoveToTargetCondition;
                //yield return movementComponent.StartMoveToTransform(target, moveCondition);
            }
            yield return thisAgent.OnTargetReached(cached);
            Debug.Log("End movement state");
            //thisAgent.MovementTarget = null;
            thisAgent.SetDefaultState();
        }
    }
}