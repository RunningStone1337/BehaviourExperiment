using System;

namespace BehaviourModel
{
    /// <summary>
    /// Базовый класс игровой активности
    /// </summary>
    public abstract class PlayActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(PlayActivityBase);
    }
}