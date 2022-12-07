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
            //может ли на АБСТРАКТНОМ месте в КОНКРЕТНОМ состоянии размещаться КОНКРЕТНЫЙ предмет
            return interierPlace.IsAvailableForPlacingInterier<TableInterier>();
        }

    }
}