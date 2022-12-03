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
        public Wall[] Walls {get => walls; }
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

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleEntranceClick(this, eventData);
        }
        private Wall ReplaceIfNotNull(Wall newValue, Wall existValue)
        {
            if (existValue != null)
                Destroy(existValue.gameObject);
            return newValue;
        }

    }
}