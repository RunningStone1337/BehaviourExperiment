namespace BehaviourModel
{
    /// <summary>
    /// ������� ������������� ������������
    /// </summary>
    public sealed class HighEmotionalStability : EmotionalInstabilityStability
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 2 * CharacterValue);
        }
        /// <summary>
        /// � �� ��������� ��������� ����������.
        /// �� �������? ���� ��, ������ �� ����, � ������������ �� ������ �����.
        /// ���� ���, �� ����� �� �����.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;
    }
}