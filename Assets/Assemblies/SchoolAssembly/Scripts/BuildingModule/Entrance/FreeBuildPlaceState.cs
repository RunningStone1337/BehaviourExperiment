using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class FreeBuildPlaceState : BuildingPlaceState
    {
        public override bool TryPlaceNewEntrance(PointerEventData eventData)
        {
            return EntranceBuilder.Builder.BuildNewEntrance(thisPlace);
        }

        public override bool TryRemoveExistEntrance(PointerEventData eventData)
        {
            return true;
        }
    }
}