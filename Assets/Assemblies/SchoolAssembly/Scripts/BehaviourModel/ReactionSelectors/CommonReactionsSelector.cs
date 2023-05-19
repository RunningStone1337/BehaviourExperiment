using System.Collections.Generic;
using System.Linq;

namespace BehaviourModel
{
    public abstract class CommonReactionsSelector
        <TAgent, TReactionSource, TReactionsCreator> : 
        ProbablyActionSelectorBase<TAgent, TReactionSource, ActionBase, TReactionsCreator>
        where TAgent : SchoolAgentBase<TAgent>
        where TReactionSource : IPhenomenon
        where TReactionsCreator : IActionsCreator<ActionBase>
    {
        protected List<ActionBase> CreateInitializedActions(TAgent actionActor, TReactionSource actionReason, TReactionsCreator selector, IUtilityCalculationSource valuable)
        {
            var reactions = selector.CreateActions();
            foreach (var r in reactions)
            {
                if (r != null)
                {
                    r.Initiate(actionReason, actionActor);
                    r.CalculateUtility(valuable);
                }
            }
            return reactions.ToList();
        }
    }
}