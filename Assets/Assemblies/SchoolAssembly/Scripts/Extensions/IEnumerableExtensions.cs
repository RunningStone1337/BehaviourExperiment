using Common;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourModel
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<TStateHanlder> GetCurrentStateHandlers<TStateType, TStateHanlder>(this IEnumerable<TStateHanlder> handlers)
                 where TStateType : IState where TStateHanlder : ICurrentStateHandler<TStateType>
        {
            return handlers.Where(x => x.CurrentState is TStateType);
        }

        public static IEnumerable<TStateType> GetCurrentStatesOfType<TStateType, TStateHanlder>(this IEnumerable<TStateHanlder> handlers)
            where TStateHanlder : ICurrentStateHandler<TStateType> where TStateType : IState
        {
            return (IEnumerable<TStateType>)handlers.Select(x => x.CurrentState).Where(x => x is TStateType);
        }

        public static void StartVisualEffect(this IEnumerable<IVisualEffectRoutineHandler> handlers)
        {
            foreach (var h in handlers)
            {
                h.StartRoutine();
            }
        }
    }
}