using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// Object can be siurce of phenomenons.
    /// </summary>
    public interface IPhenomenonsCreator
    {
        /// <summary>
        /// Creates cpenomenons.
        /// </summary>
        /// <returns></returns>
        List<IPhenomenon> CreatePhenomenons();
    }
}