using System;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ����� ����������, ���������� � ��������
    /// </summary>
    public abstract class CommunicationActivityBase : ActivityFeatureBase
    {
        protected override Type GetHierarchyBaseClass() => typeof(CommunicationActivityBase);
    }
}