namespace BehaviourModel
{
    /// <summary>
    /// ��������� ��������������
    /// </summary>
    public sealed class MiddleDiplomacy : StraightforwardnessDiplomacy
    {
        /// <summary>
        /// � ����������� �� �������� ���� ���� � ������ � ��������.
        /// �� �������? ���� ���, � ������ ������������ ����.
        /// ���� ��, ������� �� ����������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }
    }
}