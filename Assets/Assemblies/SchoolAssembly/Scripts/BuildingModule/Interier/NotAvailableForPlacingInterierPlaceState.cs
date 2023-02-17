using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// ����� ������������� ���������� ���������.
    /// </summary>
    public class NotAvailableForPlacingInterierPlaceState : InterierPlaceStateBase
    {
        private void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.red);
        }

        public override void HandleInterierPlaceClick(PointerEventData eventData)
        {
            EntranceBuilder.ReplaceInterierOrDeleteExist(thisPlace.GetInterier(), thisPlace);
        }

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetAvailForPlacingState();
        }
    }
}