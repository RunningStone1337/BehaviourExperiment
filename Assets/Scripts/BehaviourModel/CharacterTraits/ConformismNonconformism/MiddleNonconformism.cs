namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public sealed class MiddleNonconformism : ConformismNonconformism
    {
        /// <summary>
        /// � ��������.
        /// �� �������? ���� ��, � ���� ���������� � ���� ��� ������������� ���� �� ���������� �� ��� ��� ��.
        /// ���� ���, �� �� ���������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }
    }
}