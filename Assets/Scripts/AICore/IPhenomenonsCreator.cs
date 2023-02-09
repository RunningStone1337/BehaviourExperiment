using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Интерфейс, укзывающий, что объект является источником явлений.
    /// </summary>
    public interface IPhenomenonsCreator
    {
        /// <summary>
        /// Создаёт явления.
        /// </summary>
        /// <returns></returns>
        List<IPhenomenon> CreatePhenomenons();
    }
}