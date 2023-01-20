using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public sealed class HighTension : RelaxationTension
    {
        /// <summary>
        /// � ��������������, ����� �� ������, ����������������.
        /// �� �������? ���� ��, ��������� �� �������? ���� �� ������, �� �� �������.
        /// ���� ���, ������ ����� � ������� ����������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab)
        {
            throw new System.NotImplementedException();
        }

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(CommunicationActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PracticalActivityBase), 3 * CharacterValue);
        }
    }
}