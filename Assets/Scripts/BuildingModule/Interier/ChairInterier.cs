using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace BuildingModule
{
    public class ChairInterier : InterierBase, IUIViewedObject
    {
        [SerializeField] Sprite previewSprite;
        [SerializeField] string objName;
        [SerializeField] string objDescription;
        public Sprite PreviewSprite => previewSprite;

        public string ObjectName => objName;

        public string ObjectDescription => objDescription;
       
        public override void Initiate(InterierPlaceBase ipb)
        {
            transform.localPosition = ReplacePosition(0.035f);
        }
        public override bool IsPrincipAvailableForPlacing<T>(T interier) {
            if (typeof(T).Equals<MiddlePlace>())
                return true;
            return false;
        }
        public override bool IsAvailForPlacing(NotAvailableForPlacingInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);
        }
        public override bool IsAvailForPlacing(AvailableForPlacingInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);
        }
        public override bool IsAvailForPlacing(FreeInterierMiddlePlaceState state)
        {
            var place = state.ThisPlace;
            return IsAvailForPlacing(place);
        }
        public override bool IsAvailForPlacing(MiddlePlace place)
        {
            var pinc = IsPrincipAvailableForPlacing(place);
            var noTable = place.InterierCount<TableInterier>() == 0;
            var sidesFree = place.LeftMiddlePlace.InterierCount() == 0 && place.RightMiddlePlace.InterierCount() == 0;
            var chairsCount = place.InterierCount<ChairInterier>() < 2;
            var noChairs = place.OppositeMiddlePlace.InterierCount<ChairInterier>() == 0;
            if (pinc && noTable && sidesFree && chairsCount && noChairs)
                return true;
            return false;
        }

        public override bool HaveInfluenceOnOtherPlaces() => true;
        public override void ResetDependentPlaces(InterierPlaceBase interierPlaceBase)
        {
            if (interierPlaceBase is MiddlePlace mp)
                ResetOppositeAndSidePlaces(mp);
        }

        private Vector3 ReplacePosition(float v)
        {
            var oldPos = transform.localPosition;
            var chairs = ThisInterierPlace.InterierWhere<ChairInterier>();
            if (chairs != null && chairs.Count() == 2)
                v = -chairs.First(x=>!x.Equals(this)).transform.localPosition.y;
            return new Vector3(oldPos.x, v, oldPos.z);
        }
    }
}