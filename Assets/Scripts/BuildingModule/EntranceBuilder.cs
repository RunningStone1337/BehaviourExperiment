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
            BuildWalls(newEntrance);
            RebuildNeighboursWalls(thisPlace);
            return newEntrance;
        }
        public void RebuildNeighboursWalls(BuildingPlace thisPlace)
        {
            foreach (var neigh in thisPlace.Neighbours)
                RebuildWalls(neigh);
        }

        /// <summary>
        /// Удаляет лишние стены на месте новых соединений комнат
        /// </summary>
        public static void RebuildWalls(BuildingPlace neigh)
        {
            if (neigh.IsOccuped)
            {
                RemoveExcessWalls(neigh.Entrance);
                BuildWalls(neigh.Entrance);
            }
        }
        public static void BuildWalls(Entrance newEntrance)
        {
            var storage = SceneDataStorage.Storage;
            if (NeedRightWall(newEntrance.EntrancePlace))
                newEntrance.RightWall = Instantiate(storage.RightWallPrefab, newEntrance.transform).GetComponent<Wall>();
            if (NeedLeftWall(newEntrance.EntrancePlace))
                newEntrance.LeftWall = Instantiate(storage.LeftWallPrefab, newEntrance.transform).GetComponent<Wall>();
            if (NeedUpWall(newEntrance.EntrancePlace))
                newEntrance.UpWall = Instantiate(storage.UpWallPrefab, newEntrance.transform).GetComponent<Wall>();
            if (NeedDownWall(newEntrance.EntrancePlace))
                newEntrance.DownWall = Instantiate(storage.DownWallPrefab, newEntrance.transform).GetComponent<Wall>();
        }
        static bool NeedRightWall(BuildingPlace bp) =>!bp.RightNeighbour.IsOccuped;
        static bool NeedLeftWall(BuildingPlace bp) =>!bp.LeftNeighbour.IsOccuped;
        static bool NeedUpWall(BuildingPlace bp) =>!bp.UpNeighbour.IsOccuped;
        static bool NeedDownWall(BuildingPlace bp) =>!bp.DownNeighbour.IsOccuped;

        public static void RemoveExcessWalls(Entrance entrance)
        {
            if (!NeedRightWall(entrance.EntrancePlace))
                entrance.RightWall = null;
            if (!NeedLeftWall(entrance.EntrancePlace))
                entrance.LeftWall = null;
            if (!NeedUpWall(entrance.EntrancePlace))
                entrance.UpWall = null;
            if (!NeedDownWall(entrance.EntrancePlace))
                entrance.DownWall = null;
        }
    }
}