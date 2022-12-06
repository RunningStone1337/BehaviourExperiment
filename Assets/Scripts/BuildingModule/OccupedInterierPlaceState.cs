using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// ����� � ������� ������ ���������.
    /// </summary>
    public class OccupedInterierPlaceState : InterierPlaceStateBase
    {
        public override void HandleInterierPlaceClick(PointerEventData eventData)
        {
            EntranceBuilder.ReplaceInterierOrDeleteExist(thisPlace.Interier, thisPlace);
        }

       
    }
}