using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class PlacingInterierState : SceneStateBase
    {
        public override void BeforeChangeOldState() 
        {
            CanvasController.Controller.InterierListScreen.DeactivateUI();
        }
        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            placeableUIView.InterierListScreen.ActiveComponent = placeableUIView;
            //подсвечиваем доступные места и активируем мерцание

        }
        public override void Initiate() 
        {
            CanvasController.Controller.InterierListScreen.ActivateUI();
        }
    }
}