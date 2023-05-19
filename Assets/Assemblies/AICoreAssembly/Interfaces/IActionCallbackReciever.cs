using System.Collections;

namespace BehaviourModel
{
    public interface IActionCallbackReciever<TAction>
        where TAction: IAction
    {
        public IEnumerator ReactAtAction(TAction actionToReact);
    }
}
