using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using InputSystem;

namespace BuildingModule
{
    public class BuildingPlace : MonoBehaviour, IPointerClickHandler
    {
        #region Public Methods

        public void OnPointerClick(PointerEventData eventData)
        {
            InputListener.Listener.HandleBuildingPlaceClick(this, eventData);
        }

        public bool TryPlaceNewEntrance(PointerEventData eventData)
        {
            return currentState.TryPlaceNewEntrance(eventData);
        }

        public bool TryRemoveExistEntrance(PointerEventData eventData)
        {
            return currentState.TryRemoveExistEntrance(eventData);
        }

        #endregion Public Methods

        #region Public Properties
        public Entrance Entrance { get; internal set; }

        public FreeState FreeState { get => freeState; }
        public bool IsOccuped { get => isOccuped; private set => isOccuped = value; }
        public BuildingPlace LeftNeighbour
        { 
            get => leftNeighbour;
            private set {
                leftNeighbour = value;
                AddIfNotNull(leftNeighbour);
            }
        }
        public BuildingPlace RightNeighbour
        { 
            get => rightNeighbour;
            private set {
                rightNeighbour = value;
                AddIfNotNull(rightNeighbour);
            }
        } 
        public BuildingPlace UpNeighbour
        { 
            get => upNeighbour;
            private set {
                upNeighbour = value;
                AddIfNotNull(upNeighbour);
            }
        }  
        public BuildingPlace DownNeighbour
        { 
            get => downNeighbour;
            private set {
                downNeighbour = value;
                AddIfNotNull(downNeighbour);
            }
        }

        public OccupedState OccupedState { get => occupedState; }
        public Vector2Int Cordinates { get => coordinates; }
        public BuildingPlaceState CurrentState
        {
            get => currentState;
            set
            {
                currentState = value;
                IsOccuped = currentState is OccupedState;
            }
        }

        public List<BuildingPlace> Neighbours { get; internal set; }
        #endregion Public Properties

        #region Private Fields
        [SerializeField] Vector2Int coordinates;
        [SerializeField] private BoxCollider2D colldier;
        [SerializeField] private BuildingPlaceState currentState;
        [SerializeField] private BuildingPlace leftNeighbour;
        [SerializeField] private BuildingPlace rightNeighbour;
        [SerializeField] private BuildingPlace upNeighbour;
        [SerializeField] private BuildingPlace downNeighbour;
        [SerializeField] private FreeState freeState;
        [SerializeField] private bool isOccuped;
        [SerializeField] private OccupedState occupedState;

        #endregion Private Fields

        #region Private Methods

        private void Awake()
        {
            Neighbours = new List<BuildingPlace>();
            coordinates = new Vector2Int((int)transform.position.x, (int)transform.position.y);
            EntranceRoot.Root.PlacesDict.Add(coordinates, this);
        }

        private void Start()
        {
            SetNeighbours();
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

        
        #endregion Private Methods
    }
}