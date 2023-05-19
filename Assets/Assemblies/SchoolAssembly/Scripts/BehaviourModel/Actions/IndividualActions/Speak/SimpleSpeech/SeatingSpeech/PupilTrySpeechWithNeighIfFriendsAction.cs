using System.Collections;

namespace BehaviourModel
{
    public class PupilTrySpeechWithNeighIfFriendsAction : PupilTrySpeechWithNeighAction
    {
        public override IEnumerator TryPerformAction()
        {
            var actorCast = ActionActor as PupilAgent;
            var secondCast = ReactionSource as PupilAgent;
            if (actorCast != null && secondCast != null)
            {
                var rel = actorCast.RelationsSystem.GetCurrentRelationTo(secondCast);
                if (rel is FriendRelationship<PupilAgent, IAgent>)
                {
                    yield return base.TryPerformAction();
                }
                actorCast.SetDefaultState();
            }
        }
    }
}
