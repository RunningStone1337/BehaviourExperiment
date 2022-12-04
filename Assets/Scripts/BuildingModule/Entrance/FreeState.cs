using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class FreeState : BuildingPlaceState
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
