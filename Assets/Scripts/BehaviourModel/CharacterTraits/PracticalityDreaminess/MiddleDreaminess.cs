namespace BehaviourModel
{
    /// <summary>
    /// ��������� ��������������
    /// </summary>
    public sealed class MiddleDreaminess : PracticalityDreaminess
    {
        /// <summary>
        /// �� �������? ���� ���, �� ���������.
        /// ���� ��, ����� ���������?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}