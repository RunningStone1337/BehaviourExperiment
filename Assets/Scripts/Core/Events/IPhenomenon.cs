namespace BehaviourModel
{
    /// <summary>
    /// ������� - �� ��� ����� ���� ���������� ������� ��� ������� ��������������� ������������.
    /// </summary>
    public interface IPhenomenon
    {
        //List<ActionBase> CreateActions();
        /// <summary>
        /// ������� ���� ������� - ������������� ��������, ������� ����������� �� ����������
        /// </summary>
        int PhenomenonPower { get; set; }
    }
}