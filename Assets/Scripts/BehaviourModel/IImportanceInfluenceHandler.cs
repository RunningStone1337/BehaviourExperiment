namespace BehaviourModel
{
    /// <summary>
    /// ������ ����� ����� ������� �� �������� ��� ������������ �������.
    /// </summary>
    public interface IImportanceInfluenceHandler 
    {
        /// <summary>
        /// �������� ������� �� ������ �������.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        float GetImportanceValueFor<T>(T phenomenon) where T : IPhenomenon;

        /// <summary>
        /// ������� �� ������� ��� ������� ������� �� ������ �������?
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        bool HasImportanceFor<T>(T phenomenon) where T : IPhenomenon;
    }
}