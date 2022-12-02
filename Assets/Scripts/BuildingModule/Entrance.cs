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

        public BuildingPlace EntrancePlace { get; private set; }

        public void Initiate(BuildingPlace buildingPlace)
        {
            entranceSprite.sprite = GetValidSprite(buildingPlace);
            EntrancePlace = buildingPlace;
            EntrancePlace.Entrance = this;
        }

        public static Sprite GetValidSprite(BuildingPlace bp)
        {
            var storage = SceneDataStorage.Storage;
            if (IsLeftRightUp(bp))
                return storage.LeftRightUpRoom;
            if (IsUpDownRight(bp))
                return storage.UpDownRightRoom;
            if (IsUpDownLeft(bp))
                return storage.UpDownLeftRoom;
            if (IsLeftRightDown(bp))
                return storage.LeftRightDownRoom;
            if (IsUpRight(bp))
                return storage.UpRightRoom;
            if (IsUpLeft(bp))
                return storage.UpLeftRoom;
            if (IsUpDown(bp))
                return storage.UpDownRoom;
            if (IsLeftRight(bp))
                return storage.LeftRightRoom;
            if (IsDownRight(bp))
                return storage.DownRightRoom;
            if (IsDownLeft(bp))
                return storage.DownLeftRoom;
            if (IsRight(bp))
                return storage.RightRoom;
            if (IsLeft(bp))
                return storage.LeftRoom;
            if (IsUp(bp))
                return storage.UpRoom;
            if (IsDown(bp))
                return storage.DownRoom;
            else
                return storage.Floor;

            static bool IsLeftRightUp(BuildingPlace bp)=>
                bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;

            static bool IsUpDownRight(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;
            

            static bool IsUpDownLeft(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;
            

            static bool IsLeftRightDown(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;
            

            static bool IsUpRight(BuildingPlace bp)=>
               bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;


            static bool IsUpLeft(BuildingPlace bp)=>
                  bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;


            static bool IsUpDown(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;


            static bool IsLeftRight(BuildingPlace bp)=>
               bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;


            static bool IsDownRight(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;


            static bool IsDownLeft(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;

            static bool IsRight(BuildingPlace bp)=>
                bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && !bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;


            static bool IsLeft(BuildingPlace bp)=>
              bp.DownNeighbour.IsOccuped && !bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;


            static bool IsUp(BuildingPlace bp)=>
               bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && !bp.UpNeighbour.IsOccuped;


            static bool IsDown(BuildingPlace bp)=>
                !bp.DownNeighbour.IsOccuped && bp.LeftNeighbour.IsOccuped && bp.RightNeighbour.IsOccuped && bp.UpNeighbour.IsOccuped;

        }

        public void RebuildNeighbours()
        {
            foreach (var neigh in EntrancePlace.Neighbours)
            {
                neigh.RebuildNeighbours();
               
            }
        }

        public void ResetVisual()
        {
            entranceSprite.sprite = GetValidSprite(EntrancePlace);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleEntranceClick(this, eventData);
        }
    }
}