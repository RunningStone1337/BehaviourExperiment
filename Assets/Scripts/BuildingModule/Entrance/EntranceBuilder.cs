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

        private static bool NeedDownWall(BuildingPlace bp) => !bp.DownNeighbour.IsOccuped;

        private static bool NeedLeftWall(BuildingPlace bp) => !bp.LeftNeighbour.IsOccuped;

        private static bool NeedRightWall(BuildingPlace bp) => !bp.RightNeighbour.IsOccuped;

        private static bool NeedUpWall(BuildingPlace bp) => !bp.UpNeighbour.IsOccuped;

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
        /// ƒобавл€ет выбранный интерьер на место если какой-то выбран
        /// и размещение не запрещено.
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
        /// ƒобавл€ет выбранный объект интерьера если он не совпадает со старым
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

        /// <summary>
        /// ”дал€ет лишние стены на месте новых соединений комнат
        /// </summary>
        public static void RebuildWalls(BuildingPlace neigh)
        {
            if (neigh.IsOccuped)
            {
                RemoveExcessWalls(neigh.Entrance);
                BuildWalls(neigh.Entrance);
                neigh.RemoveInvalidInterier();
            }
        }

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

        public static void RemoveInterier(PlacedInterier oldInterier, InterierPlaceBase place) =>
            place.RemoveInterier(oldInterier);

        /// <summary>
        /// ”дал€ет интерьер или замен€ет его новым в зависимости от текущего выбранного компонента.
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
            BuildWalls(newEntrance);
            RebuildNeighboursWalls(thisPlace);
            return newEntrance;
        }

        public void RebuildNeighboursWalls(BuildingPlace thisPlace)
        {
            foreach (var neigh in thisPlace.Neighbours)
                RebuildWalls(neigh);
        }
    }
}