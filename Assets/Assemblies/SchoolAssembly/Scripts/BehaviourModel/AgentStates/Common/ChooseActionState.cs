namespace BehaviourModel
{
    public abstract class ChooseActionState<TAgent> : SchoolAgentStateBase<TAgent>, IOptionalToCompleteState<TAgent>
        where TAgent : SchoolAgentBase<TAgent>
    {
        public bool IsContinue { get ; set; }

        public ChooseActionState() : base()
        {
        }
    }
}