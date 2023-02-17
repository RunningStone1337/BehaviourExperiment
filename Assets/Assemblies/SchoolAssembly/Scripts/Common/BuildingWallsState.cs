using BuildingModule;
using UnityEngine.EventSystems;

namespace Common
{
    public class BuildingWallsState : SceneStateBase
    {
        private static void ActivateAllInactiveWalls()
        {
            var root = EntranceRoot.Root;
            var entrances = root.Entrances;
            foreach (var en in entrances)
            {
                foreach (var wall in en.Walls)
                {
                    if (wall.CurrentState is InactiveState)
                        wall.SetBuildingState();
                }
            }
        }

        public override void BeforeChangeOldState()
        {
            SceneMaster.Master.DeactivateAllBuildStateWalls();
        }

        public override void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            if (wall.CurrentState is AvailForBuildState)
                wall.SetActiveState();
            else
                wall.SetBuildingState();
            var entr = wall.ThisEntrance;
            entr.RemoveInvalidInterierAndFromNeighbours();
        }

        public override void Initiate()
        {
            ActivateAllInactiveWalls();
        }
    }
}