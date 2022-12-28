using Extensions;

namespace BuildingModule
{
    public class FreeInterierMiddlePlaceState : FreeInterierPlaceState
    {
        protected MiddlePlace ThisPlace { get => (MiddlePlace)thisPlace; }

        public override bool IsAvailableForPlacingInterier(InterierBase interier)
        {
            if (interier is TableInterier)
            {
                foreach (var place in thisPlace.Entrance.MiddlePlaces)
                {
                    if (place.IsOccuped && place.Interier.Count<InterierBase, TableInterier>() > 0)
                        return false;
                }
                return true;
            }
            if (interier is Chair)
            {
                if (ThisPlace.LeftMiddlePlace.IsOccuped || ThisPlace.RightMiddlePlace.IsOccuped)//справа или слева от этого
                    return false;
                return true;
            }
            return base.IsAvailableForPlacingInterier(interier);
        }
    }
}