using Common;
using UnityEngine;

namespace BuildingModule
{
    public class EntranceBuilder : MonoBehaviour
    {
        private static EntranceBuilder entranceBuilder;

        private static bool IsNew(int oldId, int newId) =>
            oldId != newId;

        private static bool IsNew(PlacedInterier newInter, PlacedInterier oldInterier) =>
            IsNew(newInter.ThisIdentifier.ID, oldInterier.ThisIdentifier.ID);

        /// <summary>
        /// ����� �� ����� ����� caller � neigh �� ������� caller? 
        /// ������ �� 1 Entrance
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="neigh"></param>
        /// <returns></returns>
        private static bool NeedWall(Entrance caller, Entrance neigh) => 
            //������ ���        ������ ����� �� �����               ����� ����, �� �� �� ������� ���������
            neigh == null || !neigh.EntrancePlace.IsOccuped || (neigh.EntrancePlace.IsOccuped && !caller.ThisRoom.Equals(neigh.ThisRoom));

        private void Awake()
        {
            if (Builder == null)
            {
                Builder = this;
                return;
            }
            Destroy(this);
        }

        public static EntranceBuilder Builder { get => entranceBuilder; private set => entranceBuilder = value; }

        /// <summary>
        /// ��������� ��������� �������� �� ����� ���� �����-�� ������
        /// � ���������� �� ���������.
        /// </summary>
        /// <param name="ipb"></param>
        public static void AddInterier(InterierBase inter, InterierPlaceBase ipb)
        {
            var newEntrance = Instantiate(inter.gameObject,
                ipb.transform).GetComponent<PlacedInterier>();
            ipb.AddInterier(newEntrance);
            newEntrance.Initiate(ipb);
        }

        /// <summary>
        /// ��������� ��������� ������ ��������� ���� �� �� ��������� �� ������
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="place"></param>
        public static void AddInterierIfNewAndAvail(PlacedInterier inter, int oldId, InterierPlaceBase place)
        {
            var newInterierId = inter.ThisIdentifier.ID;
            place.ResetCurrentStateWithDependentPlaces(inter);
            if (IsNew(oldId, newInterierId) && inter.IsAvailForPlacing(place))
                AddInterier(inter, place);
        }

        public static void BuildNewWallsIfNeed(Entrance newEntrance)
        {
            if (NeedWall(newEntrance, newEntrance.RightNeighbour))
                newEntrance.RightWall.SetActiveState();
            if (NeedWall(newEntrance, newEntrance.LeftNeighbour))
                newEntrance.LeftWall.SetActiveState();
            if (NeedWall(newEntrance, newEntrance.UpNeighbour))
                newEntrance.UpWall.SetActiveState();
            if (NeedWall(newEntrance, newEntrance.DownNeighbour))
                newEntrance.DownWall.SetActiveState();
        }

        /// <summary>
        /// ������� ������ ����� �� ����� ����� ���������� ������ ��� �������, ��� ����� ��������� �����������
        /// ��� �� �������
        /// </summary>
        public static void RebuildEntrance(Entrance entr)
        {
            if (entr)
            {
                //if (NeedWall( entr.ThisRoom.Equals(neigh.ThisRoom))
                RemoveExcessWalls(entr);
                BuildNewWallsIfNeed(entr);
                entr.RemoveInvalidInterier();
            }
        }

        public static void RemoveExcessWalls(Entrance entrance)
        {
            if (!NeedWall(entrance, entrance.RightNeighbour))
                entrance.RightWall.SetInactiveState();
            if (!NeedWall(entrance, entrance.LeftNeighbour))
                entrance.LeftWall.SetInactiveState();
            if (!NeedWall(entrance, entrance.UpNeighbour))
                entrance.UpWall.SetInactiveState();
            if (!NeedWall(entrance, entrance.DownNeighbour))
                entrance.DownWall.SetInactiveState();
        }

        public static void RemoveInterier(PlacedInterier oldInterier, InterierPlaceBase place) =>
                    place.RemoveInterier(oldInterier);

        /// <summary>
        /// ������� �������� ��� �������� ��� ����� � ����������� �� �������� ���������� ����������.
        /// </summary>
        /// <param name="oldInterier"></param>
        /// <param name="place"></param>
        public static void ReplaceInterierOrDeleteExist(PlacedInterier oldInterier, InterierPlaceBase place)
        {
            var newInter = (PlacedInterier)SceneMaster.Master.LastSelectedViewObject;
            var oldID = oldInterier.ThisIdentifier.ID;
            RemoveInterier(oldInterier, place);
            AddInterierIfNewAndAvail(newInter, oldID, place);
        }

        public Entrance BuildNewEntrance(BuildingPlace thisPlace)
        {
            var newEntrance = Instantiate(SceneDataStorage.Storage.EntrancePrefab, thisPlace.transform).GetComponent<Entrance>();
            newEntrance.Initiate(thisPlace);
            //TODO ������������ ����������� ���� ��� ��������
            //��������������� ������ ��������� ���� ����� ���������
            BuildNewWallsIfNeed(newEntrance);
            foreach (var neigh in newEntrance.Neighbours)
                RebuildEntrance(neigh);
            return newEntrance;
        }
    }
}