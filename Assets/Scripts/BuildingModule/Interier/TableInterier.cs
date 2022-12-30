using Common;
using Extensions;

namespace BuildingModule
{
    public class TableInterier : PlacedInterier, IDependentFromChanges
    {

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
        public void ResetIfConditionsChanged(object param)
        {
            ResetMiddleOppAndSidePlaces((InterierPlaceBase)param);
        }
        public override bool IsPrincipAvailableForPlacing<T>(T interier)
        {
            if (typeof(T).Equals<MiddlePlace>())
                return true;
            return false;
        }
    }
}