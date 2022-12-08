using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class SceneMaster : MonoBehaviour
    {
        [SerializeField] SceneStateBase currentState;
        [SerializeField] BuildingEntranceModeState buildingModeState;
        [SerializeField] NavigationState navigationState;
        [SerializeField] PlacingInterierSceneState placingInterierState;
        [SerializeField] BuildingWallsState buildingWallsState;
        [SerializeField] EntranceRoleEditingState entranceRoleEditingState;
        [SerializeField] RoomSplittingState roomSplittingState;
        [SerializeField] IUIViewedObject lastSelectedViewObject;
        static SceneMaster master;
        public SceneStateBase CurrentState
        {
            get => currentState; set
            {
                currentState.BeforeChangeOldState();
                currentState = value;
                currentState.Initiate();
            }
        }
        public BuildingEntranceModeState BuildingModeState { get => buildingModeState; }
        public BuildingWallsState BuildingWallsState { get => buildingWallsState; }
        public RoomSplittingState RoomSplittingState { get => roomSplittingState; }
        public PlacingInterierSceneState PlacingInterierState { get => placingInterierState; }
        public EntranceRoleEditingState EntranceRoleEditingState { get => entranceRoleEditingState; }
        public NavigationState NavigationState { get => navigationState; }
        public static SceneMaster Master { get => master; private set => master = value; }
        public IUIViewedObject LastSelectedViewObject
        {
            get
            {
                return lastSelectedViewObject;
            }
            set
            {
                lastSelectedViewObject = value;
            }
        }

        private void Awake()
        {
            if (master == null)
            {
                master = this;
                return;
            }
            Destroy(this);
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
        public void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            CurrentState.HandleWallClick(wall, eventData);
        }

        public void HandleInterierClick(InterierBase interierBase, PointerEventData eventData)
        {
            CurrentState.HandleInterierClick(interierBase, eventData);
        }

        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            CurrentState.HandleEntranceClick(entrance, eventData);
        }

        public void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)
        {
            CurrentState.HandleInterierPlaceClick(interierPlaceBase, eventData);
        }

        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            CurrentState.HandleBuildingPlaceClick(buildingPlace, eventData);
        }
        public void HandlePlaceableUIViewClick(PlaceableUIView placeableUIView, PointerEventData eventData)
        {
            CurrentState.HandlePlaceableUIViewClick(placeableUIView, eventData);
        }
    }
}