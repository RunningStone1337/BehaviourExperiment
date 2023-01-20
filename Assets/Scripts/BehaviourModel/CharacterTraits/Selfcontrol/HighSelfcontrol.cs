using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������� ������������
    /// </summary>
    public sealed class HighSelfcontrol : Selfcontrol
    {
        /// <summary>
        /// � ���������� ��������. ������������� � ������������� �� �����.
        /// �� �������? ���� ���, � �� ������� ��������.
        /// ���� ��, �� ����� � ��� ���������?
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
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 5 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -5 * CharacterValue);
        }
    }
}