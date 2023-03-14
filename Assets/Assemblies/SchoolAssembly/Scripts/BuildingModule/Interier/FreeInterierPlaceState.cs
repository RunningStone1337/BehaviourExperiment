using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// ��������� ������������� �������, ����� �� ������ � ��������,
    /// �� ������� ��������� ��� ����������� ���� ���������.
    /// </summary>
    public class FreeInterierPlaceState : InterierPlaceStateBase
    {
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.yellow);
        }
#endif

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetAvailForPlacingState();
            else
                thisPlace.SetNotAvailForPlacingState();
        }
    }
}