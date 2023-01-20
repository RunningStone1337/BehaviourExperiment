using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ��������� ������������
    /// </summary>
    public sealed class MiddleEmotionalStability : EmotionalInstabilityStability
    {
        /// <summary>
        /// � �������� �����������. ����� ���� ����� ��������������, �� �� �����.
        /// �� ������ �������� �������, �� ���� � ������������.
        /// �� �������? ���� ��, �� ��������� �� ���������? 
        /// ��� - �� �����������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 1 * CharacterValue);
        }
    }
}