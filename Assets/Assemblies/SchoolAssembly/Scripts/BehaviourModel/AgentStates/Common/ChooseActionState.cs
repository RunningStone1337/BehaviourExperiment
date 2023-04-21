namespace BehaviourModel
{
    /// <summary>
    /// Стейт бездействия
    /// </summary>
    public abstract class ChooseActionState<T> : SchoolAgentStateBase<T>, IOptionalToCompleteState
        where T : SchoolAgentBase<T>
    {
        public bool IsContinue { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ChooseActionState() : base()
        {
        }
    }
}