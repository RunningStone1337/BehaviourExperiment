namespace BehaviourModel
{
    public sealed class MiddleRadicalism : ConservatismRadicalism
    {
        /// <summary>
        /// ���, � �����, �� ����� ����� �� ���������, �������� � ����.
        /// ������� ����������, ����� � ��������� ��� ���� ���� �� ����������.
        /// ���� ������ ��� ���-�� ����������, � �� ���� ������� - �����, �� � ����, �� 
        /// ��� �� �����. 
        /// �� �������? ���� ��, �� ����� � ��� ���������? ���� ������� - ����� � ����������,
        /// ������ �� �������.
        /// ��� - �� ���������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}