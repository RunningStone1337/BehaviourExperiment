using System.Collections;

namespace BehaviourModel
{
    public class PupilTrySpeechNeighIfFamiliarOrFriendly : TryPrimitiveSpeechAction<PupilAgent, PupilAgent>, ICompletedAction
    {
        public override IEnumerator TryPerformAction()
        {
            var pup = ActionActor as PupilAgent;
            var source = ReactionSource as PupilAgent;
            if (pup && source)
            {
                var rel = pup.RelationsSystem.GetCurrentRelationTo(source);
                if (rel is FamiliarRelationship<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>> || rel is FellowRelationship<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>>)
                    yield return base.TryPerformAction();
                pup.SetDefaultState();
            }
        }
    }
}