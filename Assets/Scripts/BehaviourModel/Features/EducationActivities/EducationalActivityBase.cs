using System;

namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс обучающей активности
    /// </summary>
    public abstract class EducationalActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(EducationalActivityBase);
    }
}