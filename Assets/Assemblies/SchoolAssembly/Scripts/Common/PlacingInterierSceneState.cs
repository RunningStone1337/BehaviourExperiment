using BuildingModule;
using UI;
using UnityEngine.EventSystems;

namespace Common
{
    public class PlacingInterierSceneState : SceneStateBase
    {
        public override void BeforeChangeOldState()
        {
            CanvasController.Controller.InterierListScreen.BeforeChangeState();
            ///сбросить все стейты недоступных мест в свободные
            foreach (var e in EntranceRoot.Root.Entrances)
            {
                e.InterierPlaces.SetStatesFromS1ToS2
                    <InterierPlaceBase, NotAvailableForPlacingInterierPlaceState, FreeInterierPlaceState, InterierPlaceStateBase>();
            }
        }

        public override void HandleInterierClick(PlacedInterier interierBase, PointerEventData eventData)
        {
            var place = interierBase.ThisInterierPlace;
            EntranceBuilder.ReplaceInterierOrDeleteExist(interierBase, place);
        }

        public override void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        {
            interierPlaceBase.HandleInterierPlaceClick(eventData);
        }

        public override void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            SceneMaster.Master.LastSelectedViewObject = placeableUIView.CorrespondingObjectPrefab;
            CanvasController.Controller.InterierListScreen.ActiveComponent = placeableUIView;
            var interier = (PlacedInterier)placeableUIView.CorrespondingObjectPrefab;
            //подсвечиваем доступные места и активируем мерцание
            InterierPlaceBase.ActivateAvailableInterierPlaces(interier);
        }

        public override void Initiate()
        {
            CanvasController.Controller.InterierListScreen.InitiateState();//только активация UI списка предметов
        }
    }
}