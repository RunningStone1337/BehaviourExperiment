using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class ConditionActionPair<TEnumCondition, TEnumAction, TEnumAdditionalParam>
    {
        public TEnumCondition condition;
        public TEnumAction action;
        public TEnumAdditionalParam additionalParam;
        public TEnumCondition Condition => condition;
        public TEnumAction Action => action;
        public TEnumAdditionalParam AdditionalParam => additionalParam;
    }
}