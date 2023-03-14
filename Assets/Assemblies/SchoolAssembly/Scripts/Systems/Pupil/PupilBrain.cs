using BuildingModule;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class PupilBrain : SchoolBrain<PupilAgent>,
        ICanReactOnPhenomenon<PlacedInterier, ReactionBase>,
        ICanReactOnPhenomenon<TeacherAgent, ReactionBase>

    {
        public override bool HasReactionsOnPhenom(IPhenomenon reason, out List<ReactionBase> reaction)
        {
            reaction = default;
            if (reason is PlacedInterier pi)
                return HasReactionsOnPhenom(pi, out reaction);
            else if (reason is TeacherAgent t)
                return HasReactionsOnPhenom(t, out reaction);
            else
                return base.HasReactionsOnPhenom(reason, out reaction);
        }
        public bool HasReactionsOnPhenom(PlacedInterier reason, out List<ReactionBase> reactions)
        {
            var table = (PupilRelationsTableHandler)ThisAgent.TablesHandler;
            var selector = new CommonReactionsSelector();
            reactions = selector.SelectReactions
               (ThisAgent, reason, table.CharacterToInterierReactionsTable);
            return true;
        }
        public bool HasReactionsOnPhenom(TeacherAgent reason, out List<ReactionBase> reactions)
        {
            var table = (PupilRelationsTableHandler)ThisAgent.TablesHandler;
            var selector = new FirstColumnReactionsSelector();
            reactions = selector.SelectReactions
               (ThisAgent, reason, table.CharacterToTeacherReactionsTable);
            return true;
        }
    }
}