using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class PositiveInterierImpression : PositiveImpressionBase
    {
        private PlacedInterier placedInterier;

        public PositiveInterierImpression(PlacedInterier placedInterier)
        {
            this.placedInterier = placedInterier;
        }
    }
}