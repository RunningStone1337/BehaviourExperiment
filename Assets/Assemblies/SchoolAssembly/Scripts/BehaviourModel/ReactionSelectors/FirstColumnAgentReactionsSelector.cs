using System.Collections.Generic;

namespace BehaviourModel
{
    public class FirstColumnAgentReactionsSelector<TAgent, TReactionSource, TTableContent> :
        OtherAgentReactionsSelector<TAgent, TReactionSource, TTableContent>
        where TAgent: SchoolAgentBase<TAgent>
        where TReactionSource : SchoolAgentBase<TReactionSource>
        where TTableContent : IActionsCreator<ActionBase>
    {
        public override List<ActionBase> GetProbablyActions<TTableView>(TAgent thisAgent, TReactionSource reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table)
        {
            var result = new List<ActionBase>();
            string dimensionName = thisAgent.CurrentEvent.Name;
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, 0);
                result.AddRange(CreateInitializedActions(thisAgent, reason, selector, trait));
            }
            return result;
        }
      
    }
}