using System.Collections.Generic;

namespace BehaviourModel
{
    public class OtherAgentReactionsSelector<TAgent, TReactionSource, TReactionsCreator> : CommonReactionsSelector<TAgent,TReactionSource,TReactionsCreator>
          where TAgent : SchoolAgentBase<TAgent>
        where TReactionSource : SchoolAgentBase<TReactionSource>
        where TReactionsCreator : IActionsCreator<ActionBase>
    {
        public override List<ActionBase> GetProbablyActions<TTableView>(TAgent thisAgent, TReactionSource reason, CharacterToPhenomContainerBase<TTableView, TReactionsCreator> table)
        {
            var relations = thisAgent.RelationsSystem.GetCurrentRelationTo(reason);
            List<ActionBase> result = new List<ActionBase>();
            string dimensionName = thisAgent.CurrentEvent.Name;
            string columnName = GetRelationName(relations);
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, columnName);
                result.AddRange(CreateInitializedActions(thisAgent, reason, selector, trait));
            }
            return result;
        }
        protected static string GetRelationName(RelationshipBase<TAgent, IAgent> rel)
        {
            string relationKey;
            if (rel == null)
                relationKey = "NonFamiliar";
            else
                relationKey = rel.ToString();
            return relationKey;
        }
    }
}
