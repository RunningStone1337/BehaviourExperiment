namespace BehaviourModel
{
    /// <summary>
    /// This state is not necessary for complete completion and can be interrupted by external code.
    /// </summary>
    public interface IOptionalToCompleteState<TAgent> : IState<TAgent>
        where TAgent: IAgent
    {
        bool IsContinue { get; set; }
    }
}