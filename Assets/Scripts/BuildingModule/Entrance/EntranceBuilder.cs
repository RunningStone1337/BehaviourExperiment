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
        /// ƒобавл€ет выбранный объект интерьера если он не совпадает со старым
        /// </summary>
        /// <param name="oldId"></param>
        /// <param name="place"></param>
        public static void AddInterierIfNew(int oldId, InterierPlaceBase place)
        {
            var inter = SceneMaster.Master.LastSelectedViewObject;
            var newInterierId = inter.ThisIdentifier.ID;
            if (inter != null && oldId != newInterierId)//есть активный компон
            {
                TryAddSelectedInterier(place);
                //InterierPlaceBase.ActivateAvailableInterierPlaces(inter);
            }
            //else
            //{
            //    place.SetPlaceStateAccordingInterierPlaceability(inter);
            //}
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
            }
        }
        /// <summary>
        /// ”дал€ет интерьер или замен€ет его новым в зависимости от текущего выбранного компонента.
        /// </summary>
        /// <param name="oldInterier"></param>
        /// <param name="place"></param>
        public static void ReplaceInterierOrDeleteExist(InterierBase oldInterier, InterierPlaceBase place)
        {
            var oldID = oldInterier.ThisIdentifier.ID;
            //удалить интерьер
            RemoveInterier(oldInterier, place);
            //place.CurrentState = place.AvailableForPlacingInterierPlaceState;
            //если выбран прежний, не добавл€ть ничего, иначе выбранный
            AddInterierIfNew(oldID, place);            
        }
        public static void RemoveInterier(InterierBase interierBase, InterierPlaceBase place)
        {
            place.CurrentState = place.FreeInterierPlaceState;
            Destroy(interierBase.gameObject);
            var selected = SceneMaster.Master.LastSelectedViewObject;
            place.SetPlaceStateAccordingInterierPlaceability(selected);
            if (place is MiddlePlace tp)
                tp.SetFreeStateForOtherMiddlePlaces();
        }

        /// <summary>
        /// ƒобавл€ет выбранный интерьер на место если какой-то выбран
        /// и размещение не запрещено.
        /// </summary>
        /// <param name="ipb"></param>
        public static void TryAddSelectedInterier(InterierPlaceBase ipb)
        {
            var lastSelected = SceneMaster.Master.LastSelectedViewObject;
            if (lastSelected != null)
            {
                if (lastSelected.IsAvailableForPlacing(ipb))
                {
                    var newEntrance = Instantiate(lastSelected.gameObject,
                        ipb.transform).GetComponent<InterierBase>();
                    ipb.Interier = newEntrance;
                    ipb.CurrentState = ipb.OccupedInterierPlaceState;
                }
            }
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