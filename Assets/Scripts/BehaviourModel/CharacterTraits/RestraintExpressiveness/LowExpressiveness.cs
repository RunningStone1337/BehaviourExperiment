namespace BehaviourModel
{
    /// <summary>
    /// ������� ������������
    /// </summary>
    public sealed class LowExpressiveness : RestraintExpressiveness
    {
        /// <summary>
        /// � ����� ����������� � ���������.
        /// �� �������? ���� ���, �� ������ ���� ����� ��������������.
        /// ���� ��, ����� � ��� ���������?
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
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), -3 * CharacterValue);
        }
    }
}