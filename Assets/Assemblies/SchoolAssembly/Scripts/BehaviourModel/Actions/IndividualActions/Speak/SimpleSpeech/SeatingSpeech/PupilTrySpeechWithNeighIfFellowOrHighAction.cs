using System.Collections;

namespace BehaviourModel
{
    public class PupilTrySpeechWithNeighIfFellowOrHighAction : PupilTrySpeechWithNeighAction
    {
        public override IEnumerator TryPerformAction()
        {
            var actorCast = (PupilAgent)ActionActor;
            var secondCast = ReactionSource as PupilAgent;
            if (actorCast != null && secondCast != null)
            {
                var rel = actorCast.RelationsSystem.GetCurrentRelationTo(secondCast);
                if (rel is FellowRelationship<PupilAgent, IAgent>)
                {
                    yield return base.TryPerformAction();
                }
                actorCast.SetDefaultState();
            }
        }
    }
}