namespace BehaviourModel
{
    public interface IActionsCreator<TAction>
        where TAction : IAction

    {
        public TAction[] CreateActions();
    }
}