using BehaviourModel;
using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core
{
    public class ExperimentProcessHandler : MonoBehaviour
    {
        [SerializeField] SelectedAgentsHandler agentsHandler;
        [SerializeField] ScheduleHandler schedule;
        [SerializeField] GameObject pupilPrefab;
        [SerializeField] GameObject teacherPrefab;
        public void StartExperiment()
        {
            //создать GO агентов
            foreach (var pup in agentsHandler.Agents)
            {
                var placingRooms = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList();
                var placingPoints = placingRooms[Random.Range(0, placingRooms.Count)];
                var pupGO = Instantiate(pupilPrefab, placingPoints.RandomEntrance().transform).GetComponent<PupilAgent>();
                pupGO.Initiate(pup);
            }
        }
    }
}