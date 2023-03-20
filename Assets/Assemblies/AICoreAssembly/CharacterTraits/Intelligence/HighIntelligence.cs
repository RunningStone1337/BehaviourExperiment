namespace BehaviourModel
{
    /// <summary>
    /// ������� ���������
    /// </summary>
    public class HighIntelligence : Intelligence
    {
        public override void Initiate(int characterValue, IAgent agent)
        {
            base.Initiate(characterValue, agent);
            ThisConcreteCharType = CharTraitTypeExtended.HighIntelligence;
        }
    }
}