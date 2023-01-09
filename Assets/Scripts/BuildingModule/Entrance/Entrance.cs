using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static BuildingModule.DirectionUtils;

namespace BuildingModule
{
    public enum Direction
    {
        Up, Down, Right, Left
    }

    public class Entrance : MonoBehaviour, IPointerClickHandler, IVisualEffectRoutineHandler
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

        [Space]
        [SerializeField] private Entrance downNeighbour;

        [SerializeField] private Entrance leftNeighbour;
        [SerializeField] private List<Entrance> neighbours;
        [SerializeField] private Entrance rightNeighbour;
        [SerializeField] private Entrance upNeighbour;
        public Entrance DownNeighbour { get => downNeighbour; }
        public Entrance LeftNeighbour { get => leftNeighbour; }
        public Entrance RightNeighbour { get => rightNeighbour; }
        public Entrance UpNeighbour { get => upNeighbour; }

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

        private void Awake()
        {
            EntranceRoot.Root.Entrances.Add(this);
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
            var util = new RoomEditingUtil(this);
            return util.FindRoomOrCreateNew();
        }

        private bool HavePassageOnDirection(Direction mainDirection, Entrance mainDirectionNeighbour, Entrance secondaryDirection1,
                    Entrance secondaryDirection2)
        {
            Direction[] directions = GetAdditionalDirections(mainDirection);
            if (IsPassage(mainDirection) &&
                            mainDirectionNeighbour.ThisRoom == ThisRoom &&
                            (IsPassage(directions[0]) || IsPassage(directions[1]) || IsPassage(directions[2])))//проход есть
            {
                //провер€ем соседей по сторонам от главного направлени€
                if (secondaryDirection1 && !secondaryDirection1.IsPassage(mainDirection))//он есть
                    return true;
                else if (secondaryDirection2 && !secondaryDirection2.IsPassage(mainDirection))
                    return true;
            }
            return default;
        }

        /// <summary>
        /// ≈сть ли проход от вызывающего в указанном направлении
        /// </summary>
        /// <param name="directionFormCaller">Ќаправление, где находитс€ провер€емый сосед</param>
        /// <returns></returns>
        private bool IsPassage(Direction directionFormCaller)
        {
            return directionFormCaller switch
            {
                Direction.Up => UpWall.CurrentState is InactiveState && UpNeighbour?.DownWall.CurrentState is InactiveState,
                Direction.Down => DownWall.CurrentState is InactiveState && downNeighbour?.UpWall.CurrentState is InactiveState,
                Direction.Right => RightWall.CurrentState is InactiveState && RightNeighbour?.LeftWall.CurrentState is InactiveState,
                Direction.Left => LeftWall.CurrentState is InactiveState && LeftNeighbour?.RightWall.CurrentState is InactiveState,
                _ => throw new Exception($"Ќеизвестное направление {directionFormCaller}"),
            };
        }

        private void OnDestroy()
        {
            EntranceRoot.Root.Entrances.Remove(this);
            foreach (var n in neighbours)
                n.neighbours.Remove(this);
            ThisRoom.ThisRoomEntrances.Remove(this);
        }

        private void Start()
        {
            foreach (var n in neighbours)
                n.FindNeighbours();
        }

        public Room ThisRoom
        {
            get => thisRoom; set
            {
                ThisRoom.ThisRoomEntrances.Remove(this);
                thisRoom = value;
                ThisRoom.ThisRoomEntrances.Add(this);
            }
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

        public void Initiate(BuildingPlace buildingPlace)
        {
            buildingPlace.CurrentState = buildingPlace.OccupedState;
            EntrancePlace = buildingPlace;
            EntrancePlace.Entrance = this;
            neighbours = FindNeighbours();
            thisRoom = FindRoomOrCreateNew();
            thisRoom.ThisRoomEntrances.Add(this);
        }

        /// <summary>
        /// Ќаходитс€ ли комната на веро€тном месте разделени€?
        /// true если есть проход со стенами хот€ бы с одной стороны от главного направлени€.
        /// </summary>
        /// <returns></returns>
        public bool IsOnBoard(out Direction boardDirection)
        {
            boardDirection = default;
            if (HavePassageOnDirection(Direction.Up, UpNeighbour, LeftNeighbour, RightNeighbour))
            {
                boardDirection = Direction.Up;
                return true;
            }
            if (HavePassageOnDirection(Direction.Down, DownNeighbour, LeftNeighbour, RightNeighbour))
            {
                boardDirection = Direction.Down;
                return true;
            }
            if (HavePassageOnDirection(Direction.Left, LeftNeighbour, UpNeighbour, DownNeighbour))
            {
                boardDirection = Direction.Left;
                return true;
            }
            if (HavePassageOnDirection(Direction.Right, RightNeighbour, UpNeighbour, DownNeighbour))
            {
                boardDirection = Direction.Right;
                return true;
            }
            return default;
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
            yield return VisualEffectsProvider.ShiningEffect(baseColor, ThisRoom.Role.RoleColor, entranceSprite, step,
                () => SceneMaster.Master.CurrentState is EntranceRoleEditingState || SceneMaster.Master.CurrentState is RoomSplittingState);
        }
    }
}