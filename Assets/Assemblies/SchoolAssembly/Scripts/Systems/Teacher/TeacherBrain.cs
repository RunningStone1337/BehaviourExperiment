using System.Collections.Generic;

namespace BehaviourModel
{
    public class TeacherBrain : SchoolBrain<TeacherAgent>
    {
        public override bool HasReactionsOnPhenom(PupilAgent reason, out List<ReactionBase> reactions)
        {
            var selector = new FirstColumnReactionsSelector();
            reactions = selector.SelectReactions
                 (ThisAgent, reason, ThisAgent.TablesHandler.CharacterToPupilReactionsTable);
            return true;
        }
    }
}