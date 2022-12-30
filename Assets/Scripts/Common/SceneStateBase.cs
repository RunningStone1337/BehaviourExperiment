using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    /// <summary>
    /// Иерархия глобальных состояний сцены.
    /// </summary>
    public abstract class SceneStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected SceneMaster master;
        private void Awake()
        {
            master = GetComponent<SceneMaster>();
        }
        /// <summary>
        /// Клик по месту для размещения помещения.
        /// </summary>
        /// <param name="buildingPlace"></param>
        /// <param name="eventData"></param>
        public virtual void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData) { }
        /// <summary>
        /// Отрабатывает каждый раз после присвоения нового значения переменной состояния
        /// </summary>
        public virtual void Initiate() { }
        /// <summary>
        /// Отрабатывает каждый раз перед тем как присвоить новое значение переменной состояния
        /// </summary>
        public virtual void BeforeChangeOldState() { }

        /// <summary>
        /// Клик по помещению.
        /// </summary>
        /// <param name="entrance"></param>
        /// <param name="eventData"></param>
        public virtual void HandleEntranceClick(Entrance entrance, PointerEventData eventData) { }
        /// <summary>
        /// Клик по стене
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="eventData"></param>
        public virtual void HandleWallClick(Wall wall, PointerEventData eventData) { }

        /// <summary>
        /// Клик по размещённому элементу интерьера.
        /// </summary>
        /// <param name="interierBase"></param>
        /// <param name="eventData"></param>
        public virtual void HandleInterierClick(PlacedInterier interierBase, PointerEventData eventData) { }

        /// <summary>
        /// Клик по UI панели, соответствующей создаваемому GO
        /// </summary>
        /// <param name="placeableUIView"></param>
        /// <param name="eventData"></param>
        public virtual void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData) { }
        /// <summary>
        /// Клик по месту размещения интерьера.
        /// </summary>
        /// <param name="interierPlaceBase"></param>
        /// <param name="eventData"></param>
        public virtual void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData) { }
    }
}