using System;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ����� ������� ����������
    /// </summary>
    public abstract class PlayActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(PlayActivityBase);
    }
}