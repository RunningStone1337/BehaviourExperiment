using Events;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class EventReactionsSelector<TAgent, TReactionSource, TReactionsCreator> : CommonReactionsSelector<TAgent, TReactionSource, TReactionsCreator>
          where TAgent : SchoolAgentBase<TAgent>
        where TReactionSource : GlobalEvent
        where TReactionsCreator : IActionsCreator<ActionBase>
    {
        public override List<ActionBase> GetProbablyActions<TTableView>(TAgent thisAgent, TReactionSource reason, CharacterToPhenomContainerBase<TTableView, TReactionsCreator> table)
        {
            List<ActionBase> result = new List<ActionBase>();
            string dimensionName = reason.Name;
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, 0);
                result.AddRange(CreateInitializedActions(thisAgent, reason, selector, trait));
            }
            return result;
        }
    }
}
