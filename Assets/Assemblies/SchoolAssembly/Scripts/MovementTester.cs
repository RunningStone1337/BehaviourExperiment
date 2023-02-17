using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTester : MonoBehaviour
{
    [SerializeField] MovementComponent<PupilAgent> movementComponent;
    [SerializeField] PupilAgent agent;
    [SerializeField] Transform targetTransform;
    public void OnMoveButtonClick()
    {
        if (!agent.IsActing)
            agent.StartStateMachine();
        if (targetTransform.TryGetComponent(out IMovementTarget<PupilAgent> moveTarget))
        {
            agent.MovementTarget = moveTarget;
            agent.SetState<MoveToTargetState<PupilAgent>>();
        }
        else
            Debug.Log($"Объект {targetTransform.gameObject} не имеет компонента, реализующего IMovementTarget");
    }
}
