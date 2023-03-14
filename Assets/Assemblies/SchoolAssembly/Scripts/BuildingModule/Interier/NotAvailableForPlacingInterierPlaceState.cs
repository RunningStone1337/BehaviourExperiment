using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    /// <summary>
    /// —тейт недоступности размещени€ интерьера.
    /// </summary>
    public class NotAvailableForPlacingInterierPlaceState : InterierPlaceStateBase
    {
#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            DrawSphereGizmo(Color.red);
        }
#endif

        //public override void HandleInterierPlaceClick(PointerEventData eventData)
        //{
        //    EntranceBuilder.ReplaceInterierOrDeleteExist(thisPlace.GetInterier(), thisPlace);
        //}

        public override void SetStateForInterier(PlacedInterier interier)
        {
            if (interier.IsAvailForPlacing(thisPlace))
                thisPlace.SetAvailForPlacingState();
        }
    }
}