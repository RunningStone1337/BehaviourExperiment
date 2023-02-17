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
    public class ReactionsWrapper
    {

        [SerializeField, TypeFilter("GetTypes")]
        ReactionBase[] reactions;
        public ReactionBase[] Reactions => reactions;
        public ReactionsWrapper()
        {
            reactions = new ReactionBase[1];
            //actionsToDo = new ActionBase[10];
        }

        public List<Type> GetTypes()
        {
            var reactBase = typeof(ReactionBase);
            var types = reactBase.Assembly.GetTypes()
                .Where(x => reactBase.IsAssignableFrom(x))
                .Where(x => !x.IsAbstract)
                ;
            return types.ToList();
        }
        //public T[] GetReactions()
        //{
        //    T[] res = new T[typesNames.Length];
        //    for (int i = 0; i < typesNames.Length; i++)
        //    {
        //        res[i] = (T)Activator.CreateInstance(Type.GetType(typesNames[i]));
        //    }
        //    return res;
        //}
    }
}
