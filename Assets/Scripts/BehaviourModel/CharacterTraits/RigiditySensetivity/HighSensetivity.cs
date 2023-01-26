namespace BehaviourModel
{
    /// <summary>
    /// ������� ����������������
    /// </summary>
    public sealed class HighSensetivity : RigiditySensetivity
    {
        /// <summary>
        /// � ����� ������� � ���������� ��������.
        /// �� �������? ���� ���, �� � ������� ������� ���� �� � ���� ��� ����� �� ��� � �.
        /// ���� ��, ����� � ��� ���������?
        /// </summary>
        /// <param name="ab"></param>
        /// <returns></returns>
        protected override bool CanBeImportantForAgent(AgentBase ab) => true;

        public override void Initiate(int characterValue, AgentBase agent)
        {
            base.Initiate(characterValue, agent);
            recognitionChance = (7 + CharacterValue)/10f;
            ImportanceInfluencHandlersDict.Add(typeof(EmotionBase), 3 * CharacterValue);
        }
    }
}