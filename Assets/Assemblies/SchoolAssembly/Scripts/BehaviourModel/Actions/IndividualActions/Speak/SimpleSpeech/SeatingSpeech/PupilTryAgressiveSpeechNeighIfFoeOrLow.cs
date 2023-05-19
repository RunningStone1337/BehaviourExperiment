using System.Collections;

namespace BehaviourModel
{
    public class PupilTryAgressiveSpeechNeighIfFoeOrLow : PupilTryAgressiveSpeechNeighAction
    {
        public override IEnumerator TryPerformAction()
        {
            var speaker = ActionActor as PupilAgent;
            var target = ReactionSource as PupilAgent;
            if (speaker != null && target != null)
            {
                var rel = speaker.RelationsSystem.GetCurrentRelationTo(target);
                if (rel is FoeRelationship<PupilAgent, IAgent>)
                {
                    yield return base.TryPerformAction();
                }
            }
        }
    }
}