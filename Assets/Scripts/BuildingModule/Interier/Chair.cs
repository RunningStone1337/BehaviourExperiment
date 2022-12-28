using Extensions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace BuildingModule
{
    public class Chair : InterierBase, IUIViewedObject
    {
        [SerializeField] Sprite previewSprite;
        [SerializeField] string objName;
        [SerializeField] string objDescription;
        public Sprite PreviewSprite => previewSprite;

        public string ObjectName => objName;

        public string ObjectDescription => objDescription;
       
        public override void Initiate(InterierPlaceBase ipb)
        {
            ipb.Interier.Add(this);
            if (ipb.Interier.Count >1)
                ipb.CurrentState = ipb.OccupedInterierPlaceState;
            transform.localPosition = ReplacePosition(0.035f);
        }

        private Vector3 ReplacePosition(float v)
        {
            var oldPos = transform.localPosition;
            var chairs = ThisInterierPlace.Interier.Where(x => x is Chair);
            if (chairs != null )
            {
                if (chairs.Count() > 1)
                {
                    v = -chairs.Where(x => x != this).First().transform.localPosition.y;
                }
            }
            return new Vector3(oldPos.x, v, oldPos.z);
        }
    }
}