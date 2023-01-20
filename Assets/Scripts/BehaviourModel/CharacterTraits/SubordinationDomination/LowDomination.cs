namespace BehaviourModel
{
    /// <summary>
    /// ������������
    /// </summary>
    public sealed class LowDomination : SubordinationDomination
    {
        /// <summary>
        /// � ��������� �������. � �������� ������ �� ��� �������,
        /// ����� �������� ���� �� ���� � ��������.
        /// �� �������? ���� ��, ������ ��, ������ �� ������ ����.
        /// ���� ���, ����� �������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
        }
    }
}