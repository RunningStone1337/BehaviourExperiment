using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ���������, ����������, ��� ������ �������� ���������� �������.
    /// </summary>
    public interface IPhenomenonsCreator
    {
        /// <summary>
        /// ������ �������.
        /// </summary>
        /// <returns></returns>
        List<IPhenomenon> CreatePhenomenons();
    }
}