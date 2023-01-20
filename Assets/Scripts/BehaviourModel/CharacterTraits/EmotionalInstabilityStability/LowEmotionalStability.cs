using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    public sealed class LowEmotionalStability : EmotionalInstabilityStability
    {
        /// <summary>
        /// � ���� ���� ������ �� ������. ���� ���� �� �� �����, � ���� ���-������
        /// ����������. ���� ������ - ����� ����� ����������� �� ������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), -2 * CharacterValue);
        }
    }
}