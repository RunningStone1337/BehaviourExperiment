using BehaviourModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationTester : MonoBehaviour
{
    [SerializeField] PupilAgent agent;
    [ContextMenu("Start agent")]
    public void StartSimulate()
    {
        agent.StartStateMachine();
    }
}
