using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������ �������������
    /// </summary>
    public sealed class LowNormativityOfBehaviour : NormativityOfBehaviour
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), -3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), 3 * CharacterValue);
        }

        /// <summary>
        /// � ������. ���� �� ������� � ������ �������, �� �� ���������.
        /// �� �������? ���� ���, � ���� ������ ����� �������. ���� ��, ����� �� �� ��������?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;
    }
}