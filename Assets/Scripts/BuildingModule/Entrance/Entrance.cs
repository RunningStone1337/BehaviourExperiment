using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class Entrance : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] SpriteRenderer entranceSprite;
        [SerializeField] Wall leftWall;
        [SerializeField] Wall rightWall;
        [SerializeField] Wall upWall;
        [SerializeField] Wall downWall;
        [SerializeField] Wall[] walls;
        [SerializeField] Corner ulCorner;
        [SerializeField] Corner urCorner;
        [SerializeField] Corner drCorner;
        [SerializeField] Corner dlCorner;
        [SerializeField] Corner[] corners;
        [SerializeField] Underwall leftUnderwall;
        [SerializeField] Underwall upUnderwall;
        [SerializeField] Underwall rightUnderwall;
        [SerializeField] Underwall downUnderwall;
        [SerializeField] Underwall[] underwalls;
        [SerializeField] MiddlePlace leftPlace;
        [SerializeField] MiddlePlace upPlace;
        [SerializeField] MiddlePlace rightPlace;
        [SerializeField] MiddlePlace downPlace;
        [SerializeField] MiddlePlace[] middlePlaces;
        public Wall[] Walls {get => walls; }
        public Corner[] Corners { get => corners; }
        public Underwall[] Underwalls { get => underwalls; }
        public MiddlePlace[] MiddlePlaces { get => middlePlaces; }
        public Wall LeftWall {get => leftWall;}
        public Wall RightWall { get => rightWall;}
        public Wall UpWall { get => upWall;}
        public Wall DownWall { get => downWall;}
        public BuildingPlace EntrancePlace { get; private set; }

        public void Initiate(BuildingPlace buildingPlace)
        {
            buildingPlace.CurrentState = buildingPlace.OccupedState;
            EntrancePlace = buildingPlace;
            EntrancePlace.Entrance = this;
        }
        
        //public void SetInterierPlacesCollidersState(bool v)
        //{
        //    foreach (var uw in Underwalls)
        //        uw.SetColliderEnableIfFree( v);
        //    foreach (var uw in MiddlePlaces)
        //        uw.SetColliderEnableIfFree( v);
        //    foreach (var uw in Corners)
        //        uw.SetColliderEnableIfFree( v);
        //}
        

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleEntranceClick(this, eventData);
        }
    }
}