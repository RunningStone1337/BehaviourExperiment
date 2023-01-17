using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class NegativeInterierImpression : NegativeImpressionBase
    {
        private PlacedInterier placedInterier;

        public NegativeInterierImpression(PlacedInterier placedInterier)
        {
            this.placedInterier = placedInterier;
        }
    }
}