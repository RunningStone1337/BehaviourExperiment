using System.Collections.Generic;

namespace BehaviourModel
{
    public class TeacherBrain : SchoolBrain<TeacherAgent>
    {
        public override bool TryReactOnPhenom(PupilAgent reason, out List<ActionBase> reactions)
        {
            var selector = new FirstColumnAgentReactionsSelector<TeacherAgent, PupilAgent, ReactionsWrapper>();
            reactions = selector.GetProbablyActions
                 (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
            return true;
        }
    }
}