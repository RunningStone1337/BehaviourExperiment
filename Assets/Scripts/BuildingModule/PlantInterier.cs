using Extensions;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BuildingModule
{
    public class PlantInterier : PlacedInterier
    {        
        public override bool IsPrincipAvailableForPlacing<T>(T interierPlace)
        {
            if (typeof(T).Equals<Corner>())
                return true;
            return default;
        }
        public override bool IsAvailForPlacing(Corner place)
        {
            var princ = IsPrincipAvailableForPlacing(place);
            var isFree = place.InterierCount() == 0;
            if (princ && isFree)
                return true;
            return false;
        }
    }
}