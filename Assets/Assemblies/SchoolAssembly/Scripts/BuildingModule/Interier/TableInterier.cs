using BehaviourModel;
using Common;
using UnityEngine;

namespace BuildingModule
{
    public class TableInterier : PlacedInterier, IDependentFromChanges
    {
        [SerializeField] TableInfo tableInfo;
        public TableInfo TableInfo=> tableInfo;
        private void OnDestroy()
        {
            InterierHandler.Handler.Tables.Remove(this);
        }

        public override void Initiate(InterierPlaceBase ipb)
        {
            InterierHandler.Handler.Tables.Add(this);
        }

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