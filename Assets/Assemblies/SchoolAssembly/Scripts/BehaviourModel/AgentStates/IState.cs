
using System.Collections;

namespace BehaviourModel
{
    public interface IState<TStateHandler>
        where TStateHandler: IAgent
    {
        public IEnumerator StartState();
        public void Initiate(TStateHandler stateAgent);
    }
}