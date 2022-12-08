using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.EventSystems;
using System.Linq;

namespace BuildingModule
{
    public class Entrance : MonoBehaviour, IPointerClickHandler, IVisualEffectRoutineHandler
    {
        [SerializeField] SpriteRenderer entranceSprite;
        [SerializeField] [Range(0f, 1f)] float step = 0.005f;
        [Space]
        [SerializeField] Wall leftWall;
        [SerializeField] Wall rightWall;
        [SerializeField] Wall upWall;
        [SerializeField] Wall downWall;
        [SerializeField] Wall[] walls;
        [SerializeField] Corner ulCorner;
        [SerializeField] Corner urCorner;

      

        [SerializeField] Corner drCorner;
        [SerializeField] Corner dlCorner;
        [SerializeField] Corner[] corners;
        [SerializeField] Underwall leftUnderwall;
        [SerializeField] Underwall upUnderwall;
        [SerializeField] Underwall rightUnderwall;
        [SerializeField] Underwall downUnderwall;
        [SerializeField] Underwall[] underwalls;
        [SerializeField] MiddlePlace leftPlace;
        [SerializeField] MiddlePlace upPlace;
        [SerializeField] MiddlePlace rightPlace;
        [SerializeField] MiddlePlace downPlace;
        [SerializeField] MiddlePlace[] middlePlaces;
        [Space]
        [SerializeField] Room thisRoom;
        [Space]
        [SerializeField] List<Entrance> neighbours;
        [SerializeField] Entrance upNeighbour;
        [SerializeField] Entrance rightNeighbour;
        [SerializeField] Entrance downNeighbour;
        [SerializeField] Entrance leftNeighbour;

        Coroutine routine;
        public Wall[] Walls {get => walls; }
        public List<Entrance> Neighbours { get => neighbours; }
        public Room ThisRoom { get => thisRoom; }
        public Corner[] Corners { get => corners; }
        public Underwall[] Underwalls { get => underwalls; }
        public MiddlePlace[] MiddlePlaces { get => middlePlaces; }
        public Wall LeftWall {get => leftWall;}
        public Wall RightWall { get => rightWall;}
        public Wall UpWall { get => upWall;}
        public Wall DownWall { get => downWall;}
        public BuildingPlace EntrancePlace { get; private set; }
        public Coroutine Routine { get => routine; set => routine = value; }
        public Entrance UpNeighbour { get => upNeighbour; }
        public Entrance RightNeighbour { get => rightNeighbour; }
        public Entrance LeftNeighbour { get => leftNeighbour; }
        public Entrance DownNeighbour { get => downNeighbour; }

        public void Initiate(BuildingPlace buildingPlace)
        {
            buildingPlace.CurrentState = buildingPlace.OccupedState;
            EntrancePlace = buildingPlace;
            EntrancePlace.Entrance = this;
            neighbours = FindNeighbours();
            thisRoom = FindRoomOrCreateNew();
            thisRoom.ThisRoomEntrances.Add(this);
        }
        public void TrySeparateRoom()
        {
            ///условия разделения комнаты:
            ///1)от этого места в одну из 4х сторон
            ///в зависимости от ориентации
            if (IsOnBoard())
            {

            }
        }

        public bool IsOnBoard()
        {
            return default;
        }
        public List<Entrance> FindNeighbours()
        {
            List<Entrance> neighs = new List<Entrance>();
            upNeighbour = FindNeighbour(neighs, new Vector2Int(0, 2));
            rightNeighbour = FindNeighbour(neighs, new Vector2Int(2, 0));
            downNeighbour = FindNeighbour(neighs, new Vector2Int(0, -2));
            leftNeighbour = FindNeighbour(neighs, new Vector2Int(-2, 0));
            return neighs;
        }
        /// <summary>
        /// Возвращает лист Entrance, начиная с этого, которые принадлежат текущей комнате кроме,
        /// разделяя по exceptionEntrance
        /// </summary>
        /// <param name="exceptionEntrance"></param>
        /// <returns></returns>
        //public List<Entrance> GetCurrentRoomEntrancesExcept(Entrance exceptionEntrance)
        //{
        //    List<Entrance> res = new List<Entrance>();
        //    foreach (var n in Neighbours)
        //    {
        //        if (n != exceptionEntrance)
        //        {
        //            res.Add(n);
        //            res.AddRange(n.GetCurrentRoomEntrancesExcept(exceptionEntrance));
        //        }
        //    }
        //    return res;
        //}
        public bool VerticalConnection()
        {
            return upNeighbour != null && downNeighbour != null;
        } 
        public bool HorizontalConnection()
        {
            return leftNeighbour != null && rightNeighbour != null;
        }
        private Entrance FindNeighbour(List<Entrance> neighs, Vector2Int offset)
        {
            var coords = EntrancePlace.Cordinates + offset;
            var entr = EntranceRoot.Root.PlacesDict[coords].Entrance;
            if (entr != null)
            {
                if (!neighs.Contains(entr))
                    neighs.Add(entr);
                return entr;
            }
            return default;
        }

        private Room FindRoomOrCreateNew()
        {
            ///смотрим соседей, если их нет - создаём новую комнату
            if (Neighbours.Count == 0)
                return EntranceRoot.Root.RoomsPlace.gameObject.AddComponent<Room>();
            ///отсекаем тех соседей, между которыми есть стены.
            var potentialRooms = new List<Room>();
            foreach (var n in Neighbours)
            {
                if (!n.HasWallBetween(this) && !HasWallBetween(n))
                {
                    if (!potentialRooms.Contains(n.ThisRoom))
                        potentialRooms.Add(n.ThisRoom);
                }
            }
            ///смотрим к каким комнатам они принадлежат.
            if (potentialRooms.Count > 1)
            {
                return potentialRooms.OrderBy(x => x.ThisRoomEntrances.Count).Last();
            }
            else
                return potentialRooms[0];
            ///между остальными выбираем наибольшее и присасываемся к нему.
            ///дополнительные ограничения?
        }

        private bool HasWallBetween(Entrance neigh)
        {
            if (neigh == upNeighbour)
            {
                if (UpWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == rightNeighbour)
            {
                if (RightWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == downNeighbour)
            {
                if (DownWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == leftNeighbour)
            {
                if (LeftWall.CurrentState is ActiveState)
                    return true;
            }
            return false;
        }

        private void Awake()
        {
            EntranceRoot.Root.Entrances.Add(this);
        }
        private void Start()
        {
            foreach (var n in neighbours)
                n.FindNeighbours();
        }
        private void OnDestroy()
        {
            EntranceRoot.Root.Entrances.Remove(this);
            foreach (var n in neighbours)
                n.neighbours.Remove(this);
            ThisRoom.ThisRoomEntrances.Remove(this);
            //if (ThisRemoveBreakRoom())
            //{
            //    ThisRoom.HandleRoomSeparation(this);
            //}
        }

        private bool ThisRemoveBreakRoom()
        {
            //не предусмотрено соединение комнаты крестом
            if (WasLinked(upNeighbour, downNeighbour, rightNeighbour, leftNeighbour) 
                || WasLinked(rightNeighbour, leftNeighbour, upNeighbour, downNeighbour))
                return true;
            return false;
        }

        private bool WasLinked(Entrance pair1Entr1, Entrance pair1entr2, Entrance pair2entr1, Entrance pair2entr2)
        {
            //условие соседства
            var neighCondition = pair1Entr1 == null && pair1entr2 == null && pair2entr1 != null && pair2entr2 != null;
            if (neighCondition)
            {
                //условие одинаковой комнаты
                var roomCondition = pair2entr1.ThisRoom == pair2entr2.ThisRoom;
                if (roomCondition)
                    return true;
            }
            return default;
        }

        private bool WasHorizintallyLinked()
        {
            return rightNeighbour != null && leftNeighbour != null && upNeighbour == null && downNeighbour == null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleEntranceClick(this, eventData);
        }

        public IEnumerator VisualEffectRoutine()
        {
            var baseColor = new Color(1, 1, 1, 1);
            yield return VisualEffectsProvider.ShiningEffect(baseColor, ThisRoom.Role.RoleColor, entranceSprite, step,
                () => SceneMaster.Master.CurrentState is EntranceRoleEditingState);
        }

        public void StartRoutine()
        {
            if (Routine != null)
                StopCoroutine(Routine);
            Routine = StartCoroutine(VisualEffectRoutine());
        }
    }
}