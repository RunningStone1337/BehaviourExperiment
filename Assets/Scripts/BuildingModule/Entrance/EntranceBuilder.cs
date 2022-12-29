using Common;
using System;
using UI;
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
        /// ��������� ��������� ������ ��������� ���� �� �� ��������� �� ������
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="place"></param>
        public static void AddInterierIfNewAndAvail(InterierBase inter, int oldId, InterierPlaceBase place)
        {
            var newInterierId = inter.ThisIdentifier.ID;
            place.ResetCurrentStateWithDependentPlaces(inter);
            if (IsNew(oldId, newInterierId) && inter.IsAvailForPlacing(place))
                AddInterier(inter, place);
        }

        private static bool IsNew(int oldId, int newId)=>
            oldId != newId;

        /// <summary>
        /// ������� ������ ����� �� ����� ����� ���������� ������
        /// </summary>
        public static void RebuildWalls(BuildingPlace neigh)
        {
            if (neigh.IsOccuped)
            {
                RemoveExcessWalls(neigh.Entrance);
                BuildWalls(neigh.Entrance);
            }
        }
        /// <summary>
        /// ������� �������� ��� �������� ��� ����� � ����������� �� �������� ���������� ����������.
        /// </summary>
        /// <param name="oldInterier"></param>
        /// <param name="place"></param>
        public static void ReplaceInterierOrDeleteExist(InterierBase oldInterier, InterierPlaceBase place)
        {
            var newInter = (InterierBase)SceneMaster.Master.LastSelectedViewObject;
            var oldID = oldInterier.ThisIdentifier.ID;
            RemoveInterier(oldInterier, place);
            AddInterierIfNewAndAvail(newInter, oldID, place);            
            
        }
        public static void RemoveInterier(InterierBase oldInterier,  InterierPlaceBase place)=>
            place.RemoveInterier(oldInterier);
         
        private static bool IsNew(InterierBase newInter, InterierBase oldInterier) =>
            IsNew(newInter.ThisIdentifier.ID, oldInterier.ThisIdentifier.ID);

        /// <summary>
        /// ��������� ��������� �������� �� ����� ���� �����-�� ������
        /// � ���������� �� ���������.
        /// </summary>
        /// <param name="ipb"></param>
        public static void AddInterier(InterierBase inter, InterierPlaceBase ipb)
        {
            var newEntrance = Instantiate(inter.gameObject,
                ipb.transform).GetComponent<InterierBase>();
            ipb.AddInterier(newEntrance);
            newEntrance.Initiate(ipb);
        }

        public static void BuildWalls(Entrance newEntrance)
        {
            if (NeedRightWall(newEntrance.EntrancePlace))
                newEntrance.RightWall.SetActiveState();
            if (NeedLeftWall(newEntrance.EntrancePlace))
                newEntrance.LeftWall.SetActiveState();
            if (NeedUpWall(newEntrance.EntrancePlace))
                newEntrance.UpWall.SetActiveState();
            if (NeedDownWall(newEntrance.EntrancePlace))
                newEntrance.DownWall.SetActiveState();
        }

        static bool NeedRightWall(BuildingPlace bp) =>!bp.RightNeighbour.IsOccuped;
        static bool NeedLeftWall(BuildingPlace bp) =>!bp.LeftNeighbour.IsOccuped;
        static bool NeedUpWall(BuildingPlace bp) =>!bp.UpNeighbour.IsOccuped;
        static bool NeedDownWall(BuildingPlace bp) =>!bp.DownNeighbour.IsOccuped;

        public static void RemoveExcessWalls(Entrance entrance)
        {
            if (!NeedRightWall(entrance.EntrancePlace))
                entrance.RightWall.SetInactiveState();
            if (!NeedLeftWall(entrance.EntrancePlace))
                entrance.LeftWall.SetInactiveState();
            if (!NeedUpWall(entrance.EntrancePlace))
                entrance.UpWall.SetInactiveState();
            if (!NeedDownWall(entrance.EntrancePlace))
                entrance.DownWall.SetInactiveState();
        }
    }
}