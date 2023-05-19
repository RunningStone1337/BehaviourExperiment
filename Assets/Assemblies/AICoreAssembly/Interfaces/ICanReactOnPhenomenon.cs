using System.Collections.Generic;

namespace BehaviourModel
{
    public interface ICanReactOnPhenomenon<TReason, TReaction>
        where TReason : IPhenomenon
        where TReaction : IAction
    {
        bool TryReactOnPhenom(TReason reason, out List<TReaction> reaction);
    }
}