using BuildingModule;
using System.Collections.Generic;

namespace BehaviourModel
{
    public class PupilBrain : SchoolBrain<PupilAgent>,
        ICanReactOnPhenomenon<TeacherAgent, ActionBase>
    {
        public override bool TryGetActionsOnPhenom(IPhenomenon reason, out List<ActionBase> reaction)
        { if (reason is TeacherAgent t)
                return TryGetActionsOnPhenom(t, out reaction);
            else
                return base.TryGetActionsOnPhenom(reason, out reaction);
        }
        public bool TryGetActionsOnPhenom(TeacherAgent reason, out List<ActionBase> reactions)
        {
            var table = (PupilRelationsTableHandler)ThisAgent.TablesHandler;
            var selector = new FirstColumnAgentReactionsSelector<PupilAgent, TeacherAgent, ReactionsWrapper>();
            reactions = selector.GetProbablyActions
               (ThisAgent, reason, table.CharacterToTeacherReactionsTable);
            return true;
        }
    }
}