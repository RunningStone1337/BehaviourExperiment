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

        public Wall LeftWall { 
            get => leftWall;
            set
            {
                leftWall = ReplaceIfNotNull(value, leftWall);
            }
        }

        public Wall RightWall { get => rightWall;
            set
            {
                rightWall = ReplaceIfNotNull(value, rightWall);
            }
        }
        public Wall UpWall { get => upWall; set
            {
                upWall = ReplaceIfNotNull(value, upWall);
            }
        }
        public Wall DownWall { get => downWall; set
            {
                downWall = ReplaceIfNotNull(value, downWall);
            }
        }
        public BuildingPlace EntrancePlace { get; private set; }

        public void Initiate(BuildingPlace buildingPlace)
        {
            buildingPlace.CurrentState = buildingPlace.OccupedState;
            //entranceSprite.sprite = SceneDataStorage.Storage.Floor;
            //entranceSprite.sprite = GetValidSprite(buildingPlace);
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