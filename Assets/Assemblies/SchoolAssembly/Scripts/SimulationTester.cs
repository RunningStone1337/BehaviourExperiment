using BehaviourModel;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationTester : MonoBehaviour
{
    [SerializeField] List<PupilAgent> agents;
    [Button("Start simulation")]
    public void StartSimulate()
    {
        foreach (var ag in agents)
        {
            ag.SetDefaultState();
            ag.StartStateMachine();
        }
    }
}
