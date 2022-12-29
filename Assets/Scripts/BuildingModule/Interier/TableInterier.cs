using UI;
using UnityEngine;
using Extensions;

namespace BuildingModule
{
    public class TableInterier : InterierBase, IUIViewedObject
    {
        [SerializeField] Sprite previewSprite;
        [SerializeField] string objName;
        [SerializeField] string objDescription;
        public Sprite PreviewSprite => previewSprite;

        public string ObjectName => objName;

        public string ObjectDescription => objDescription;
        public override bool IsAvailForPlacing(AvailableForPlacingInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);
        }

        public override bool IsAvailForPlacing(MiddlePlace place)
        {
            //принципиально может размещаться на это месте
            var princCond = IsPrincipAvailableForPlacing(place);
            //на месте ничего нет
            var noInterier = place.InterierCount() == 0;
            //напротив нет стола
            var noOppNable = place.OppositeMiddlePlace.InterierCount<TableInterier>() == 0;
            //по сторонам ничего нет
            var noSides = place.LeftMiddlePlace.InterierCount() == 0 && place.RightMiddlePlace.InterierCount() == 0;
            if (princCond && noOppNable && noInterier && noSides)
                return true;
            return false;
        }

        public override bool IsAvailForPlacing(FreeInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);           
        }
        public override bool IsAvailForPlacing(NotAvailableForPlacingInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);
        }
        public override bool IsPrincipAvailableForPlacing<T>(T interier)
        {
            if (typeof(T).Equals<MiddlePlace>())
                    return true;
            return false;
        }
        public override bool HaveInfluenceOnOtherPlaces() => true;
        public override void ResetDependentPlaces(InterierPlaceBase interierPlaceBase)
        {
            if (interierPlaceBase is MiddlePlace mp)
                ResetOppositeAndSidePlaces(mp);
        }

       
    }
}