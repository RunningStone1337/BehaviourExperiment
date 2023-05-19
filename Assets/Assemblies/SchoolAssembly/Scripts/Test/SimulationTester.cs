#if UNITY_EDITOR
using BehaviourModel;
using Sirenix.OdinInspector;
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
            ag.StartActing();
        }
        if (teacher != null)
        {
            teacher.SetDefaultState();
            teacher.StartActing();
        }
    }
    private void Start()
    {
        if (autoStart)
            StartSimulate();
    }
}
#endif