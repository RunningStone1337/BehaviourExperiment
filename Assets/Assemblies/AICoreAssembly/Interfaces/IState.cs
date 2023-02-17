
using System.Collections;

namespace BehaviourModel
{
    /// <summary>
    /// The interface of the base state, which is processed by the state machine.
    /// </summary>
    public interface IState
    {
        public IEnumerator StartState();
    }
}