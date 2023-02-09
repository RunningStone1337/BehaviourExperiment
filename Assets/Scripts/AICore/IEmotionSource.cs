using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Объект является источником возникновения эмоций.
    /// </summary>
    public interface IEmotionSource : IPhenomenon
    {
        List<IReaction> GetReactionsOnPhenomenon();
    }
}