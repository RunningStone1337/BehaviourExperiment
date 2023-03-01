using System;

namespace BehaviourModel
{
    /// <summary>
    /// Everything you want to react at your model by agent.
    /// </summary>
    public interface IPhenomenon
    {
        /// <summary>
        /// Use this value for scalling agents reaction at some phenomenons.
        /// </summary>
        float PhenomenonPower { get; set; }
    }
}