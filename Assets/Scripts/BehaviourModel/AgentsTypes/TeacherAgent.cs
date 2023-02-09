using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public sealed class TeacherAgent : SchoolAgentBase
    {
        [SerializeField] BehaviourPatternBase pattern;

        public override List<IReaction> GetReactionsOnPhenomenon()
        {
            throw new System.NotImplementedException();
        }
        #region tables


        #endregion tables
        public override void Initiate(HumanRawData pup)
        {
            base.Initiate(pup);
            var data = (TeacherRawData)pup;
            pattern = data.behModel;
        }
    }
}