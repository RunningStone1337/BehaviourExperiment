using BehaviourModel;
using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BuildingModule
{
    public abstract class PlacedInterier : InterierBase, IUIViewedObject, IPointerClickHandler,
        IMovementTarget,
        IPhenomenon
    {
        [SerializeField] protected Collider2D collider2d;
        [SerializeField] private int influenceValue;
        [SerializeField] private string objDescription;
        [SerializeField] private string objName;
        [SerializeField] private Sprite previewSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ObjectUniqIdentifier thisIdentifier;
        [SerializeField] private InterierPlaceBase thisInterierPlace;

        protected virtual void Awake()
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

        public int PhenomenonPower { get => influenceValue; set => influenceValue = value; }
        public string Name => objName;
        public string ObjDescription => objDescription;
        public Sprite PreviewSprite => previewSprite;
        public SpriteRenderer Renderer { get => spriteRenderer; }
        public ObjectUniqIdentifier ThisIdentifier { get => thisIdentifier; }
        public InterierPlaceBase ThisInterierPlace { get => thisInterierPlace; }

        /// <summary>
        /// ћожет ли данный интерьер находитьс€ при текущих услови€х?
        /// </summary>
        /// <param name="underwall"></param>
        /// <returns></returns>
        public virtual bool CanExist(Underwall underwall) => true;

        /// <summary>
        /// Ёмоции, возникающие при воспри€тии данного интерьера
        /// </summary>
        /// <returns></returns>
        //public List<EmotionBase> GetEmotions()
        //{
        //    var res = new List<EmotionBase>();
        //    if (PhenomenonPower > 0)
        //    {
        //        res.Add(new HappyHappinessEmotion(this));
        //        res.Add(new ApprovalApprovalEmotion(this));
        //    }
        //    else if (PhenomenonPower < 0)
        //    {
        //        res.Add(new AnnoyanceAngerEmotion(this));
        //        res.Add(new DislikeDisgustEmotion(this));
        //        res.Add(new DespondencySadEmotion(this));
        //    }
        //    else
        //        res.Add(new SerenityHappinessEmotion(this));
        //    return res;
        //}      

        public virtual bool IsAvailForPlacing(MiddlePlace place) => default;

        public virtual bool IsAvailForPlacing(Corner place) => default;

        public virtual bool IsAvailForPlacing(Underwall place) => default;

        /// <summary>
        /// ћожет ли быть размещЄн при текущих услови€х?
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

        public virtual IEnumerator OnTargetReached(SchoolAgentBase moveAgent)
        { yield break; }
    }
}