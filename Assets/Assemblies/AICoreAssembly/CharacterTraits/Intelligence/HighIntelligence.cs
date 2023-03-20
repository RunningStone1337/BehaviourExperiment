namespace BehaviourModel
{
    /// <summary>
    /// Высокий интеллект
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