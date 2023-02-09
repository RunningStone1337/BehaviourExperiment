using System.Collections;

namespace BehaviourModel
{
    public interface IMovementTarget
    {
        IEnumerator OnTargetReached(SchoolAgentBase moveAgent);
    }
}