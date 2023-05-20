using Events;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourModel
{
    public class SchoolBrain<TAgent> : BrainSystem<TAgent, ActionBase>,
        ICanReactOnPhenomenon<PupilAgent, ActionBase>,
        ICanReactOnPhenomenon<GlobalEvent, ActionBase>
        where TAgent : SchoolAgentBase<TAgent>
    {
        #region reactions calculations

        public override IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact)
        {
            var phenomsWeights = phenomensToReact.Select(x => (x, x.PhenomValue)).ToList();
            var selected = phenomsWeights.SelectRandom().Key;
            return selected;
        }

        public override ActionBase SelectActionFromList(List<ActionBase> reactions)
        {
            var tuples = reactions.Select(x => (x, x.ActionUtility)).ToList();
            var selected = tuples.SelectRandom();
            return selected.Key;
        }

        public override bool TryGetActionsOnPhenom(IPhenomenon reason, out List<ActionBase> reaction)
        {
            reaction = default;
            if (reason is PupilAgent p)
                return TryGetActionsOnPhenom(p, out reaction);
            else if (reason is GlobalEvent be)
                return TryGetActionsOnPhenom(be, out reaction);          
            else return default;
        }

        public virtual bool TryGetActionsOnPhenom(PupilAgent reason, out List<ActionBase> reactions)
        {
            var selector = new OtherAgentReactionsSelector<TAgent, PupilAgent, ReactionsWrapper>();
            reactions = selector.GetProbablyActions
                (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
            return true;
        }

        public bool TryGetActionsOnPhenom(GlobalEvent reason, out List<ActionBase> reactions)
        {
            var selector = new EventReactionsSelector<TAgent, GlobalEvent, ReactionsWrapper>();
            reactions = selector.GetProbablyActions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }

        #endregion reactions calculations
    }
}