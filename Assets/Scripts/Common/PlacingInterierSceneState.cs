using BuildingModule;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine.EventSystems;

namespace Common
{
    public class PlacingInterierSceneState : SceneStateBase
    {
        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            SceneMaster.Master.LastSelectedViewObject = placeableUIView.CorrespondingObjectPrefab;
            CanvasController.Controller.InterierListScreen.ActiveComponent = placeableUIView;
            var interier = (InterierBase)SceneMaster.Master.LastSelectedViewObject;
            //подсвечиваем доступные места и активируем мерцание
            InterierPlaceBase.ActivateAvailableInterierPlaces(interier);
        }
        public override void HandleInterierClick(InterierBase interierBase, PointerEventData eventData) 
        {
            var place = interierBase.ThisInterierPlace;
            EntranceBuilder.ReplaceInterierOrDeleteExist(interierBase, place);
        }
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.InterierListScreen.BeforeChangeState();
        }

        public override void Initiate()
        {
            CanvasController.Controller.InterierListScreen.InitiateState();//только активаци€ UI списка предметов
        }
        public override void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        {
            interierPlaceBase.HandleInterierPlaceClick(eventData);
        }
    }
}