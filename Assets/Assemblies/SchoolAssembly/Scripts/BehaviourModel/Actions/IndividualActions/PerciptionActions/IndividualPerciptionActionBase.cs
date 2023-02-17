using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class IndividualPerciptionActionBase : IndividualAction
    {
        public IndividualPerciptionActionBase(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }

        protected IndividualPerciptionActionBase():base()
        {
        }
    }
}