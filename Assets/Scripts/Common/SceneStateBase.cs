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
        ///  лик по месту дл€ размещени€ помещени€.
        /// </summary>
        /// <param name="buildingPlace"></param>
        /// <param name="eventData"></param>
        public abstract void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData);
        /// <summary>
        /// ќтрабатывает каждый раз после присвоени€ нового значени€ переменной состо€ни€
        /// </summary>
        public abstract void Initiate();
        /// <summary>
        /// ќтрабатывает каждый раз перед тем как присвоить новое значение переменной состо€ни€
        /// </summary>
        public abstract void BeforeChangeState();

        /// <summary>
        ///  лик по помещению.
        /// </summary>
        /// <param name="entrance"></param>
        /// <param name="eventData"></param>
        public abstract void HandleEntranceClick(Entrance entrance, PointerEventData eventData);
        /// <summary>
        ///  лик по стене
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="eventData"></param>
        public abstract void HandleWallClick(Wall wall, PointerEventData eventData);
    }
}