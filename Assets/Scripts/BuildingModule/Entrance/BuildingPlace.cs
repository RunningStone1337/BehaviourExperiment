using Common;
using InputSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public class BuildingPlace : MonoBehaviour, IPointerClickHandler, ICanBeOccuped, ICurrentStateHandler
    {

        public void OnPointerClick(PointerEventData eventData)
        {
            InputListener.Listener.HandleBuildingPlaceClick(this, eventData);
        }

        public void RemoveInvalidInterier()
        {
            if (IsOccuped)
                Entrance.RemoveInvalidInterier();
        }

        public bool TryPlaceNewEntrance(PointerEventData eventData)
        {
            return currentState.TryPlaceNewEntrance(eventData);
        }

        public bool TryRemoveExistEntrance(PointerEventData eventData)
        {
            return currentState.TryRemoveExistEntrance(eventData);
        }


        public Vector2Int Cordinates { get => coordinates; }
        public IState CurrentState
        {
            get => currentState;
            set
            {
                currentState = (BuildingPlaceState)value;
                IsOccuped = currentState is OccupedState;
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

        public FreeState FreeState { get => freeState; }
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

        public List<BuildingPlace> Neighbours { get; internal set; }
        public OccupedState OccupedState { get => occupedState; }
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


        #region Private Fields

        [SerializeField] private BoxCollider2D colldier;
        [SerializeField] private Vector2Int coordinates;
        [SerializeField] private BuildingPlaceState currentState;
        [SerializeField] private BuildingPlace downNeighbour;
        [SerializeField] private FreeState freeState;
        [SerializeField] private bool isOccuped;
        [SerializeField] private BuildingPlace leftNeighbour;
        [SerializeField] private OccupedState occupedState;
        [SerializeField] private BuildingPlace rightNeighbour;
        [SerializeField] private BuildingPlace upNeighbour;

        #endregion Private Fields


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
            Neighbours = new List<BuildingPlace>();
            coordinates = new Vector2Int((int)transform.position.x, (int)transform.position.y);
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

        public void SetState<S2>() where S2 : IState
        {
            throw new System.NotImplementedException();
        }

    }
}