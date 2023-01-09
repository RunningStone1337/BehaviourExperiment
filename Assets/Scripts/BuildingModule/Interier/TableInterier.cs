using Common;
using Extensions;

namespace BuildingModule
{
    public class TableInterier : PlacedInterier, IDependentFromChanges
    {
        public override bool IsAvailForPlacing(MiddlePlace place)
        {
            //������������� ����� ����������� �� ��� �����
            var princCond = IsPrincipAvailableForPlacing(place);
            //�� ����� ������ ���
            var noInterier = place.InterierCount() == 0;
            //�������� ��� �����
            var noOppNable = place.OppositeMiddlePlace.InterierCount<TableInterier>() == 0;
            //�� �������� ������ ���
            var noSides = place.LeftMiddlePlace.InterierCount() == 0 && place.RightMiddlePlace.InterierCount() == 0;
            if (princCond && noOppNable && noInterier && noSides)
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