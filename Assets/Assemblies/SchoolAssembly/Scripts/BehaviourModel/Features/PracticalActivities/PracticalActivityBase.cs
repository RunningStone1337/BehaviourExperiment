using System;

namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс практически направленной активности - труд и его производство
    /// </summary>
    public abstract class PracticalActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(PracticalActivityBase);
    }
}