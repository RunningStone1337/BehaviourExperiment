using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingModule
{
    public class MiddlePlace : InterierPlaceBase
    {
        [SerializeField] MiddlePlace oppositeMiddlePlace;
        public MiddlePlace OppositeMiddlePlace { get => oppositeMiddlePlace; }
    }
}