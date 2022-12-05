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
        public override void ActivateAvailableInterierPlaces(IEnumerable<BuildingPlace> places)
        {
            /////////должен также вызываться после размещения нового объекта интерьера
            ///для обновления доступных мест для выбранного объекта
            foreach (var pl in places)
            {
                foreach (var middlePlace in pl.Entrance.MiddlePlaces)
                {
                    if (!middlePlace.IsOccuped && !middlePlace.OppositeMiddlePlace.IsOccuped)
                        middlePlace.CurrentState = middlePlace.AvailableForPlacingInterierPlaceState;
                }
            }
        }

    }
}