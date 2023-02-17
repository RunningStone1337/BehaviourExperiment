using System.Collections.Generic;

namespace BehaviourModel
{
    public interface IReactionSource : IPhenomenon
    {
        List<IReaction> GetReactionsOnPhenomenon();
    }
}