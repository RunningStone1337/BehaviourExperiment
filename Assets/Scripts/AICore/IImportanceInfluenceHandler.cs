namespace BehaviourModel
{
    /// <summary>
    /// ������ ����� ����� ������� �� �������� ��� ������������ �������.
    /// </summary>
    public interface IImportanceInfluenceHandler<T> where T : IPhenomenon
    {
        /// <summary>
        /// �������� ������� �� ������ �������.
        /// </summary>
        /// <param name="ph"></param>
        /// <returns></returns>
        float GetImportanceValueFor(T phenomenon);
      
    }
}