using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ���������
    /// </summary>
    public sealed class HighIntelligence : Intelligence
    {
        /// <summary>
        /// � ���������� � ������ �������.
        /// ��������� ������ ������ �� ��� �. ���� �� ������ ����,
        /// ���� ��� ����� ������������.
        /// �� �������? ���� ��, ����� � ���� �������� � ���������?
        /// ���� ���, ������ ����� �� �� ������������� ��������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 3 * CharacterValue);
        }
    }
}