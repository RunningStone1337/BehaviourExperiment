using BuildingModule;
using Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class CommonReactionsSelector
    {
        private static List<ReactionBase> GetReactionsForEvent<TAgent, TReactionReason, TTableView, TTableContent>(TAgent thisAgent, TReactionReason reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table, GlobalEvent ge)
            where TAgent : SchoolAgentBase<TAgent>
            where TReactionReason : IReactionSource
            where TTableView : ViewDimensionBase<TTableContent>, new()
            where TTableContent : IReactionsCreator
        {
            List<ReactionBase> result = new List<ReactionBase>();
            string dimensionName = ge.Name;
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, 0);
                result.AddRange(GetInitializedReactions(thisAgent, reason, selector, trait));
            }
            return result;
        }

        private static List<ReactionBase> GetReactionsForInterier<TAgent, TReactionReason, TTableView, TTableContent>(TAgent thisAgent, TReactionReason reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table)
            where TAgent : SchoolAgentBase<TAgent>
            where TReactionReason : IReactionSource
            where TTableView : ViewDimensionBase<TTableContent>, new()
            where TTableContent : IReactionsCreator
        {
            List<ReactionBase> result = new List<ReactionBase>();
            int dimensionIndex = 0;
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionIndex, trait.ThisConcreteCharType, 0);
                result.AddRange(GetInitializedReactions(thisAgent, reason, selector, trait));
            }
            return result;
        }

        protected static List<ReactionBase> GetInitializedReactions<TAgent, TReactionReason, TTableContent>(TAgent thisAgent, TReactionReason reason, TTableContent selector, CharacterTraitBase trait)
            where TAgent : SchoolAgentBase<TAgent>
            where TReactionReason : IReactionSource
            where TTableContent : IReactionsCreator
        {
            var reactions = selector.GetReactions();
            foreach (var r in reactions)
            {
                if (r != null)
                {
                    r.Initiate(reason, thisAgent);
                    r.PhenomenonPower = Mathf.Abs(trait.SpecializedCharacterValue);
                }
            }
            return reactions.ToList();
        }

        protected static string GetRelationName<TAgent>(RelationshipBase<TAgent, IAgent, SchoolAgentStateBase<TAgent>> rel)
            where TAgent : SchoolAgentBase<TAgent>
        {
            string relationKey;
            if (rel == null)
                relationKey = "NonFamiliar";
            else
                relationKey = rel.ToString();
            return relationKey;
        }

        protected virtual List<ReactionBase> GetReactionsForAgent<TAgent, TReactionReason, TTableView, TTableContent>(TAgent thisAgent, TReactionReason reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table, IAgent ag)
            where TAgent : SchoolAgentBase<TAgent>
            where TReactionReason : IReactionSource
            where TTableView : ViewDimensionBase<TTableContent>, new()
            where TTableContent : IReactionsCreator
        {
            var relations = thisAgent.RelationsSystem.GetCurrentRelationTo(ag);
            List<ReactionBase> result = new List<ReactionBase>();
            string dimensionName = thisAgent.CurrentEvent.Name;
            string columnName = GetRelationName(relations);
            foreach (var trait in thisAgent.CharacterSystem)
            {
                var selector = table.GetTableValueFor(dimensionName, trait.ThisConcreteCharType, columnName);
                result.AddRange(GetInitializedReactions(thisAgent, reason, selector, trait));
            }
            return result;
        }

        public List<ReactionBase> SelectReactions
                                                    <TAgent, TReactionReason, TTableView, TTableContent>
            (TAgent thisAgent, TReactionReason reason, CharacterToPhenomContainerBase<TTableView, TTableContent> table)
            where TAgent : SchoolAgentBase<TAgent>
            where TReactionReason : IReactionSource
            where TTableView : ViewDimensionBase<TTableContent>, new()
            where TTableContent : IReactionsCreator
        {
            var result = new List<ReactionBase>();

            if (reason is IAgent ag)
            {
                result.AddRange(GetReactionsForAgent(thisAgent, reason, table, ag));
            }
            else if (reason is GlobalEvent ge)
            {
                result.AddRange(GetReactionsForEvent(thisAgent, reason, table, ge));
            }
            else if (reason is PlacedInterier pe)
            {
                result.AddRange(GetReactionsForInterier(thisAgent, reason, table));
            }

            return result;
        }
    }
}