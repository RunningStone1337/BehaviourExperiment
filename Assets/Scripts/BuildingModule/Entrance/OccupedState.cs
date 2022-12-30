using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class OccupedState : BuildingPlaceState
    {
        public override bool TryPlaceNewEntrance(PointerEventData eventData)
        {
            return false;
        }

        public override bool TryRemoveExistEntrance(PointerEventData eventData)
        {
            Destroy(thisPlace.Entrance.gameObject);
            thisPlace.CurrentState = thisPlace.FreeState;
            foreach (var neigh in thisPlace.Neighbours)
            {
                EntranceBuilder.RebuildWalls(neigh);
            }
            return true;
        }
    }
}