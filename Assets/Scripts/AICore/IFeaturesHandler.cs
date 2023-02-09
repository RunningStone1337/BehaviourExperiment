using System.Collections.Generic;

namespace BehaviourModel
{
    public interface IFeaturesHandler<TFeature>
        where TFeature : IFeature
    {
        List<TFeature> Features { get; set; }
    }
}