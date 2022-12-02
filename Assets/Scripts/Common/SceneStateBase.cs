using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public abstract class SceneStateBase : MonoBehaviour
    {
        public abstract void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData);
        public abstract void HandleEntranceClick(Entrance entrance, PointerEventData eventData);
    }
}