using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// ����� ������������� ���������� ���������.
    /// </summary>
    public class NotAvailableForPlacingInterierPlaceState : InterierPlaceStateBase
    {
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.red);
        }
#endif
              

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetAvailForPlacingState();
        }
    }
}