using BuildingModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class NeutralInterierImpression : NeutralImpressionBase
    {
        private PlacedInterier placedInterier;

        public NeutralInterierImpression(PlacedInterier placedInterier)
        {
            this.placedInterier = placedInterier;
        }
    }
}