using System;
using System.Collections;

namespace BehaviourModel
{
    [Serializable]
    public class PupilTrySpeechWithNeighAction : TryPrimitiveSpeechAction<PupilAgent, PupilAgent>, ICompletedAction
    {
        public PupilTrySpeechWithNeighAction() : base()
        {
        }

        public override IEnumerator TryPerformAction()
        {
            var actorCast = ActionActor as PupilAgent;
            if (actorCast != null && ReactionSource is PupilAgent secondCast)
            {
                var table1 = actorCast.AgentEnvironment.TableInfo;
                var table2 = secondCast.AgentEnvironment.TableInfo;
                var oneTable = table1 == table2;
                if (actorCast.AgentEnvironment.ChairInfo != null && secondCast.AgentEnvironment.ChairInfo != null && oneTable)
                {
                    //var cachedRotation = actorCast.transform.rotation.eulerAngles.z%360f;
                    yield return base.TryPerformAction();
                    //var rotator = new RotationHandler();
                    //yield return rotator.RotateToAngle(actorCast.AgentRigidbody, cachedRotation, 2f);
                }
                actorCast.SetDefaultState();
            }
        }
    }
}