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
        /// Нужна ли стена между caller и neigh НА СТОРОНЕ caller? 
        /// Расчёт на 1 Entrance
        /// </summary>
        /// <param name="caller"></param>
        /// <param name="neigh"></param>
        /// <returns></returns>
        private static bool NeedWall(Entrance caller, Entrance neigh) => 
            //соседа нет        соседа скоро не будет               сосед есть, но он от другого помещения
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
        /// Добавляет выбранный интерьер на место если какой-то выбран
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
        /// Добавляет выбранный объект интерьера если он не совпадает со старым
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
        /// Удаляет лишние стены на месте новых соединений комнат при условии, что новое помещение принадлежит
        /// той же комнате
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
        /// Удаляет интерьер или заменяет его новым в зависимости от текущего выбранного компонента.
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
            //TODO пересмотреть перестройку стен при создании
            //разграничивающи разные помещения стны нужно оставлять
            BuildNewWallsIfNeed(newEntrance);
            foreach (var neigh in newEntrance.Neighbours)
                RebuildEntrance(neigh);
            return newEntrance;
        }
    }
}