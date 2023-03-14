using Sirenix.OdinInspector;
using Sirenix.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BehaviourModel
{
    [Serializable]
    public class ReactionsWrapper:IReactionsCreator
    {
        [SerializeField, ValueDropdown("GetTypesFullNames", IsUniqueList = true)]
        string[] reactions = new string[0];
      
        public IEnumerable<string> GetTypesFullNames()
        {
            var actionsToShow = typeof(ICompletedAction);
            var types = actionsToShow.Assembly.GetTypes()
                .Where(x => actionsToShow.IsAssignableFrom(x))
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                ;
            return types.Select(x => x.AssemblyQualifiedName).ToList();
        }
        public IEnumerable<string> GetTypesNames()
        {
            var reactBase = typeof(ReactionBase);
            var types = reactBase.Assembly.GetTypes()
                .Where(x => reactBase.IsAssignableFrom(x))
                .Where(x => !x.IsAbstract)
                .Where(x => !x.IsGenericTypeDefinition)
                ;
            return types.Select(x=>x.Name).ToList();
        }

        public ReactionBase[] GetReactions()
        {
            ReactionBase[] res = new ReactionBase[reactions.Length];
            for (int i = 0; i < res.Length; i++)
            {
                var type = Type.GetType(reactions[i]);
#if DEBUG
                if (type == null)
                {
                    Debug.Log($"Created type of {reactions[i]} was null");
                }
#endif
                var instance = (ReactionBase)Activator.CreateInstance(type);
                res[i] = instance;
            }
            return res;
        }
    }
}
