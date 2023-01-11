using Common;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class NervousBalanceType : ScriptableObject, INameHandler, IDescriptionHandler
    {
        [SerializeField] string objName;
        [SerializeField] string objDescription;
        public string Name => objName;
        public string ObjDescription => objDescription;
    }
}