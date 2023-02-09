using System.Collections.Generic;

namespace BehaviourModel
{
    public abstract class ReactionResolverBase :
        ResolverBase,
        ICanReactOnPhenomenon<IPhenomenon, IReaction>
    {
        public abstract bool HasReactionOn(IPhenomenon reason, out List<IReaction> reaction);
    }
}