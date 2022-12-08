using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Extensions;
using System.Linq;

namespace BuildingModule
{
    public class FreeMiddleInterierPlaceState : FreeInterierPlaceState
    {
        protected MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }

        public override bool IsAvailableForPlacingInterier<T>()
        {
            if (typeof(T).Equals<TableInterier>())
            {

                foreach (var place in thisPlace.Entrance.MiddlePlaces)
                {
                    if (place.IsOccuped && place.Interier.Count<InterierBase, TableInterier>()>0)
                        return false;
                }
                return true;
            }
            if (typeof(T).Equals<Chair>())
            {
                //var opp = ThisPlace.OppositeMiddlePlace;
                if (ThisPlace.LeftMiddlePlace.IsOccuped || ThisPlace.RightMiddlePlace.IsOccuped)//справа или слева от этого
                    return false;
                //if (opp.IsOccuped)//место напротив занято чем-то
                //    return true;  
                //else
                    return true;
            }
            return base.IsAvailableForPlacingInterier<T>();
        }
    }
}