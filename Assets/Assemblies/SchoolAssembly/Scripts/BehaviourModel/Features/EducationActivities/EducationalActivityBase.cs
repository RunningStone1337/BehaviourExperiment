using System;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ����� ��������� ����������
    /// </summary>
    public abstract class EducationalActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(EducationalActivityBase);
    }
}