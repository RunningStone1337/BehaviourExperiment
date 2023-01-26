namespace BehaviourModel
{
    /// <summary>
    /// ������� ����������
    /// </summary>
    public sealed class HighRadicalism : ConservatismRadicalism
    {
        protected override float CalculateImportanceForFamiliar(AgentBase ab)
        {
            float res = default;
            var currentRelation = ThisAgent.GetCurrentRelationTo(ab);
            if (currentRelation.HasImportanceFor(this))
                res += currentRelation.GetImportanceValueFor(this);
            return res;
        }

        /// <summary>
        /// � ����� ������������� �������� � ������ ������ ����� �� ��� �,
        /// ��������� ��� ���� ���������. ������ �����, ��� �� �����
        /// ���� � ���������. ���� ��� ���������, ��� �� �������������
        /// ���������������� ���������, � ���� �������� �������. ����� ���.
        /// �� �������? ���� ��, �� ����� � ���� �������� � ���������? ����
        /// ���� �� �� ���� �����, ����� ����������� ��������.
        /// ���� ��� - � ���� �� �����������, ��������� �� �� ��� ����������.
        /// � ����� ������ ����� �������� ������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}