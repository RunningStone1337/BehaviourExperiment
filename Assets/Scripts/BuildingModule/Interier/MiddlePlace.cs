using UnityEngine;

namespace BuildingModule
{
    public class MiddlePlace : InterierPlaceBase
    {
        [SerializeField] private MiddlePlace leftMiddlePlace;
        [SerializeField] private MiddlePlace oppositeMiddlePlace;
        [SerializeField] private MiddlePlace rightMiddlePlace;
        public MiddlePlace LeftMiddlePlace { get => leftMiddlePlace; }
        public MiddlePlace OppositeMiddlePlace { get => oppositeMiddlePlace; }
        public MiddlePlace RightMiddlePlace { get => rightMiddlePlace; }
    }
}