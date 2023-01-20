using System;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ����� ����������� ������������ ���������� - ���� � ��� ������������
    /// </summary>
    public abstract class PracticalActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(PracticalActivityBase);
    }
}