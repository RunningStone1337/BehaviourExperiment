using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������� �������������
    /// </summary>
    public sealed class HighNormativityOfBehaviour : NormativityOfBehaviour
    {
        /// <summary>
        /// ���� � ���� ��������� ��������, ��� �� � ��� �������������.
        /// ����� ����� � �����������. �� ������� �� ����.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -2 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 3 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(EducationalActivityBase), 3 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(PlayActivityBase), -3 * CharacterValue);
        }
    }
}