using System.Collections;

namespace BehaviourModel
{
    public interface IReaction
    {
        bool WasPerformed { get; set; }

        public IEnumerator TryPerformAction();
    }
}