using System.Collections.Generic;

namespace BehaviourModel
{
    public interface ICanReactOnPhenomenon<TReason, TReaction>
        where TReason : IPhenomenon
        where TReaction : IReaction
    {
        bool HasReactionsOnPhenom(TReason reason, out List<TReaction> reaction);
    }
}