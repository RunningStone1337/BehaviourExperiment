using UnityEngine;

namespace BehaviourModel
{
    [CreateAssetMenu(fileName = "NerviousBalance", menuName = "BehaviourModel/NerviousBalance")]
    public class NerviousBalanceExample : ScriptableObject
    {
        [SerializeField] private int[] nervousBalance = new int[9];
        /// <summary>
        /// ���� ������� �� ������������ ���� i, ��� i = ������. ���� ������� �� ���� 2 = NervousReaction[i-1].
        /// ����� �� ������������ ������������, ���������, ������������, ������������ � ����������������� ��������.
        /// </summary>
        public int[] NervousReaction { get => nervousBalance; }
    }
}