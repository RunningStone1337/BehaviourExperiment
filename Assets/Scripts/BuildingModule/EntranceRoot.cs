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

        static EntranceRoot entranceRoot;
        [SerializeField] BuildingPlace[] places;
        private void Awake()
        {
            if (Root == null)
            {
                Root = this;
                return;
            }
            Destroy(this);
        }
    }
}