using BuildingModule;
using UnityEngine.EventSystems;

namespace Common
{
    public class BuildingEntranceModeState : SceneStateBase
    {
        public override void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            var isSucceed = buildingPlace.TryPlaceNewEntrance(eventData);
            if (!isSucceed)
            {
                isSucceed = buildingPlace.TryRemoveExistEntrance(eventData);
                if (!isSucceed)
                    throw new System.Exception("Unhandled exception in building module");
            }
        }

        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            var isSucceed = entrance.EntrancePlace.TryRemoveExistEntrance(eventData);
            if (!isSucceed)
                throw new System.Exception("Unhandled exception in building module");
        }
    }
}