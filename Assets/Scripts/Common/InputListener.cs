using BuildingModule;
using Common;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        #region Public Properties

        public static InputListener Listener { get => listener; private set => listener = value; }
        public bool BlockInputClickEvents { get => blockInputClickEvents; }
        public NavigationHandler NavigationHandler { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public void HandleBuildingPlaceClick(BuildingPlace buildingPlace, PointerEventData eventData)
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleBuildingPlaceClick(buildingPlace, eventData);
        }

        public void HandleEntranceClick(Entrance entrance, PointerEventData eventData)
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleEntranceClick(entrance, eventData);
        }

        public void HandleInterierClick<T>(T interierBase, PointerEventData eventData) where T : PlacedInterier
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleInterierClick(interierBase, eventData);
        }

        public void HandleInterierPlaceClick(InterierPlaceBase interierPlaceBase, PointerEventData eventData) =>
            sceneMaster.HandleInterierPlaceClick(interierPlaceBase, eventData);

        public void HandleUIScreenPointerDown(object sender, PointerEventData eventData)
        {
            NavigationHandler.FreezeSwipes = true;
        }

        public void HandleUIScreenPointerUp(object sender, PointerEventData eventData)
        {
            NavigationHandler.FreezeSwipes = false;
        }

        public void HandleWallClick(Wall wall, PointerEventData eventData)
        {
            if (!BlockInputClickEvents)
                sceneMaster.HandleWallClick(wall, eventData);
        }

        #endregion Public Methods

        #region Private Fields

        private static InputListener listener;
        [SerializeField] private bool blockInputClickEvents;
        [SerializeField] private SceneMaster sceneMaster;

        #endregion Private Fields

        #region Private Methods

        private void Awake()
        {
            if (Listener == null)
            {
                Listener = this;
                return;
            }
            Destroy(this);
        }

        private void OnMouseHoldingLimitReachedCallback()
        {
            blockInputClickEvents = true;
        }

        private void OnMouseReleasedCallback()
        {
            blockInputClickEvents = false;
        }

        private void Start()
        {
            sceneMaster = FindObjectOfType<SceneMaster>();
            NavigationHandler = FindObjectOfType<NavigationHandler>();
            NavigationHandler.HoldingMouseLimitReachedEvent += OnMouseHoldingLimitReachedCallback;
            NavigationHandler.MouseReleasedEvent += OnMouseReleasedCallback;
        }

        private void Update()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            NavigationHandler.MouseScroll(scroll);
            NavigationHandler.Swipes();
        }

        #endregion Private Methods
    }
}