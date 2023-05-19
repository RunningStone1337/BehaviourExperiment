using System;

namespace BehaviourModel
{
    [Serializable]
    public abstract class ActionsCreatorBase<TCreatedAction> : IActionsCreator<TCreatedAction>
         where TCreatedAction : IAction
    {
        public abstract TCreatedAction[] CreateActions();
    }
}
