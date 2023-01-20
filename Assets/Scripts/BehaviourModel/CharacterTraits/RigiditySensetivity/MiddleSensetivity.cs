namespace BehaviourModel
{
    /// <summary>
    /// ��������� ����������������
    /// </summary>
    public sealed class MiddleSensetivity : RigiditySensetivity
    {
        /// <summary>
        /// � ���� ����������������� � �������, � �������. ������� �� ��������.
        /// �� �������? ���� ��, ��� ��� ���������? 
        /// ���� ���, � ������ �� ������� �������.
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 1 * CharacterValue);
        }
    }
}