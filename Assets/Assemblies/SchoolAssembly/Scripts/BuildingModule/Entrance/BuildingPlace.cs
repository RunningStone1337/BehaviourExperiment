using Common;
using InputSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class BuildingPlace : MonoBehaviour, IPointerClickHandler, ICanBeOccuped, ICurrentStateHandler<BuildingPlaceState>
    {
        [SerializeField] private BoxCollider2D colldier;
        [SerializeField] private Vector2Int coordinates;
        [SerializeField] private BuildingPlaceState currentState;
        [SerializeField] private FreeBuildPlaceState freeState;
        [SerializeField] private bool isOccuped;
        [SerializeField] private OccupedBuildPlaceState occupedState;

        #region neighs

        [SerializeField] private List<BuildingPlace> neighbours;
        [SerializeField] private BuildingPlace downNeighbour;
        [SerializeField] private BuildingPlace leftNeighbour;
        [SerializeField] private BuildingPlace rightNeighbour;
        [SerializeField] private BuildingPlace upNeighbour;

        #endregion neighs

        private void AddIfNotNull(BuildingPlace n)
        {
            if (n != null)
                Neighbours.Add(n);
        }

        private BuildingPlace AssignIfExists(Vector2Int coords)
        {
            var root = EntranceRoot.Root;
            return root.PlacesDict.ContainsKey(coords) ? root.PlacesDict[coords] : default;
        }

        private void Awake()
        {
            neighbours = new List<BuildingPlace>();
            Coordinates = new Vector2Int(Mathf.RoundToInt(transform.position.x), (Mathf.RoundToInt(transform.position.y)));
            EntranceRoot.Root.PlacesDict.Add(coordinates, this);
        }

        private void SetNeighbours()
        {
            var coords = coordinates + new Vector2Int(-2, 0);
            LeftNeighbour = AssignIfExists(coords);
            coords = coordinates + new Vector2Int(+2, 0);
            RightNeighbour = AssignIfExists(coords);
            coords = coordinates + new Vector2Int(0, -2);
            DownNeighbour = AssignIfExists(coords);
            coords = coordinates + new Vector2Int(0, +2);
            UpNeighbour = AssignIfExists(coords);
        }

        private void Start()
        {
            SetNeighbours();
        }

        public Vector2Int Coordinates { get => coordinates; private set => coordinates = value; }

        public BuildingPlaceState CurrentState
        {
            get => currentState;
            set
            {
                currentState = (BuildingPlaceState)value;
                IsOccuped = currentState is OccupedBuildPlaceState;
            }
        }

        public BuildingPlace DownNeighbour
        {
            get => downNeighbour;
            private set
            {
                downNeighbour = value;
                AddIfNotNull(downNeighbour);
            }
        }

        public Entrance Entrance { get; internal set; }

        public FreeBuildPlaceState FreeState { get => freeState; }

        public bool IsOccuped { get => isOccuped; set => isOccuped = value; }

        public BuildingPlace LeftNeighbour
        {
            get => leftNeighbour;
            private set
            {
                leftNeighbour = value;
                AddIfNotNull(leftNeighbour);
            }
        }

        public List<BuildingPlace> Neighbours => neighbours;

        public OccupedBuildPlaceState OccupedState { get => occupedState; }

        public BuildingPlace RightNeighbour
        {
            get => rightNeighbour;
            private set
            {
                rightNeighbour = value;
                AddIfNotNull(rightNeighbour);
            }
        }

        public BuildingPlace UpNeighbour
        {
            get => upNeighbour;
            private set
            {
                upNeighbour = value;
                AddIfNotNull(upNeighbour);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            InputListener.Listener.HandleBuildingPlaceClick(this, eventData);
        }

        public void RemoveInvalidInterier()
        {
            if (IsOccuped)
                Entrance.RemoveInvalidInterier();
        }

        public void SetState<S2>() where S2 : BuildingPlaceState
        {
            throw new System.NotImplementedException();
        }

        public bool TryPlaceNewEntrance(PointerEventData eventData)
        {
            return currentState.TryPlaceNewEntrance(eventData);
        }

        public bool TryRemoveExistEntrance(PointerEventData eventData)
        {
            return currentState.TryRemoveExistEntrance(eventData);
        }
    }
}