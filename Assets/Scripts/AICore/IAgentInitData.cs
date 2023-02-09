using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public interface IAgentInitData<TFeature>:  
        IRawCharacterInfoSource, IFeaturesHandler<TFeature>
        where TFeature : IFeature 
    {
      
    }
}
