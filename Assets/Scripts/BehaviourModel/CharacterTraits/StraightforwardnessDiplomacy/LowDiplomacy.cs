namespace BehaviourModel
{
    /// <summary>
    /// ������ ���������������
    /// </summary>
    public sealed class LowDiplomacy : StraightforwardnessDiplomacy
    {
        /// <summary>
        /// � ����� ����������� � ���� ���������.
        /// �� �������? ���� ��, ���� �������� ������� �������� �� ��������� ������������.
        /// ���� ���, ���� ���� ��� ���������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}