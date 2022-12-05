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
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.InterierListScreen.BeforeChangeState();
        }
        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            placeableUIView.InterierListScreen.ActiveComponent = placeableUIView;
            //подсвечиваем доступные места и активируем мерцание
            //var places = EntranceRoot.Root.PlacesDict.Values.Where(x => x.CurrentState is OccupedState);
            ///ПОЧЕМУ НЕ РАБОТАЕТ???
            var places = (IEnumerable<BuildingPlace>)EntranceRoot.Root.PlacesDict.Values.GetCurrentStateHandlers<OccupedState>()/* as IEnumerable<BuildingPlace>*/;
            var interier = placeableUIView.CorrespondingObjectPrefab.GetComponent<InterierBase>();
            interier.ActivateAvailableInterierPlaces(places);
        }
        public override void HandleInterierClick(InterierBase interierBase, PointerEventData eventData)
        {
            var place = interierBase.ThisInterierPlace;
            EntranceBuilder.ReplaceInterierOrDeleteExist(interierBase, place);
        }

        public override void Initiate()
        {
            CanvasController.Controller.InterierListScreen.InitiateState();//только активация UI списка предметов
        }
        public override void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        {
            ((InterierPlaceStateBase)interierPlaceBase.CurrentState).HandleInterierPlaceClick(eventData);
        }
    }
}