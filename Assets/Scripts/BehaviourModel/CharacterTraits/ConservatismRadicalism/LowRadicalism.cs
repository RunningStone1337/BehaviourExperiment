namespace BehaviourModel
{
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
    }
}