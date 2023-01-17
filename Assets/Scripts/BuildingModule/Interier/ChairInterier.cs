using Common;
using Core;
using Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingModule
{
    public class ChairInterier : PlacedInterier, IDependentFromChanges
    {
        private void OnDestroy()
        {
            InterierHandler.Handler.Chairs.Remove(this);
        }

        private Vector3 ReplacePosition(float v)
        {
            var oldPos = transform.localPosition;
            var chairs = ThisInterierPlace.InterierWhere<ChairInterier>();
            if (chairs != null && chairs.Count() == 2)
                v = -chairs.First(x => !x.Equals(this)).transform.localPosition.y;
            return new Vector3(oldPos.x, v, oldPos.z);
        }

        protected override void Awake()
        {
            base.Awake();
            InterierHandler.Handler.Chairs.Add(this);
        }

        public override void Initiate(InterierPlaceBase ipb)
        {
            transform.localPosition = ReplacePosition(0.035f);
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

        public override bool IsPrincipAvailableForPlacing<T>(T interier)
        {
            if (typeof(T).Equals<MiddlePlace>())
                return true;
            return false;
        }

        public void ResetIfConditionsChanged(object param)
        {
            ResetMiddleOppAndSidePlaces((InterierPlaceBase)param);
        }
       
    }
}