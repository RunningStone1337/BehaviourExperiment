using System.Collections;

namespace BehaviourModel
{
    public class PupilTryAgressiveSpeechNeighIfEnemy : PupilTrySpeechWithNeighAction
    {
        public override IEnumerator TryPerformAction()
        {
            var speaker = ActionActor as PupilAgent;
            var target = ReactionSource as PupilAgent;
            if (speaker != null && target != null)
            {
                var rel = speaker.RelationsSystem.GetCurrentRelationTo(target);
                if (rel is EnemyRelationship<PupilAgent, IAgent, SchoolAgentStateBase<PupilAgent>>)
                {
                    yield return base.TryPerformAction();
                }
            }
        }
    }
}