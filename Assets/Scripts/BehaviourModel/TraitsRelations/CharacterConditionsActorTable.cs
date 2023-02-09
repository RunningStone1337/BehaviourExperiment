using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class CharacterConditionsActorTable<TEnumCondition, TEnumAction, TEnumAdditionalParam> : 
        CharacterListTableBase<ConditionActionPair<TEnumCondition, TEnumAction, TEnumAdditionalParam>>
    {
        
    }
}