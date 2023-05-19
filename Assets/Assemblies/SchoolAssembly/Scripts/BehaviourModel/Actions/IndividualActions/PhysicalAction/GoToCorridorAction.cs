using BuildingModule;
using System.Collections;
using System.Linq;

namespace BehaviourModel
{
    public abstract class GoToCorridorAction<TAgent> : PhysicalAction, ICompletedAction
        where TAgent:SchoolAgentBase<TAgent>
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = (TAgent)ActionActor;
            var role = cast.AgentEnvironment.CurrentRoom.Role as CorridorRole;
            if (role == null)
            {
                var corridorEntrances = EntranceRoot.Root.Rooms.Where(x => x.Role is CorridorRole)
                    .SelectMany(x => x.ThisRoomEntrances).ToList();
                if (corridorEntrances.Count > 0)
                {
                    var entranceToGo = corridorEntrances.GetRandom();
                    cast.MovementTarget = entranceToGo.transform;
                    var state = cast.SetState<MoveToTargetState<TAgent>>();
                    yield return state.StartState();
                    WasPerformed = true;
                }
            }
        }
    }
}
