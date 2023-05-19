using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public abstract class StringActionsCreatorBase<TActionBaseType> : ActionsCreatorBase<TActionBaseType>
        where TActionBaseType : IAction
    {
        [SerializeField, ValueDropdown("GetTypesFullNames", IsUniqueList = true)]
        private string[] reactions = new string[0];

        public IEnumerable<string> GetTypesFullNames()
        {
            var actionsToShow = typeof(TActionBaseType);
            var types = actionsToShow.Assembly.GetTypes()
                .Where(x => actionsToShow.IsAssignableFrom(x))
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                ;
            return types.Select(x => x.AssemblyQualifiedName).ToList();
        }
        public override TActionBaseType[] CreateActions()
        {
            TActionBaseType[] res = new TActionBaseType[reactions.Length];
            for (int i = 0; i < res.Length; i++)
            {
                var type = Type.GetType(reactions[i]);
#if DEBUG
                if (type == null)
                {
                    Debug.Log($"Created type of {reactions[i]} was null");
                }
#endif
                var instance = (TActionBaseType)Activator.CreateInstance(type);
                res[i] = instance;
            }
            return res;
        }
    }
}
