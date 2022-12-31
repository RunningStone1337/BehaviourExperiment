using Common;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public abstract class PlacedInterier : InterierBase, IUIViewedObject, IPointerClickHandler
    {
        [SerializeField] private Collider2D collider2d;
        [SerializeField] private string objDescription;
        [SerializeField] private string objName;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ObjectUniqIdentifier thisIdentifier;
        [SerializeField] private InterierPlaceBase thisInterierPlace;

        private void Awake()
        {
            thisInterierPlace = GetComponentInParent<InterierPlaceBase>();
        }

        protected virtual void ResetMiddleOppAndSidePlaces(InterierPlaceBase interierPlaceBase)
        {
            if (interierPlaceBase is MiddlePlace mp)
                ResetOppositeAndSidePlaces(mp);
        }

        protected void ResetOppositeAndSidePlaces(MiddlePlace mp)
        {
            if (mp.InterierContains(this))
            {
                mp.LeftMiddlePlace.SetFreePlaceState();
                mp.RightMiddlePlace.SetFreePlaceState();
            }
            else
            {
                mp.LeftMiddlePlace.SetStateForInterier(this);
                mp.RightMiddlePlace.SetStateForInterier(this);
            }
            mp.OppositeMiddlePlace.SetStateForInterier(this);
        }

        public string ObjDescription => objDescription;
        public string Name => objName;
        public Sprite PreviewSprite => previewSprite;
        public SpriteRenderer Renderer { get => spriteRenderer; }
        public ObjectUniqIdentifier ThisIdentifier { get => thisIdentifier; }
        public InterierPlaceBase ThisInterierPlace { get => thisInterierPlace; }

        /// <summary>
        /// Сожет ли данный интерьер находиться при текущих условиях?
        /// </summary>
        /// <param name="underwall"></param>
        /// <returns></returns>
        public virtual bool CanExist(Underwall underwall) => true;

        public virtual bool IsAvailForPlacing(MiddlePlace place) => default;

        public virtual bool IsAvailForPlacing(Corner place) => default;

        public virtual bool IsAvailForPlacing(Underwall place) => default;

        /// <summary>
        /// Может ли быть размещён при текущих условиях?
        /// </summary>
        /// <param name="place"></param>
        /// <returns></returns>
        public bool IsAvailForPlacing(InterierPlaceBase place)
        {
            if (place is MiddlePlace m)
                return IsAvailForPlacing(m);
            if (place is Corner c)
                return IsAvailForPlacing(c);
            if (place is Underwall u)
                return IsAvailForPlacing(u);
            return default;
        }

        public virtual bool IsPrincipAvailableForPlacing<T>(T interierPlace) where T : InterierPlaceBase
           => default;

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            InputSystem.InputListener.Listener.HandleInterierClick(this, eventData);
        }
    }
}