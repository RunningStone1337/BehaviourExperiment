using BehaviourModel;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationTester : MonoBehaviour
{
    [SerializeField] bool autoStart;
    [SerializeField] List<PupilAgent> agents;
    [SerializeField] TeacherAgent teacher;
    [Button("Start simulation")]
    public void StartSimulate()
    {
        foreach (var ag in agents)
        {
            ag.SetDefaultState();
            ag.StartStateMachine();
        }
        if (teacher != null)
        {
            teacher.SetDefaultState();
            teacher.StartStateMachine();
        }
    }
    private void Start()
    {
        if (autoStart)
            StartSimulate();
    }
}
