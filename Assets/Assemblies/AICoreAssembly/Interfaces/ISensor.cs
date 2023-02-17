using System.Collections.Generic;

namespace BehaviourModel
{
    public interface ISensor
    {
        public List<IPhenomenon> CollectObservations();
    }
}