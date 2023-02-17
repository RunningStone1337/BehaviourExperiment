using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace BehaviourModel
{
    public abstract class FeatureBase : ScriptableObject, INameHandler, IPhenomenon, IFeature
    {
        [SerializeField] [Range(1f, 5f)] private float categoricalMatchMultiplier = 1.5f;
        [SerializeField] [Range(1f, 5f)] private float exactMatchMultiplier = 3f;
        [SerializeField] private string featureName;
        [SerializeField] [Range(1f, 10f)] private float featurePower;

        /// <summary>
        /// ������� ������ ��� ��������, � ������� ����������� ��� ����.
        /// </summary>
        /// <returns></returns>
        protected abstract Type GetHierarchyBaseClass();

        public string Name { get => featureName; }
        public float PhenomenonPower { get => featurePower; set => featurePower = value; }

        /// <summary>
        /// �������� �������� <paramref name="phenomenon"/> ��� ������ �����������.
        ///
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        public float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon
        {
            if (phenomenon is FeatureBase f)
            {
                if (f.GetInstanceID() == GetInstanceID())//��� �� ����
                    return phenomenon.PhenomenonPower * exactMatchMultiplier;
                var type = typeof(T);
                if (type.IsSubclassOf(GetHierarchyBaseClass()))
                    return phenomenon.PhenomenonPower * categoricalMatchMultiplier;
            }
            return default;
        }

        /// <summary>
        /// �������� �� <paramref name="phenomenon"/> ������ ��� ������, � �������� ���� this �����������?
        /// ��� ���� ��������� ���������� <paramref name="phenomenon"/> ��� ������.
        /// �������� ��� ��������� ����� ���� ���������� ��������� (��������������� ��� ������, � ������ ��������������)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="phenomenon"></param>
        /// <returns></returns>
        //public bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon
        //{
        //    if (phenomenon is FeatureBase)
        //        return true;
        //    return default;
        //}

      
    }
}