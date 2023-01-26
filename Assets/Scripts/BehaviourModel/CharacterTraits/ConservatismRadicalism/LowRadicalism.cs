using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ����������.
    /// </summary>
    public sealed class LowRadicalism : ConservatismRadicalism
    {
        /// <summary>
        /// ���� ����������� �������. ��� ��� ������� - ��� � �����.
        /// ���� �� ������� � �������� ���� ���� ���� �����������, �� ��� �� ���������.
        /// � � ��� ����, ��� ��������� - ��� ������� �������.
        /// �� �������? ���� ��, ����� � ���� ��������? ���� �� ����� �� ��� � ����, �� 
        /// �� �������. �� ������� - � �����, ��� �� ��������� ��� �������� ���� �������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
        protected override float CalculateImportanceForFamiliar(AgentBase ab)
        {
            float res = default;
            var currentRelation = ThisAgent.GetCurrentRelationTo(ab);
            if (currentRelation.HasImportanceFor(this))
                res += currentRelation.GetImportanceValueFor(this);
            return res;
        }
    }
}