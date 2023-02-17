using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// ��������� ������������� �������, ����� �� ������ � ��������,
    /// �� ������� ��������� ��� ����������� ���� ���������.
    /// </summary>
    public class FreeInterierPlaceState : InterierPlaceStateBase
    {
        private void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.yellow);
        }

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetAvailForPlacingState();
            else
                thisPlace.SetNotAvailForPlacingState();
        }
    }
}