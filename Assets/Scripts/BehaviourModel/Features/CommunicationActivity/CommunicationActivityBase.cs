using System;

namespace BehaviourModel
{
    /// <summary>
    /// Ѕазовый класс активности, свз€занной с общением
    /// </summary>
    public abstract class CommunicationActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(CommunicationActivityBase);
    }
}