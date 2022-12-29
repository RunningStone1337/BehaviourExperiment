using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// ����� ������������� ���������� ���������.
    /// </summary>
    public class NotAvailableForPlacingInterierPlaceState : InterierPlaceStateBase
    {
       
        public override void HandleInterierPlaceClick(PointerEventData eventData)
        {
            EntranceBuilder.ReplaceInterierOrDeleteExist(thisPlace.GetInterier(), thisPlace);
        }

        public override void ResetState(InterierBase interier)
        {
            ///����� �������� ���������
            var intCount = thisPlace.InterierCount();
            if (intCount == 0)
            {
                thisPlace.SetAvailForPlacingState();
            }
        }
        void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.red);

        }
    }
}