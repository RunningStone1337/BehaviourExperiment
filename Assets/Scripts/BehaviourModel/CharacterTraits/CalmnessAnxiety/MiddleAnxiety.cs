using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������� �����������
    /// </summary>
    public sealed class MiddleAnxiety : CalmnessAnxiety
    {
        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
          
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 1 * CharacterValue);
        }

        /// <summary>
        /// ������ ���� ���� ���������, �� ������ ���� � �� ������������ ����.
        /// � �����, � ��������� �������� �� �������������.
        /// ��� ���, ������? �� �������?
        /// ���� ���, ���� ��� �� ���������, ���� �� - ��� �����.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => false;
    }
}