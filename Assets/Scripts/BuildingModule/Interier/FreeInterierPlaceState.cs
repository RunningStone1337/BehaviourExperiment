using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// ��������� ������������� �������, ����� �� ������ � ��������, 
    /// �� ������� ��������� ��� ����������� ���� ���������.
    /// </summary>
    public class FreeInterierPlaceState : InterierPlaceStateBase
    {
     
        public override void ResetState(InterierBase interier)
        {
            var princCOnd = interier.IsPrincipAvailableForPlacing(thisPlace);
            var intCount = thisPlace.InterierCount();
            if (intCount == 0 && princCOnd)
                thisPlace.SetAvailForPlacingState();
            else
                thisPlace.SetNotAvailForPlacingState();
        }
        void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.yellow);
        }
    }
}