using BuildingModule;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    public class GoToExitAction<TAgent> : PhysicalAction
        where TAgent : SchoolAgentBase<TAgent>
    {
        public override IEnumerator TryPerformAction()
        {
            var cast = ActionActor as TAgent;
            if (cast != null)
            {
                cast.MovementTarget = FindExit();
                var state = cast.SetState<MoveToTargetState<TAgent>>();
                yield return state.StartState();
                WasPerformed = true;
                cast.SetDefaultState();
            }            
        }

        private Transform FindExit()
        {
            var entrance = EntranceRoot.Root.Rooms.Where(x => x.Role is ExitRole).ToList().GetRandom().RandomEntrance();
            return entrance.transform;
        }
    }
}
