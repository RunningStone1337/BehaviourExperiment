using BuildingModule;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class SceneMaster : MonoBehaviour
    {
        #region Private Fields

        private static SceneMaster master;
        [SerializeField] private BuildingEntranceModeState buildingModeState;
        [SerializeField] private BuildingWallsState buildingWallsState;
        [SerializeField] private SceneStateBase currentState;
        [SerializeField] private EntranceRoleEditingState entranceRoleEditingState;
        [SerializeField] private EventsPlanningState eventsPlanningState;
        [SerializeField] private IUIViewedObject lastSelectedViewObject;
        [SerializeField] private NavigationState navigationState;
        [SerializeField] private PlacingInterierSceneState placingInterierState;
        [SerializeField] private RoomSplittingState roomSplittingState;

        #endregion Private Fields

        private void Awake()
        {
            if (master == null)
            {
                master = this;
                return;
            }
            Destroy(this);
        }

        public static SceneMaster Master { get => master; private set => master = value; }
        public BuildingEntranceModeState BuildingModeState { get => buildingModeState; }
        public BuildingWallsState BuildingWallsState { get => buildingWallsState; }

        public SceneStateBase CurrentState
        {
            get => currentState; set
            {
                currentState.BeforeChangeOldState();
                currentState = value;
                currentState.Initiate();
            }
        }

        public EntranceRoleEditingState EntranceRoleEditingState { get => entranceRoleEditingState; }
        public EventsPlanningState EventsPlanningState { get => eventsPlanningState; }
        public IUIViewedObject LastSelectedViewObject
        {
            get => lastSelectedViewObject;
            set => lastSelectedViewObject = value;
        }

        public NavigationState NavigationState { get => navigationState; }
        public PlacingInterierSceneState PlacingInterierState { get => placingInterierState; }
        public RoomSplittingState RoomSplittingState { get => roomSplittingState; }

        public void ClearEntrances()
        {
            var entr = EntranceRoot.Root.Entrances;
            foreach (var e in entr)
                e.EntrancePlace.TryRemoveExistEntrance(null);
        }

        public void CreateTemplateEntrances()
        {
            TemplateBuilder.Instance.BuildRandomTemplate();
        }

        public void DeactivateAllBuildStateWalls()
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var en in entrances)
            {
                foreach (var wall in en.Walls)
                {
                    if (wall.CurrentState is AvailForBuildState)
                        wall.SetInactiveState();
                }
            }
        }

        public void DeactivateAllInterierPlaces()
        {
            var entrances = EntranceRoot.Root.Entrances;
            foreach (var en in entrances)
            {
                var places = new List<InterierPlaceBase>(en.MiddlePlaces);
                places.AddRange(en.Underwalls);
                places.AddRange(en.Corners);
                foreach (var wall in places)
                {
                    if (wall.CurrentState is AvailableForPlacingInterierPlaceState)
                        wall.CurrentState = wall.FreeInterierPlaceState;
                }
            }
        }

        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            CurrentState.HandleBuildingPlaceClick(buildingPlace, eventData);
        }

        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            CurrentState.HandleEntranceClick(entrance, eventData);
        }

        public void HandleInterierClick<T>(T interierBase, PointerEventData eventData) where T : PlacedInterier
        {
            CurrentState.HandleInterierClick(interierBase, eventData);
        }

        public void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        {
            CurrentState.HandleInterierPlaceClick(interierPlaceBase, eventData);
        }

        public void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            CurrentState.HandlePlaceableUIViewClick(placeableUIView, eventData);
        }

        public void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            CurrentState.HandleWallClick(wall, eventData);
        }
    }
}