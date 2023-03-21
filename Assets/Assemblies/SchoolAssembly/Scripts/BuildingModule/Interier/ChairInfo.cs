using BehaviourModel;

namespace BuildingModule
{
    public class ChairInfo : InterierInfoBase<ChairInterier>
    {
        protected IAgent bindedAgent;
        protected IAgent currentAgent;
        public IAgent BindedAgent { get => bindedAgent; set => bindedAgent = value; }
        public IAgent CurrentAgent { get => currentAgent; set => currentAgent = value; }
    }
}