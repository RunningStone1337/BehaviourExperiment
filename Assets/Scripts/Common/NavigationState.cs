using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class NavigationState : SceneStateBase
    {
        public override void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData){}

        public override void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
        }
    }
}