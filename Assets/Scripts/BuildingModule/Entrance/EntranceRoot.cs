using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class EntranceRoot : MonoBehaviour
    {
        private static EntranceRoot entranceRoot;
        [SerializeField] private List<Entrance> entrances;
        [SerializeField] private TemplateBuilder  templateBuilder;
        [SerializeField] private BuildingPlace[] places;
        [SerializeField] private List<Room> rooms;
        [SerializeField] private Transform roomsPlace;
        public static EntranceRoot Root
        {
            get
            {
                if (entranceRoot == null)
                    entranceRoot = FindObjectOfType<EntranceRoot>();
                return entranceRoot;
            }
            private set => entranceRoot = value;
        }

        public List<Entrance> Entrances { get => entrances; private set => entrances = value; }
        public Dictionary<Vector2Int, BuildingPlace> PlacesDict { get; set; } = new Dictionary<Vector2Int, BuildingPlace>();
        public List<Room> Rooms { get => rooms; }
        public Transform RoomsPlace { get => roomsPlace; }
    }
}