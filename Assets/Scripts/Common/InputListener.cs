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
        [SerializeField] bool blockInputClickEvents;
        public bool BlockInputClickEvents { get => blockInputClickEvents; }

       

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
            NavigationHandler.HoldingMouseLimitReachedEvent += OnMouseHoldingLimitReachedCallback;
            NavigationHandler.MouseReleasedEvent += OnMouseReleasedCallback;
        }

        private void OnMouseReleasedCallback()
        {
            blockInputClickEvents = false;
        }

        private void OnMouseHoldingLimitReachedCallback()
        {
            blockInputClickEvents = true;
        }
        public void HandleInterierClick(InterierBase interierBase, PointerEventData eventData)
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleInterierClick(interierBase, eventData);
        }
        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData) 
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleBuildingPlaceClick(buildingPlace, eventData);
        }

        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData) 
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleEntranceClick(entrance, eventData); 
        }

        public void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleWallClick(wall, eventData);
        }

        private void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            NavigationHandler.MouseScroll(scroll);
            NavigationHandler.Swipes();
          
        }

        public void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData)=>
            sceneMaster.HandleInterierPlaceClick(interierPlaceBase, eventData);
    }
}