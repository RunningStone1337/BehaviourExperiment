using BehaviourModel;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public enum Direction
    {
        Up, Down, Right, Left
    }

    public class Entrance : MonoBehaviour, IPointerClickHandler, IVisualEffectRoutineHandler, ICurrentRoomHandler
    {
        #region corners

        [SerializeField] private Corner[] corners;
        [SerializeField] private Corner dlCorner;
        [SerializeField] private Corner drCorner;
        [SerializeField] private Corner ulCorner;
        [SerializeField] private Corner urCorner;
        public Corner[] Corners { get => corners; }

        #endregion corners

        #region middles

        [Space]
        [SerializeField] private MiddlePlace downPlace;

        [SerializeField] private MiddlePlace leftPlace;
        [SerializeField] private MiddlePlace[] middlePlaces;
        [SerializeField] private MiddlePlace rightPlace;
        [SerializeField] private MiddlePlace upPlace;
        public MiddlePlace[] MiddlePlaces { get => middlePlaces; }

        #endregion middles

        #region underwalls

        [Space]
        [SerializeField] private Underwall downUnderwall;

        [SerializeField] private Underwall leftUnderwall;
        [SerializeField] private Underwall rightUnderwall;
        [SerializeField] private Underwall[] underwalls;
        [SerializeField] private Underwall upUnderwall;
        public Underwall[] Underwalls { get => underwalls; }

        #endregion underwalls

        #region neighbours

        [SerializeField] private Entrance downNeighbour;
        [SerializeField] private Entrance leftNeighbour;
        [Space]
        [SerializeField] private List<Entrance> neighbours;

        [SerializeField] private Entrance rightNeighbour;
        [SerializeField] private Entrance upNeighbour;
        public Entrance DownNeighbour
        {
            get => downNeighbour;
            set
            {
                if (downNeighbour != null)
                {
                    Neighbours.Remove(downNeighbour);
                    Neighbours.Add(value);
                }
                downNeighbour = value;
            }
        }

        public Entrance LeftNeighbour
        {
            get => leftNeighbour;
            set
            {
                if (leftNeighbour != null)
                {
                    Neighbours.Remove(leftNeighbour);
                    Neighbours.Add(value);
                }
                leftNeighbour = value;
            }
        }

        public Entrance RightNeighbour
        {
            get => rightNeighbour;
            set
            {
                if (rightNeighbour != null)
                {
                    Neighbours.Remove(rightNeighbour);
                    Neighbours.Add(value);
                }
                rightNeighbour = value;
            }
        }

        public Entrance UpNeighbour
        {
            get => upNeighbour;
            set
            {
                if (upNeighbour != null)
                {
                    Neighbours.Remove(upNeighbour);
                    Neighbours.Add(value);
                }
                upNeighbour = value;
            }
        }

        #endregion neighbours

        #region walls

        [Space]
        [SerializeField] private Wall downWall;

        [SerializeField] private Wall leftWall;
        [SerializeField] private Wall rightWall;
        [SerializeField] private Wall upWall;
        [SerializeField] private Wall[] walls;
        public Wall DownWall { get => downWall; }
        public Wall LeftWall { get => leftWall; }
        public Wall RightWall { get => rightWall; }
        public Wall UpWall { get => upWall; }
        public Wall[] Walls => walls;

        #endregion walls

        #region common

        [SerializeField] private SpriteRenderer entranceSprite;
        [SerializeField] private List<InterierPlaceBase> interierPlaces;
        private Coroutine routine;
        [SerializeField] [Range(0f, 1f)] private float step = 0.005f;
        [SerializeField] private Room thisRoom;
        public BuildingPlace EntrancePlace { get; private set; }
        public List<InterierPlaceBase> InterierPlaces => interierPlaces;
        public List<Entrance> Neighbours { get => neighbours; }

        public Coroutine Routine { get => routine; set => routine = value; }

        #endregion common
        private Entrance FindNeighbour(List<Entrance> neighs, Vector2Int offset)
        {
            var coords = EntrancePlace.Coordinates + offset;
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
            var util = new RoomEditingUtil(this);
            return util.FindRoomOrCreateNew();
        }

        /// <summary>
        /// ≈сть ли проход между помещени€ми в указанном направлении?
        /// </summary>
        /// <param name="mainDirNeighbour">—осед с провер€емого направлени€</param>
        /// <param name="leftToMainDirNeigh">ѕомещение с одной из сторон по соседству этим и главным соседом</param>
        /// <param name="rightToMainDirNeigh">ѕомещение с одной из сторон по соседству этим и главным соседом</param>
        /// <param name="thisLeftByDirWall">Ћева€ стена относительно отдел€емого помещени€</param>
        /// <param name="thisRightByDirWall">ѕрава€ стена относительно отдел€емого помещени€</param>
        /// <param name="leftToLeftMDNeighWall">Ћева€ стена относительно направлени€ главного соседа leftToMainDirNeigh</param>
        /// <param name="rightToRightMDNeighWall">ѕрава€ стена относительно направлени€ главного соседа rightToMainDirNeigh</param>
        /// <returns></returns>
        private bool HavePassageOnDirection(Entrance mainDirNeighbour, Entrance leftToMainDirNeigh, Entrance rightToMainDirNeigh,
            Wall thisLeftByDirWall, Wall thisRightByDirWall, Wall leftToLeftMDNeighWall, Wall rightToRightMDNeighWall)
        {
            if (mainDirNeighbour)
            {
                var isPassable = IsPassage(mainDirNeighbour);
                var sameRoom = mainDirNeighbour.CurrentRoom == CurrentRoom;
                if (isPassable && sameRoom)
                {
                    //хот€ бы 1 сосед со стороны от главного направлени€ дл€ mainDirectionNeighbour
                    if (leftToMainDirNeigh)
                    {
                        var secEntrPassage1 = mainDirNeighbour.IsPassage(leftToMainDirNeigh) &&
                            HasWallOnCallerOrNeighSide(thisLeftByDirWall, leftToLeftMDNeighWall);
                        if (secEntrPassage1) return true;
                    }
                    if (rightToMainDirNeigh)
                    {
                        var secEntrPassage2 = mainDirNeighbour.IsPassage(rightToMainDirNeigh) &&
                            HasWallOnCallerOrNeighSide(rightToRightMDNeighWall, thisRightByDirWall);
                        if (secEntrPassage2) return true;
                    }
                }
            }
            return default;

            static bool HasWallOnCallerOrNeighSide(Wall thisLeftByDirWall, Wall leftToLeftMDNeighWall) =>
                leftToLeftMDNeighWall.CurrentState is ActiveState || thisLeftByDirWall.CurrentState is ActiveState;
        }

        /// <summary>
        /// ≈сть ли проход от вызывающего в указанном направлении
        /// </summary>
        /// <param name="directionFormCaller">Ќаправление, где находитс€ провер€емый сосед</param>
        /// <returns></returns>
        private bool IsPassage(Entrance neighbour)
        {
            if (neighbour && Neighbours.Contains(neighbour))
            {
                if (neighbour.Equals(UpNeighbour))
                    return UpWall.CurrentState is InactiveState && neighbour.DownWall.CurrentState is InactiveState;
                if (neighbour.Equals(DownNeighbour))
                    return DownWall.CurrentState is InactiveState && neighbour.UpWall.CurrentState is InactiveState;
                if (neighbour.Equals(RightNeighbour))
                    return RightWall.CurrentState is InactiveState && neighbour.LeftWall.CurrentState is InactiveState;
                if (neighbour.Equals(LeftNeighbour))
                    return LeftWall.CurrentState is InactiveState && neighbour.RightWall.CurrentState is InactiveState;
            }
            return default;
        }

        private void OnDestroy()
        {
            EntranceRoot.Root.Entrances.Remove(this);
            foreach (var n in neighbours)
                n.neighbours.Remove(this);
            CurrentRoom.RemoveEntrance(this);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            ResetCurrentRoomIfAgent<PupilAgent>(collision);
            ResetCurrentRoomIfAgent<TeacherAgent>(collision);
            
        }

        private void ResetCurrentRoomIfAgent<T>(Collider2D collision)
            where T:SchoolAgentBase<T>
        {
            if (collision.TryGetComponent(out T agent))
            {
                Debug.Log("Entrance entered!");
                agent.AgentEnvironment.CurrentRoom = CurrentRoom;
            }
        }
    
        public int NeighboursCount => Neighbours.Count;
        public Room CurrentRoom
        {
            get => thisRoom;
            set
            {
                CurrentRoom.RemoveEntrance(this);
                thisRoom = value;
                CurrentRoom.AddEntrance(this);
            }
        }

        /// <summary>
        /// Ќаходитс€ ли комната на веро€тном месте разделени€?
        /// true если есть проход со стенами хот€ бы с одной стороны от главного направлени€.
        /// </summary>
        /// <returns></returns>
        public bool CanBeSeparated(out Direction boardDirection)
        {
            boardDirection = default;
            var mainNeigh = UpNeighbour;
            var firstToMainN = NullCheckShortcutLeft(mainNeigh);
            var secondToMainN = NullCheckShortcutRight(mainNeigh);
            if (HavePassageOnDirection(mainNeigh, firstToMainN, secondToMainN, LeftWall, RightWall,
                NullCheckShortcutDownWall(firstToMainN), NullCheckShortcutDownWall(secondToMainN)))
            {
                boardDirection = Direction.Up;
                return true;
            }
            mainNeigh = DownNeighbour;
            firstToMainN = NullCheckShortcutLeft(mainNeigh);
            secondToMainN = NullCheckShortcutRight(mainNeigh);
            if (HavePassageOnDirection(mainNeigh, firstToMainN, secondToMainN, RightWall, LeftWall,
                 NullCheckShortcutUpWall(firstToMainN), NullCheckShortcutUpWall(secondToMainN)))
            {
                boardDirection = Direction.Down;
                return true;
            }
            mainNeigh = LeftNeighbour;
            firstToMainN = NullCheckShortcutUp(mainNeigh);
            secondToMainN = NullCheckShortcutDown(mainNeigh);
            if (HavePassageOnDirection(mainNeigh, firstToMainN, secondToMainN, UpWall, DownWall,
                 NullCheckShortcutRightWall(firstToMainN), NullCheckShortcutRightWall(secondToMainN)))
            {
                boardDirection = Direction.Left;
                return true;
            }
            mainNeigh = RightNeighbour;
            firstToMainN = NullCheckShortcutUp(mainNeigh);
            secondToMainN = NullCheckShortcutDown(mainNeigh);
            if (HavePassageOnDirection(mainNeigh, firstToMainN, secondToMainN, DownWall, UpWall,
                 NullCheckShortcutLeftWall(firstToMainN), NullCheckShortcutLeftWall(secondToMainN)))
            {
                boardDirection = Direction.Right;
                return true;
            }
            return default;

            Entrance NullCheckShortcutUp(Entrance e) => e != null ? e.UpNeighbour : null;
            Entrance NullCheckShortcutDown(Entrance e) => e != null ? e.DownNeighbour : null;
            Entrance NullCheckShortcutLeft(Entrance e) => e != null ? e.LeftNeighbour : null;
            Entrance NullCheckShortcutRight(Entrance e) => e != null ? e.RightNeighbour : null;

            Wall NullCheckShortcutUpWall(Entrance e) => e != null ? e.UpWall : null;
            Wall NullCheckShortcutDownWall(Entrance e) => e != null ? e.DownWall : null;
            Wall NullCheckShortcutLeftWall(Entrance e) => e != null ? e.LeftWall : null;
            Wall NullCheckShortcutRightWall(Entrance e) => e != null ? e.RightWall : null;
        }

        public List<Entrance> FindNeighbours()
        {
            List<Entrance> neighs = new List<Entrance>();
            UpNeighbour = FindNeighbour(neighs, new Vector2Int(0, 2));
            RightNeighbour = FindNeighbour(neighs, new Vector2Int(2, 0));
            DownNeighbour = FindNeighbour(neighs, new Vector2Int(0, -2));
            LeftNeighbour = FindNeighbour(neighs, new Vector2Int(-2, 0));
            return neighs;
        }

        public Entrance GetNeighbourFromDirection(Direction d)
        {
            return d switch
            {
                Direction.Up => UpNeighbour,
                Direction.Down => DownNeighbour,
                Direction.Right => RightNeighbour,
                Direction.Left => LeftNeighbour,
                _ => throw new Exception($"Ќеизвестное направление {d}"),
            };
        }

        /// <summary>
        /// ≈сть ли здесь активна€ стена по направлению к neigh
        /// </summary>
        /// <param name="neigh"></param>
        /// <returns></returns>
        public bool HasWallBetween(Entrance neigh)
        {
            if (neigh == UpNeighbour)
            {
                if (UpWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == RightNeighbour)
            {
                if (RightWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == DownNeighbour)
            {
                if (DownWall.CurrentState is ActiveState)
                    return true;
            }
            else if (neigh == LeftNeighbour)
            {
                if (LeftWall.CurrentState is ActiveState)
                    return true;
            }
            return false;
        }

        public void Initiate(BuildingPlace buildingPlace)
        {
            buildingPlace.CurrentState = buildingPlace.OccupedState;
            EntrancePlace = buildingPlace;
            EntrancePlace.Entrance = this;
            EntranceRoot.Root.Entrances.Add(this);
            neighbours = FindNeighbours();
            foreach (var n in neighbours)
                n.StartFindNeighbours();
            thisRoom = FindRoomOrCreateNew();
            thisRoom.AddEntrance(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleEntranceClick(this, eventData);
        }

        /// <summary>
        /// ”дал€ет интерьеры, которые больше не могут располагатьс€ из-за изменившихс€ условий
        /// </summary>
        public void RemoveInvalidInterier()
        {
            foreach (var ip in InterierPlaces)
            {
                if (ip is IDependentFromChanges dep)
                    dep.ResetIfConditionsChanged(null);
            }
        }

        /// <summary>
        /// ”дал€ет интерьеры, которые не могут располашатьс€ из-за изменени€ условий здесь
        /// и у соседей.
        /// </summary>
        public void RemoveInvalidInterierAndFromNeighbours()
        {
            RemoveInvalidInterier();
            foreach (var n in Neighbours)
                n.RemoveInvalidInterier();
        }

        public void StartFindNeighbours()
        {
            neighbours = FindNeighbours();
        }

        public void StartRoutine()
        {
            if (Routine != null)
                StopCoroutine(Routine);
            Routine = StartCoroutine(VisualEffectRoutine());
        }

        public bool TrySeparateRoom()
        {
            var util = new RoomEditingUtil(this);
            return util.TrySeparateRoom();
        }

        public IEnumerator VisualEffectRoutine()
        {
            var baseColor = new Color(1, 1, 1, 1);
            yield return VisualEffectsProvider.ShiningEffect(baseColor, CurrentRoom.Role.RoleColor, entranceSprite, step,
                () => SceneMaster.Master.CurrentState is EntranceRoleEditingState || SceneMaster.Master.CurrentState is RoomSplittingState);
        }
    }
}