using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������ �����������=���������
    /// </summary>
    public sealed class LowAnxiety : CalmnessAnxiety
    {
        /// <summary>
        /// � ������� ��� ������. ��-����������, � �� ������ ��������� ���.
        /// ����� �� ����� �������� �������? �� ������ �������?
        /// ���� �������, �� ��� ����� � ����� � ��� ���������? � ����� ������, �� ���� �� ������
        /// ���������.
        /// ���� �� �������, � �� ���� ������������ � ��������� ����������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(PositiveEmotionBase), 1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
        }
    }
}