using System.Collections;

namespace BehaviourModel
{
    public interface IMovementTarget<TMovedAgent>
        where TMovedAgent: SchoolAgentBase<TMovedAgent>
    {
        IEnumerator OnTargetReached(TMovedAgent moveAgent);
    }
}