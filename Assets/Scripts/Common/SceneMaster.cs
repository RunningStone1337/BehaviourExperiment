using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public PlacingInterierSceneState PlacingInterierState { get => placingInterierState; }

       

        public NavigationState NavigationState { get => navigationState; }
        public static SceneMaster Master { get => master; private set => master = value; }

        private void Awake()
        {
            if (master == null)
            {
                master = this;
                return;
            }
            Destroy(this);
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