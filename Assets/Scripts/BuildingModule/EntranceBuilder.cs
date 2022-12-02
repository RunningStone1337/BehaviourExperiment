using Common;
using System;
using UnityEngine;

namespace BuildingModule
{
    public class EntranceBuilder : MonoBehaviour
    {
        static EntranceBuilder entranceBuilder;
        public static EntranceBuilder Builder { get => entranceBuilder; private set => entranceBuilder = value; }
        private void Awake()
        {
            if (Builder == null)
            {
                Builder = this;
                return;
            }
            Destroy(this);
        }

        public Entrance BuildNewEntrance(BuildingPlace thisPlace)
        {
            var newEntrance = Instantiate(SceneDataStorage.Storage.EntrancePrefab, thisPlace.transform).GetComponent<Entrance>();
            newEntrance.Initiate(thisPlace);
            thisPlace.CurrentState = thisPlace.OccupedState;
            newEntrance.RebuildNeighbours();
            return newEntrance;
        }
    }
}