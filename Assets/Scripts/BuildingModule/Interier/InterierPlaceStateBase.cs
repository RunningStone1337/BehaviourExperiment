using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        /// �������� ���� �������� ���������� ���������� - � ����������� �� ��������� ����� ����������
        /// </summary>
        /// <param name="tableInterier"></param>
        /// <returns></returns>
        public virtual bool IsAvailableForPlacingInterier(InterierBase interier) { return default; }

        public virtual void InitializeState() { }

        public virtual void BeforeChangeState() { }

        public virtual void HandleInterierPlaceClick(PointerEventData eventData) { }
        /// <summary>
        /// ������������� ��������� ���������������� ����� � ����������� �� ������� ����� ��������� ���� �
        /// </summary>
        /// <typeparam name="T">���, �������������� ���������� �� ��������������� �������.</typeparam>
        public void SetOppositePlaceStateAccordingSelectedInterier<T>() where T : InterierBase
        {
            var pl = (MiddlePlace)thisPlace;
            var op = pl.OppositeMiddlePlace;
            var currentObj = (InterierBase)SceneMaster.Master.LastSelectedViewObject;
            //����� �������� � ��������������� ����� ���� �������� ��� ����������
            if (thisPlace.Interier.Count != 0 && thisPlace.Interier.Where(x=>x is T).Count()>0)
            {
                if (op.CurrentState is AvailableForPlacingInterierPlaceState && currentObj is T)//��������� ���������
                    op.CurrentState = op.FreeInterierPlaceState;
                else
                    op.CurrentState = op.AvailableForPlacingInterierPlaceState;
            }
            else if (op.Interier.Count == 0)
            {
                op.SetStateForPlacing(currentObj);
                //op.CurrentState = op.AvailableForPlacingInterierPlaceState;
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
            if (opp.Interier.Where(x=>x is TableInterier).Count() > 0)
                return true;
            return false;
        }

    }
}