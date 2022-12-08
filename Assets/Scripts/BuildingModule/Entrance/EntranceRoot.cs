using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule {
    public class EntranceRoot : MonoBehaviour
    {
        public static EntranceRoot Root { 
            get 
            {
                if (entranceRoot == null)
                    entranceRoot = FindObjectOfType<EntranceRoot>();
                return entranceRoot; 
            }
            private set => entranceRoot = value; }
        public Dictionary<Vector2Int, BuildingPlace> PlacesDict { get; set; } = new Dictionary<Vector2Int, BuildingPlace>();
        public List<Entrance> Entrances { get=> entrances; private set=> entrances = value; }
        public List<Room> Rooms { get=> rooms; }
        public Transform RoomsPlace { get => roomsPlace; }

        static EntranceRoot entranceRoot;
        [SerializeField] BuildingPlace[] places;
        [SerializeField] List<Entrance> entrances;
        [SerializeField] List<Room> rooms;
        [SerializeField] Transform roomsPlace;
    }
}