using System.Collections.Generic;

namespace BehaviourModel
{
    public abstract class ProbablyActionSelectorBase

        <TAgent, TActionsReason, TAction, TActionsCreator>
        where TAgent : IAgent
        where TActionsReason : IPhenomenon
        where TAction: IAction
        where TActionsCreator : IActionsCreator<TAction>
    {
        public abstract List<TAction> GetProbablyActions<TTableView>
           (TAgent thisAgent, TActionsReason reason, CharacterToPhenomContainerBase<TTableView, TActionsCreator> table)
           where TTableView : ViewDimensionBase<TActionsCreator>, new();

     
    }
}
