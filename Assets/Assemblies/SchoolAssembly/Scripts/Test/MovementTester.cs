# if UNITY_EDITOR
using BehaviourModel;
using Sirenix.OdinInspector;
using UnityEngine;

public class MovementTester : MonoBehaviour
{
    [SerializeField] PupilAgent agent;
    [SerializeField] Transform targetTransform;
    private Coroutine routine;

    [Button]
    public void MoveToTarget()
    {
        if (targetTransform == null)
            return;
        agent.MovementTarget = targetTransform;
        var state = agent.SetState<MoveToTargetState<PupilAgent>>();
        routine = StartCoroutine(state.StartState());
    }
}
#endif
