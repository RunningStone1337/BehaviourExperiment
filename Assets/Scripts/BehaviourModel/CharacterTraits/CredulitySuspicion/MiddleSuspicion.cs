namespace BehaviourModel
{
    /// <summary>
    /// ��������� ����������������
    /// </summary>
    public sealed class MiddleSuspicion : CredulitySuspicion
    {
        /// <summary>
        /// � �������� ��� �������� ���� � � �� ��� �� ��� �������.
        /// ���� ���� ����� ���������, � �� ������� ��� �� ���������.
        /// ��� ��� ���� �� ������� � �� ���� �� ��������� � �� ��������
        /// ������������, �� �������. ���� �� ������� - ����� �������������. 
        /// ��� ������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}