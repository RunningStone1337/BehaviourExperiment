using Common;
using System.Collections.Generic;
using System.Linq;

namespace BehaviourModel
{
    public static class IEnumerableExtensions
    {
        public static void StartVisualEffect(this IEnumerable<IVisualEffectRoutineHandler> handlers)
        {
            foreach (var h in handlers)
            {
                h.StartRoutine();
            }
        }
    }
}