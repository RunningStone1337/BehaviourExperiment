using Extensions;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

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
       
        public override bool IsAvailableForPlacing(InterierPlaceBase interierPlace)
        {
            //����� �� �� ����������� ����� � ���������� ��������� ����������� ���������� �������
            return interierPlace.IsAvailableForPlacingInterier(this);
        }
        //public override void ActivateAvailableInterierPlaces()
        //{
        //    var places = EntranceRoot.Root.PlacesDict.Values.GetCurrentStateHandlers<OccupedState, BuildingPlace>();
        //    /////////������ ����� ���������� ����� ���������� ������ ������� ���������
        //    ///��� ���������� ��������� ���� ��� ���������� �������
        //    foreach (var pl in places)
        //    {
        //        foreach (var middlePlace in pl.Entrance.MiddlePlaces)
        //        {
        //            //�������� ���
        //            //if (!middlePlace.IsOccuped && !middlePlace.OppositeMiddlePlace.IsOccuped)
        //            if (IsAvailableForPlacing(middlePlace))
        //                middlePlace.CurrentState = middlePlace.AvailableForPlacingInterierPlaceState;
        //            //���� �������� ��� � ������ ���������������
        //            //if (!middlePlace.IsOccuped && middlePlace.OppositeMiddlePlace.IsOccuped)
        //            //    middlePlace.CurrentState = middlePlace.FreeInterierPlaceState;
        //        }
        //    }
        //}

    }
}