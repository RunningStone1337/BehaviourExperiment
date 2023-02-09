using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Объект может реагировать на явление, возвращая определённую реакцию на явление: действие, мысль,
    /// состояние, что угодно.
    /// </summary>
    public interface ICanReactOnPhenomenon<TReason, TReaction> 
        where TReason : IPhenomenon
        where TReaction : IReaction
    {
        /// <summary>
        /// Имеется ли реакция на <paramref name="action"/>? Если да, то это <paramref name="reaction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        bool HasReactionOn(TReason reason, out List<TReaction> reaction);
    }
}