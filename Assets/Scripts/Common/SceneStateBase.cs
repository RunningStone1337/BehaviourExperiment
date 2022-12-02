using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public abstract class SceneStateBase : MonoBehaviour
    {
        /// <summary>
        /// ���� �� ����� ��� ���������� ���������.
        /// </summary>
        /// <param name="buildingPlace"></param>
        /// <param name="eventData"></param>
        public abstract void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData);
        /// <summary>
        /// ���� �� ���������.
        /// </summary>
        /// <param name="entrance"></param>
        /// <param name="eventData"></param>
        public abstract void HandleEntranceClick(Entrance entrance, PointerEventData eventData);
    }
}