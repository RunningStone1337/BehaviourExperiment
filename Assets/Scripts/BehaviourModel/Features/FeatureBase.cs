using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, INameHandler, IPhenomenon, IImportanceInfluenceHandler, ICanReactOnPhenomenon
    {
        [SerializeField] [Range(1f, 5f)] private float categoricalMatchMultiplier = 1.5f;
        [SerializeField] [Range(1f, 5f)] private float exactMatchMultiplier = 3f;
        [SerializeField] private string featureName;
        [SerializeField] [Range(1, 10)] private int featurePower;

        /// <summary>
        /// Базовый нижний тип иерархии, к которой принадлежит эта фича.
        /// </summary>
        /// <returns></returns>
        protected abstract Type GetHierarchyBaseClass();

        public string Name { get => featureName; }
        public int PhenomenonPower { get => featurePower; set => featurePower = value; }

        /// <summary>
        /// Значение важности <paramref name="phenomenon"/> для данной особенности.
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon
        {
            if (phenomenon is FeatureBase f)
            {
                if (f.GetInstanceID() == GetInstanceID())//эта же фича
                    return phenomenon.PhenomenonPower * exactMatchMultiplier;
                var type = typeof(T);
                if (type.IsSubclassOf(GetHierarchyBaseClass()))
                    return phenomenon.PhenomenonPower * categoricalMatchMultiplier;
            }
            return default;
        }

        /// <summary>
        /// Является ли <paramref name="phenomenon"/> важным для агента, у которого есть this особенность?
        /// ЭТА фича оценивает значимость <paramref name="phenomenon"/> для агента.
        /// Откликом для интересов может быть совпадение интересов (приблизительное или точное, с разной интенсивностью)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon
        {
            if (phenomenon is FeatureBase)
                return true;
            return default;
        }

        public bool HasReactionOn<T>(T action, out List<EmotionBase> reaction) where T : IPhenomenon
        {
            throw new NotImplementedException();
        }
    }
}