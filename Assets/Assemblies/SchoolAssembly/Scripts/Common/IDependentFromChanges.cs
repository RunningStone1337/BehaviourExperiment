namespace Common
{
    /// <summary>
    /// ���������, ����������� ��������� ��������� ������� ��� ��������� ����������� �������
    /// </summary>
    public interface IDependentFromChanges
    {
        /// <summary>
        /// �������� ��������� ������� ��� ����������
        /// </summary>
        /// <param name="param"></param>
        void ResetIfConditionsChanged(object param);
    }
}