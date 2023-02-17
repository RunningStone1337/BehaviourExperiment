using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public class ListenToAgentAction : IndividualPerciptionActionBase
    {
        public ListenToAgentAction(IReactionSource source, int phenomPower) : base(source, phenomPower)
        {
        }
        public ListenToAgentAction():base()
        {

        }
    }
}