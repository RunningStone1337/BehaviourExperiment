using System.Collections.Generic;

namespace BehaviourModel
{
    /// <summary>
    /// ������ �������� ���������� ������������� ������.
    /// </summary>
    public interface IEmotionSource : IPhenomenon
    {
        List<IReaction> GetReactionsOnPhenomenon();
    }
}