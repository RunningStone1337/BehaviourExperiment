using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// Иерархия состояний для мест размещения интерьера.
    /// </summary>
    public abstract class InterierPlaceStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected InterierPlaceBase thisPlace;
        private void Awake()
        {
            thisPlace = GetComponent<InterierPlaceBase>();
        }
        /// <summary>
        /// Конечный эта проверки разрешения размещения - в зависимости от состояния места размещения
        /// </summary>
        /// <param name="tableInterier"></param>
        /// <returns></returns>
        public virtual bool IsAvailableForPlacingInterier(TableInterier tableInterier) => default;

        public virtual void InitializeState() { }

        public virtual void BeforeChangeState() { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData) { }
        /// <summary>
        /// Устанавливает состояние противоположного места в зависимости от наличия ЗДЕСЬ интерьера типа Т
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetOppositePlaceStateAccordingSelectedInterier<T>() where T : InterierBase
        {
            var pl = (MiddlePlace)thisPlace;
            var op = pl.OppositeMiddlePlace;
                var currentObj = SceneMaster.Master.LastSelectedViewObject;
            //ЗДЕСЬ интерьер и противоположное место было доступно для размещения
            if (thisPlace.IsOccuped && thisPlace.Interier is T)//в кликнутом стейт = AvailableForPlacing, удален интерьер
            {
                if (op.CurrentState is AvailableForPlacingInterierPlaceState && currentObj is T)//запрещаем размещать
                    op.CurrentState = op.FreeInterierPlaceState;
                else
                    op.CurrentState = op.AvailableForPlacingInterierPlaceState;
            }//а если противоположный фри, он так и останется всегда, нужно менять его стейт в зависимости от выбранного объекта
            else if (!op.IsOccuped)
            {
                op.CurrentState = op.AvailableForPlacingInterierPlaceState;
            }

        }
        /// <summary>
        /// Если противоположная сторона занята столом, вернет true
        /// </summary>
        /// <returns></returns>
        protected bool IsOppositeOccupedByTable()
        {
            var place = (MiddlePlace)thisPlace;
            var opp = place.OppositeMiddlePlace;
            if (opp.IsOccuped && opp.Interier is TableInterier)
                return true;
            return false;
        }

    }
}