using BehaviourModel;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTester : MonoBehaviour
{
    //[SerializeField] MovementComponent<PupilAgent> movementComponent;
    [SerializeField] PupilAgent agent;
    [SerializeField] Transform targetTransform;
    private Coroutine routine;

    [Button]
    public void MoveToTarget()
    {
        //if (!agent.IsActing)
        //    agent.StartStateMachine();
        //if (targetTransform.TryGetComponent(out IMovementTarget moveTarget))
        //{
        if (targetTransform == null)
        {
            Debug.Log("Set movement target tarnsform");
            return;
        }
        agent.MovementTarget = targetTransform;
        var state = agent.SetState<MoveToTargetState<PupilAgent>>();
        routine = StartCoroutine(state.StartState());
        //}
        //else
        //    Debug.Log($"Объект {targetTransform.gameObject} не имеет компонента, реализующего IMovementTarget");
    }
}
