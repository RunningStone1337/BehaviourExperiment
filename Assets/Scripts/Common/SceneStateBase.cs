using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public abstract class SceneStateBase : MonoBehaviour
    {
        [SerializeField] protected SceneMaster master;
        private void Awake()
        {
            master = GetComponent<SceneMaster>();
        }

        /// <summary>
        ///  лик по месту дл€ размещени€ помещени€.
        /// </summary>
        /// <param name="buildingPlace"></param>
        /// <param name="eventData"></param>
        public virtual void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData) { }
        /// <summary>
        /// ќтрабатывает каждый раз после присвоени€ нового значени€ переменной состо€ни€
        /// </summary>
        public virtual void Initiate() { }
        /// <summary>
        /// ќтрабатывает каждый раз перед тем как присвоить новое значение переменной состо€ни€
        /// </summary>
        public virtual void BeforeChangeOldState() { }

        /// <summary>
        ///  лик по помещению.
        /// </summary>
        /// <param name="entrance"></param>
        /// <param name="eventData"></param>
        public virtual void HandleEntranceClick(Entrance entrance, PointerEventData eventData) { }
        /// <summary>
        ///  лик по стене
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="eventData"></param>
        public virtual void HandleWallClick(Wall wall, PointerEventData eventData) { }
        /// <summary>
        ///  лик по UI панели, соответствующей создаваемому GO
        /// </summary>
        /// <param name="placeableUIView"></param>
        /// <param name="eventData"></param>
        public virtual void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData) { }
    }
}