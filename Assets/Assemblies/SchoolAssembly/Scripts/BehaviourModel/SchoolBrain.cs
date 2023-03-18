using BuildingModule;
using Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourModel
{
    public class SchoolBrain<TAgent> : BrainBase<TAgent, ReactionBase, FeatureBase, SchoolAgentStateBase<TAgent>, Sensor>,
        ICanReactOnPhenomenon<PupilAgent, ReactionBase>,
        ICanReactOnPhenomenon<BreakEvent, ReactionBase>,
        ICanReactOnPhenomenon<LessonEvent, ReactionBase>,
        ICanReactOnPhenomenon<DayOverEvent, ReactionBase>
        where TAgent: SchoolAgentBase<TAgent>
    {
       
        #region reactions calculations

        public override bool HasReactionsOnPhenom(IPhenomenon reason, out List<ReactionBase> reaction)
        {
            reaction = default;
            if (reason is PupilAgent p)
                return HasReactionsOnPhenom(p, out reaction);           
            else if (reason is BreakEvent be)
                return HasReactionsOnPhenom(be, out reaction);
            else if (reason is LessonEvent le)
                return HasReactionsOnPhenom(le, out reaction);
            else if (reason is DayOverEvent dov)
                return HasReactionsOnPhenom(dov, out reaction);
            else return default;
        }

        /// <summary>
        /// –еакци€ на школ€ра зависит от 
        /// -характера
        /// -взаимоотношений
        /// -текущего событи€
        /// </summary>
        /// <param name="reason"></param>
        /// <param name="reactions"></param>
        /// <returns></returns>
        public virtual bool HasReactionsOnPhenom(PupilAgent reason, out List<ReactionBase> reactions)
        {
            var selector = new CommonReactionsSelector();
            reactions = selector.SelectReactions                
                (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
            return true;
        }

             

        public bool HasReactionsOnPhenom(BreakEvent reason, out List<ReactionBase> reactions)
        {
            var selector = new CommonReactionsSelector();
            reactions = selector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }
        public bool HasReactionsOnPhenom(DayOverEvent reason, out List<ReactionBase> reactions)
        {
            var selector = new CommonReactionsSelector();
            reactions = selector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }

        public bool HasReactionsOnPhenom(LessonEvent reason, out List<ReactionBase> reactions)
        {
            var selector = new CommonReactionsSelector();
            reactions = selector.SelectReactions
               (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToEventsReactionsTable);
            return true;
        }

        protected override ReactionBase SelectReaction(List<ReactionBase> reactions)
        {
            var tuples = reactions.Select(x => (x, x.PhenomenonPower)).ToList();
            var selected = tuples.SelectRandom();
            return selected.Key;
        }

        protected override IPhenomenon SelectPhenomToReact(List<IPhenomenon> phenomensToReact)
        {
            var phenomsWeights = phenomensToReact.Select(x => (x, x.PhenomenonPower)).ToList();
            var selected = phenomsWeights.SelectRandom().Key;
            return selected;
        }
        #endregion
    }
}