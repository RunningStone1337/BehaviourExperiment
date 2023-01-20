using Core;

namespace BehaviourModel
{
    /// <summary>
    /// ��������
    /// </summary>
    public sealed class HighCourage : TimidityCourage
    {
        /// <summary>
        /// � ����� ��� ������� ������ �� �������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(IAgressiveEmotion), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(NegativeEmotionBase), 1 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(ISubordinationEmotion), -1 * CharacterValue);

            ImportanceInfluencHandlersDict.Add(typeof(LessonEvent), 2 * CharacterValue);
            ImportanceInfluencHandlersDict.Add(typeof(BreakEvent), 3 * CharacterValue);
        }
    }
}