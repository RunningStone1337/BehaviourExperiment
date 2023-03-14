using System.Collections.Generic;

namespace BehaviourModel
{
    public class FirstColumnReactionsSelector : CommonReactionsSelector
    {
        protected override List<ReactionBase> GetReactionsForAgent<TAgent, TReactionReason, TTableView, TTableContent>(TAgent thisAgent, TReactionReason reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table, IAgent ag)
        {
            List<ReactionBase> result = new List<ReactionBase>();
            string dimensionName = thisAgent.CurrentEvent.Name;
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, 0);
                result.AddRange(GetInitializedReactions(thisAgent, reason, selector, trait));
            }
            return result;
        }
    }
}