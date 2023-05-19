using System.Collections;

namespace BehaviourModel
{
    public interface IAction: IUtilityCalculator
    {
        bool WasPerformed { get; set; }

        public IEnumerator TryPerformAction();
        void Initiate(IPhenomenon source, IAgent actionActor);
    }
}