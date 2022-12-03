using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class SceneMaster : MonoBehaviour
    {
        [SerializeField] SceneStateBase currentState;
        [SerializeField] BuildingModeState buildingModeState;
        [SerializeField] NavigationState navigationState;
        [SerializeField] PlacingInterierState placingInterierState;
        [SerializeField] BuildingWallsState buildingWallsState;
        static SceneMaster master;
        public SceneStateBase CurrentState
        {
            get => currentState; set
            {
                currentState.BeforeChangeState();
                currentState = value;
                currentState.Initiate();
            }
        }
        public BuildingModeState BuildingModeState { get => buildingModeState; }
        public BuildingWallsState BuildingWallsState { get => buildingWallsState; }
        public PlacingInterierState PlacingInterierState { get => placingInterierState; }
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

        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            CurrentState.HandleEntranceClick(entrance, eventData);
        }

        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            CurrentState.HandleBuildingPlaceClick(buildingPlace, eventData);
        }
    }
}