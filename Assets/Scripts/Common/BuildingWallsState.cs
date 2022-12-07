using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class BuildingWallsState : SceneStateBase
    {
        public override void Initiate()
        {
            ActivateAllInactiveWalls();
        }

        private static void ActivateAllInactiveWalls()
        {
            var root = EntranceRoot.Root;
            var entrances = root.PlacesDict.Select(x => x.Value).Where(x => x.CurrentState is OccupedState).Select(x => x.Entrance);
            foreach (var en in entrances)
            {
                foreach (var wall in en.Walls)
                {
                    if (wall.CurrentState is InactiveState)
                        wall.SetBuildingState();
                }
            }
        }

        public override void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            if (wall.CurrentState is AvailForBuildState)
                wall.SetActiveState();
            else
                wall.SetBuildingState();
        }
       
        public override void BeforeChangeOldState()
        {
            SceneMaster.Master.DeactivateAllBuildStateWalls();
        }
    }
}