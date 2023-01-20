using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ����� ����������� �� �������, ��������� ����������� ������� �� �������: ��������, �����,
    /// ���������, ��� ������.
    /// </summary>
    public interface ICanReactOnPhenomenon
    {
        /// <summary>
        /// ������� �� ������� �� <paramref name="action"/>? ���� ��, �� ��� <paramref name="reaction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        bool HasReactionOn<T>(T action, out List<EmotionBase> reaction) where T : IPhenomenon;
    }
}