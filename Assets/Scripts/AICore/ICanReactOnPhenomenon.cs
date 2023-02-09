using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ����� ����������� �� �������, ��������� ����������� ������� �� �������: ��������, �����,
    /// ���������, ��� ������.
    /// </summary>
    public interface ICanReactOnPhenomenon<TReason, TReaction> 
        where TReason : IPhenomenon
        where TReaction : IReaction
    {
        /// <summary>
        /// ������� �� ������� �� <paramref name="action"/>? ���� ��, �� ��� <paramref name="reaction"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="reaction"></param>
        /// <returns></returns>
        bool HasReactionOn(TReason reason, out List<TReaction> reaction);
    }
}