using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ������ ������������
    /// </summary>
    public sealed class LowSelfcontrol : Selfcontrol
    {
        /// <summary>
        /// � ������� �� ������� � ����������� �������.
        /// �� �������? ���� ��, � ����� ����� ������������?
        /// ���� ���, �� ������ ����� �������� ���� �������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            recognitionChance = (7 + CharacterValue) / 10f;
            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), -5 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), -5 * CharacterValue);
        }
    }
}