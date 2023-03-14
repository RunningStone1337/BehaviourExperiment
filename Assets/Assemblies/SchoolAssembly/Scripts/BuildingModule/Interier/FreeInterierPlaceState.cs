using UnityEngine;

namespace BuildingModule
{
    /// <summary>
    /// Состояние неопределённой свободы, место не занято в принципе,
    /// но требует уточнения для конкретного типа интерьера.
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