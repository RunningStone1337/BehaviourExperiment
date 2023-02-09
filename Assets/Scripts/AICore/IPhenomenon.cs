namespace BehaviourModel
{
    /// <summary>
    /// ������� - �� ��� ����� ���� ���������� ������� ��� ������� ��������������� ������������.
    /// </summary>
    public interface IPhenomenon
    {
        /// <summary>
        /// ������� ���� ������� - ������������� ��������, ������� ����������� �� ����������
        /// </summary>
        int PhenomenonPower { get; set; }
    }
}