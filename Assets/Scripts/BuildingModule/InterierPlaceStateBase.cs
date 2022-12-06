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
    /// �������� ��������� ��� ���� ���������� ���������.
    /// </summary>
    public abstract class InterierPlaceStateBase : MonoBehaviour, IState
    {
        [SerializeField] protected InterierPlaceBase thisPlace;
        private void Awake()
        {
            thisPlace = GetComponent<InterierPlaceBase>();
        }
        /// <summary>
        /// �������� ��� �������� ���������� ���������� - � ����������� �� ��������� ����� ����������
        /// </summary>
        /// <param name="tableInterier"></param>
        /// <returns></returns>
        public virtual bool IsAvailableForPlacingInterier(TableInterier tableInterier) => default;

        public virtual void InitializeState() { }

        public virtual void BeforeChangeState() { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData) { }
        /// <summary>
        /// ������������� ��������� ���������������� ����� � ����������� �� ������� ����� ��������� ���� �
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void SetOppositePlaceStateAccordingSelectedInterier<T>() where T : InterierBase
        {
            var pl = (MiddlePlace)thisPlace;
            var op = pl.OppositeMiddlePlace;
                var currentObj = SceneMaster.Master.LastSelectedViewObject;
            //����� �������� � ��������������� ����� ���� �������� ��� ����������
            if (thisPlace.IsOccuped && thisPlace.Interier is T)//� ��������� ����� = AvailableForPlacing, ������ ��������
            {
                if (op.CurrentState is AvailableForPlacingInterierPlaceState && currentObj is T)//��������� ���������
                    op.CurrentState = op.FreeInterierPlaceState;
                else
                    op.CurrentState = op.AvailableForPlacingInterierPlaceState;
            }//� ���� ��������������� ���, �� ��� � ��������� ������, ����� ������ ��� ����� � ����������� �� ���������� �������
            else if (!op.IsOccuped)
            {
                op.CurrentState = op.AvailableForPlacingInterierPlaceState;
            }

        }
        /// <summary>
        /// ���� ��������������� ������� ������ ������, ������ true
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