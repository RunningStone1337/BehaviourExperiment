using BuildingModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] SceneMaster sceneMaster;

        public NavigationHandler NavigationHandler { get; private set; }

        static InputListener listener;
        public static InputListener Listener { get => listener; private set => listener = value; }
        private void Awake()
        {
            if (Listener == null)
            {
                Listener = this;
                return;
            }
            Destroy(this);
        }

        private void Start()
        {
            sceneMaster = FindObjectOfType<SceneMaster>();
            NavigationHandler = FindObjectOfType<NavigationHandler>();
        }

        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            sceneMaster.HandleBuildingPlaceClick(buildingPlace, eventData);
        }
        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            sceneMaster.HandleEntranceClick(entrance, eventData);
        }
        private void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            NavigationHandler.MouseScroll(scroll);
            if (sceneMaster.CurrentState is NavigationState)
            {
                NavigationHandler.Swipes();
            }
        }

    }
}